using BusinessObjects;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public String UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (Context.User.Identity.IsAuthenticated)
                {
                    User c = new UserController().GetUser(Context.User.Identity.Name);

                    UserName = c.FirstName;
                    PreloginSection.Visible = false;
                    PostLoginSection.Visible = true;
                }
                else
                {
                    Response.Redirect("~/default?echotgt=" + Request.RawUrl);
                }


            
        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            // Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}