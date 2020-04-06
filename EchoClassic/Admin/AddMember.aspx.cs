using BusinessObjects;
using Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Admin
{
    public partial class AddMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GroupID = General.QueryStringInt("GroupID");
            if (!IsPostBack)
            {
                bindGvContacts();
                UserGroups ug = new UserController().GetUserGroup(GroupID);
                if (ug != null)
                {
                    litFlowType.Text = ug.FlowType.ToString();
                    litClientID.Text = ug.ClientID.ToString();
                    litGroupName.Text = ug.Group_Name + " (" + ug.Description + ")";
                }
                bindGvAdminsOfClient();
            }
        }
        public int GroupID
        {
            get;
            set;
        }
        private void bindGvContacts()
        {
            gvContactsFromXls.DataSource = null;
            gvContactsFromXls.DataBind();
            litBulkUploadResult.Text = string.Empty;
            IList<User> AdminList = new UserController().GetGroupAdmins(GroupID);
            IList<User> userList = new UserController().GetUserListGroup(GroupID);
            gvContacts.DataSource = userList.Where(ss => ss.UserID != Context.User.Identity.Name).OrderBy(dd => dd.Custom5);
            gvContacts.DataBind();
            if(gvContacts.Rows.Count==0)
            {
                btnDeleteSelected.Visible = false;
            }
        }
        private void bindGvAdminsOfClient()
        {
            IList<User> ClientAdminsList = new UserController().GetAllAdminsForAClient(Convert.ToInt32(litClientID.Text));
            gvAdmins.DataSource = ClientAdminsList.Where(ss => ss.UserID != Context.User.Identity.Name);
            gvAdmins.DataBind();
            if (gvAdmins.Rows.Count == 0)
            {
                btnMakeAdmin.Visible = false;
            }
        }
        protected void GvContacts_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblType = (Label)e.Row.FindControl("lblType");
                User u = e.Row.DataItem as User;
                if (!string.IsNullOrEmpty(u.Custom1))
                {
                    lblType.Text = u.Custom1;
                }
                else
                {
                    lblType.Text = "0";
                }
            }
        }
        protected void GvContacts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvContacts.EditIndex = e.NewEditIndex;
            bindGvContacts();

        }
        protected void GvContacts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //User objUser = new User();
            //  int userid = Convert.ToInt32(gvContacts.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)gvContacts.Rows[e.RowIndex];
            Label UserID = (Label)row.FindControl("UserID");
            TextBox RollNo = (TextBox)row.FindControl("txtRollNumber");
            TextBox txtUserName = (TextBox)row.FindControl("txtUserName");
            TextBox txtUserEmail = (TextBox)row.FindControl("txtUserEmail");
            TextBox txtUserMobile = (TextBox)row.FindControl("txtUserMobile");
            DropDownList UserType = (DropDownList)row.FindControl("ddType");
            TextBox doj = (TextBox)row.FindControl("txtDOJ");
            TextBox designation = (TextBox)row.FindControl("txtDesignation");
            gvContacts.EditIndex = -1;

            User u = new UserController().GetUser(UserID.Text);

            u.FirstName = txtUserName.Text;
            if (txtUserEmail.Text != string.Empty)
            {
                u.EMail = txtUserEmail.Text;
            }
            if (txtUserMobile.Text != string.Empty)
            {
                u.MobileNo = txtUserMobile.Text;
            }

            u.Custom2 = UserType.SelectedValue;
            u.Custom3 = doj.Text;
            u.Custom4 = designation.Text;
            if (u.Custom1 != RollNo.Text)
            {

                UserGroupMapping objUserGroupMapping = new UserController().GetUserGroupMapping(u.UserID).Where(ss => ss.UserGroupID == GroupID).FirstOrDefault();
                objUserGroupMapping.SerialNoForGroup = RollNo.Text;
                new UserController().DeleteUserGroupMapping(u.UserID, GroupID);
                new UserController().CreateUserGroupMapping(objUserGroupMapping);
            }
            u.Custom1 = RollNo.Text;
            if (u.FirstName != string.Empty)
            {
                new UserController().UpdateUser(u);
            }

            else
            { General.ShowAlertMessage("Please enter the Name!"); }


            bindGvContacts();
        }

        protected void GvContacts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvContacts.EditIndex = -1;
            bindGvContacts();
        }
        protected void GvContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvContacts.Rows[e.RowIndex];
            Label UserID = (Label)row.FindControl("UserID");
            new UserController().DeleteUserGroupMapping(UserID.Text, GroupID);
            bindGvContacts();
        }
        protected void ViewAllMembers(object sender, EventArgs e)
        {
            ErrorMessage.Text = string.Empty;
            bindGvContacts();

        }
        protected void Insert(object sender, EventArgs e)
        {
            try
            {
                User currentUser = new UserController().GetUser(Context.User.Identity.Name);
                if (txtNewUserName.Text == "")
                {
                    General.ShowAlertMessage("Name field is required!");
                }

                else
                {

                    if (isValidUser())
                    {
                        User u = new User();
                        string strUserID = string.Empty;
                        bool CreateMapping = true;
                        bool success = false;
                        bool isAdmin = Convert.ToBoolean(ddlIsAdmin.SelectedValue);
                        if (txtMobileNo.Text != string.Empty)
                        {
                            u = new UserController().GetUserbyMobile(txtMobileNo.Text.Trim());
                            if (u != null)
                            {
                                strUserID = u.UserID;
                                if (u.UserGroup.Select(ss => ss.UserGroupID).Contains(Convert.ToInt32(GroupID)))
                                {
                                    CreateMapping = false;

                                }
                            }
                        }
                        if (txtEmailID.Text != string.Empty)
                        {
                            u = new UserController().GetUserbyEmail(txtEmailID.Text.Trim());
                            if (u != null)
                            {
                                strUserID = u.UserID;
                                if (u.UserGroup.Select(ss => ss.UserGroupID).Contains(Convert.ToInt32(GroupID)))
                                {
                                    CreateMapping = false;

                                }
                            }
                        }

                        if (u == null)
                        {
                            u = new BusinessObjects.User();
                            string CouponCode = string.Empty;
                            u.FirstName = txtNewUserName.Text;
                            u.EMail = txtEmailID.Text;
                            u.MobileNo = txtMobileNo.Text;
                            u.CreateDate = DateTime.Now;
                            u.DOB = Convert.ToDateTime("1/1/1900");
                            u.LastLockoutDate = DateTime.Now;
                            u.LastLoginDate = DateTime.Now;
                            u.LastPasswordChangedDate = DateTime.Now;
                            u.CouponCode = CouponCode;
                            u.IsDeleted = false;
                            u.IsLockedOut = false;
                            u.PWD = Encryption.Encrypt("ab@345");
                            //if (litFlowType.Text == "1" && !isAdmin)
                            //{
                            //    u.IsLockedOut = true;
                            //    u.PWD = string.Empty;
                            //}
                            u.RoleID = 4;
                            u.Custom1 = txtRollNo.Text;
                            u.Custom2 = rdGender.SelectedValue;
                            u.Custom3 = txtDOJ.Text;
                            u.Custom4 = txtDesignation.Text;
                            u.Custom5 = "1";//This field is used Type of Flow that it should go

                            u.Session = General.GetCurrentSession;
                            u.ClientID =Convert.ToInt32(litClientID.Text);
                            strUserID = new UserController().CreateUser(u);

                        }




                        if (CreateMapping)
                        {
                            UserGroupMapping objUserGroupMapping = new UserGroupMapping();
                            objUserGroupMapping.UserGroupID = GroupID;
                            objUserGroupMapping.UserID = strUserID;
                            objUserGroupMapping.isAdmin = Convert.ToBoolean(ddlIsAdmin.SelectedValue);
                            objUserGroupMapping.SerialNoForGroup = txtRollNo.Text;
                            string strMsg = new UserController().CreateUserGroupMapping(objUserGroupMapping);
                            success = true;
                        }

                        if (success == true)
                        {
                            General.ShowAlertMessage("Success");
                            this.bindGvContacts();
                            txtNewUserName.Text = string.Empty; ;
                            txtEmailID.Text = string.Empty;
                            txtMobileNo.Text = string.Empty;
                            ErrorMessage.Text = "The temporary password for the user is ab@345";
                        }
                        else
                        {
                            ErrorMessage.Text = "This User already exists!";
                        }

                    }

                    else
                    {
                        General.ShowAlertMessage("Invalid User! Please verify the data and try again");
                    }
                }
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = ex.Message;
            }
        }
        private bool isValidUser()
        {
            bool isValid = true;
            bool isAdmin = Convert.ToBoolean(ddlIsAdmin.SelectedValue);
            if (isAdmin && txtMobileNo.Text == string.Empty)
            {
                isValid = false;
            }
            else if (isAdmin && txtMobileNo.Text.Length < 10)
            {
                isValid = false;
            }
            else if (txtNewUserName.Text == string.Empty && !isAdmin)
            {
                isValid = false;
            }
            return isValid;
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

        protected void UploadContacts(object sender, EventArgs e)
        {
            if (fuContacts.HasFile)
            {
                if (fuContacts.FileName.EndsWith(".xls") || fuContacts.FileName.EndsWith(".xlsx"))
                {
                    fuContacts.PostedFile.SaveAs(Server.MapPath("~/ContactsUpload/" + GroupID + fuContacts.PostedFile.FileName));
                    string ContactsFile = Server.MapPath("~/ContactsUpload/" + GroupID + fuContacts.PostedFile.FileName);
                    var ConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties =Excel 12.0;", ContactsFile);
                    var adapter = new OleDbDataAdapter("select * from [Contacts$]", ConnectionString);
                    var ds = new DataSet();
                    adapter.Fill(ds, "Contacts");
                    DataTable contacts = ds.Tables["Contacts"];
                    DataColumn dc = new DataColumn("Status", typeof(string));
                    contacts.Columns.Add(dc);
                    gvContactsFromXls.DataSource = contacts;
                    gvContactsFromXls.DataBind();
                    gvContacts.DataSource = null;
                    gvContacts.DataBind();
                    adapter.Dispose();
                    int AdminCount = 0;
                    string duplicates = string.Empty;
                    foreach (GridViewRow row in gvContactsFromXls.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            if (IsValidRow(row))
                            {
                                User u = null;
                                //if (litFlowType.Text != "1" || row.Cells[7].Text.ToLower() == "yes")
                                //{
                                if (row.Cells[5].Text != string.Empty && row.Cells[5].Text != "&nbsp;")
                                {
                                    u = new UserController().GetUserbyEmail(row.Cells[5].Text.Trim());
                                }
                                if (u == null && row.Cells[4].Text != string.Empty && row.Cells[4].Text != "&nbsp;")
                                {
                                    u = new UserController().GetUserbyMobile(row.Cells[4].Text.Trim());
                                }
                                //}
                                //else
                                //{
                                //    if (u == null && row.Cells[1].Text != string.Empty && row.Cells[1].Text != "&nbsp;")
                                //    {
                                //        u = new UserController().GetUser_byNameAndMobile(row.Cells[4].Text.Trim(), row.Cells[1].Text.Trim());
                                //    }
                                //}

                                string strUserID = string.Empty;
                                //User u = null;
                                string couponCode = string.Empty;

                                //this is for the case of siblings in same class with same number
                                //bool createNewUser = false;
                                //if (u != null)
                                //{
                                //    if (u.FirstName!= row.Cells[1].Text)
                                //    {
                                //        createNewUser = true;
                                //    }
                                //}
                                if (u == null)
                                {
                                    User objUser = new User
                                    {
                                        CouponCode = couponCode,
                                        CreatedBy = Context.User.Identity.Name,
                                        CreateDate = DateTime.Now,
                                        DOB = Convert.ToDateTime("1/1/1900"),
                                        EMail = (row.Cells[5].Text == "&nbsp;") ? string.Empty : row.Cells[5].Text,
                                        //row.Cells[1].Text?="": row.Cells[1].Text ,
                                        FirstName = row.Cells[1].Text,
                                        IsDeleted = false,
                                        IsLockedOut = false,

                                        LastLockoutDate = DateTime.Now,
                                        LastLoginDate = DateTime.Now,
                                        LastName = string.Empty,
                                        LastPasswordChangedDate = DateTime.Now,
                                        MobileNo = row.Cells[4].Text,
                                        PWD = string.Empty,
                                        RoleID = 4,
                                        // UserGroup= listGroup,// for Normal user
                                        ImageID = string.Empty,
                                        Custom1 = row.Cells[0].Text.Replace("&nbsp;", string.Empty),//used for Roll Number
                                        Custom2 = row.Cells[6].Text.Replace("&nbsp;", string.Empty),//used for User Type(Gender or Teacher)
                                        Custom3 = row.Cells[3].Text.Replace("&nbsp;", string.Empty),//used for date of joining
                                        Custom4 = row.Cells[2].Text.Replace("&nbsp;", string.Empty),//used for Designation
                                        Custom5 = "1",
                                        Session = General.GetCurrentSession,
                                        ClientID = Convert.ToInt32(litClientID.Text)
                                    };

                                    objUser.PWD = Encryption.Encrypt("ab@345");

                                    strUserID = new UserController().CreateUser(objUser);
                                }
                                else
                                {
                                    strUserID = u.UserID;
                                }
                                bool isAdmin = false;

                                UserGroupMapping objUserGroupMapping = new UserGroupMapping();
                                objUserGroupMapping.UserGroupID = GroupID;
                                objUserGroupMapping.UserID = strUserID;
                                objUserGroupMapping.isAdmin = isAdmin;
                                objUserGroupMapping.SerialNoForGroup = row.Cells[0].Text.Replace("&nbsp;", string.Empty);//will be used as serial number for that group;
                                IList<UserGroupMapping> mlist = new UserController().GetUserGroupMapping(strUserID);

                                mlist = mlist.Where(ss => ss.UserGroupID == GroupID).ToList();
                                if (row.Cells[7].Text.ToLower() == "yes" && AdminCount <= 5)
                                {
                                    isAdmin = true;
                                    AdminCount++;
                                }
                                if (mlist.Count < 1)
                                {
                                    objUserGroupMapping.isAdmin = isAdmin;
                                    string strMsg = new UserController().CreateUserGroupMapping(objUserGroupMapping);
                                    row.Cells[8].Text = "Imported";
                                    row.Cells[8].BackColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    duplicates = u.MobileNo + ", " + duplicates;
                                    row.Cells[8].Text = "Duplicate";
                                    row.Cells[8].BackColor = System.Drawing.Color.Yellow;
                                }

                            }
                            else
                            {
                                row.Cells[8].Text = "Invalid record";
                                row.Cells[8].BackColor = System.Drawing.Color.Red;
                            }

                        }
                    }
                    gvContacts.DataSource = null;
                    gvContacts.DataBind();
                    if (duplicates != string.Empty)
                    {
                        General.ShowAlertMessage("Import completed! Users with MobileNo " + duplicates + " Could not be import because they are duplicate mobile numbers");
                    }
                    litBulkUploadResult.Text = "<h3>Bulk upload results</h3>";
                    ErrorMessage.Text = "Import completed! Users with MobileNo " + duplicates + " Could not be import because they are duplicate mobile numbers.<br/> The temporary password for the members are ab@345";
                }
                else { ErrorMessage.Text = "Invalid Contact file please upload a valid file!"; }
            }
        }
        private bool IsValidRow(GridViewRow row)
        {
            bool result = true;

            if (row.Cells[0].Text != string.Empty && row.Cells[0].Text != "&nbsp;")
            {
                if (!General.IsNumber(row.Cells[0].Text))
                {
                    result = false;
                }

            }
            else if (row.Cells[1].Text == string.Empty && row.Cells[1].Text == "&nbsp;")
            {
                result = false;
            }

            if (row.Cells[3].Text != string.Empty && row.Cells[3].Text != "&nbsp;")
            {
                try
                {
                    Convert.ToDateTime(row.Cells[3].Text);
                }
                catch
                {
                    result = false;
                }

            }

            if (row.Cells[4].Text != string.Empty && row.Cells[4].Text != "&nbsp;")
            {
                if (!General.IsNumber(row.Cells[4].Text))
                {
                    if (row.Cells[4].Text.Length < 10 || row.Cells[4].Text.Length > 11)
                    {
                        result = false;
                    }
                }
            }
            if (row.Cells[5].Text != string.Empty && row.Cells[5].Text != "&nbsp;")
            {
                if (!General.ValidEmail(row.Cells[5].Text))
                {
                    result = false;
                }
            }
            if (row.Cells[6].Text != string.Empty && row.Cells[6].Text != "&nbsp;")
            {
                if (row.Cells[6].Text.ToLower() != "male" && row.Cells[6].Text.ToLower() != "female")
                {
                    result = false;
                }
            }
            if (row.Cells[7].Text != string.Empty && row.Cells[7].Text != "&nbsp;")
            {
                if (row.Cells[7].Text.ToLower() != "yes" && row.Cells[7].Text.ToLower() != "no")
                {
                    result = false;
                }
            }
            return result;
        }
        protected void rdManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdManual.Checked)
            {
                pnlManualEntry.Visible = true;
                pnlBulkUpload.Visible = false;
            }

        }
        protected void BulkUpload_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBulkUpload.Checked)
            {
                pnlManualEntry.Visible = false;
                pnlBulkUpload.Visible = true;
            }

        }

        protected void MakeAdmin(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                foreach (GridViewRow AdminRow in gvAdmins.Rows)
                {
                    CheckBox isAdminchk = AdminRow.FindControl("chkAdmin") as CheckBox;
                    if (isAdminchk.Checked)
                    {
                        Label AdminUserID = AdminRow.FindControl("UserID") as Label;
                        Label lblRollNo = AdminRow.FindControl("lblRollNo") as Label;

                        UserGroupMapping objUserGroupMapping = new UserGroupMapping();
                        objUserGroupMapping.UserGroupID = GroupID;
                        objUserGroupMapping.UserID = AdminUserID.Text;
                        objUserGroupMapping.isAdmin = true;
                        objUserGroupMapping.SerialNoForGroup = lblRollNo.Text;
                        new UserController().DeleteUserGroupMapping(AdminUserID.Text, GroupID);

                        string strMsg = new UserController().CreateUserGroupMapping(objUserGroupMapping);
                        success = true;

                    }
                }
                if (success == true)
                {
                    General.ShowAlertMessage("Admin Mapped successfully!");
                    bindGvContacts();
                }

            }
            catch (Exception ex)
            {

                ErrorMessage.Text = ex.Message;
            }
        }
        protected void DeleteMember(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                foreach (GridViewRow grow in gvContacts.Rows)
                {
                    CheckBox chkdel = (CheckBox)grow.FindControl("chkDel");
                    if (chkdel.Checked)
                    {
                        Label lbl = (Label)grow.FindControl("UserID");
                        new UserController().DeleteUserGroupMapping(lbl.Text, GroupID);

                        success = true;

                    }
                }
                if (success == true)
                {
                    General.ShowAlertMessage("Success");
                    bindGvContacts();
                }

            }
            catch (Exception ex)
            {

                ErrorMessage.Text = ex.Message;
            }
        }

        protected void gvAdmins_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvContacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Find the checkbox control in header and add an attribute
                ((CheckBox)e.Row.FindControl("chkSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" +
                        ((CheckBox)e.Row.FindControl("chkSelectAll")).ClientID + "')");
            }
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                User u = e.Row.DataItem as User;
                Label lblDOJ = e.Row.FindControl("lblDOJ") as Label;
                try
                {
                    lblDOJ.Text = Convert.ToDateTime(u.Custom3).ToShortDateString();
                }
                catch 
                {
                }
            }
        }
        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                foreach (GridViewRow grow in gvContacts.Rows)
                {
                    CheckBox chkdel = (CheckBox)grow.FindControl("chkDel");
                    if (chkdel.Checked)
                    {
                        Label lbl = (Label)grow.FindControl("UserID");
                        new UserController().DeleteUserGroupMapping(lbl.Text, GroupID);

                        success = true;

                    }
                }
                if (success == true)
                {
                    General.ShowAlertMessage("Success");
                    bindGvContacts();
                }
                else
                {
                    General.ShowAlertMessage("Please select at least one member!");
                }

            }
            catch (Exception ex)
            {

                ErrorMessage.Text = ex.Message;
            }
        }
    }
}