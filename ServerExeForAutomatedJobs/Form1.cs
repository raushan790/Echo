using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using DataObjects;
using System.Data.SqlClient;
using DataObjects.AdoNet;

namespace ServerExeForAutomatedJobs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //string dtAtendance = Convert.ToDateTime("2019-10-09 00:00:00.000").ToShortDateString() +" "+ Convert.ToDateTime("11:46:38 pm").ToShortTimeString();
            //DateTime dd = Convert.ToDateTime(dtAtendance);
            //string ss = "chk123";
        }
        Random random = new Random();
        public int GetCodeForAttendance()
        {
            return random.Next(100001, 999999);
        }

        private void InsertOfflineAttendanceCode()
        {
            lblGenerateCode.Text = "Currently code is being generated";
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectGroupsToGenerateAttendanceCode");
            if (ds.Tables[0].Rows.Count > 0)
            {

                DateTime fromDate = DateTime.UtcNow.AddHours(5.5).Date;
                int currentYear = fromDate.Year;
                int currentMonth = fromDate.Month;
                int SessionYear = 0;
                if (currentMonth < 4)
                {
                    SessionYear = currentYear;

                }
                else
                {
                    SessionYear = currentYear + 1;
                }

                DateTime toDate = Convert.ToDateTime(SessionYear.ToString() + "-03-31");
                int numberOfDays = Convert.ToInt32((toDate - fromDate).TotalDays);
                if (numberOfDays > 0)
                {
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        for (int i = 0; i <= numberOfDays; i++)
                        {
                            StringBuilder sbCodes = new StringBuilder();
                            sbCodes.Append(GetCodeForAttendance().ToString());
                            sbCodes.Append(",");
                            sbCodes.Append(GetCodeForAttendance().ToString());
                            sbCodes.Append(",");
                            sbCodes.Append(GetCodeForAttendance().ToString());
                            OfflineAttendanceCode ac = new OfflineAttendanceCode();

                            ac.AttendanceCode = sbCodes.ToString();
                            ac.GroupId = Convert.ToInt32(drow["GroupID"]);
                            ac.DateofUse = fromDate.AddDays(i).ToShortDateString();
                            DataAccess.AttendanceCodeDao.CreateOfflineAttendanceCode(ac);
                        }

                    }
                }

                lblGenerateCode.Text = string.Empty;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblGenerateCode.Text = "Currently code is being generated";

                InsertOfflineAttendanceCode();
                lblGenerateCode.Text = "";

            }
            catch
            {

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                lblNotification.Text = "Sending Notification";
                SendNotificationsForNotice();
                lblNotification.Text = string.Empty;
            }
            catch
            {
                lblNotification.Text = string.Empty;
            }
        }
        private void SendNotificationsForNotice()
        {
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectNoticeToBeNotified");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drow in ds.Tables[0].Rows)
                {
                    try
                    {
                        if (drow["Platform"].ToString() == "Android")
                        {
                            General.SendPushNotificationAndroid(drow["DeviceToken"].ToString(), drow["NoticeTitle"].ToString(), drow["NoticeDetail"].ToString());
                        }
                        else if (drow["Platform"].ToString() == "IOS")
                        {
                            General.SendPushNotificationIOS(drow["DeviceToken"].ToString(), drow["NoticeTitle"].ToString(), drow["NoticeDetail"].ToString());
                        }
                        SqlParameter[] m = new SqlParameter[2];
                        m[0] = new SqlParameter("@UserID", drow["UserID"].ToString());
                        m[1] = new SqlParameter("@NoticeID", drow["NoticeID"].ToString());

                        SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "SetNotifiedForNotice", m);
                    }
                    catch
                    {
                    }
                }

            }
        }

        private void ValidateOfflineAttendance_Tick(object sender, EventArgs e)
        {
            try
            {
                lblAttendanceVerification.Text = "Attendance verification in progress";

                ValidateOfflineAttendance();
                lblAttendanceVerification.Text = string.Empty;
            }
            catch
            {
                lblAttendanceVerification.Text = string.Empty;
            }

        }
        private void ValidateOfflineAttendance()
        {
            DataSet dsType5Groups = GetType5Groups();
            if (dsType5Groups.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drow in dsType5Groups.Tables[0].Rows)
                {
                    try
                    {
                        int GroupID = Convert.ToInt32(drow["GroupID"]);
                        DataSet dsAttendanceOfGroup = GetType5GroupsAttendance(GroupID);
                        DateTime CodeGenerationTime = Convert.ToDateTime(drow["DateOfUse"]);
                        if (dsAttendanceOfGroup.Tables[0].Rows.Count > 0)
                        {
                            string NoticeTitle = "Your Attendance for Class(group)" + drow["GroupName"].ToString() + " / " + drow["Description"].ToString() + " ,date:" + CodeGenerationTime.ToShortTimeString() + " is marked Absent";
                            string NoticeDetails = "Your Attendance for Class(group)" + drow["GroupName"].ToString() + " / " + drow["Description"].ToString() + " ,date:" + CodeGenerationTime.ToShortTimeString() + " is marked Absent. Please contact the respected class teacher for any query or confusion.";
                            IList<string> UserIDs = null;
                            IList<string> UserIDsPresent = null;
                            foreach (DataRow drowAttendance in dsAttendanceOfGroup.Tables[0].Rows)
                            {
                                DateTime AttendanceDatetime = Convert.ToDateTime(Convert.ToDateTime(drowAttendance["AttendanceDate"]).ToShortDateString() + " " + Convert.ToDateTime(drowAttendance["AttendanceTime"]).ToShortTimeString());
                                int CodeAndAttendanceTimeDifference = (AttendanceDatetime - CodeGenerationTime).Minutes;
                                if (CodeAndAttendanceTimeDifference > 60)
                                {
                                    UserIDs.Add(drowAttendance["UserID"].ToString());

                                }
                                else
                                {
                                    UserIDsPresent.Add(drowAttendance["UserID"].ToString());
                                }
                            }
                            if (UserIDs.Count > 0)
                            {
                                DataAccess.NoticeDao.CreateNotice(Convert.ToInt32(drow["GroupID"]), UserIDs, NoticeTitle, NoticeDetails, "Attendance Admin", DateTime.UtcNow.AddDays(5.5),string.Empty);
                                string UserIDsCommaSeparated = string.Join(",", UserIDs);
                                MarkAbsent(UserIDsCommaSeparated, GroupID);
                            }
                            if (UserIDsPresent.Count > 0)
                            {
                                string UserIDsCommaSeparated = string.Join(",", UserIDsPresent);
                                SqlParameter[] m = new SqlParameter[3];
                                m[0] = new SqlParameter("@UserIDs", UserIDs);
                                m[1] = new SqlParameter("@CreateDate", DateTime.UtcNow.AddHours(5.5).Date);
                                m[2] = new SqlParameter("@GroupID", GroupID);
                                int ds = SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "SetNotifiedForPresent", m);
                            }

                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        private DataSet GetType5Groups()
        {
            SqlParameter[] m = new SqlParameter[2];
            m[0] = new SqlParameter("@FromDate", DateTime.UtcNow.AddHours(5.5).Date.AddDays(-7));
            m[1] = new SqlParameter("@Todate", DateTime.UtcNow.AddHours(5.5).Date);

            DataSet ds = null;
            ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectType5Groups", m);
            return ds;
        }
        private DataSet GetType5GroupsAttendance(int GroupID)
        {
            DataSet ds = null;
            SqlParameter[] m = new SqlParameter[2];
            m[0] = new SqlParameter("@GroupID", GroupID);
            m[1] = new SqlParameter("@CreateDate", DateTime.UtcNow.AddHours(5.5).Date);
            ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectType5GroupsAttendance", m);
            return ds;
        }
        private void MarkAbsent(string UserIDs, int GroupID)
        {
            SqlParameter[] m = new SqlParameter[3];
            m[0] = new SqlParameter("@UserIDs", UserIDs);
            m[1] = new SqlParameter("@CreateDate", DateTime.UtcNow.AddHours(5.5).Date);
            m[2] = new SqlParameter("@GroupID", GroupID);
            int ds = SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "SetAbsentForAttendance", m);

        }
    }
}
