using System;
using Sitecore.Base.Web.Controls;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Roadshow.Application.Constants;

namespace Sitecore.Roadshow.sublayouts.ContentModules.ImageList
{
    public partial class ImageList : SublayoutBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();
            Item[] imageItems = DataSourceItem.Axes.SelectItems(string.Format("./*[@@templateid = '{0}']", TemplateIds.ImageEntry));
            if (imageItems != null)
            {
                foreach (Item item in imageItems)
                {
                    if (item.Fields["Image"] != null && (!string.IsNullOrEmpty(item.Fields["Image"].Value) || Sitecore.Context.PageMode.IsPageEditorEditing))
                    {
                        items.Add(item);
                    }
                }
            }

            this.repImages.DataSource = items;
            this.repImages.DataBind();
        }
    }
}