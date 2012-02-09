using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Analytics;
using Sitecore.Analytics.Data.DataAccess;

namespace Sitecore.Roadshow.Profiling
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Tracker.CurrentVisit != null)
            {
                if ( Tracker.CurrentVisit.Location != null)
                    litUserLocation.Text = string.Format("Location= {0}", Tracker.CurrentVisit.Location.Country);
            }
            
        }
    }
}