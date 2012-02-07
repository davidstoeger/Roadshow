using System;
using Sitecore.Publishing.Pipelines.PublishItem;

namespace Sitecore.Roadshow.Application.Events
{
    public class CoursePublishRestriction
    {
        protected void OnItemProcessing(object sender, EventArgs args)
        {
            ItemProcessingEventArgs eventArgs = args as ItemProcessingEventArgs;
            if (eventArgs.Context.PublishOptions.Mode == Publishing.PublishMode.Smart)
            {
                if (eventArgs.Context.ItemId.ToString().Contains("0000-0000-0000"))
                {
                    eventArgs.Cancel = true;
                }
            }
        }
    }
}
