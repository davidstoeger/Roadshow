using Sitecore.Diagnostics;
using Sitecore.Roadshow.Application.Constants;
using Sitecore.Data.Items;
using System.Diagnostics;

namespace Sitecore.Roadshow.Application.Utils
{
    public static class Dictionary
    {
        public static string GetLabel(string key)
        {
            Stopwatch watch = Stopwatch.StartNew();
            string result = string.Empty;
            Assert.IsNotNullOrEmpty(key, "key must not be null or empty");
            string query = string.Format("{0}/{1}/{2}", Paths.DictionaryPath, key[0], key);
            Item dictionaryEntry = Context.Database.GetItem(query);
            if (dictionaryEntry != null)
            {
                result = dictionaryEntry.Fields["Phrase"].Value;
            }

            Log.Debug(string.Format("Time to retrieve dictionary entry '{0}': {1}ms", key, watch.ElapsedMilliseconds));
            return result;
        }
    }
}
