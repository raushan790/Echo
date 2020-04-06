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
    public partial class SelfAttendanceType3 : System.Web.UI.Page
    {
        // private static DateTime? button1ClickAt = null;
        private static bool isAdmin = false;
        //private User u = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            GroupID = General.QueryStringInt("GroupID");
            if (!Context.User.Identity.IsAuthenticated || Context.User.Identity.Name == string.Empty)
                Response.Redirect("~/default?echotgt=" + Request.RawUrl);
            if (GroupID > 0)
            {
                User u = new UserController().GetUser(Context.User.Identity.Name);
                string type = u.UserGroup.Where(ss => ss.UserGroupID == GroupID).FirstOrDefault().FlowType.ToString();

                if (type != "3")
                {
                    General.ShowAlertMessage("You are not authorized!", "~/logout.aspx");
                }
                pnlAttendance.Visible = true;
            }
        }
        
     
        // public int MyProperty { get; set; }
        public int GroupID
        {
            get;
            set;
        }
       
        protected void btnSendAttendanceMail_Click(object sender, EventArgs e)
        {
            try
            {
               DateTime AttendanceDate = DateTime.UtcNow.AddHours(5.5).Date;
                int AttChk = new AttendanceController().CheckMemberAttendance(GroupID, AttendanceDate);
                if (AttChk == 0)
                {
                    IList<User> Members =new UserController(). GetUserListGroup(GroupID);
                    if (Members.Count > 0)
                    {
                        foreach (User member in Members)
                        {
                            MemberAttendance ma = new MemberAttendance();
                            ma.AttendanceDate = AttendanceDate;
                            ma.AttendanceStatus = "Absent";
                            ma.AttendanceTime = DateTime.UtcNow.AddHours(5.5).ToShortTimeString();
                            ma.ClientID = member.ClientID;
                            ma.CreateDate = DateTime.UtcNow.AddHours(5.5);
                            ma.Device = "Web";
                            ma.DeviceIDOrName = string.Empty;
                            ma.DeviceLocation = txtLatLong.Text;
                            ma.GroupID = GroupID;
                            ma.Session = General.GetCurrentSession;
                            ma.UDF1 = "0";
                            ma.UDF2 = member.FirstName;
                            ma.UDF3 = "Admin";
                            ma.UserID = member.UserID;
                            new AttendanceController().CreateMemberAttendance(ma);
                        }
                    }
                }
                User u = new UserController().GetUser(Context.User.Identity.Name);
                    string DeviceIDOrName = string.Empty;
                    try
                    {
                        DeviceIDOrName = Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName;

                    }
                    catch
                    {

                        
                    }
                    new AttendanceController().UpdateMemberAttendance(u.UserID, GroupID, DateTime.UtcNow.AddHours(5.5).Date, "Present", 1, DateTime.UtcNow.AddHours(5.5).ToShortTimeString(),"Web",DeviceIDOrName,txtLatLong.Text,"Self");
                    General.ShowAlertMessage("Thank you!\r\n Your attendance is saved.");
                    lblError.Text = "Thank you! Your attendance is saved.";
                    lblError.ForeColor = System.Drawing.Color.Green;
                    btnSendAttendanceMail.Visible = false;
                    btnSendAttendanceMail.Enabled = false;
                
                

            }
            catch (Exception ex)
            {
                lblError.Text = "Something is not right, Please try again later!";
                General.ShowAlertMessage("Something is not right, Please try again later!");
            }

        }

        
    }
}