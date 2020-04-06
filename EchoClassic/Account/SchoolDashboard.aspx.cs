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
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Account
{
    public partial class SchoolDashboard : System.Web.UI.Page
    {
        public double PerAbsent = 0.0;
        public double PerPresent = 0.0;
        public double PerAbsentTeacher = 0.0;
        public double PerPresentTeacher = 0.0;
        public string DateSelected = string.Empty;
        public string AbsentSeries = string.Empty;
        public string PresentSeries = string.Empty;
        public string DateSeries = string.Empty;
        public string AbsentSeriesforLineChart = string.Empty;
        public string PresentSeriesforLineChart = string.Empty;
        public string DateSeriesTeacher = string.Empty;
        public string PresentSeriesforLineChartTeacher = string.Empty;

        public int TotalStudents = 0;
        public int TotalMale = 0;
        public int TotalFemale = 0;
        public int TotalDistrict = 0;
        public int TotalSchool = 0;

        //for date selected

        public int TotalStudentsonDate = 0;
        public int TotalMaleonDate = 0;
        public int TotalFemaleonDate = 0;
        public int TotalStudentsPresentonDate = 0;
        public int TotalMalePresentonDate = 0;
        public int TotalFemalePresentonDate = 0;
        public int TotalDistrictonDate = 0;
        public int TotalSchoolonDate = 0;
        public int TotalTeacheronDate = 0;
        public int TotalTeacherPresentonDate = 0;
        //top 5
        public string Top1 = string.Empty;
        public string Top2 = string.Empty;
        public string Top3 = string.Empty;
        public string Top4 = string.Empty;
        public string Top5 = string.Empty;

        //Bottom 5
        public string Bottom1 = string.Empty;
        public string Bottom2 = string.Empty;
        public string Bottom3 = string.Empty;
        public string Bottom4 = string.Empty;
        public string Bottom5 = string.Empty;
        public string CurrentDate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            CurrentDate = string.Empty;
            if (!Context.User.Identity.IsAuthenticated)
            { Response.Redirect("~/Default?echotgt=" + Request.RawUrl); }
            else
            {

            }
            if (!IsPostBack)
            {
                CurrentDate = DateTime.Now.ToShortDateString();
                if (Context.User.Identity.IsAuthenticated)
                {
                    User c = new UserController().GetUser(Context.User.Identity.Name);
                    lblUserName.Text = "Hello" + " " + c.FirstName;
                    if (c.ClientID == 1)
                    {
                        litSchoolName.Text = c.UserGroup.FirstOrDefault().Group_Name;
                       
                    }
                    else
                    {
                        imgGroup.ImageUrl = "../images/" + c.ClientID.ToString() + ".jpg";
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
                    }
                    //litSchoolName.Text = c.UserGroup.FirstOrDefault().Group_Name;
                }

            }
        }

        public string MaleSeries = string.Empty;
        public string FemaleSeries = string.Empty;

        private void BindGenderChart(DashboardSummary d, string Owner)
        {

            System.Text.StringBuilder sbMale = new System.Text.StringBuilder();
            System.Text.StringBuilder sbFemale = new System.Text.StringBuilder();
            if (Convert.ToInt32(d.TotalStudentsPresent) > 0)
            {
                double MalePercentage1 = Math.Round(Convert.ToInt32(d.TotalMalePresent) * 100.0 / Convert.ToInt32(d.TotalStudentsPresent));
                int MalePercentage = Convert.ToInt32(MalePercentage1);

                double FemalePercentage1 = Math.Round((Convert.ToInt32(d.TotalFemalePresent) * 100.0) / Convert.ToInt32(d.TotalStudentsPresent));
                int FemalePercentage = Convert.ToInt32(FemalePercentage1);

                sbMale.Append("['Gender', " + MalePercentage + "]");
                sbFemale.Append("['Gender', " + FemalePercentage + "]");
                MaleSeries = "[" + sbMale.ToString() + "]";
                FemaleSeries = "[" + sbFemale.ToString() + "]";
            }

        }

        public string CasteSeries = string.Empty;
        private void BindCasteChart(string Owner)
        {
            System.Text.StringBuilder sbGen = new System.Text.StringBuilder();
            System.Text.StringBuilder sbObc = new System.Text.StringBuilder();
            System.Text.StringBuilder sbSC = new System.Text.StringBuilder();
            System.Text.StringBuilder sbST = new System.Text.StringBuilder();
            System.Text.StringBuilder sbMinority = new System.Text.StringBuilder();
            System.Text.StringBuilder sbOther = new System.Text.StringBuilder();
            IList<KeyValue> CastWiseDataForADate = new KeyValueController().GetCastWiseDataForADate(Convert.ToDateTime(txtDate.Text), Owner, Convert.ToInt32(Session["ClientID"]));
            int TotalStudents = TotalStudentsPresentonDate;
            if (TotalStudents > 0)
            {
                double TotalGen = 0;
                try
                {
                    TotalGen = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "Gen") == null) ? 0 :
                                   Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "Gen").FirstOrDefault().Value));
                }
                catch
                {
                }
                double GenPercentage = Math.Round((TotalGen * 100 / TotalStudents));

                double TotalObc = 0;
                try
                {
                    TotalObc = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "OBC") == null) ? 0 :
                     Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "OBC").FirstOrDefault().Value));
                }
                catch
                {
                }

                double ObcPercentage = Math.Round((TotalObc * 100 / TotalStudents));
                double TotalSC = 0;
                try
                {
                    TotalSC = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "SC") == null) ? 0 :
                     Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "SC").FirstOrDefault().Value));
                }
                catch
                {
                }

                double SCPercentage = Math.Round((TotalSC * 100 / TotalStudents));
                double TotalST = 0;
                try
                {
                    TotalST = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "ST") == null) ? 0 :
                     Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "ST").FirstOrDefault().Value));
                }
                catch
                {
                }

                double STPercentage = Math.Round((TotalST * 100 / TotalStudents));
                double TotalMinority = 0;
                try
                {
                    TotalMinority = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "Minority") == null) ? 0 :
                                   Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "Minority").FirstOrDefault().Value));
                }
                catch
                {
                }

                double MinorityPercentage = Math.Round((TotalMinority * 100 / TotalStudents));

                double TotalOther = 0;
                try
                {
                    TotalOther = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "Other") == null) ? 0 :
                           Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "Other").FirstOrDefault().Value));
                }
                catch
                {
                }

                double OtherPercentage = Math.Round((TotalOther * 100 / TotalStudents));

                sbGen.Append(",['Gen', " + GenPercentage + "]");
                sbObc.Append(",['Obc', " + ObcPercentage + "]");
                sbSC.Append(",['SC', " + SCPercentage + "]");
                sbST.Append(",['ST', " + STPercentage + "]");
                sbMinority.Append(",['Minority', " + MinorityPercentage + "]");
                sbOther.Append(",['Other', " + OtherPercentage + "]");

                CasteSeries = "[" + sbGen.ToString() + "" + sbObc.ToString() + "" + sbSC.ToString() + "" + sbST.ToString() + "" + sbMinority.ToString() + "" + sbOther.ToString() + "]";
            }

        }



        private void BindTrendLineChart(string Owner)
        {
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbDates = new System.Text.StringBuilder();

            // DateSeries = "[" + sbDates.ToString().Substring(0, sbDates.Length - 1) + "]";
            SqlParameter[] m = new SqlParameter[4];
            m[0] = new SqlParameter("@FromDate", Convert.ToDateTime(txtDate.Text).AddDays(-11).ToShortDateString());
            m[1] = new SqlParameter("@ToDate", Convert.ToDateTime(txtDate.Text).AddDays(-1).ToShortDateString());
            m[2] = new SqlParameter("@Owner", Owner);
            m[3] = new SqlParameter("@ClientID", Convert.ToInt32(Session["ClientID"]));
            DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesForTrendsForSchool", m).Tables[0];
            DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesForTrendsPresentForSchool", m).Tables[0];
            ds.PrimaryKey = new DataColumn[] { ds.Columns["AttendanceDate"] };
            ds1.PrimaryKey = new DataColumn[] { ds1.Columns["AttendanceDate"] };
            ds.Merge(ds1);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Rows)
                {

                    double countPresent = Convert.ToDouble(dr["TotalStudentPresent"]);


                    if (countPresent != 0)
                    {
                        double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (Convert.ToDouble(dr["TotalStudent"])))));
                        sbPresent.Append(PresentPercent + ",");
                        sbDates.Append("'" + Convert.ToDateTime(dr["AttendanceDate"]).ToShortDateString() + "',");
                    }
                    else
                    {

                    }
                }
            }
            if (sbPresent.Length > 0)
            {
                PresentSeriesforLineChart = "[" + sbPresent.ToString().Substring(0, sbPresent.Length - 1) + "]";
                DateSeries = "[" + sbDates.ToString().Substring(0, sbDates.Length - 1) + "]";
            }
        }
        private void BindTrendLineChartTeacher(string Owner)
        {

            System.Text.StringBuilder sbAbsent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbDates = new System.Text.StringBuilder();
            SqlParameter[] m = new SqlParameter[4];
            m[0] = new SqlParameter("@FromDate", Convert.ToDateTime(txtDate.Text).AddDays(-11).ToShortDateString());
            m[1] = new SqlParameter("@ToDate", Convert.ToDateTime(txtDate.Text).AddDays(-1).ToShortDateString());
            m[2] = new SqlParameter("@Owner", Owner);
            m[3] = new SqlParameter("@ClientID", Convert.ToInt32(Session["ClientID"]));

            DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesTeachersForTrendsForSchool", m).Tables[0];
            DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesTeachersPresentForTrendsForSchool", m).Tables[0];
            ds.PrimaryKey = new DataColumn[] { ds.Columns["AttendanceDate"] };
            ds1.PrimaryKey = new DataColumn[] { ds1.Columns["AttendanceDate"] };
            ds.Merge(ds1);
            if (ds.Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Rows)
                {

                    double countPresent = Convert.ToDouble(dr["TotalTeacherPresent"]);


                    if (countPresent != 0)
                    {
                        double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (Convert.ToDouble(dr["TotalTeacher"])))));
                        sbPresent.Append(PresentPercent + ",");
                        sbDates.Append("'" + Convert.ToDateTime(dr["AttendanceDate"]).ToShortDateString() + "',");
                    }
                    else
                    {

                    }
                }
            }
            if (sbPresent.Length > 0)
            {
                PresentSeriesforLineChartTeacher = "[" + sbPresent.ToString().Substring(0, sbPresent.Length - 1) + "]";
                DateSeriesTeacher = "[" + sbDates.ToString().Substring(0, sbDates.Length - 1) + "]";
            }

        }

        private void BindGraph(DashboardSummary d)
        {

            double countAbsent = Convert.ToDouble(Convert.ToInt32(d.TotalStudents) - Convert.ToInt32(d.TotalStudentsPresent));

            double countPresent = Convert.ToDouble(Convert.ToInt32(d.TotalStudentsPresent));

            if (countAbsent != 0 || countPresent != 0)
            {
                double AbsentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countAbsent * 100 / (countPresent + countAbsent))), 2);
                double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (countPresent + countAbsent))), 2);
                PerAbsent = AbsentPercent;
                PerPresent = PresentPercent;
                DateSelected = Convert.ToDateTime(txtDate.Text).ToShortDateString();

            }

        }
        private void BindGraphTeacher(DashboardSummary d)
        {

            double countAbsent = Convert.ToDouble(Convert.ToInt32(d.TotalTeachers) - Convert.ToInt32(d.TotalTeachersPresent));

            double countPresent = Convert.ToDouble(d.TotalTeachersPresent);


            if (countAbsent != 0 || countPresent != 0)
            {
                double AbsentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countAbsent * 100 / (countPresent + countAbsent))), 2);
                double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (countPresent + countAbsent))), 2);
                PerAbsentTeacher = AbsentPercent;
                PerPresentTeacher = PresentPercent;
                DateSelected = Convert.ToDateTime(txtDate.Text).ToShortDateString();

            }

        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDate.Text != "")
            {
                try
                {


                    string userID = Context.User.Identity.Name;
                    User u = new UserController().GetUser(userID);
                    string owner = string.Empty;
                    DashboardSummary d = new DashboardSummary();
                    if (u.ClientID == 1)
                    {
                        owner = u.MobileNo;
                        //litSchoolName.Text = u.UserGroup.FirstOrDefault().Group_Name;
                        d = new AnalyticsController().GetDashboardSummary(Convert.ToDateTime(txtDate.Text), owner, u.ClientID);

                    }
                    else
                    {
                        //imgGroup.ImageUrl = "../images/" + u.ClientID.ToString() + ".jpg";
                        //string Query = string.Format("Select OrganizationName from Clients where ID=" + u.ClientID + "");
                        //SqlCommand cmd = new SqlCommand(Query);
                        //String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                        //SqlConnection con = new SqlConnection(constr);
                        //cmd.CommandType = CommandType.Text;
                        //cmd.Connection = con;
                        //con.Open();
                        //string ClientName = cmd.ExecuteScalar().ToString();
                        //con.Close();
                        //imgGroup.AlternateText = ClientName;
                        d = new AnalyticsController().GetDashboardSummary(Convert.ToDateTime(txtDate.Text), string.Empty, u.ClientID);

                    }
                    TotalStudentsonDate = Convert.ToInt32(d.TotalStudents);
                    TotalMaleonDate = Convert.ToInt32(d.TotalMale);
                    TotalFemaleonDate = Convert.ToInt32(d.TotalFemale);
                    TotalStudentsPresentonDate = Convert.ToInt32(d.TotalStudentsPresent);
                    TotalMalePresentonDate = Convert.ToInt32(d.TotalMalePresent);
                    TotalFemalePresentonDate = Convert.ToInt32(d.TotalFemalePresent);
                    //TotalDistrictonDate = Convert.ToInt32(d.TotalDistrict);
                    //TotalSchoolonDate = Convert.ToInt32(d.TotalSchool);
                    TotalTeacheronDate = Convert.ToInt32(d.TotalTeachers);
                    TotalTeacherPresentonDate = Convert.ToInt32(d.TotalTeachersPresent);

                    BindGraph(d);
                    BindGraphTeacher(d);
                    BindCasteChart(owner);
                    BindGenderChart(d, owner);
                    BindTrendLineChart(owner);
                    BindTrendLineChartTeacher(owner);
                    BindData(owner);
                }
                catch (Exception)
                {

                    General.ShowAlertMessage("Something is not write, no records found! Please try again.");
                }
            }
        }
        protected void BindData(string Owner)
        {


            gvClassLevel.DataSource = null;
            gvClassLevel.DataBind();
            string userID = Context.User.Identity.Name;
            User u = new UserController().GetUser(userID);

            SqlParameter[] m = new SqlParameter[3];
            m[0] = new SqlParameter("@Date", txtDate.Text);
            m[1] = new SqlParameter("@Owner", Owner);
            m[2] = new SqlParameter("@ClientID", u.ClientID);

            DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClassLevelTotalStudentForADateForSchool", m).Tables[0];
            DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClassLevelTotalStudentPresentForADateForSchool", m).Tables[0];
            ds.PrimaryKey = new DataColumn[] { ds.Columns["Description"] };
            ds1.PrimaryKey = new DataColumn[] { ds1.Columns["Description"] };

            ds.Merge(ds1);

            gvClassLevel.DataSource = ds;
            gvClassLevel.DataBind();

        }
        protected void gvClassLevel_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTotalStudentDistrict = e.Row.FindControl("lblTotalStudentDistrict") as Label;
                Label lblTotalPresentDistrict = e.Row.FindControl("lblTotalPresentDistrict") as Label;
                Label lblTotalAbsentDistrict = e.Row.FindControl("lblTotalAbsentDistrict") as Label;
                Label lblPercentageDistrict = e.Row.FindControl("lblPercentageDistrict") as Label;
                try
                {
                    lblTotalAbsentDistrict.Text = Convert.ToString(Convert.ToInt32(lblTotalStudentDistrict.Text) - Convert.ToInt32(lblTotalPresentDistrict.Text));
                    lblPercentageDistrict.Text = Convert.ToString(Math.Round((Convert.ToDouble(lblTotalPresentDistrict.Text) * 100) / Convert.ToDouble(lblTotalStudentDistrict.Text), 2));
                }
                catch
                {
                }

            }
        }
        protected void gvClassLevel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                LinkButton LinkSchool = e.CommandSource as LinkButton;
                gvStudentAttendance.DataSource = null;
                gvStudentAttendance.DataBind();

                litClass.Text = LinkSchool.Text;

                IList<MemberAttendance> Att = new AttendanceController().GetMemberAttendances(Convert.ToInt32(e.CommandArgument), Convert.ToDateTime(txtDate.Text));
                gvStudentAttendance.DataSource = Att;
                gvStudentAttendance.DataBind();
            }
        }
    }


}