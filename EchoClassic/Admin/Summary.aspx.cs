using BusinessObjects;
using Controllers;
using DataObjects.AdoNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Admin
{
    public partial class Summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    User c = new UserController().GetUser(Context.User.Identity.Name);
                    imgGroup.ImageUrl = "../images/" + c.ClientID.ToString() + ".jpg";
                    litClientID.Text = c.ClientID.ToString();
                    string Query = string.Format("Select OrganizationName from Clients where ID=" + c.ClientID + "");
                    SqlCommand cmd = new SqlCommand(Query);
                    String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    string ClientName = cmd.ExecuteScalar().ToString();
                    con.Close();
                    imgGroup.AlternateText = ClientName;
                    BindClientGroupsReportedAttendanceForADay();
                    BindClientSummary();
                    BindClientGroups();
                    LoadAttendanceSummeryForDateRange();
                    GetCountUsersChangedPassword();
                    //Response.Redirect("~/Default?echotgt=" + Request.RawUrl);
                }
                else
                    Response.Redirect("~/Default?echotgt=" + Request.RawUrl);
            }

        }
        private void BindClientSummary()
        {
            SummaryTotal st = new DashboardController().GetSummaryTotal(Convert.ToInt32(litClientID.Text));
            if (st != null)
            {
                litTotalStudent.Text = st.TotalStudents.ToString();
                litTotalTeacher.Text = st.TotalTeachers.ToString();
                litTotalMale.Text = st.TotalMale.ToString();
                litTotalFemale.Text = st.TotalFemale.ToString();
                LitTotalClasses.Text = st.TotalClasses.ToString();
            }

        }
        List<int> dsGroupsReportedAttendance= new List<int>();
        private void BindClientGroupsReportedAttendanceForADay()
        {
           // dsGroupsReportedAttendance = new IList<int>();
            //dsGroupsReportedAttendance.Add(122829);
            SqlParameter[] m = new SqlParameter[2];
            m[0] = new SqlParameter("@ClientID", Convert.ToInt32(litClientID.Text));
            m[1] = new SqlParameter("@Date", DateTime.UtcNow.AddHours(5.5));
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetGroupsNotReportedAttendanceForADay", m);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dsGroupsReportedAttendance.Add(Convert.ToInt32(dr["GroupID"]));
                }
            }
        }
        private void BindClientGroups()
        {
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ClientID", Convert.ToInt32(litClientID.Text));
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAdminMemberSummaryByGroupWithAdminNames", m);
            gvGroupAndMembers.DataSource = ds;
            gvGroupAndMembers.DataBind();

        }

        protected void gvGroupAndMembers_databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblGroupID = e.Row.FindControl("lblGroupID") as Label;
                int GroupID = Convert.ToInt32(lblGroupID.Text);
                if (dsGroupsReportedAttendance != null)
                {
                    if (dsGroupsReportedAttendance.Count > 0)
                    {
                        if (!dsGroupsReportedAttendance.Contains(GroupID))
                        {
                            e.Row.BackColor = System.Drawing.Color.Green;
                            
                        }
                        dsGroupsReportedAttendance.Remove(GroupID);
                    }
                }
                //SqlParameter[] m = new SqlParameter[1];
                //m[0] = new SqlParameter("@GroupID", ag.GroupID);
                //m[0] = new SqlParameter("@Date", DateTime.UtcNow.AddDays(5.5).Date);
                //try
                //{
                //    int Count = Convert.ToInt32(SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "CheckAttendanceForGroup", m));
                //    if (Count > 0)
                //    {
                //        e.Row.BackColor = System.Drawing.Color.Green;
                //    }
                //}
                //catch
                //{

                //}
            }
        }
        private void LoadAttendanceSummeryForDateRange()
        {
            DashboardSummary d = new DashboardController().GetDashboardSummaryAttendance(Convert.ToInt32(litClientID.Text), DateTime.UtcNow.AddHours(5.5).Date, DateTime.UtcNow.AddHours(5.5).Date);
            if (!IsPostBack && d != null)
            {
                litClassesCount.Text = d.TotalClasses;
            }
            // BindTrendLineChartTeacher(d);
        }

        protected void GetCountUsersChangedPassword()
        {
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ClientID", Convert.ToInt32(litClientID.Text));
            litInstallationReport.Text = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "SelectCountUsersChangedPassword", m).ToString();

        }
    }
}