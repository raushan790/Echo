using System;
using System.Web;
using System.Web.UI;
using BusinessObjects;
using Controllers;
using EchoClassic.Models;
using System.Linq;

namespace EchoClassic.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Default");
                    //Page.Title = "Change Password";
                    //User u = new UserController().GetUser(Context.User.Identity.Name);
                    //Email.Text = u.MobileNo;
                    //txtRecoveryMobile.Text = u.MySpace;
                }
            }
        }
        protected void SendOTP(object sender, EventArgs e)
        {
            if (IsValid)
            {
                User u = null;
                if (General.IsNumber(Email.Text))
                {
                    u = new UserController().GetUserbyMobile(Email.Text);

                }
                else
                {
                    if (General.ValidEmail(Email.Text))
                    {
                        u = new UserController().GetUserbyEmail(Email.Text);
                    }
                    else
                    {
                        General.ShowAlertMessage("Please enter a valid email.");
                        ErrorMessage.Text = "Please enter a valid email.";
                    }
                }

                if (u != null)
                {
                    string OTP = GetOTP();
                    litChk.Text = DateTime.Now.ToString() + "," + Encryption.Encrypt(OTP);
                    try
                    {
                        General.SendSMS(u.MySpace, "The OTP is " + OTP.ToString());
                        ErrorMessage.Text = string.Empty;
                    }
                    catch
                    {
                    }
                    try
                    {
                        General.SendEmail(u.EMail, "OTP from Echo", "The OTP is " + OTP.ToString());
                        ErrorMessage.Text = string.Empty;
                    }
                    catch
                    { }
                    pnlOTP.Visible = false;
                    pnlPWD.Visible = true;
                    litUserID.Text = u.UserID;
                    General.ShowAlertMessage("Please check your registered email or moblie for OTP");
                    ErrorMessage.Text = "Please check your registered email or moblie for OTP <br/> OTP is Valid for 2 minutes only";

                }
                else
                {
                    General.ShowAlertMessage("Invalid username");
                    ErrorMessage.Text = "Invalid username";

                }

            }
        }
        public string GetOTP()
        {
            Random random = new Random();
            return random.Next(1001, 9999).ToString();
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    DateTime sentTime = Convert.ToDateTime(litChk.Text.Split(',').First());

                    string sentOTP = Encryption.Decrypt(litChk.Text.Split(',').Last());
                    if (sentTime.AddMinutes(2) > DateTime.Now)
                    {
                        if (txtOTP.Text == sentOTP)
                        {
                            int ss = new UserController().ChangePassword(litUserID.Text, Encryption.Encrypt(Password.Text));
                            ErrorMessage.Text = string.Empty;
                            General.ShowAlertMessage("Password successfully updated", "../Default");
                        }
                    }
                    else
                    {
                        General.ShowAlertMessage("OTP has been expired! Please try again");
                        ErrorMessage.Text = "OTP has been expired! Please try again";
                    }
                }
            }
            catch (Exception ex)
            {
                General.ShowAlertMessage("Something went wrong! Please try again " + ex.Message);
                ErrorMessage.Text = "Something went wrong! Please try again " + ex.Message;
            }
        }
    }
}