using BusinessObjects;
using Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string serviceUrl = "http://localhost:7375/service1.svc/CreateAttendance";
            //object input = new
            //{
            //    Attendance="chk"
            //};
            //string inputJson = (new JavaScriptSerializer()).Serialize(input);

            //HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(serviceUrl + "/GetData"));
            //httpRequest.Accept = "application/json";
            //httpRequest.ContentType = "application/json";
            //httpRequest.Method = "POST";

            //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(inputJson);

            //using (Stream stream = httpRequest.GetRequestStream())
            //{
            //    stream.Write(bytes, 0, bytes.Length);
            //    stream.Close();
            //}

            //using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            //{
            //    using (Stream stream = httpResponse.GetResponseStream())
            //    {
            //        string ss = (new StreamReader(stream)).ReadToEnd();
            //    }
            //}
            //string ss= Encryption.Encrypt("abC@123");
            // General.SendEmail("shashibhanmaurya@gmail.com","test","test");
            if (Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/account/managegroups");
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
                    if (objCustomer.RoleID == 2) //  1 == Administrator
                    {

                        Response.Redirect(Page.ResolveUrl("~/") + "account/managegroups.aspx");
                    }
                    else
                    {
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }



                }
            }
        }
    }
}