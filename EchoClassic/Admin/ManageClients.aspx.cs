using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using Controllers;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using DataObjects.AdoNet;

namespace EchoClassic.Admin
{
    public partial class ManageClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClients();
                LoadGoverningBody();
                // GenerateCoupon();
                // BindGroupAndRole();
            }
        }
        private void BindClients()
        {
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "Client_SelectAll");
            gvClients.DataSource = ds;
            gvClients.DataBind();
        }
        private void LoadGoverningBody()
        {
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAllGoverningBody");
            if (ds.Tables.Count > 0)
            {
                DataRow newRow = ds.Tables[0].NewRow();
                newRow[0] = "0";
                newRow[1] = "Select Governing Body";
                ds.Tables[0].Rows.InsertAt(newRow, 0);
                ddlGoverningBody.DataSource = ds;
                ddlGoverningBody.DataBind();
            }
        }
        protected void btnSaveClient_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessObjects.Clients cl = new BusinessObjects.Clients();
                cl.OrganizationName = txtOrganizationName.Text;
                cl.ContactPersonName = txtContactPersonName.Text;
                cl.MobileNo = txtMobile.Text;
                cl.Email = txtEmail.Text;
                cl.Address = txtAddress.Text;
                cl.City = txtCity.Text;
                cl.State = txtState.Text;
                cl.GoverningId = ddlGoverningBody.SelectedItem.Value;//.SelectedValue

                cl.MemberCount = 0;//String.IsNullOrEmpty(txtMembersCount.Text) ? 0 : Convert.ToInt32(txtMembersCount.Text);
                cl.UserAllowed = string.Empty; //txtUsersAllowedCount.Text;
                cl.CreateDate = DateTime.Now;
                int ClientID = 0;
                if (litClientID.Text == string.Empty)
                {
                    ClientID = new ClientController().CreateNewClient(cl);

                }
                else
                {
                    ClientID = Convert.ToInt32(litClientID.Text);
                    cl.ID = ClientID;
                    new ClientController().UpdateClient(cl);
                }
                if (fuLogo.HasFile)
                {
                    fuLogo.PostedFile.SaveAs(Server.MapPath("~/images/" + ClientID.ToString() + ".jpg"));

                }
                fuLogo.PostedFile.SaveAs(Server.MapPath("~/images/" + ClientID.ToString() + ".jpg"));


                User u = new User();
                string strUserID = string.Empty;

                if (litAdminID.Text == string.Empty && txtMobile.Text != string.Empty && isExist(txtMobile.Text, txtContactPersonName.Text))
                {
                    General.ShowAlertMessage("This Contact detail is already in database");
                }
                else
                {
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
                    u.Custom5 = "3";//This field is used Type of Flow that it should go
                    u.PWD = Encryption.Encrypt("ab@345");
                    u.Session = General.GetCurrentSession;
                    u.ClientID = ClientID;
                    if (litAdminID.Text == string.Empty)
                    {
                        strUserID = new UserController().CreateUser(u);
                        General.ShowAlertMessage("Success!");
                    }
                    else
                    {
                        u.UserID = litAdminID.Text;
                        strUserID = new UserController().UpdateUser(u);
                        General.ShowAlertMessage("Success!");
                        litClientID.Text = string.Empty;
                    }


                }
                BindClients();
                txtOrganizationName.Text = string.Empty;
                txtContactPersonName.Text = string.Empty;
                txtMobile.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtState.Text = string.Empty;

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
        protected void btnClearClient_Click(object sender, EventArgs e)
        {

        }


        protected void gvClients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvClients.Rows[e.RowIndex];
            Label ID = (Label)row.FindControl("ClientID");
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ID", Convert.ToInt32(ID.Text));
            SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Client_Delete", m);

            BindClients();
        }



        protected void gvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditClient")
            {
                int ClientID = Convert.ToInt32(e.CommandArgument);
                if (ClientID > 0)
                {
                    SqlParameter[] m = new SqlParameter[1];
                    m[0] = new SqlParameter("@ID", ClientID);
                    SqlDataReader dr = SqlHelper.ExecuteReader(Connection.Connection_string, CommandType.StoredProcedure, "Client_Select", m);
                    while (dr.Read())
                    {
                        litClientID.Text = dr["ID"].ToString();
                        txtOrganizationName.Text = dr["OrganizationName"].ToString();
                        txtContactPersonName.Text = dr["ContactPersonName"].ToString();
                        txtMobile.Text = dr["MobileNo"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtAddress.Text = dr["Address"].ToString();
                        txtCity.Text = dr["City"].ToString();
                        txtState.Text = dr["State"].ToString();
                        m = new SqlParameter[2];
                        m[0] = new SqlParameter("@ClientID", ClientID);
                        m[1] = new SqlParameter("@Mobile", txtMobile.Text);

                        try
                        {
                            string userID = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "GetClientAdmin", m).ToString();
                            litAdminID.Text = userID;
                            string govId = "0";
                            
                            if (dr["GoverningId"].GetType() != typeof(DBNull))
                                govId = dr["GoverningId"].ToString();
                            //ddlGoverningBody.Items.FindByValue(govId).Selected=true;
                            ddlGoverningBody.SelectedValue = govId;
                            
                        }
                        catch (Exception ex)
                        {                          
                        }
                       
                    }
                    BindClients();
                }
            }
            if (e.CommandName == "Optin")
            {
                int ClientID = Convert.ToInt32(e.CommandArgument);
                if (ClientID > 0)
                {
                    SqlParameter[] m = new SqlParameter[2];
                    m[0] = new SqlParameter("@ClientID", ClientID);
                    m[1] = new SqlParameter("@Opt", "1");
                    int i = SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "UpdateFaceOptionForClient", m);
                   
                    BindClients();
                }
            }
            if (e.CommandName == "Optout")
            {
                int ClientID = Convert.ToInt32(e.CommandArgument);
                if (ClientID > 0)
                {
                    SqlParameter[] m = new SqlParameter[2];
                    m[0] = new SqlParameter("@ClientID", ClientID);
                    m[1] = new SqlParameter("@Opt", "0");
                    int i = SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "UpdateFaceOptionForClient", m);

                    BindClients();
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in gvClients.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("ChkItems");
                if (chk != null & chk.Checked)
                {
                    Label ID = (Label)gvrow.FindControl("ClientID");
                    SqlParameter[] m = new SqlParameter[1];
                    m[0] = new SqlParameter("@ID", Convert.ToInt32(ID.Text));
                    SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Client_Delete", m);
                }
            }
            BindClients();
        }

        protected void gvClients_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                Label lblOptedFaceID = e.Row.FindControl("lblOptedFaceID")as Label;
                if(lblOptedFaceID.Text=="1")
                {
                    Button btnOptFaceID = e.Row.FindControl("btnOptFaceID") as Button;
                    btnOptFaceID.Text = "Disable Face Bio";
                    btnOptFaceID.CommandName = "Optout";
                    btnOptFaceID.ToolTip = "Click here to Disable face biometric for attendance";
                }
            }
           

        }
    }
}