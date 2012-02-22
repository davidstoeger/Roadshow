<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Teaser.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.Global.Home.Teaser" %>
<h2><sc:Text Field="Headline" Item="<%# DataSourceItem %>" runat="server" /></h2>
<sc:Image Field="Image" Item="<%# DataSourceItem %>" CssClass="teaser-image" MaxWidth="150" MaxHeight="100" runat="server" />
<p><sc:Text Field="Text" Item="<%# DataSourceItem %>" runat="server" /></p>
<div class="clear"></div>
<sc:Link Field="Link" Item="<%# DataSourceItem %>" runat="server" />
