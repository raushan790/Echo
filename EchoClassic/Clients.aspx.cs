using BusinessObjects;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Admin
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnClearClient_Click(object sender, EventArgs e)
        {
            txtOrganizationName.Text = string.Empty;
            txtContactPersonName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;

        }
        protected void btnSaveClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMobile.Text != string.Empty && isExist(txtMobile.Text, txtContactPersonName.Text))
                {
                    General.ShowAlertMessage("This Contact detail is already in database");
                }
                else
                {
                    BusinessObjects.Clients cl = new BusinessObjects.Clients();
                    cl.OrganizationName = txtOrganizationName.Text;
                    cl.ContactPersonName = txtContactPersonName.Text;
                    cl.MobileNo = txtMobile.Text;
                    cl.Email = txtEmail.Text;
                    cl.Address = txtAddress.Text;
                    cl.City = txtCity.Text;
                    cl.State = txtState.Text;

                    cl.MemberCount = 0;//String.IsNullOrEmpty(txtMembersCount.Text) ? 0 : Convert.ToInt32(txtMembersCount.Text);
                    cl.UserAllowed = string.Empty; //txtUsersAllowedCount.Text;
                    cl.CreateDate = DateTime.UtcNow.AddHours(5.5);
                    int ClientID = 0;

                    ClientID = new ClientController().CreateNewClient(cl);



                    if (fuLogo.HasFile)
                    {
                        fuLogo.PostedFile.SaveAs(Server.MapPath("~/images/" + ClientID.ToString() + ".jpg"));

                    }
                    fuLogo.PostedFile.SaveAs(Server.MapPath("~/images/" + ClientID.ToString() + ".jpg"));


                    User u = new User();
                    string strUserID = string.Empty;


                    string CouponCode = string.Empty;
                    u.FirstName = txtContactPersonName.Text;
                    u.EMail = txtEmail.Text;
                    u.MobileNo = txtMobile.Text;
                    u.CreateDate = DateTime.Now;
                    u.DOB = Convert.ToDateTime("1/1/1900");
                    u.LastLockoutDate = DateTime.Now;
                    u.LastLoginDate = DateTime.Now;
                    u.LastPasswordChangedDate = DateTime.Now;
                    u.CouponCode = CouponCode;
                    u.IsDeleted = false;
                    u.IsLockedOut = false;
                    u.RoleID = 2;
                    u.Custom1 = "0";
                    u.Custom2 = string.Empty;
                    u.Custom3 = string.Empty;
                    u.Custom4 = string.Empty;
                    u.Custom5 = "3";
                    u.PWD = Encryption.Encrypt(txtPwd.Text);
                    u.ChangedPassword = true;
                    u.Session = General.GetCurrentSession;
                    u.ClientID = ClientID;
                    strUserID = new UserController().CreateUser(u);
                    new UserController().FirstTimeUpdatePassword(strUserID, u.PWD, u.MobileNo);
                    FormsAuthentication.SetAuthCookie(strUserID, false);
                    General.ShowAlertMessage("Congratulations for successfully registering. Your first 5 groups are free forever.", "/admin/addgroup?ClientID=" + ClientID.ToString());
                        //, "/admin/addgroup?ClientID = " + ClientID.ToString());
                    //You have successfully registered!", "/admin/addgroup?ClientID=" + ClientID.ToString() + "");
                    txtOrganizationName.Text = string.Empty;
                    txtContactPersonName.Text = string.Empty;
                    txtMobile.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                    txtCity.Text = string.Empty;
                    txtState.Text = string.Empty;

                }
            }
            catch (Exception ex)
            {
                General.ShowAlertMessage(ex.Message + "\r\n Please validate the details and try again.");
            }

        }
        private bool isExist(string Mobile, string Name)
        {
            bool isExist = false;
            if (new UserController().Verify_byNameAndMobile(Mobile, Name))
            {
                isExist = true;
            }
            return isExist;
        }
    }
}