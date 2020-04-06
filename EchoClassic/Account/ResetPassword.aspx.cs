using System;
using System.Web;
using System.Web.UI;
using BusinessObjects;
using Controllers;
using EchoClassic.Models;
using System.Linq;


namespace EchoClassic.Account
{
    public partial class ResetPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Context.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Default");
                    
                   
                }
                
            }
        }
        protected string StatusMessage
        {
            get;
            private set;
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            User u = new UserController().GetUser(Context.User.Identity.Name);
            if (u.PWD == Encryption.Encrypt(txtOldPassword.Text))
            {
                int ss = new UserController().ChangePassword(Context.User.Identity.Name, Encryption.Encrypt(Password.Text));
                ErrorMessage.Text = string.Empty;
                General.ShowAlertMessage("Password successfully updated", "../Default");

            }
            else
            {
                General.ShowAlertMessage("Old Password is not correct. Please try again!");
            }

        }
    }
}