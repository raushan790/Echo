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
    public partial class SelfAttendanceType4 : System.Web.UI.Page
    {
        // private static DateTime? button1ClickAt = null;

        //private User u = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            GroupID = General.QueryStringInt("GroupID");
            if (!Context.User.Identity.IsAuthenticated || Context.User.Identity.Name == string.Empty)
                Response.Redirect("~/default?echotgt=" + Request.RawUrl);
            if (GroupID > 0)
            {
                User u = new UserController().GetUser(Context.User.Identity.Name);
                CreateSetup(GroupID, u);
            }
        }

        public void CreateSetup(int CurrentGroupID, User u)
        {
            string type = u.UserGroup.Where(ss => ss.UserGroupID == GroupID).FirstOrDefault().FlowType.ToString();

            if (type != "4")
            {
                General.ShowAlertMessage("You are not authorized!", "~/logout.aspx");
            }
            int AttendanceCount = new AttendanceController().GetAttendanceCountByUser(u.UserID, GroupID, DateTime.UtcNow.AddHours(5.5).Date);

            if (AttendanceCount % 2 == 0)
            {
                btnSendAttendanceMail.Text = "Checkin";
            }
            else
            {

                btnSendAttendanceMail.Text = "Checkout";
            }

            litAttCount.Text = AttendanceCount.ToString();
            pnlAttendance.Visible = true;
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
                User member = new UserController().GetUser(Context.User.Identity.Name);
                MemberAttendance ma = new MemberAttendance();
                ma.AttendanceDate = AttendanceDate;
                int AttendanceCount = Convert.ToInt32(litAttCount.Text);

                if (AttendanceCount % 2 == 0)
                {
                    ma.AttendanceStatus = "Checkin";
                }
                else
                {
                    ma.AttendanceStatus = "Checkout";
                }

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
                ma.UDF3 = "Self";
                ma.UserID = member.UserID;
                string DeviceIDOrName = string.Empty;
                try
                {
                    DeviceIDOrName = Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName;
                }
                catch
                {
                }
                new AttendanceController().CreateMemberAttendance(ma);


                // new AttendanceController().UpdateMemberAttendance(u.UserID, GroupID, DateTime.UtcNow.AddHours(5.5).Date, "Present", 1, DateTime.UtcNow.AddHours(5.5).ToShortTimeString(),"Web",DeviceIDOrName,txtLatLong.Text,"Self");
                General.ShowAlertMessage("Thank you! Your " + btnSendAttendanceMail.Text + " is successfull.");
                lblError.Text = "Thank you! Your " + btnSendAttendanceMail.Text + " is successfull.";
                lblError.ForeColor = System.Drawing.Color.Green;
                AttendanceCount++;
                litAttCount.Text = AttendanceCount.ToString();
                CreateSetup(GroupID,member);



            }
            catch (Exception ex)
            {
                lblError.Text = "Something is not right, Please try again later!";
                General.ShowAlertMessage("Something is not right, Please try again later!");
            }

        }


    }
}