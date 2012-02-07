<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactBox.ascx.cs"
    Inherits="Sitecore.Roadshow.sublayouts.SideBarModules.Contact.ContactBox" %>
<div class="contact-box">
    <h3><sc:Text Field="Headline" Item="<%# DataSourceItem %>" runat="server" /></h3>
    <span class="shadow"></span>
    <div class="ishadow">
        <%= Sitecore.Roadshow.Application.Utils.Dictionary.GetLabel("Name") %>: <sc:Text Field="Name" Item="<%# DataSourceItem %>" runat="server" /><br />
        <%= Sitecore.Roadshow.Application.Utils.Dictionary.GetLabel("E-Mail") %>: <sc:Text Field="E-Mail" Item="<%# DataSourceItem %>" runat="server" /><br />
        <%= Sitecore.Roadshow.Application.Utils.Dictionary.GetLabel("Phone") %>: <sc:Text Field="Phone" Item="<%# DataSourceItem %>" runat="server" />
    </div>
</div>
