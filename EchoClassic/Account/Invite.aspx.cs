using BusinessObjects;
using Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Account
{
    public partial class Invite : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GenerateCoupon();
                BindGroupAndRole();
            }
        }
        private void BindGroupAndRole()
        {
            IList<UserGroups> Groups = new UserController().GetUserGroupsList();
            ddlGroup.DataSource = Groups.Where(ss=>ss.Owner==Context.User.Identity.Name&& ss.IsRole == false);
            ddlGroup.DataValueField = "UserGroupID";
            ddlGroup.DataTextField = "Group_Name";
            ddlGroup.DataBind();
            ddlRole.DataSource = Groups.Where(ss => ss.Owner == Context.User.Identity.Name&&ss.IsRole==true);
            ddlRole.DataValueField = "UserGroupID";
            ddlRole.DataTextField = "Group_Name";
            ddlRole.DataBind();
        }
        protected void IssueCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsExist = new UserController().Verify_Email(Email.Text.Trim());

                if (IsExist)
                    ErrorMessage.Text = "This e-mail address already in our database, please use another e-mail address.";
                else
                {
                    string strUserID = string.Empty;

                    User objUser = new User
                    {
                        CouponCode = txtCouponCode.Text,
                        CreatedBy=Context.User.Identity.Name,
                        CreateDate = DateTime.Now,
                        DOB = Convert.ToDateTime("1/1/1900"),
                        EMail = Email.Text,
                        FirstName = txtName.Text,
                        IsDeleted = false,
                        IsLockedOut = true,
                        LastLockoutDate = DateTime.Now,
                        LastLoginDate = DateTime.Now,
                        LastName = string.Empty,
                        LastPasswordChangedDate = DateTime.Now,
                        MobileNo = txtMobile.Text,
                        PWD = string.Empty,
                        RoleID = 3, // for Normal user
                        ImageID = string.Empty,
                        Custom1 = string.Empty,
                        Custom2 = string.Empty,
                        Custom3 = string.Empty,
                        Custom4 = string.Empty,
                        Custom5 = string.Empty
                    };
                    strUserID = new UserController().CreateUser(objUser);

                }

            }
            catch (Exception ex)
            {

                ErrorMessage.Text = ex.Message;
            }
        }

        private void GenerateCoupon()

        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string Code = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();



            for (int i = 0; i < 12; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                Code += sTempChars;

            }
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            cmd.CommandText = "select count(UserID) from Users where Custom1='" + Code + "'";
            cmd.Connection = con;
            con.Open();
            int chk = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (chk > 0)
            {
                GenerateCoupon();
            }
            else
            {
                txtCouponCode.Text = Code;
            }

        }
    }
}