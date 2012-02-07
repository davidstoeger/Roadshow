<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginBox.ascx.cs" Inherits="Sitecore.Roadshow.sublayouts.SideBarModules.Login.LoginBox" %>
<%@ Import Namespace="Sitecore.Roadshow.Application.Utils" %>
<div class="login-box">
    <h3><%= Dictionary.GetLabel("My Account") %></h3>
    <span class="shadow"></span>
    <div class="ishadow">
    <asp:Login ID="loginBox" runat="server" BorderStyle="Solid" BackColor="#FFFFFF" BorderWidth="0px"
        BorderColor="#CCCC99" Font-Names="Arial, Helvetica" UserNameLabelText="Username:"
        VisibleWhenLoggedIn="false" OnLoggingIn="OnLoggingIn"
        OnLoginError="OnLoginError">
        <TextBoxStyle Width="135px" Font-Size="12px" />
    </asp:Login>
    
        <asp:PlaceHolder ID="phUserDetails" runat="server" Visible="false">
        
            <asp:Literal ID="litUserDetails" runat="server" /><br />
            <asp:LoginStatus ID="loginStatus" runat="server" />
        
        </asp:PlaceHolder>
    </div>
</div>
