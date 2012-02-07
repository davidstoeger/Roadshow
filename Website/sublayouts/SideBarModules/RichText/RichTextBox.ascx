<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RichTextBox.ascx.cs"
    Inherits="Sitecore.Roadshow.sublayouts.SideBarModules.RichText.RichTextBox" %>
<div class="rich-text-box">
    <h3><sc:Text Field="Headline" Item="<%# DataSourceItem %>" runat="server" /></h3>
    <span class="shadow"></span>
    <div class="ishadow">
        <sc:Text Field="Text" Item="<%# DataSourceItem %>" runat="server" />
    </div>
</div>
