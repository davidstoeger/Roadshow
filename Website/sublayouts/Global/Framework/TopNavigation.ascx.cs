using System;
using System.Collections.Generic;
using Sitecore.Base.Web.Controls;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Roadshow.Application.Constants;
using Sitecore.Roadshow.Model.Global.Framework;

namespace Sitecore.Roadshow.sublayouts.Global.Framework
{
    public partial class TopNavigation : SublayoutBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
            this.LoadTopNavigation();
        }

        private void LoadTopNavigation()
        {
            Item[] subitems = this.DataSourceItem.Axes.SelectItems(string.Format("./*[@@templateid = '{0}']", TemplateIds.Page));
            List<NavigationElement> navigationElements = new List<NavigationElement>();
            if (subitems != null)
            {
                foreach (Item item in subitems)
                {
                    NavigationElement element = new NavigationElement { NavigationTitle = item.Fields["Navigation Title"].Value, NavigationUrl = LinkManager.GetItemUrl(item), Item = item };
                    navigationElements.Add(element);
                }
            }

            this.repTopNavigation.DataSource = navigationElements;
            this.repTopNavigation.DataBind();
        }
    }
}