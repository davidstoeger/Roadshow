<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeaserNavigation.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.Global.Common.Page.TeaserNavigation" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="startModules">
<div class="colmod">
 
    <asp:ListView ID="ListView1" runat="server"  ItemPlaceholderID="itemPlaceholder">
    <LayoutTemplate>
     <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
    </LayoutTemplate>
    <ItemTemplate>
    <div class="teaserNav module">
    <h1><sc:FieldRenderer runat="server" ID="scHeadline" FieldName="teaser headline" Item='<%# Sitecore.Context.Database.GetItem(new Sitecore.Data.ID( Eval("ID").ToString())) %>'/></h1>
    <sc:Image MaxWidth="100" Field="image" runat="server"  Item='<%# Sitecore.Context.Database.GetItem(new Sitecore.Data.ID( Eval("ID").ToString())) %>'/>
    <sc:FieldRenderer runat="server" ID="scText" FieldName="teaser text"  Item='<%# Sitecore.Context.Database.GetItem(new Sitecore.Data.ID( Eval("ID").ToString())) %>'/>     
    <br />
    <asp:HyperLink runat="server" ID="hypLink" Text="weiter >>" NavigateUrl='<%# Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(new Sitecore.Data.ID( Eval("ID").ToString()))) %>'></asp:HyperLink>
    </div> 
    </ItemTemplate>    
    </asp:ListView>
</div>
</div>