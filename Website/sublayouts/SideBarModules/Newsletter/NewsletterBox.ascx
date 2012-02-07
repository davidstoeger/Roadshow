<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsletterBox.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.SideBarModules.Newsletter.NewsletterBox" %>
<%@ Import Namespace="Sitecore.Roadshow.Application.Utils" %>
<div class="rich-text-box">
    <h3><sc:Text Field="Headline" Item="<%# DataSourceItem %>" runat="server" /></h3>
    <span class="shadow"></span>
    <div class="ishadow">
        <sc:Text ID="Text2" Field="Text" Item="<%# DataSourceItem %>" runat="server" />
    </div>
</div>