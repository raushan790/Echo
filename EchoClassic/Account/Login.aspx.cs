using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EchoClassic.Models;
using BusinessObjects;
using Controllers;
using System.Web.Security;
using System.Linq;
namespace EchoClassic.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                User objCustomer = new UserController().GetUser(Email.Text.Replace("'", "''"), Encryption.Encrypt(Password.Text));
                bool IsSuccess = objCustomer != null ? true : false;

                if (!IsSuccess)
                    General.ShowAlertMessage("Invalid username / password");

                else
                {
                    FormsAuthentication.SetAuthCookie(objCustomer.UserID.ToString(), false);
                    HttpCookie myCookie;

                    string strUserID = string.Empty;
                    if (RememberMe.Checked)
                    {
                        myCookie = new HttpCookie("UserCookie");
                        DateTime now = DateTime.Now;
                        // Set the cookie value.
                        myCookie.Value = objCustomer.EMail;
                        // Set the cookie expiration date.
                        myCookie.Expires = now.AddDays(7);
                        Response.Cookies.Add(myCookie);
                    }
                    if (objCustomer.Custom5 == "1")
                    {
                        Response.Redirect(Page.ResolveUrl("~/") + "account/managegroups");
                    }
                    if (objCustomer.Custom5 == "2")
                    {
                        if (objCustomer.UserGroup.Where(ss => ss.isAdmin == true).Count() > 0)
                        {
                            Response.Redirect(Page.ResolveUrl("~/") + "account/managegroupstype2");
                        }
                        else
                        {
                            Response.Redirect(Page.ResolveUrl("~/") + "account/selfattendance");
                        }
                    }
                    if (objCustomer.Custom5 == "3")
                    {
                        if (objCustomer.UserGroup.Where(ss => ss.isAdmin == true).Count() > 0)
                        {
                            Response.Redirect(Page.ResolveUrl("~/") + "account/managegroupstype3");
                        }
                        else
                        {
                            Response.Redirect(Page.ResolveUrl("~/") + "account/selfattendancetype3");
                        }
                    }
                }
            }
        }
    }
}