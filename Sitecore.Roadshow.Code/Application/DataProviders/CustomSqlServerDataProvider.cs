using Sitecore.Data;
using Sitecore.Data.DataProviders;
using Sitecore.Data.Items;
using Sitecore.Data.SqlServer;

namespace Sitecore.Roadshow.Application.DataProviders
{
    public class CustomSqlServerDataProvider : SqlServerDataProvider
    {
        public CustomSqlServerDataProvider(string connectionString) : base(connectionString) { }

        public override bool SaveItem(ItemDefinition itemDefinition, ItemChanges changes, CallContext context)
        {
            Item item = this.Database.GetItem(itemDefinition.ID);
            ItemDefinition parent = GetItemDefinition(item.ParentID, context);
            /* only creates the item if it does not exist yet */
            CreateItem(itemDefinition.ID, itemDefinition.Name, itemDefinition.TemplateID, parent, context);
            bool result = base.SaveItem(itemDefinition, changes, context);
            return result;
        }
    }
}
