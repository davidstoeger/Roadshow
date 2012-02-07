using System;
using Sitecore.Data.Items;
using Sitecore.Roadshow.Application.Constants;

namespace Sitecore.Roadshow.layouts
{
    public partial class Default : System.Web.UI.Page
    {
        public Item SkinItem
        {
            get
            {
                return Sitecore.Context.Database.GetItem(Paths.SkinItem);
            }
        }

        public Item HomeItem
        {
            get
            {
                return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.slTopNavigation.DataSource = HomeItem.ID.ToString();
            this.imgLogo.DataSource = SkinItem.ID.ToString();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
    }
}