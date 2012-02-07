using System;
using System.Collections.Generic;
using Sitecore.Base.Web.Controls;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Roadshow.Application.Constants;
using Sitecore.Roadshow.Model.Global.Framework;

namespace Sitecore.Roadshow.sublayouts.Global.Framework
{
    public partial class LeftNavigation : SublayoutBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item startItem = this.FindStartItem();
            this.LoadLeftNavigation(startItem);
        }

        private Item FindStartItem()
        {
            Item result = this.DataSourceItem;

            result = this._FindStartItem(result);

            return result;
        }

        private Item _FindStartItem(Item item)
        {
            Item parent = item;
            Stack<Item> parentItems = new Stack<Item>();
            while (parent != null && parent.TemplateID != Sitecore.Data.ID.Parse(TemplateIds.HomePage))
            {
                parentItems.Push(parent);
                parent = parent.Parent;
            }

            return parentItems.Pop();
        }

        private void LoadLeftNavigation(Item startItem)
        {
            Item[] subitems = startItem.Axes.SelectItems(string.Format("./*[@@templateid = '{0}']", TemplateIds.Page));
            List<NavigationElement> navigationElements = new List<NavigationElement>();
            if (subitems != null)
            {
                foreach (Item item in subitems)
                {
                    NavigationElement element = new NavigationElement { NavigationTitle = item.Fields["Navigation Title"].Value, NavigationUrl = LinkManager.GetItemUrl(item), Item = item };
                    if (DataSourceItem.ID == item.ID)
                    {
                        element.ActiveClass = "active";
                    }
                    navigationElements.Add(element);
                }
            }

            this.repLeftNavigation.DataSource = navigationElements;
            this.repLeftNavigation.DataBind();
        }
    }
}