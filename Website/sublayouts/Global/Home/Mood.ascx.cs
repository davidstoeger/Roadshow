namespace Sitecore.Roadshow.sublayouts.Global.Home
{
    using System;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Sitecore.Web;
using Sitecore.Collections;
    using Sitecore.Base.Web.Controls;

    public partial class Mood : SublayoutBase
    {
        //private Item _dataSourceItem;


        private void Page_Load(object sender, EventArgs e)
        {
             moodimage.Item = DataSourceItem;
        }
    //    public Item DataSourceItem
    //    {

    //        get
    //        {
    //            if (this._dataSourceItem == null)
    //            {
    //                Sublayout parent = this.Parent as Sublayout;
    //                if (parent == null)
    //                {
    //                    this._dataSourceItem = Sitecore.Context.Item;
    //                }
    //                else if (string.IsNullOrEmpty(parent.DataSource))
    //                {
    //                    this._dataSourceItem = Sitecore.Context.Item;
    //                }
    //                else
    //                {
    //                    string dataSource = parent.DataSource;
    //                    this._dataSourceItem = Sitecore.Context.Database.GetItem(dataSource) ?? Sitecore.Context.ContentDatabase.GetItem(dataSource);
    //                    if (this._dataSourceItem == null)
    //                    {
    //                        this._dataSourceItem = Sitecore.Context.Item;
    //                    }
    //                }
    //            }
    //            return this._dataSourceItem;
    //        }
    //    }

    //           public string DataSourceItemPath
    //{
    //    get
    //    {
    //        return this.DataSourceItem.Paths.FullPath;
    //    }
    //}

    //public SafeDictionary<string> Parameters
    //{
    //    get
    //    {
    //        return WebUtil.ParseQueryString(((Sublayout) this.Parent).Parameters);
    //    }
    //}

    }

}