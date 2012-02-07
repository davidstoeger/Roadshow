using System;
using Sitecore.Base.Web.Controls;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Roadshow.Application.Constants;
using Sitecore.Roadshow.Application.Search;
using Sitecore.Search;
using Sitecore.Roadshow.Model.Global.Framework;
using Sitecore.Links;
using Sitecore.Diagnostics;
using Sitecore.Base.Utils;

namespace Sitecore.Roadshow.sublayouts.ContentModules.NewsList
{
    public partial class NewsList : SublayoutBase
    {
        public int MaxEntries
        {
            get
            {
                return NumberUtil.Parse(this.Parameters["Max News Items"], 5);
            }
        }

        public string IndexName
        {
            get
            {
                return this.Parameters["Index Name"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<NavigationElement> navigationElements = new List<NavigationElement>();

            NewsSearcher searcher = new NewsSearcher();
            Item[] searchResults = searcher.Search(IndexName, new string[] { "{0EB2F38A-FA48-433E-B6C2-E183E64A9E1C}".ToLower() }, MaxEntries);

            foreach (Item item in searchResults)
            {
                string navigationTitle = item.Fields["Headline"].Value;
                if (!string.IsNullOrEmpty(item.Fields["Publish Date"].Value))
                {
                    navigationTitle = DateUtil.FormatIsoDate(item.Fields["Publish Date"].Value, "d") + ": " + item.Fields["Headline"].Value;
                }
                NavigationElement element = new NavigationElement { NavigationTitle = navigationTitle, NavigationUrl = LinkManager.GetItemUrl(item) };
                navigationElements.Add(element);
            }

            this.repNewsEntries.DataSource = navigationElements;
            this.repNewsEntries.DataBind();
        }
    }
}