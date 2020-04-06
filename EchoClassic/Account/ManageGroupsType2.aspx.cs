using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using Controllers;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections.Specialized;


namespace EchoClassic.Account
{
    public partial class ManageGroupsType2 : System.Web.UI.Page
    {
        // private static DateTime? button1ClickAt = null;
        private bool isAdmin = false;
        //private User u = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            GroupID = General.QueryStringInt("GroupID");
            if (!Context.User.Identity.IsAuthenticated || Context.User.Identity.Name == string.Empty)
                Response.Redirect("~/default?echotgt=" + Request.RawUrl);
            if (!IsPostBack)
            {

                if (GroupID > 0)
                {

                    User u = new UserController().GetUser(Context.User.Identity.Name);
                    string type = u.UserGroup.Where(ss => ss.UserGroupID == GroupID).FirstOrDefault().FlowType.ToString();

                    if (type != "2")
                    {
                        General.ShowAlertMessage("You are not authorized!", "~/logout.aspx");
                    }
                    UserGroups grp = new UserController().GetUserGroup(GroupID);
                    UserGroups userGroup = u.UserGroup.Where(ss => ss.UserGroupID == GroupID).FirstOrDefault();
                    isAdmin = userGroup.isAdmin;
                    if (userGroup.isAdmin == false)
                    {
                        Response.Redirect("~/account/selfattendance/?GroupID=" + GroupID);
                    }
                    txtName.Text = grp.Group_Name;

                    txtDesc.Text = grp.Description;

                    gvContactsFromXls.DataSource = null;
                    gvContactsFromXls.DataBind();
                    bindGvContacts();
                    //attendance code process
                    new AttendanceController().DeleteAttendanceCode(GroupID, DateTime.UtcNow.AddHours(5.5).Date);
                    int Code = General.GetCodeForAttendance();

                    AttendanceCode attendanceCode = new AttendanceCode();
                    attendanceCode.AttendanceDate = DateTime.UtcNow.AddHours(5.5).Date;
                    attendanceCode.GroupID = GroupID;
                    attendanceCode.Code = Code;
                    attendanceCode.CreateDate = DateTime.UtcNow.AddHours(5.5);
                    try
                    {
                        new AttendanceController().CreateAttendanceCode(attendanceCode);
                        litAttendanceCode.Text = Code.ToString();
                        litTimer.Text = "0";
                        AttendanceTimer.Enabled = true;



                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    //End Attendance Code Process


                    // bindGvAttendaneByDate();

                    if (isAdmin == false)
                    {
                        pnlForm.Enabled = false;
                        btnCreateGroup.Visible = false;
                        btnDeleteRecord.Visible = false;
                        fuContacts.Enabled = false;
                        fuImage.Enabled = false;
                        //divFormSection.e.Attributes.Add("Disabled", "");// = true;
                    }
                    else
                    {
                        btnDelete.Visible = true;
                    }
                }

            }
        }
        protected void TimerTick(object sender, EventArgs e)
        {
            if (litTimer.Text != "30")
            {
                litTimer.Text = (Convert.ToInt32(litTimer.Text) + 1).ToString();
            }
            else
            {
                AttendanceTimer.Enabled = false;
                litAttendanceCode.Text = string.Empty;
                new AttendanceController().DeleteAttendanceCode(GroupID, DateTime.UtcNow.AddHours(5.5).Date);
                litTimer.Text = string.Empty;
                bindGvContacts();
            }

        }
        private void bindGvContacts()
        {
            User u = new UserController().GetUser(Context.User.Identity.Name);

            IList<User> AdminList = new UserController().GetGroupAdmins(GroupID);
            IList<User> userList = new UserController().GetUserListGroup(GroupID);
            //gvContacts.DataSource = userList.Where(ss => ss.UserID != Context.User.Identity.Name);
            //gvContacts.DataBind();

            btnSendAttendanceMail.Visible = false;
            if (userList.Count > 0)
            {
               // btnDeleteRecord.Visible = true;
                btnSendAttendanceMail.Visible = true;
            }
            IList<MemberAttendance> chkAtt = new AttendanceController().GetMemberAttendances(GroupID, DateTime.UtcNow.AddHours(5.5).Date);
            if (chkAtt.Where(ss => ss.UDF1 == "1").ToList().Count > 0|| chkAtt.Where(ss => ss.UDF1 == "0").ToList().Count > 0)
            {
                litAtt.Text = "1";
            }
            if (chkAtt.Where(ss => ss.UDF1 == "2").ToList().Count > 0)
            {
                litAtt.Text = "2";
            }

            if (userList.Count < 300 && isAdmin == true && litAtt.Text != "2")
            {
                var Students = userList.Where(o => !AdminList.Any(n => n.UserID == o.UserID)).ToList();


                gvAttendance.DataSource = Students;// userList.Where(ss => ss.UserID != Context.User.Identity.Name);//.Where(ss => ss.IsLockedOut == false);
                gvAttendance.DataBind();
                gvAttendance.Visible = true;
                btnSendAttendanceMail.Visible = true;
                if (userList.Count > 10)
                {
                    pnlAttendance.Height = Unit.Pixel(510);
                    pnlAttendance.ScrollBars = ScrollBars.Vertical;
                }
            }
            //Insert default attendance as false
            //int chkAtt = new AttendanceController().CheckMemberAttendance(GroupID, DateTime.Now.Date);

            if (litAtt.Text == string.Empty)
            {

                foreach (GridViewRow grow in gvAttendance.Rows)
                {
                    CheckBox rbPresent = (CheckBox)grow.FindControl("rbPresent");
                    CheckBox rbAbsent = (CheckBox)grow.FindControl("rbAbsent");
                    Label lblName = (Label)grow.FindControl("lblName");

                    Label lblUserId = (Label)grow.FindControl("UserID");
                    string Chkattend = string.Empty;
                    string ChkattendForEmail = string.Empty;

                    Chkattend = "Absent";

                    MemberAttendance objMat = new MemberAttendance();
                    objMat.UserID = lblUserId.Text;
                    objMat.GroupID = GroupID;
                    objMat.AttendanceStatus = Chkattend;
                    objMat.UDF2 = lblName.Text;
                    objMat.UDF3 = u.FirstName;
                    objMat.AttendanceDate = DateTime.UtcNow.AddHours(5.5).Date;
                    objMat.CreateDate = DateTime.UtcNow.AddHours(5.5);
                    objMat.AttendanceTime = DateTime.UtcNow.AddHours(5.5).ToShortTimeString();
                    objMat.Device = "Web";
                    objMat.Session = General.GetCurrentSession;
                    objMat.DeviceLocation = txtLatLong.Text;
                    objMat.DeviceIDOrName = string.Empty;
                    try
                    {
                        objMat.DeviceIDOrName = Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName;
                        objMat.DeviceLocation = Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName;

                    }
                    catch
                    {  
                    }
                     if (litAtt.Text == string.Empty)
                    {
                        objMat.UDF1 = "0";
                    }
                    if (litAtt.Text == "1")
                    {
                        objMat.UDF1 = "2";
                    }
                    objMat.ClientID = u.ClientID;
                    new AttendanceController().CreateMemberAttendance(objMat);

                }
            }
            else if (litAtt.Text == "1")
            {
                IList<MemberAttendance> PresentList = chkAtt.Where(ss => ss.AttendanceStatus == "Present").ToList();

                foreach (GridViewRow grow in gvAttendance.Rows)
                {
                    CheckBox rbPresent = (CheckBox)grow.FindControl("rbPresent");
                    CheckBox rbAbsent = (CheckBox)grow.FindControl("rbAbsent");

                    Label lblUserId = (Label)grow.FindControl("UserID");
                    MemberAttendance a = PresentList.Where(ss => ss.UserID == lblUserId.Text).FirstOrDefault();
                    if (a != null)
                    {
                        if (a.AttendanceStatus == "Present")
                        {
                            rbPresent.Checked = true;
                            rbAbsent.Checked = false;
                        }
                        
                    }
                }
            }
            else
            {
                lblError.Text = "Not valid!";
                gvAttendance.Visible = false;
                btnSendAttendanceMail.Visible = false;
            }
        }
        protected void GvContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvContacts.Rows[e.RowIndex];
            Label UserID = (Label)row.FindControl("UserID");
            new UserController().DeleteUserGroupMapping(UserID.Text, GroupID);
            bindGvContacts();
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
            DropDownList Cast = (DropDownList)row.FindControl("ddlCast");
            DropDownList Handicap = (DropDownList)row.FindControl("ddlHandicap");

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
            u.Custom1 = RollNo.Text;
            u.Custom2 = UserType.SelectedValue;
            u.Custom3 = Cast.SelectedValue;
            u.Custom4 = Handicap.SelectedValue;
            if (u.FirstName != string.Empty)
            {
                new UserController().UpdateUser(u);
            }
            else
            { General.ShowAlertMessage("Please enter the Name!"); }

            bindGvContacts();
        }
        protected void Insert(object sender, EventArgs e)
        {
            //string input = Encryption.Decrypt("nJfH QEbkgjs3f1 M956og==");
            //string encryptedCouponCode = Encryption.Encrypt(input);
            //if (encryptedCouponCode.Substring(encryptedCouponCode.Length - 2, 2) == "==")
            //{
            //    encryptedCouponCode = encryptedCouponCode + "echo";
            //}
            //encryptedCouponCode = encryptedCouponCode.Replace("+", "plus");
            //encryptedCouponCode = encryptedCouponCode.Replace(" ", "%20");
            //General.SendSMS("9953624768", "Register using the following link: http://echocommunicator.com/account/register?cc=" + encryptedCouponCode);
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
                        if (txtMobileNo.Text != string.Empty && isExist(txtMobileNo.Text, txtNewUserName.Text))
                        {
                            u = new UserController().GetUser_byNameAndMobile(txtMobileNo.Text.Trim(), txtNewUserName.Text.Trim());
                            strUserID = u.UserID;
                            if (u.UserGroup.Select(ss => ss.UserGroupID).Contains(Convert.ToInt32(GroupID)))
                            {
                                CreateMapping = false;

                            }
                        }
                        else
                        {
                            string CouponCode = GenerateCoupon();
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
                            u.RoleID = 4;
                            u.Custom1 = txtRollNo.Text;
                            u.Custom2 = ddlType.Text;
                            u.Custom3 = ddlCast.Text;
                            u.Custom4 = ddlHandicap.Text;
                            u.Custom5 = "2";             //This field is used Type of Flow that it should go
                            u.PWD = Encryption.Encrypt("ab@345");             
                            u.Session = General.GetCurrentSession;
                            u.ClientID = currentUser.ClientID;
                            strUserID = new UserController().CreateUser(u);

                        }


                        if (CreateMapping)
                        {
                            UserGroupMapping objUserGroupMapping = new UserGroupMapping();
                            objUserGroupMapping.UserGroupID = GroupID;
                            objUserGroupMapping.UserID = strUserID;
                            objUserGroupMapping.isAdmin = chkIsAdmin.Checked;
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
                        }
                        else
                        {
                            ErrorMessage.Text = "Something is not right Please try again!";
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
            if (chkIsAdmin.Checked && txtMobileNo.Text == string.Empty)
            {
                isValid = false;
            }
            else if (chkIsAdmin.Checked && txtMobileNo.Text.Length < 10)
            {
                isValid = false;
            }
            else if (txtNewUserName.Text == string.Empty && !chkIsAdmin.Checked)
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
        protected void GvContacts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvContacts.EditIndex = -1;
            bindGvContacts();
        }
        private bool removeGroupAdminsFromList(User u)
        {
            UserGroups userGroup = u.UserGroup.Where(ss => ss.UserGroupID == GroupID).FirstOrDefault();
            return userGroup.isAdmin;
        }

        protected void CreateGroup_Click(object sender, EventArgs e)
        {
            // General.SendSMS("9953624768", "this is test from ECHO");
            try
            {
                // General.SendSMS("9953624768", "this is test from ECHO");
                User currentUser = new UserController().GetUser(Context.User.Identity.Name);
                string img = string.Empty;
                if (fuImage.HasFile)
                {

                    string filename = Guid.NewGuid().ToString();
                    string extn = Path.GetExtension(fuImage.PostedFile.FileName);
                    fuImage.PostedFile.SaveAs(Server.MapPath("~/images/GroupImages/" + filename + extn));
                    img = filename + extn;
                }


                // string groupID = string.Empty;
                UserGroups group = new UserGroups
                {

                    Group_Name = txtName.Text,
                    Description = txtDesc.Text,
                    Image = img,
                    Owner = Context.User.Identity.Name,
                    IsRole = false,
                    IsDeleted = false,
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now

                };
                if (GroupID == 0)
                {
                    GroupID = Convert.ToInt32(new UserController().CreateUserGroup(group));
                    UserGroupMapping objUserGroupMapping = new UserGroupMapping();
                    objUserGroupMapping.UserGroupID = GroupID;
                    objUserGroupMapping.UserID = Context.User.Identity.Name;
                    objUserGroupMapping.isAdmin = true;
                    string strMsg = new UserController().CreateUserGroupMapping(objUserGroupMapping);
                }

                else
                {
                    group.UserGroupID = GroupID;
                    string ss = new UserController().UpdateUserGroup(group);
                }
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
                        int AdminCount = 0;
                        foreach (GridViewRow row in gvContactsFromXls.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                //if ((row.Cells[1].Text != string.Empty && row.Cells[1].Text != "&nbsp;") || (row.Cells[2].Text != string.Empty && row.Cells[2].Text != "&nbsp;"))
                                //{

                                if (IsValidRow(row))
                                {


                                    //    string strUserID = string.Empty;
                                    User u = null;
                                    if (row.Cells[3].Text.ToLower() == "yes")
                                    {
                                        if (row.Cells[1].Text != string.Empty && row.Cells[1].Text != "&nbsp;")
                                        {
                                            u = new UserController().GetUserbyEmail(row.Cells[1].Text.Trim());
                                        }
                                        if (u == null && row.Cells[2].Text != string.Empty && row.Cells[2].Text != "&nbsp;")
                                        {
                                            u = new UserController().GetUserbyMobile(row.Cells[2].Text.Trim());
                                        }
                                    }
                                    else
                                    {
                                        if (u == null && row.Cells[2].Text != string.Empty && row.Cells[2].Text != "&nbsp;")
                                        {
                                            u = new UserController().GetUser_byNameAndMobile(row.Cells[2].Text.Trim(), row.Cells[0].Text);
                                        }
                                    }
                                    string strUserID = string.Empty;
                                    //User u = null;
                                    string couponCode = GenerateCoupon();
                                    List<UserGroups> listGroup = new List<UserGroups>();
                                    listGroup.Add(group);
                                    if (u == null)
                                    {
                                        User objUser = new User
                                        {
                                            CouponCode = couponCode,
                                            CreatedBy = Context.User.Identity.Name,
                                            CreateDate = DateTime.Now,
                                            DOB = Convert.ToDateTime("1/1/1900"),
                                            EMail = (row.Cells[1].Text == "&nbsp;") ? string.Empty : row.Cells[1].Text,
                                            //row.Cells[1].Text?="": row.Cells[1].Text ,
                                            FirstName = row.Cells[0].Text,
                                            IsDeleted = false,
                                            IsLockedOut = true,

                                            LastLockoutDate = DateTime.Now,
                                            LastLoginDate = DateTime.Now,
                                            LastName = string.Empty,
                                            LastPasswordChangedDate = DateTime.Now,
                                            MobileNo = row.Cells[2].Text,
                                            PWD = string.Empty,
                                            RoleID = 4,
                                            // UserGroup= listGroup,// for Normal user
                                            ImageID = string.Empty,
                                            Custom1 = row.Cells[4].Text,//used for Roll Number
                                            Custom2 = row.Cells[5].Text,//used for User Type(Gender or Teacher)
                                            Custom3 = row.Cells[6].Text,//used for Cast
                                            Custom4 = row.Cells[7].Text,//used for Physically Handicap
                                            Custom5 = "1",              //This field is used Type of Flow that it should go

                                            Session = General.GetCurrentSession,
                                            ClientID = Convert.ToInt32(txtClientID.Text)
                                        };
                                        if (row.Cells[3].Text.ToLower() == "yes")
                                        {
                                            objUser.IsLockedOut = false;
                                        }
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
                                    IList<UserGroupMapping> mlist = new UserController().GetUserGroupMapping(strUserID);
                                    mlist = mlist.Where(ss => ss.UserGroupID == GroupID).ToList();
                                    if (row.Cells[3].Text.ToLower() == "yes" && AdminCount <= 5)
                                    {
                                        isAdmin = true;
                                        AdminCount++;
                                    }
                                    if (mlist.Count < 1)
                                    {
                                        objUserGroupMapping.isAdmin = isAdmin;
                                        string strMsg = new UserController().CreateUserGroupMapping(objUserGroupMapping);
                                    }
                                    if (isAdmin)
                                    {

                                        if (u == null)
                                        {
                                            string encryptedCouponCode = Encryption.Encrypt(couponCode);
                                            if (encryptedCouponCode.Substring(encryptedCouponCode.Length - 2, 2) == "==")
                                            {
                                                encryptedCouponCode = encryptedCouponCode + "echo";
                                            }
                                            encryptedCouponCode = encryptedCouponCode.Replace("+", "plus");
                                            encryptedCouponCode = encryptedCouponCode.Replace(" ", "%20");

                                            string messageBody = "Dear " + row.Cells[0].Text + ", Welcome to ECHO! You have been added to " + txtName.Text + " by" + currentUser.FirstName + " on EchoAttendance. Register using the following link: http://echocommunicator.com/account/register?cc=" + encryptedCouponCode + ". to download our mobile App click https://bit.ly/2RbXp5r";
                                            string EmailBody = "Dear " + row.Cells[0].Text + ", <br/><br/>Welcome to ECHO!<br/><br/> You have been added to " + txtName.Text + " by" + currentUser.FirstName + " on EchoAttendance.<br/><br/> Register using the following link:http://echocommunicator.com/account/register?cc=" + encryptedCouponCode + " <br/><br/>to download our mobile App click https://bit.ly/2RbXp5r";
                                            try
                                            {
                                                General.SendSMS(row.Cells[2].Text.Trim(), messageBody);
                                                General.SendEmail(row.Cells[1].Text.Trim(), "Welcome to ECHO", EmailBody);
                                            }
                                            catch
                                            {


                                            }
                                            row.Cells[4].Text = "Invitation Sent";
                                            row.Cells[4].BackColor = System.Drawing.Color.Green;
                                        }
                                        else
                                        {
                                            string encryptedCouponCode = Encryption.Encrypt(u.CouponCode);
                                            if (encryptedCouponCode.Substring(encryptedCouponCode.Length - 2, 2) == "==")
                                            {
                                                encryptedCouponCode = encryptedCouponCode + "echo";
                                            }
                                            encryptedCouponCode = encryptedCouponCode.Replace("+", "plus");
                                            encryptedCouponCode = encryptedCouponCode.Replace(" ", "%20");
                                            string messageBody = "Dear " + u.FirstName + ", Welcome to ECHO! You have been added to " + txtName.Text + " " + txtDesc.Text + " by" + currentUser.FirstName + " on EchoAttendance. Register using the following link: http://echocommunicator.com/account/register?cc=" + encryptedCouponCode + ". To download our mobile App click https://bit.ly/2RbXp5r";
                                            string EmailBody = "Dear " + u.FirstName + ", <br/><br/>Welcome to ECHO!<br/><br/> You have been added to " + txtName.Text + " " + txtDesc.Text + " by" + currentUser.FirstName + " on EchoAttendance.<br/><br/> Register using the following link:http://echocommunicator.com/account/register?cc=" + encryptedCouponCode + " <br/><br/>to download our mobile App click https://bit.ly/2RbXp5r";

                                            //string messageBody = "Dear " + u.FirstName + ", Welcome to ECHO! click this link to complete your Registration http://echocommunicator.com/account/register?cc=" + Encryption.Encrypt(u.CouponCode) + "";
                                            //string EmailBody = "Dear " + u.FirstName + ", <br/><br/>Welcome to ECHO! click this link to complete your Registration<br/><br/> http://echocommunicator.com/account/register?cc=" + Encryption.Encrypt(u.CouponCode) + "";
                                            try
                                            {


                                                General.SendSMS(row.Cells[2].Text.Trim(), messageBody);
                                                General.SendEmail(row.Cells[1].Text.Trim(), "Welcome to ECHO", EmailBody);
                                            }
                                            catch
                                            {


                                            }
                                            row.Cells[4].Text = "Invitation sent again";
                                            row.Cells[4].BackColor = System.Drawing.Color.YellowGreen;

                                        }
                                    }
                                    else
                                    {
                                        row.Cells[4].Text = "Imported";
                                        row.Cells[4].BackColor = System.Drawing.Color.Green;
                                    }

                                    //User uu = objUser;
                                    //}
                                    //else
                                    //{
                                    //    row.Cells[4].Text = "Invalid record";
                                    //    row.Cells[4].BackColor = System.Drawing.Color.Red;
                                    //}
                                }
                                else
                                {
                                    row.Cells[4].Text = "Invalid record";
                                    row.Cells[4].BackColor = System.Drawing.Color.Red;
                                }

                            }
                        }
                        Response.Redirect("~/account/managegroups");
                    }
                    else { ErrorMessage.Text = "Invalid Contact file please upload a valid file!"; }
                }
                //MasterPage  ac = this.Master;
                //ac.BindGroups();
                //BindGroups();
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }

        }
        private bool IsValidRow(GridViewRow row)
        {
            bool result = false;
            if (row.Cells[3].Text.ToLower() == "yes")
            {
                if (row.Cells[2].Text != string.Empty && row.Cells[2].Text != "&nbsp;" && row.Cells[0].Text != "&nbsp;" && row.Cells[0].Text != string.Empty)
                {
                    result = true;
                }
            }


            else if (row.Cells[3].Text.ToLower() != "yes" && row.Cells[0].Text != "&nbsp;" && row.Cells[0].Text != string.Empty)
            {
                result = true;
            }


            return result;
        }

        private string GenerateCoupon()

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
            bool verifyCoupon = new UserController().Verify_CouponCode(Code);

            if (verifyCoupon)
                GenerateCoupon();
            return Code;


        }
        // public int MyProperty { get; set; }
        public int GroupID
        {
            get;
            set;
        }
        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow grow in gvContacts.Rows)
            {
                CheckBox chkdel = (CheckBox)grow.FindControl("chkDel");
                if (chkdel.Checked)
                {
                    Label lbl = (Label)grow.FindControl("UserID");
                    new UserController().DeleteUserGroupMapping(lbl.Text, GroupID);
                }
            }
            bindGvContacts();
        }
        //private void bindGvAttendaneByDate()
        //{
        //    IList<MemberAttendance> chkAtt = new AttendanceController().GetMemberAttendances(GroupID, DateTime.Now.Date);
        //    gvGroupAttendance.DataSource = chkAtt;
        //    gvGroupAttendance.DataBind();
        //}
        //private void HandleButtonEnable()
        //{
        //    btnSendAttendanceMail.Enabled = (button1ClickAt == null || button1ClickAt.Value.Date != DateTime.Now.Date);
        //}
        protected void btnSendAttendanceMail_Click(object sender, EventArgs e)
        {
            try
            {

                User u = new UserController().GetUser(Context.User.Identity.Name);
                if (litAtt.Text != "2")
                {
                    int totalPresent = 0;

                    foreach (GridViewRow grow in gvAttendance.Rows)
                    {
                        CheckBox rbPresent = (CheckBox)grow.FindControl("rbPresent");
                        CheckBox rbAbsent = (CheckBox)grow.FindControl("rbAbsent");
                        Label lblName = (Label)grow.FindControl("lblName");
                        Label lblMobile = (Label)grow.FindControl("Mobile");
                        Label lblUserId = (Label)grow.FindControl("UserID");
                        string Chkattend = string.Empty;
                        string ChkattendForEmail = string.Empty;

                        if (rbPresent.Checked)
                        {
                            //string messageBody = "Dear " + grow.Cells[1].Text + ", <br/> Your attendance status for the date " + DateTime.Now.ToShortDateString() + " is Present.";
                            //string EmailBody = "Dear " + grow.Cells[1].Text + ", <br/> Your attendance status for the date " + DateTime.Now.ToShortDateString() + " is Present.";
                            //General.SendSMS(lblMobile.Text, messageBody);
                            //General.SendEmail(lblEmail.Text, "Attendance for Today", EmailBody);
                            Chkattend = "Present";
                            ChkattendForEmail = "Present";
                            totalPresent++;
                        }
                        else if (rbAbsent.Checked)
                        {
                            //string messageBody = "Dear " + grow.Cells[1].Text + ", <br/> Your attendance status for the date " + DateTime.Now.ToShortDateString() + " is Absent.";
                            //string EmailBody = "Dear " + grow.Cells[1].Text + ", <br/> Your attendance status for the date " + DateTime.Now.ToShortDateString() + " is Absent.";
                            //General.SendSMS(lblMobile.Text, messageBody);
                            // General.SendEmail(lblEmail.Text, "Attendance for Today", EmailBody);
                            Chkattend = "Absent";
                            ChkattendForEmail = "<b>Absent</b>";
                        }
                        string DeviceIDOrName = string.Empty;
                        try
                        {
                            DeviceIDOrName = Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName;

                        }
                        catch 
                        {  
                        }

                        new AttendanceController().UpdateMemberAttendance(lblUserId.Text, GroupID, DateTime.UtcNow.AddHours(5.5).Date, Chkattend,2,DateTime.UtcNow.AddHours(5.5).ToShortTimeString(),"Web", DeviceIDOrName, DeviceIDOrName,u.FirstName);


                    }
                    General.ShowAlertMessage("Attendance Status Saved");
                }
                else
                {
                    lblError.Text = "Not valid!";
                    gvAttendance.Visible = false;
                    btnSendAttendanceMail.Visible = false;
                }
            }
            catch (Exception ex)
            {

                General.ShowAlertMessage("Something is not right, Please try again later!");
            }

        }

        protected void DeleteGroup(object sender, EventArgs e)
        {
            try
            {
                if (GroupID > 0)
                {
                    new UserController().DeleteUserGroup(GroupID);
                    // General.ShowAlertMessage("Group has been deleted!", "/account/managegroups");
                    Response.Redirect("/account/managegroups");
                }
            }
            catch (Exception ex)
            {

                ErrorMessage.Text = "Group could not be deleted" + ex.Message;
            }
        }
        private string LoadHTML()
        {
            string file = Server.MapPath("~/EmailTemplates/Attendance.html");
            StreamReader objSR;
            FileInfo fi = new FileInfo(file);
            StringBuilder objSB = new StringBuilder();
            objSB.Append("");
            if (File.Exists(file))
            {
                objSR = File.OpenText(file);
                objSB.Append(objSR.ReadToEnd());
                objSR.Close();
            }
            return Convert.ToString(objSB);
        }


    }
}