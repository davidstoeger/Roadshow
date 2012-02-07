using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Search;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Lucene.Net.Search;
using Lucene.Net.Index;

namespace Sitecore.Roadshow.Application.Search
{
    public class NewsSearcher
    {
        public Item[] Search(string index, string[] areas, int maxItems)
        {
            List<Item> searchResults = new List<Item>();

            var searchIndex = Sitecore.Search.SearchManager.GetIndex(index);
            using (IndexSearchContext context = searchIndex.CreateSearchContext())
            {
                
                /***********/
                /* First we need to create a BooleanQuery so we can concatenate the different queries */

                BooleanQuery completeQuery = new BooleanQuery();
                //completeQuery.SetMinimumNumberShouldMatch(2);
 
                /* search only in current language */
                completeQuery.Add(new TermQuery(new Lucene.Net.Index.Term("_language", Sitecore.Context.Language.Name)), BooleanClause.Occur.MUST);
 
                Sort sort = new Sort(new SortField("publish date", true));
 
                Lucene.Net.Search.Searcher searcher = context.Searcher;
                try
                {
                    Hits hits = context.Searcher.Search(completeQuery, sort);
                    SearchHits searchHits = new SearchHits(hits);

                    // assuming, no more than every second result is a null-item, that is why the maxItems parameter is multiplied by 2
                    var results = searchHits.FetchResults(0, maxItems * 2);
                    int count = 0;
                    foreach (SearchResult result in results)
                    {
                        try
                        {
                            Item item = result.GetObject<Item>();
                            if (item != null)
                            {
                                count++;
                                searchResults.Add(item);
                            }
                        }
                        catch (Exception e)
                        {
                            Log.Error("error while converting lucene search hit in NewsSearcher.cs", e, searchIndex);
                        }

                        if (count >= maxItems) break;
                    }
                }
                catch (Exception e)
                {
                    Log.Error("error while performing a lucene search in NewsSearcher.cs", e, searchIndex);
                }
            }
            
            return searchResults.ToArray();
        }
    }
}
