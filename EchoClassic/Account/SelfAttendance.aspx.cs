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
    public partial class SelfAttendance : System.Web.UI.Page
    {
        // private static DateTime? button1ClickAt = null;
        private static bool isAdmin = false;
        //private User u = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            GroupID = General.QueryStringInt("GroupID");
            if (!Context.User.Identity.IsAuthenticated || Context.User.Identity.Name == string.Empty)
                Response.Redirect("~/default?echotgt=" + Request.RawUrl);
            if (GroupID>0)
            {
                User u = new UserController().GetUser(Context.User.Identity.Name);
                string type = u.UserGroup.Where(ss => ss.UserGroupID == GroupID).FirstOrDefault().FlowType.ToString();

                if (type != "2")
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

                
                int Code = new AttendanceController().VerifyAttendanceCode(GroupID, DateTime.UtcNow.AddHours(5.5).Date);
                if (Code > 0 && Code == Convert.ToInt32(txtAttendanceCode.Text))
                {
                    User u = new UserController().GetUser(Context.User.Identity.Name);
                    string DeviceIDOrName = string.Empty;
                    try
                    {
                        DeviceIDOrName = Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName;

                    }
                    catch
                    {

                        
                    }
                    new AttendanceController().UpdateMemberAttendance(u.UserID, GroupID, DateTime.UtcNow.AddHours(5.5).Date, "Present", 1, DateTime.UtcNow.AddHours(5.5).ToShortTimeString(),"Web",DeviceIDOrName,DeviceIDOrName,"Self");
                    General.ShowAlertMessage("Thank you!\r\n Your attendance is saved.");
                    lblError.Text = "Thank you! Your attendance is saved.";
                    lblError.ForeColor = System.Drawing.Color.Green;
                    btnSendAttendanceMail.Visible = false;
                    btnSendAttendanceMail.Enabled = false;
                }
                else
                {
                    General.ShowAlertMessage("Please check the code you have entered!");
                    lblError.Text = "Please check the code you have entered!";
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
                

            }
            catch (Exception ex)
            {

                General.ShowAlertMessage("Something is not right, Please try again later!");
            }

        }

        
    }
}