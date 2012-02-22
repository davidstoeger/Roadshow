namespace Sitecore.Roadshow.sublayouts.Global.Common.Page
{
    using System;
using System.Collections.Generic;
using Sitecore.Data.Items;
    using System.Linq;

    public partial class TeaserNavigation : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            ListView1.DataSource = GetSubPages();
            ListView1.DataBind();
        }

        private List<Item> GetSubPages()
        {
            List<Item> subpages = (from c in Sitecore.Context.Item.Children
                    where c.TemplateID.ToString() == "{8B997BBB-FF14-48C3-BCFE-1CF6B1CCF381}"
                    select c).ToList();
            return subpages;
        }

        
    }
}