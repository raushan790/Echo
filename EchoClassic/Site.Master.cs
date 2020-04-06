using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using BusinessObjects;
using Controllers;
namespace EchoClassic
{
    public partial class SiteMaster : MasterPage
    {

        public String UserName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    PreloginSection.Visible = true;
                    PostLoginSection.Visible = false;
                }
                   
               
            }
        }

      
    }

}