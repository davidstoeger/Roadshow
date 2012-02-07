
using Sitecore.Data.Items;
namespace Sitecore.Roadshow.Model.Global.Framework
{
    public class NavigationElement
    {
        public string NavigationTitle { get; set; }

        public string NavigationUrl { get; set; }

        public string ActiveClass { get; set; }

        public Item Item { get; set; }
    }
}