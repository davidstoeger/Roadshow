<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThreeColumnContent.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.Global.Framework.Frames.ThreeColumnContent" %>
<div id="main">
    <div id="sub-navigation">
        <sc:Sublayout Path="/sublayouts/Global/Framework/LeftNavigation.ascx" runat="server" />
    </div>
    <div id="sidebar">
        <sc:Placeholder Key="SideBar" runat="server" />
    </div>
    <div id="main-content" style="float:left">
        <sc:Placeholder Key="MiddleColumn" runat="server" />
    </div>
</div>