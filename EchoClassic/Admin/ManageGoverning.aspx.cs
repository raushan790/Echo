using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataObjects.AdoNet;
using BusinessObjects;
using Controllers;
using System.Data.SqlClient;


namespace EchoClassic.Admin
{
    public partial class ManageGoverning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGoverningBody();
                // GenerateCoupon();
                // BindGroupAndRole();
            }
        }

        private void LoadGoverningBody()
        {
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAllGoverningBody");
            if (ds.Tables.Count > 0)
            {
                gvGov.DataSource = ds;
                gvGov.DataBind();
            }
        }

        protected void btnSaveGov_Click(object sender, EventArgs e)
        {
            try
            {
                string ImageId = string.Empty;
                if (fuLogo.HasFile)
                {
                    ImageId = Guid.NewGuid().ToString("N");
                    fuLogo.PostedFile.SaveAs(Server.MapPath("~/images/" + ImageId + ".jpg"));

                }
                User u = new User();
                string strUserID = string.Empty;
                string CouponCode = string.Empty;
                u.FirstName = txtGovName.Text;
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
                u.RoleID = 1;
                u.Custom1 = txtContactPersonName.Text; //This field is used to save Contact Person Name
                u.Custom2 = string.Empty;
                u.Custom3 = string.Empty;
                u.Custom4 = string.Empty;
                u.Custom5 = string.Empty;
                u.PWD = Encryption.Encrypt("ab@345");
                u.Session = General.GetCurrentSession;
                u.ClientID = 0;
                u.ImageID = ImageId;
                if (litGovID.Text == string.Empty)
                {
                    strUserID = new UserController().CreateUser(u);
                    General.ShowAlertMessage("Success!");
                }
                else
                {
                    u.UserID = litGovID.Text;
                    strUserID = new UserController().UpdateUser(u);
                    General.ShowAlertMessage("Success!");
                }
                ClearForm();
                LoadGoverningBody();
            }
            catch(Exception ex)
            {
                General.ShowAlertMessage(ex.Message + "\r\n Please validate the details and try again.");
            }
        }

        protected void btnClearGov_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void gvGov_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvGov.Rows[e.RowIndex];
            Label ID = (Label)row.FindControl("GovID");
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ID", ID.Text);
            SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Governing_Delete", m);
        }
        protected void gvGov_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditGov")
            {
                //int ClientID = Convert.oInt32();
                if (e.CommandArgument!="")
                {
                    //GridViewRow row = (GridViewRow)gvGov.Rows[e.RowIndex];
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    Label ID = (Label)row.FindControl("GovID");
                    litGovID.Text = ID.Text.ToString();

                    Label Name = (Label)row.FindControl("lblGoverningBodyName");
                    txtGovName.Text = Name.Text.ToString();

                    Label CPName = (Label)row.FindControl("lblContactPersonName");
                    txtContactPersonName.Text = CPName.Text.ToString();

                    Label Mobile = (Label)row.FindControl("lblMobileNo");
                    txtMobile.Text = Mobile.Text.ToString();

                    Label Email = (Label)row.FindControl("lblEmail");
                    txtEmail.Text = Email.Text.ToString();

                }
                    //BindClients();
                
            }
        }

        private void ClearForm()
        {
            litGovID.Text = string.Empty;
            txtGovName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContactPersonName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            //fuLogo.Text = string.Empty;
        }
            
    }
}