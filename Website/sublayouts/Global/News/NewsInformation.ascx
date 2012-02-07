<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsInformation.ascx.cs"
    Inherits="Sitecore.Roadshow.sublayouts.Global.News.NewsInformation" %>
<h1><sc:Text Field="Headline" Item="<%# DataSourceItem %>" runat="server" /></h1>

<h2><sc:Text Field="Teaser Text" Item="<%# DataSourceItem %>" runat="server" /></h2>
<sc:Text Field="Location" Item="<%# DataSourceItem %>" runat="server" />, <sc:Date Field="Publish Date" Item="<%# DataSourceItem %>" Format="d" runat="server" />
<br />
<sc:Text Field="Description" Item="<%# DataSourceItem %>" runat="server" />