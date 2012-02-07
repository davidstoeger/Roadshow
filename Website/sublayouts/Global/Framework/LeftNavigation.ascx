<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftNavigation.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.Global.Framework.LeftNavigation" %>
<%@ Import Namespace="Sitecore.Roadshow.Model.Global.Framework" %>
<asp:Repeater ID="repLeftNavigation" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
    <ItemTemplate>
        <li class="<%# ((NavigationElement)Container.DataItem).ActiveClass %>"><a href="<%# ((NavigationElement)Container.DataItem).NavigationUrl %>">
            <sc:Text Field="Navigation Title" Item="<%# ((NavigationElement)Container.DataItem).Item %>" runat="server" />
        </a></li>
    </ItemTemplate>
</asp:Repeater>
