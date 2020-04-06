using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EchoClassic.Models;
using BusinessObjects;
using Controllers;
using System.Web.Security;

namespace EchoClassic.Account
{
    public partial class Register : Page
    {
        public string OTP { get; set; }

        public string CouponCode
        {
            get { return (General.QueryString("cc")); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CouponCode != string.Empty)
                {
                   string actCouponCode = CouponCode.Replace("plus","+");
                    actCouponCode = actCouponCode.Replace("echo","");
                    txtCouponCode.Text = Encryption.Decrypt(actCouponCode);
                    LoadData();
                }
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {

                string strUserID = string.Empty;
                bool IsExistEmail = false;
                if (Email.Text != string.Empty)
                {
                    IsExistEmail = new UserController().Verify_Email(Email.Text.Trim());
                }
                bool IsExistMobile = new UserController().Verify_Mobile(txtMobile.Text.Trim());

                if (IsExistEmail || IsExistMobile)
                {

                    FormsAuthentication.SetAuthCookie(litUserID.Text, false);
                    IdentityHelper.RedirectToReturnUrl("/account/managegroups", Response);

                }
                //ErrorMessage.Text = "This e-mail address already in our database, please use another e-mail address.";
                else
                {
                    divFormSection.Visible = false;
                    divOtpSection.Visible = true;
                    OTP = GetOTP();
                    litChk.Text = DateTime.Now.ToString() + "," + Encryption.Encrypt(OTP);
                    try
                    {
                        General.SendSMS(txtMobile.Text, "The OTP for Echo registration is " + OTP.ToString());
                    }
                    catch
                    {
                    }
                    try
                    {
                        General.SendEmail(Email.Text, "OTP from Echo", "The OTP for Echo registration is " + OTP.ToString());
                    }
                    catch
                    { }
                    //strUserID = new UserController().CreateUser(objUser);
                }
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = ex.Message;
            }
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (s.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
        }

        public string GetOTP()
        {
            Random random = new Random();
            return random.Next(1001, 9999).ToString();
        }
        protected void OTPValidate_Click(object sender, EventArgs e)
        {
            try
            {

                string strUserID = string.Empty;
                DateTime sentTime = Convert.ToDateTime(litChk.Text.Split(',').First());

                string sentOTP = Encryption.Decrypt(litChk.Text.Split(',').Last());
                if (sentTime.AddMinutes(2) > DateTime.Now)
                {


                    if (txtOtp.Text == sentOTP)
                    {
                        User objUser = new User
                        {
                            UserID = litUserID.Text,
                            CreateDate = DateTime.Now,
                            DOB = Convert.ToDateTime("1/1/1900"),
                            EMail = Email.Text,
                            FirstName = txtName.Text,
                            IsDeleted = false,
                            IsLockedOut = false,
                            LastLockoutDate = DateTime.Now,
                            LastLoginDate = DateTime.Now,
                            LastName = string.Empty,
                            LastPasswordChangedDate = DateTime.Now,
                            MobileNo = txtMobile.Text,
                            PWD = Password.Text,
                            RoleID = 3, // for Normal user
                            ImageID = string.Empty,
                            Custom1 = string.Empty,
                            Custom2 = string.Empty,
                            Custom3 = string.Empty,
                            Custom4 = string.Empty,
                            Custom5 = string.Empty
                        };
                        strUserID = new UserController().UpdateUser(objUser);
                        new UserController().ChangePassword(litUserID.Text, Encryption.Encrypt(Password.Text));
                        if (strUserID != string.Empty)
                        {
                            FormsAuthentication.SetAuthCookie(litUserID.Text, false);
                            Response.Redirect("/account/managegroups");
                        }
                        else
                        {
                            ErrorMessage.Text = "something is not right please try again!";
                        }
                    }
                    else { ErrorMessage.Text = "OTP did not match! Please try again"; }
                }
                else { ErrorMessage.Text = "OTP has been expired! Please try again"; }

            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "something is not right please try again!" + ex.Message;
            }
        }

        private void LoadData()
        {
            if (txtCouponCode.Text != string.Empty)
            {
                try
                {


                    User u = new UserController().GetUserByCouponCode(txtCouponCode.Text);
                    if (u != null)
                    {
                        txtName.Text = u.FirstName;
                        txtMobile.Text = u.MobileNo;
                        Email.Text = u.EMail;
                        litUserID.Text = u.UserID;
                    }

                }
                catch (Exception ex)
                {

                    ErrorMessage.Text = ex.Message;
                }
            }
        }
    }
}