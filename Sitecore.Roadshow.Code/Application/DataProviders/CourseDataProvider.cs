using Sitecore.Data.DataProviders;
using Sitecore.Data;
using System.Xml.XPath;
using Sitecore.Collections;
using Sitecore.Globalization;
using System.Web;
using Sitecore.Data.Managers;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Caching;

namespace Sitecore.Roadshow.Application.DataProviders
{
    public class CourseDataProvider : DataProvider
    {
        #region Fields

        static XPathDocument doc = null;
        static XPathNavigator nav = null;
        static Cache courseCache = null;

        #endregion

        #region Properties

        public static string FileName { get; set; }

        public static ID TemplateID { get; set; }

        public string ParentItemID { get; set; }

        public XPathNavigator CourseData
        {
            get
            {
                return nav;
            }
        }

        #endregion

        #region Constructor

        public CourseDataProvider(string parentItem, string templateID, string xmlFileName)
            : base()
        {
            ParentItemID = parentItem;
            TemplateID = ID.Parse(templateID);
            FileName = xmlFileName;
            Initialize();
        }

        #endregion

        #region Helpers

        public static void Initialize()
        {
            doc = new XPathDocument(HttpContext.Current.Server.MapPath(FileName));
            nav = doc.CreateNavigator();
            courseCache = new Cache("courses cache", 10 * 1024 * 1024);
        }

        #endregion

        #region DataProvider overrides

        public override LanguageCollection GetLanguages(CallContext context)
        {
            /* return an empty language collection otherwise two additional languages appear in the content editor */
            LanguageCollection collection = new LanguageCollection();
            return collection;
        }

        public override Data.ItemDefinition GetItemDefinition(Data.ID itemId, CallContext context)
        {
            Log.Debug("start GetItemDefinition(..) with itemId " + itemId.ToString() + ", database: " + this.Database.Name);
            XPathNavigator element = null;

            if (courseCache.ContainsKey(itemId))
            {
                context.Abort();
                element = (XPathNavigator)courseCache[itemId];
            }
            else
            {
                element = CourseData.SelectSingleNode(string.Format("//course[@id='{0}']", itemId.ToString()));
                if (element != null)
                {
                    context.Abort();
                    string itemName = element.SelectSingleNode("./name").Value;
                    ItemDefinition definition = new ItemDefinition(itemId, itemName, TemplateID, ID.Null);
                    courseCache.Add(itemId, element, 0L);
                    return definition;
                }
            }

            return base.GetItemDefinition(itemId, context);

        }

        public override Collections.VersionUriList GetItemVersions(Data.ItemDefinition itemDefinition, CallContext context)
        {
            XPathNavigator element = (XPathNavigator)courseCache[itemDefinition.ID];// CourseData.SelectSingleNode(string.Format("//course[@id='{0}']", itemDefinition.ID.ToString()));
            if (element != null)
            {
                context.Abort();
                VersionUriList versions = new VersionUriList();
                LanguageCollection languages = LanguageManager.GetLanguages(this.Database);
                foreach (Language language in languages)
                {
                    versions.Add(language, new Sitecore.Data.Version(1));
                }

                return versions;
            }

            return null;
        }

        public override Data.FieldList GetItemFields(Data.ItemDefinition itemDefinition, Data.VersionUri versionUri, CallContext context)
        {
            XPathNavigator element = (XPathNavigator)courseCache[itemDefinition.ID];// CourseData.SelectSingleNode(string.Format("//course[@id='{0}']", itemDefinition.ID.ToString()));
            if (element != null)
            {
                FieldList fieldList = new FieldList();
                fieldList.Add(ID.Parse("{DA699F8C-F0AF-4377-A57F-1FC0D63B4721}"), element.SelectSingleNode("./name").Value);
                fieldList.Add(ID.Parse("{372CD04F-9224-4302-AF9E-E3DED2DB5E64}"), element.SelectSingleNode("./costs").Value);
                return fieldList;
            }

            return base.GetItemFields(itemDefinition, versionUri, context);

        }

        public override Collections.IDList GetChildIDs(Data.ItemDefinition itemDefinition, CallContext context)
        {
            IDList currentChildIDs = context.CurrentResult as IDList;
            IDList idList = new IDList();
            XPathNavigator element = (XPathNavigator)courseCache[itemDefinition.ID];// CourseData.SelectSingleNode(string.Format("//course[@id='{0}']", itemDefinition.ID.ToString()));
            if (element != null)
            {
                context.Abort();
                XPathNodeIterator childCourses = element.Select("./courses/course");
                foreach (XPathNavigator childCourse in childCourses)
                {
                    ID id = ID.Parse(childCourse.GetAttribute("id", string.Empty));
                    idList.Add(id);
                }
            }
            else if (itemDefinition.ID.ToString() == ParentItemID)
            {
                context.Abort();
                XPathNodeIterator childCourses = CourseData.Select("/courses/course");
                foreach (XPathNavigator childCourse in childCourses)
                {
                    ID id = ID.Parse(childCourse.GetAttribute("id", string.Empty));
                    idList.Add(id);
                }
            }

            return idList;

        }

        public override Data.ID GetParentID(Data.ItemDefinition itemDefinition, CallContext context)
        {
            XPathNavigator element = (XPathNavigator)courseCache[itemDefinition.ID];// CourseData.SelectSingleNode(string.Format("//course[@id='{0}']", itemDefinition.ID.ToString()));
            if (element != null)
            {
                XPathNavigator parentCourse = element.SelectSingleNode("./../..");
                if (parentCourse == null || string.IsNullOrEmpty(parentCourse.Name))
                {
                    return ID.Parse(ParentItemID);
                }

                return ID.Parse(parentCourse.GetAttribute("id", string.Empty));
            }

            return base.GetParentID(itemDefinition, context);
        }

        #endregion
    }
}
