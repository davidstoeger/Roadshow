using System;
using Sitecore.Base.Web.Controls;

namespace Sitecore.Roadshow.sublayouts.Global.Framework.Frames
{
    public partial class OneColumnContent : SublayoutBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            this.DataBind();
        }
    }
}