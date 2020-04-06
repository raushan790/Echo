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
    public partial class AddGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                User u = new UserController().GetUser(Context.User.Identity.Name);
                int cv = ClientIDValue;
                if (ClientIDValue == 0)
                    cv = u.ClientID;
                litClientID.Text = u.ClientID.ToString();
                if (u.RoleID != 2 || cv != u.ClientID)
                {
                    if (u.EMail == "admin@echocommunicator.com")
                    { litClientID.Text = cv.ToString(); }
                    else
                    {
                        General.ShowAlertMessage("You are not authorized for this action", "../logout");
                    }

                }


            }
            else
            {
                General.ShowAlertMessage("You are not authorized for this action", "../logout");
            }
            if (!IsPostBack)
            {
                //if (ClientIDValue > 0 && litClientID.Text != string.Empty)
                //{
                //    BindGroups();
                //}
                //litClientID.Text = ClientIDValue.ToString();
                BindGroups();
                // GenerateCoupon();
                // BindGroupAndRole();
            }
        }
        private void BindGroups()
        {
            int cv = Convert.ToInt32(litClientID.Text);
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ClientID", cv);
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "UserGroups_SelectByClient", m);
            gvGroups.DataSource = ds;
            gvGroups.DataBind();
        }
        protected void btnSaveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int cv = Convert.ToInt32(litClientID.Text);
                if (pnlGeoLocation.Visible == true && txtGeoLocation.Text == string.Empty)
                {
                    General.ShowAlertMessage("Please enter geo location details");
                    txtGeoLocation.Focus();
                }
                else if (pnlWifiID.Visible == true && txtWifiID.Text == string.Empty)
                {
                    General.ShowAlertMessage("Please enter WIFI MAC ID");
                    txtWifiID.Focus();
                }
                else
                {
                    BusinessObjects.UserGroups cl = new BusinessObjects.UserGroups();
                    cl.Group_Name = txtGroupName.Text;
                    cl.Description = txtDescription.Text;
                    cl.ClientID = cv;
                    cl.Owner = Context.User.Identity.Name;
                    cl.FlowType = Convert.ToInt32(ddlFlowType.SelectedValue);
                    cl.AttendanceOption = Convert.ToInt32(ddlSelfAttendanceOption.SelectedValue);
                    cl.AttendanceOptionValue = string.Empty;
                    cl.Department = txtDepartment.Text;
                    cl.SubDepartment=txtSubDepartment.Text;
                    cl.StartTime=TxtStartTime.Text;
                    cl.EndTime=txtEndTime.Text;
                    cl.GraceTime = Convert.ToInt32(txtGraceTime.Text);
                    cl.NoOfClasses = txtNoOfClasses.Text;

                    if (pnlGeoLocation.Visible == true)
                    {
                        cl.AttendanceOptionValue = txtGeoLocation.Text;
                    }
                    if (pnlWifiID.Visible == true)
                    {
                        cl.AttendanceOptionValue = txtWifiID.Text;
                    }
                    cl.CreateDate = DateTime.UtcNow.AddHours(5.5);
                    cl.Image = string.Empty;
                    cl.IsActive = true;
                    cl.IsDeleted = false;
                    cl.IsRole = false;


                    cl.ModifiedDate = DateTime.UtcNow.AddHours(5.5);


                    if (litGroupID.Text == string.Empty)
                    {
                        int GroupID = Convert.ToInt32(new UserController().CreateUserGroup(cl));
                        string userID = string.Empty;
                        SqlParameter[] m = new SqlParameter[1];
                        m[0] = new SqlParameter("@ID", cv);
                        SqlDataReader dr = SqlHelper.ExecuteReader(Connection.Connection_string, CommandType.StoredProcedure, "Client_Select", m);
                        while (dr.Read())
                        {
                            m = new SqlParameter[2];
                            m[0] = new SqlParameter("@ClientID", cv);
                            m[1] = new SqlParameter("@Mobile", dr["MobileNo"].ToString());
                            try
                            {
                                userID = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "GetClientAdmin", m).ToString();
                            }
                            catch
                            {
                            }

                        }
                        if (userID != string.Empty)
                        {
                            UserGroupMapping objUserGroupMapping = new UserGroupMapping();
                            objUserGroupMapping.UserGroupID = GroupID;
                            objUserGroupMapping.UserID = userID;
                            objUserGroupMapping.isAdmin = true;
                            objUserGroupMapping.SerialNoForGroup = "0";
                            string strMsg = new UserController().CreateUserGroupMapping(objUserGroupMapping);
                        }
                        General.ShowAlertMessage("Group added successfully!");
                    }
                    else
                    {
                        cl.UserGroupID = Convert.ToInt32(litGroupID.Text);
                        new UserController().UpdateUserGroup(cl);
                        string userID = string.Empty;
                        SqlParameter[] m = new SqlParameter[1];
                        m[0] = new SqlParameter("@ID", cv);
                        SqlDataReader dr = SqlHelper.ExecuteReader(Connection.Connection_string, CommandType.StoredProcedure, "Client_Select", m);
                        while (dr.Read())
                        {
                            m = new SqlParameter[2];
                            m[0] = new SqlParameter("@ClientID", cv);
                            m[1] = new SqlParameter("@Mobile", dr["MobileNo"].ToString());
                            try
                            {
                                userID = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "GetClientAdmin", m).ToString();
                            }
                            catch
                            {
                            }

                        }
                        if (userID != string.Empty)
                        {
                            UserGroupMapping objUserGroupMapping = new UserGroupMapping();
                            objUserGroupMapping.UserGroupID = cl.UserGroupID;
                            objUserGroupMapping.UserID = userID;
                            objUserGroupMapping.isAdmin = true;
                            objUserGroupMapping.SerialNoForGroup = "0";
                            new UserController().DeleteUserGroupMapping(userID, cl.UserGroupID);
                            string strMsg = new UserController().CreateUserGroupMapping(objUserGroupMapping);
                        }

                        General.ShowAlertMessage("Group updated successfully!");

                    }

                    BindGroups();
                    txtGroupName.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    litGroupID.Text = string.Empty;
                    ddlFlowType.Enabled = true;
                    ddlSelfAttendanceOption.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                General.ShowAlertMessage("Please validate the details and try again.");
            }

        }

        public int ClientIDValue
        {
            get { return General.QueryStringInt("ClientID"); }

        }
        protected void btnClearClient_Click(object sender, EventArgs e)
        {

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

        protected void gvGroups_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvGroups.Rows[e.RowIndex];
            Label ID = (Label)row.FindControl("lblGroupID");
            new UserController().DeleteUserGroup(Convert.ToInt32(ID.Text));

            BindGroups();
        }



        protected void gvGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditGroup")
            {
                int GroupID = Convert.ToInt32(e.CommandArgument);
                if (GroupID > 0)
                {
                    UserGroups cl = new UserController().GetUserGroup(GroupID);
                    litGroupID.Text = e.CommandArgument.ToString();
                    txtGroupName.Text = cl.Group_Name;
                    txtDescription.Text = cl.Description;
                    ddlFlowType.SelectedValue = cl.FlowType.ToString();
                    if (ddlFlowType.SelectedValue == "3"||ddlFlowType.SelectedValue == "4")
                    {
                        pnlSelfAttendanceOption.Visible = true;
                        try
                        {
                            ddlSelfAttendanceOption.SelectedValue = cl.AttendanceOption.ToString();
                        }
                        catch
                        {
                        }

                        if (ddlSelfAttendanceOption.SelectedValue == "2")
                        {
                            pnlGeoLocation.Visible = true;
                            pnlWifiID.Visible = false;
                            txtWifiID.Text = string.Empty;
                        }
                        if (ddlSelfAttendanceOption.SelectedValue == "3")
                        {
                            pnlGeoLocation.Visible = false;
                            pnlWifiID.Visible = true;
                            txtGeoLocation.Text = string.Empty;
                        }

                        try
                        {
                            if (pnlGeoLocation.Visible == true)
                            {
                                txtGeoLocation.Text = cl.AttendanceOptionValue;
                            }
                            if (pnlWifiID.Visible == true)
                            {
                                txtWifiID.Text = cl.AttendanceOptionValue;
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        pnlSelfAttendanceOption.Visible = false;
                        pnlGeoLocation.Visible = false;
                        pnlWifiID.Visible = false;
                        txtGeoLocation.Text = string.Empty;
                        txtWifiID.Text = string.Empty;
                    }
                   
                    ddlFlowType.Enabled = false;
                    ddlSelfAttendanceOption.Enabled = false;
                    BindGroups();
                }
            }
        }

        protected void ddlFlowType_change(object sender, EventArgs e)
        {
            if (ddlFlowType.SelectedValue == "3"|| ddlFlowType.SelectedValue == "4")
            {
                pnlSelfAttendanceOption.Visible = true;
                ddlSelfAttendanceOption.SelectedValue = "2";
                pnlGeoLocation.Visible = true;
                pnlWifiID.Visible = false;
                txtWifiID.Text = string.Empty;
            }
            else
            {
                pnlSelfAttendanceOption.Visible = false;
                ddlSelfAttendanceOption.SelectedValue = "2";
                pnlGeoLocation.Visible = false;
                pnlWifiID.Visible = false;
                txtGeoLocation.Text = string.Empty;
                txtWifiID.Text = string.Empty;
            }
        }

        protected void ddlSelfAttendanceOption_change(object sender, EventArgs e)
        {
            if (ddlSelfAttendanceOption.SelectedValue == "2")
            {
                pnlGeoLocation.Visible = true;
                pnlWifiID.Visible = false;
                txtWifiID.Text = string.Empty;
            }
            if (ddlSelfAttendanceOption.SelectedValue == "3")
            {
                pnlGeoLocation.Visible = false;
                pnlWifiID.Visible = true;
                txtGeoLocation.Text = string.Empty;
            }
        }
    }
}