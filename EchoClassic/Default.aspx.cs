using BusinessObjects;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic
{
    public partial class _Default : Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            //General.SendPushNotificationAndroid("c9ChnWbGrkM:APA91bFgguBJpjdnYFfYwQ2mc-n2dEbgoNRuXYVH09_ucn0YCUXzYdjrmRtHNzIFUwwwtNzZaTrkhpwo9FI96xUr30Y5I4UqgmCKbXmBtEi7wAAblT7WehJVtrwtbozQhyxDC9Waesly", "vhk title","chk message");
            // string sds = Encryption.Decrypt("3BQgfCWunZg=");

            if (Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect(Page.ResolveUrl("~/") + "account/managegroups");
            }

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                User objCustomer = null;
                bool isNumber = General.IsNumber(Email.Text.Trim());
                if (objCustomer == null && isNumber)
                {
                    objCustomer = new UserController().GetUserForLoginByMobile(Email.Text.Replace("'", "''"), Encryption.Encrypt(Password.Text));
                }
                else
                {
                    objCustomer = new UserController().GetUser(Email.Text.Replace("'", "''"), Encryption.Encrypt(Password.Text));
                }
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
                    //Response.Redirect("~/account/managegroups");
                    string fromUrl = Request.QueryString["echotgt"];

                    if (!string.IsNullOrEmpty(fromUrl))
                    {
                        Session["ClientID"] = objCustomer.ClientID;
                        Response.Redirect(fromUrl);
                    }
                    else
                    {
                        if (objCustomer.RoleID==2)
                        {
                            Response.Redirect(Page.ResolveUrl("~/") + "admin/su-dashboard");

                        }

                        else
                        {
                            Response.Redirect(Page.ResolveUrl("~/") + "account/managegroups");
                        }
                    }
                }
            }
        }
    }
}