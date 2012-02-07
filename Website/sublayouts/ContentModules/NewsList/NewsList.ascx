<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsList.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.ContentModules.NewsList.NewsList" %>
<%@ Import Namespace="Sitecore.Roadshow.Model.Global.Framework" %>
<div class="news-list">
    <h3>
        <sc:Text Field="Headline" Item="<%# DataSourceItem %>" runat="server" />
    </h3>
    <asp:Repeater ID="repNewsEntries" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
        <ItemTemplate>
            <li>
                <a href="<%# ((NavigationElement)Container.DataItem).NavigationUrl%>"><%# ((NavigationElement)Container.DataItem).NavigationTitle %></a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</div>
