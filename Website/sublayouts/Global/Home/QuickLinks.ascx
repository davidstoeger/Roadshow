<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuickLinks.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.Global.Home.QuickLinks" %>
<h2><sc:Text ID="Text1" Field="Headline" Item="<%# DataSourceItem %>" runat="server" /></h2>
<ul class="news-list">
    <li><sc:Link Field="Link 1" Item="<%# DataSourceItem %>" runat="server" /></li>
    <li><sc:Link Field="Link 2" Item="<%# DataSourceItem %>" runat="server" /></li>
    <li><sc:Link Field="Link 3" Item="<%# DataSourceItem %>" runat="server" /></li>
    <li><sc:Link Field="Link 4" Item="<%# DataSourceItem %>" runat="server" /></li>
</ul>
