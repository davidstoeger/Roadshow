using System;
using Sitecore.Base.Web.Controls;
using Sitecore.Security.Authentication;

namespace Sitecore.Roadshow.sublayouts.SideBarModules.Login
{
    public partial class LoginBox : SublayoutBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Sitecore.Context.User != null && Sitecore.Context.User.IsAuthenticated)
                {
                    this.phUserDetails.Visible = true;
                    this.litUserDetails.Text = string.Format("Welcome, {0} ({1})", Sitecore.Context.User.Profile.FullName, Sitecore.Context.User.DisplayName);
                }
            }
        }

        public void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
            if (string.IsNullOrEmpty(loginBox.UserName))
            {
                loginBox.InstructionText = "Enter a valid e-mail address.";
                loginBox.InstructionTextStyle.ForeColor = System.Drawing.Color.RosyBrown;
                e.Cancel = true;
                this.phUserDetails.Visible = false;
            }
            else
            {
                if (AuthenticationManager.Login(loginBox.UserName, loginBox.Password, loginBox.RememberMeSet))
                {
                    loginBox.InstructionText = String.Empty;
                    this.litUserDetails.Text = string.Format("User.Name: {0}<br /> User.Displayname: {1}", Sitecore.Context.User.Name, Sitecore.Context.User.DisplayName);
                    this.phUserDetails.Visible = true;
                }
                else
                {
                    loginBox.InstructionText = "Your username/password combination was wrong.";
                    loginBox.InstructionTextStyle.ForeColor = System.Drawing.Color.RosyBrown;
                    e.Cancel = true;
                    this.phUserDetails.Visible = false;
                }
            }
        }

        public void OnLoginError(object sender, EventArgs e)
        {
            loginBox.HelpPageText = "Help with logging in...";
            loginBox.PasswordRecoveryText = "Forgot your password?";
            this.phUserDetails.Visible = false;
        }
    }
}