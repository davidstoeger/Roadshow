<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageList.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.ContentModules.ImageList.ImageList" %>
<div class="image-list">
    <h3>
        <sc:Text Field="Headline" Item="<%# DataSourceItem %>" runat="server" />
    </h3>
    <asp:Repeater ID="repImages" runat="server">
        <ItemTemplate>
        <div class="image-entry">
            <sc:Image Field="Image" MaxHeight="160" runat="server" Item="<%# ((Sitecore.Data.Items.Item)Container.DataItem)%>" />
            <div class="clear"></div>
            <sc:Text Field="Image Description" runat="server" Item="<%# ((Sitecore.Data.Items.Item)Container.DataItem)%>" />
        </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear"></div>
</div>
