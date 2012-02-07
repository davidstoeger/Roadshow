<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwoColumnContent.ascx.cs"
    Inherits="Sitecore.Roadshow.sublayouts.Global.Framework.Frames.TwoColumnContent" %>
<div id="main">
    <div id="teaser">
        <sc:Placeholder Key="MiddleColumn" runat="server" />
    </div>
    <div id="sidebar">
        <sc:Placeholder runat="server" Key="SideBar"></sc:Placeholder>
    </div>
</div>
