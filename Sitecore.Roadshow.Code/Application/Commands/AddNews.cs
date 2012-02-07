using Sitecore.Shell.Framework.Commands;
using Sitecore.Configuration;
using Sitecore.Globalization;
using Sitecore.Roadshow.Application.Constants;
using Sitecore.Data.Fields;
using System;
using Sitecore.Data.Items;
using Sitecore.Data;

namespace Sitecore.Roadshow.Application.Commands
{
    class AddNews : Command
    {
        public override void Execute(Sitecore.Shell.Framework.Commands.CommandContext context)
        {
            if (context.Items.Length == 1)
            {
                Sitecore.Data.Items.Item item = context.Items[0];
                if (context.Parameters.Count == 1)
                {
                    CreateNewsItem(context.Parameters[0], item.Database.Name, item.Language.ToString());
                }
                else
                {
                    System.Collections.Specialized.NameValueCollection parameters = new System.Collections.Specialized.NameValueCollection();

                    parameters["id"] = item.ID.ToString();
                    parameters["language"] = item.Language.ToString();
                    parameters["database"] = item.Database.Name;
                    Sitecore.Context.ClientPage.Start(this, "Run", parameters);
                }
            }
        }
        protected void Run(Sitecore.Web.UI.Sheer.ClientPipelineArgs args)
        {
            if (args.IsPostBack)
            {
                CreateNewsItem(args.Result, args.Parameters["database"], args.Parameters["language"]);
            }
            else
            {
                string text = StringUtil.GetString(new string[] { args.Parameters["prompt"], "Enter the name of the new item:" });
                Sitecore.Context.ClientPage.ClientResponse.Input(text, Translate.Text("New Item"), Settings.ItemNameValidation, "'$Input' is not a valid name.", Settings.MaxItemNameLength);
                args.WaitForPostBack();
            }
        }

        private void CreateNewsItem(string newsItemName, string databaseName, string language)
        {
            if ((!string.IsNullOrEmpty(newsItemName)) && newsItemName != "undefined")
            {
                Database db = Factory.GetDatabase(databaseName);
                Item newsFolderItem = db.GetItem(Paths.NewsFolder, Language.Parse(language));

                TemplateItem newsTemplate = Sitecore.Context.ContentDatabase.Templates[TemplateIds.News];
                TemplateItem folderTemplate = Sitecore.Context.ContentDatabase.Templates[TemplateIDs.Folder];

                Item newsItem = newsFolderItem.Add(newsItemName, newsTemplate);
                DateField publishDateField = newsItem.Fields["Publish Date"];
                DateTime publishDate = publishDateField.DateTime;
                if (publishDate == DateTime.MinValue)
                {
                    publishDate = DateTime.Now;
                }

                Item yearItem = newsFolderItem.Axes.SelectSingleItem(string.Format("./{0}", publishDate.Year));
                if (yearItem == null)
                {
                    yearItem = newsFolderItem.Add(publishDate.Year.ToString(), folderTemplate);
                }

                Item monthItem = yearItem.Axes.SelectSingleItem(string.Format("./#{0}#", publishDate.Month.ToString("00")));
                if (monthItem == null)
                {
                    monthItem = yearItem.Add(publishDate.Month.ToString("00"), folderTemplate);
                }

                newsItem.MoveTo(monthItem);

                Sitecore.Context.ClientPage.SendMessage(this, "item:load(id=" + newsItem.ID.ToString() + ")");
            }
        }
    }
}
