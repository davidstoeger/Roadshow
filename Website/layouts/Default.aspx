<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sitecore.Roadshow.layouts.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <sc:Sublayout Path="/sublayouts/Global/Framework/HtmlHeader.ascx" runat="server" />
</head>
<body>
    <form id="mainForm" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <sc:VisitorIdentification ID="VisitorIdentification" runat="server"/>
    <div id="page">
        <div id="header">
            <div id="logo">
                <a href="/"><sc:Image ID="imgLogo" Field="Logo" Border="0" runat="server" /></a>
            </div>
            <sc:Sublayout Path="/sublayouts/Global/Framework/TopNavigation.ascx" ID="slTopNavigation" runat="server" />
        </div>
        <!-- /#header -->
        <sc:Placeholder ID="phMain" Key="Main" runat="server" />
        <!-- /#main -->
        <div id="footer">
            <sc:Sublayout Path="/sublayouts/Global/Framework/Footer.ascx" runat="server" />
        </div>
    </div>
    <sc:Placeholder Key="Debug" runat="server" />
    </form>
</body>
</html>
