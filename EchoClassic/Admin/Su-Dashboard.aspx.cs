using DataObjects.AdoNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using BusinessObjects;
using Controllers;

namespace EchoClassic.Admin
{
    public partial class Su_Dashboard : System.Web.UI.Page
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

        public int TotalClasses = 0;
        public string DashbaordCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentDate = string.Empty;
            calEFromDate.EndDate = DateTime.UtcNow.AddHours(5.5);
            CalETodate.EndDate = DateTime.UtcNow.AddHours(5.5);
            if (!IsPostBack)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    User c = new UserController().GetUser(Context.User.Identity.Name);
                    imgGroup.ImageUrl = "../images/" + c.ClientID.ToString() + ".jpg";
                    litClientID.Text = c.ClientID.ToString();
                    string Query = string.Format("Select OrganizationName,coalesce(DashboardCode,'') DashboardCode from Clients where ID=" + c.ClientID + "");
                    //SqlCommand cmd = new SqlCommand(Query);
                    String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    string ClientName = string.Empty;
                    try
                    {
                        SqlCommand cmd = new SqlCommand(Query, con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ClientName = reader.GetString(0).ToString();
                            DashbaordCode = reader.GetString(1).ToString();
                        }
                        reader.Close();
                    }
                    catch 
                    {

                    }
                    
                    con.Close();
                    imgGroup.AlternateText = ClientName;

                    GetCountUsersChangedPassword();
                    CurrentDate = DateTime.UtcNow.AddHours(5.5).ToShortDateString();

                    txtDateFrom.Text = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                    txtDateTo.Text = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                    SummaryTotal st = new DashboardController().GetSummaryTotal(Convert.ToInt32(litClientID.Text));
                    if (st != null)
                    {
                        litTotalGroups.Text= st.TotalClasses.ToString();
                        litGroupNotReported.Text = st.TotalClasses.ToString();
                    }
                    
                    LoadAttendanceSummeryForDateRange();
                    //Response.Redirect("~/Default?echotgt=" + Request.RawUrl);
                }
                else
                    Response.Redirect("~/Default?echotgt=" + Request.RawUrl);
            }

        }
        protected void GetCountUsersChangedPassword()
        {
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ClientID", Convert.ToInt32(litClientID.Text));
            litInstallationReport.Text = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "SelectCountUsersChangedPassword", m).ToString();

        }
        protected void ToDateChanged(object sender, EventArgs e)
        {

            int datediff = 0;
            bool showError = false;
            try
            {
                datediff = (Convert.ToDateTime(txtDateTo.Text) - Convert.ToDateTime(txtDateFrom.Text)).Days;
                if (datediff <= 0)
                {
                    showError = true;
                }
            }
            catch
            {
                showError = false;
            }
            if (datediff >= 0)
            {
                LoadAttendanceSummeryForDateRange();
            }
            else
            {
                if (showError == true)
                {
                    General.ShowAlertMessage("Please select the dates properly!");
                }

            }
        }
        protected void FromDateChanged(object sender, EventArgs e)
        {

            int datediff = 0;
            bool showError = false;
            try
            {
                datediff = (Convert.ToDateTime(txtDateTo.Text) - Convert.ToDateTime(txtDateFrom.Text)).Days;
                if (datediff <= 0)
                {
                    showError = true;
                }
            }
            catch
            {
                showError = false;
            }
            if (datediff >= 0)
            {
                LoadAttendanceSummeryForDateRange();
            }
            else
            {
                if (showError == true)
                {
                    General.ShowAlertMessage("Please select the dates properly!");
                }

            }
        }

        private void LoadAttendanceSummeryForDateRange()
        {
            if (txtDateFrom.Text != string.Empty && txtDateTo.Text != string.Empty)
            {
                DashboardSummary d = new DashboardController().GetDashboardSummaryAttendance(Convert.ToInt32(litClientID.Text), Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text));
                if (d != null)
                {
                    if (!IsPostBack)
                    {
                        litClassesCount.Text = d.TotalClasses;
                    }
                    TotalClasses = Convert.ToInt32(d.TotalClasses);
                    litGroupNotReported.Text = (Convert.ToInt32(litTotalGroups.Text) - TotalClasses).ToString();
                    BindGraph(d);
                    BindGraphTeacher(d);
                    BindGenderChart(d);
                    TotalStudentsonDate = string.IsNullOrEmpty(d.TotalStudents) ? 0 : Convert.ToInt32(d.TotalStudents);
                    TotalMaleonDate = Convert.ToInt32(d.TotalMale);
                    TotalFemaleonDate = Convert.ToInt32(d.TotalFemale);
                    TotalStudentsPresentonDate = Convert.ToInt32(d.TotalStudentsPresent);
                    TotalMalePresentonDate = Convert.ToInt32(d.TotalMalePresent);
                    TotalFemalePresentonDate = Convert.ToInt32(d.TotalFemalePresent);

                    TotalTeacheronDate = Convert.ToInt32(d.TotalTeachers);
                    TotalTeacherPresentonDate = Convert.ToInt32(d.TotalTeachersPresent);
                    BindTrendLineChart(d);
                    // BindTrendLineChartTeacher(d);
                }
            }

        }


        public string MaleSeries = string.Empty;
        public string FemaleSeries = string.Empty;

        private void BindGenderChart(DashboardSummary d)
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

        private void BindTrendLineChart(DashboardSummary d)
        {
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbDates = new System.Text.StringBuilder();


            List<FilterAttendance> ds = d.Trends;// SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesForTrends", m).Tables[0];
            try
            {
                if (ds.Count > 0)
                {
                    foreach (FilterAttendance fa in ds)
                    {

                        double countPresent = Convert.ToDouble(fa.TotalStudentPresent);


                        if (countPresent != 0)
                        {
                            double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (Convert.ToDouble(fa.TotalStudent)))));
                            sbPresent.Append(PresentPercent + ",");
                            sbDates.Append("'" + Convert.ToDateTime(fa.PrimaryColoumn).ToShortDateString() + "',");
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch
            {


            }

            if (sbPresent.Length > 0)
            {
                PresentSeriesforLineChart = "[" + sbPresent.ToString().Substring(0, sbPresent.Length - 1) + "]";
                DateSeries = "[" + sbDates.ToString().Substring(0, sbDates.Length - 1) + "]";
            }
        }
        private void BindTrendLineChartTeacher(DashboardSummary d)
        {

            System.Text.StringBuilder sbAbsent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbDates = new System.Text.StringBuilder();
            List<FilterAttendance> ds = d.Trends;
            if (ds.Count > 0)
            {
                foreach (FilterAttendance fa in ds)
                {

                    double countPresent = Convert.ToDouble(fa.TotalTeacherPresent);


                    if (countPresent != 0)
                    {
                        double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (Convert.ToDouble(fa.TotalTeacher)))));
                        sbPresent.Append(PresentPercent + ",");
                        sbDates.Append("'" + Convert.ToDateTime(fa.PrimaryColoumn).ToShortDateString() + "',");
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
                DateSelected = General.GetCurrentSession;// Convert.ToDateTime(txtDate.Text).ToShortDateString();

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
                DateSelected = General.GetCurrentSession;// Convert.ToDateTime(txtDate.Text).ToShortDateString();

            }

        }

    }
}