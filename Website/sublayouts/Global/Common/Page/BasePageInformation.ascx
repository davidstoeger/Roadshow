<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasePageInformation.ascx.cs"
    Inherits="Sitecore.Roadshow.sublayouts.Global.Common.Page.BasePageInformation" %>
<h1><sc:Text Field="Headline" Item="<%# DataSourceItem %>" runat="server" /></h1>
<sc:Image Field="Image" Item="<%# DataSourceItem %>" runat="server" MaxHeight="150" MaxWidth="510" Border="0" />

<h2><sc:Text Field="Teaser Text" Item="<%# DataSourceItem %>" runat="server" /></h2>
<sc:Text Field="Description" Item="<%# DataSourceItem %>" runat="server" />