<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavigation.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.Global.Framework.TopNavigation" %>
<%@ Import Namespace="Sitecore.Roadshow.Model.Global.Framework" %>
<div id="nav">
    <asp:Repeater ID="repTopNavigation" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
        <ItemTemplate>
            <li><a href="<%# ((NavigationElement)Container.DataItem).NavigationUrl %>">
                <sc:Text ID="Text1" Field="Navigation Title" Item="<%# ((NavigationElement)Container.DataItem).Item %>" runat="server" />
            </a></li>
        </ItemTemplate>
    </asp:Repeater>
</div>