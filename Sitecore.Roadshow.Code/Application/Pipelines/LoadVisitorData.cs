using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.Analytics;
using Sitecore.Analytics.Data.DataAccess;

namespace Sitecore.Roadshow.Application.Pipelines
{
    public class LoadVisitorData
    {
        public void Process(StartTrackingArgs args)
        {
            if (Tracker.CurrentVisit != null)
            {
                //Alle Daten des Besuchers werden geladen, sofern Cookie vorhanden. Dadurch sind bereits getrackte Profile wieder present!!!
                Visitor visitor = Sitecore.Analytics.Tracker.Visitor;
                visitor.LoadAll();
            }
        }                                        
    }
}