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

using System.Web.UI.WebControls;

namespace EchoClassic.Admin
{
    public partial class New_Dashboard : System.Web.UI.Page
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

        public int TotalStudents=0;
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

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Context.User.Identity.IsAuthenticated)
            { Response.Redirect("~/Default?echotgt="+Request.RawUrl); }
            if (!IsPostBack)
            {
                
                
            }
        }
        DataView view = null;
        DataView viewTeacher = null;
        public string MaleSeries = string.Empty;
        public string FemaleSeries = string.Empty;
        private void BindGenderChart()
        {
            if (Session["StudentView"] != null)
            {
                view = Session["StudentView"] as DataView;
                System.Text.StringBuilder sbMale = new System.Text.StringBuilder();
                System.Text.StringBuilder sbFemale = new System.Text.StringBuilder();

                DataView dvToFilter = view;
                dvToFilter.RowFilter = "Gender = 'Male'";
                TotalMaleonDate = dvToFilter.Count;
                dvToFilter.RowFilter = "Gender = 'Female'";
                TotalFemaleonDate = dvToFilter.Count;
                dvToFilter.RowFilter = "AttendanceStatus = 'Present'";
                int TotalStudents = dvToFilter.Count;
                TotalStudentsPresentonDate = TotalStudents;
                if (TotalStudents > 0)
                {
                    dvToFilter.RowFilter = "Gender = 'Male' and AttendanceStatus = 'Present'";
                    DataTable dt = (dvToFilter).ToTable();
                    int TotalMale = dt.Rows.Count;
                    TotalMalePresentonDate = TotalMale;
                    double MalePercentage1 = Math.Round(TotalMale * 100.0 / TotalStudents);
                    int MalePercentage = Convert.ToInt32(MalePercentage1);
                    dvToFilter = view;
                    dvToFilter.RowFilter = "AttendanceStatus = 'Present'";

                    dvToFilter.RowFilter = "Gender = 'Female' and AttendanceStatus = 'Present'";
                    dt = (dvToFilter).ToTable();
                    int TotalFemale = dt.Rows.Count;
                    TotalFemalePresentonDate = TotalFemale;
                    double FemalePercentage1 = Math.Round((TotalFemale * 100.0) / TotalStudents);
                    int FemalePercentage = Convert.ToInt32(FemalePercentage1);

                    sbMale.Append("['Gender', " + MalePercentage + "]");
                    sbFemale.Append("['Gender', " + FemalePercentage + "]");
                    MaleSeries = "[" + sbMale.ToString() + "]";
                    FemaleSeries = "[" + sbFemale.ToString() + "]";
                }


            }
        }
        
        public string CasteSeries = string.Empty;
        private void BindCasteChart()
        {
            if (Session["StudentView"] != null)
            {
                view = Session["StudentView"] as DataView;
                System.Text.StringBuilder sbGen = new System.Text.StringBuilder();
                System.Text.StringBuilder sbObc = new System.Text.StringBuilder();
                System.Text.StringBuilder sbSC = new System.Text.StringBuilder();
                System.Text.StringBuilder sbST = new System.Text.StringBuilder();
                System.Text.StringBuilder sbMinority = new System.Text.StringBuilder();
                System.Text.StringBuilder sbOther = new System.Text.StringBuilder();

                DataView dvToFilter = view;
                dvToFilter.RowFilter = "AttendanceStatus = 'Present'";
                int TotalStudents = dvToFilter.Count;
                dvToFilter.RowFilter = "Cast = 'Gen' and AttendanceStatus = 'Present'";
                DataTable dt = (dvToFilter).ToTable();
                double TotalGen = dt.Rows.Count;
                double GenPercentage = Math.Round((TotalGen * 100 / TotalStudents));

                dvToFilter = view;
                dvToFilter.RowFilter = "AttendanceStatus = 'Present'";
                dvToFilter.RowFilter = "Cast = 'Obc' and AttendanceStatus = 'Present'";
                dt = (dvToFilter).ToTable();
                double TotalObc = dt.Rows.Count;
                double ObcPercentage = Math.Round((TotalObc * 100 / TotalStudents));

                dvToFilter = view;
                dvToFilter.RowFilter = "AttendanceStatus = 'Present'";
                dvToFilter.RowFilter = "Cast = 'SC' and AttendanceStatus = 'Present'";
                dt = (dvToFilter).ToTable();
                double TotalSC = dt.Rows.Count;
                double SCPercentage = Math.Round((TotalSC * 100 / TotalStudents));

                dvToFilter = view;
                dvToFilter.RowFilter = "AttendanceStatus = 'Present'";
                dvToFilter.RowFilter = "Cast = 'ST' and AttendanceStatus = 'Present'";
                dt = (dvToFilter).ToTable();
                double TotalST = dt.Rows.Count;
                double STPercentage = Math.Round((TotalST * 100 / TotalStudents));

                dvToFilter = view;
                dvToFilter.RowFilter = "AttendanceStatus = 'Present'";
                dvToFilter.RowFilter = "Cast = 'Minority' and AttendanceStatus = 'Present'";
                dt = (dvToFilter).ToTable();
                double TotalMinority = dt.Rows.Count;
                double MinorityPercentage = Math.Round((TotalMinority * 100 / TotalStudents));

                dvToFilter = view;
                dvToFilter.RowFilter = "AttendanceStatus = 'Present'";
                dvToFilter.RowFilter = "Cast = 'Other' and AttendanceStatus = 'Present'";
                dt = (dvToFilter).ToTable();
                double TotalOther = dt.Rows.Count;
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

        private void BindDistrictData()
        {
            gvClusterLevel.DataSource = null;
            gvClusterLevel.DataBind();
            gvBlockLevel.DataSource = null;
            gvBlockLevel.DataBind();
            gvSchoolLevel.DataSource = null;
            gvSchoolLevel.DataBind();
            gvClassLevel.DataSource = null;
            gvClassLevel.DataBind();
            litDistrict.Text = string.Empty;
            litBlock.Text = string.Empty;
            litCluster.Text = string.Empty;
            litScholl.Text = string.Empty;

            string Query = string.Format("select District,Cluster,Division as Block,School,Class, Name as StudentName, AttendanceStatus,Gender,Cast from Analytics where date='" + txtDate.Text + "'");

            SqlCommand cmd = new SqlCommand(Query);
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int TotalStudents = ds.Tables[0].Rows.Count;
            TotalStudentsonDate = TotalStudents;
            view = new DataView(ds.Tables[0]);
          
            Session["StudentView"] = view;
            DataTable Schools = view.ToTable(true, "School");
            TotalSchoolonDate = Schools.Rows.Count;
            BindDistrictTeacherData();
            DataTable districts = view.ToTable(true, "District");
            TotalDistrictonDate = districts.Rows.Count;
            gvDistrictLevel.DataSource = districts;
            gvDistrictLevel.DataBind();

        }
        private void BindDistrictTeacherData()
        {

            string Query = string.Format("select District,Cluster,Division as Block,School,Class, Name as TeacherName, AttendanceStatus from AnalyticsTeacher where date='" + txtDate.Text + "'");

            SqlCommand cmd = new SqlCommand(Query);
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            // double TotalStudents = ds.Tables[0].Rows.Count;
            viewTeacher = new DataView(ds.Tables[0]);
            Session["TeacherView"] = viewTeacher;

        }
        private void BindTrendLineChart()
        {

            System.Text.StringBuilder sbAbsent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbDates = new System.Text.StringBuilder();
            for (int i = 0; i <= 10; i++)
            {
                string AbsentQuery = string.Format("select count(AttendanceStatus)as AbsentCount from Analytics where AttendanceStatus='Absent' and Date='" + DateTime.Parse(txtDate.Text).AddDays(-i) + "' ");

                SqlCommand cmd = new SqlCommand(AbsentQuery);
                String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                double countAbsent = Convert.ToDouble(cmd.ExecuteScalar());
                con.Close();

                string PresentQuery = string.Format("select count(AttendanceStatus)as PresentCount from Analytics where AttendanceStatus='Present' and Date='" + DateTime.Parse(txtDate.Text).AddDays(-i) + "' ");

                SqlCommand cmd1 = new SqlCommand(PresentQuery);

                SqlConnection con1 = new SqlConnection(constr);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con1;
                con1.Open();
                double countPresent = Convert.ToDouble(cmd1.ExecuteScalar());
                con1.Close();

                if (countAbsent != 0 || countPresent != 0)
                {
                    double AbsentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countAbsent * 100 / (countPresent + countAbsent))));
                    double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (countPresent + countAbsent))));

                    sbAbsent.Append(AbsentPercent + ",");
                    sbPresent.Append(PresentPercent + ",");
                    // sbAbsent.Append("['" + DateTime.Parse(txtDate.Text).AddDays(-i).ToShortDateString() + "', " + AbsentPercent + "],");

                    sbDates.Append("'" + DateTime.Parse(txtDate.Text).AddDays(-i).ToShortDateString() + "',");
                }
                else
                {

                }
            }
            if (sbPresent.Length > 0)
            {
                //AbsentSeriesforLineChart = "[" + sbAbsent.ToString().Substring(0, sbAbsent.Length - 1) + "]";
                string[] PresentArray = sbPresent.ToString().Substring(0, sbPresent.Length - 1).Split(',');
                PresentArray = PresentArray.Reverse().ToArray();
                PresentSeriesforLineChart = string.Empty;
                foreach (string item in PresentArray)
                {
                    PresentSeriesforLineChart += item + ",";
                }
                PresentSeriesforLineChart = "[" + PresentSeriesforLineChart.Substring(0, PresentSeriesforLineChart.Length - 1) + "]";

                string[] DateArray = sbDates.ToString().Substring(0, sbDates.Length - 1).Split(',');
                DateArray = DateArray.Reverse().ToArray();
                DateSeries = string.Empty;
                foreach (string date in DateArray)
                {
                    DateSeries += date + ",";
                }
                DateSeries = "[" + DateSeries.Substring(0, DateSeries.Length - 1) + "]";


                // DateSeries = "[" + sbDates.ToString().Substring(0, sbDates.Length - 1) + "]";


            }
        }
        private void BindTrendLineChartTeacher()
        {

            System.Text.StringBuilder sbAbsent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbDates = new System.Text.StringBuilder();
            for (int i = 0; i <= 10; i++)
            {
                string AbsentQuery = string.Format("select count(AttendanceStatus)as AbsentCount from AnalyticsTeacher where AttendanceStatus='Absent' and Date='" + DateTime.Parse(txtDate.Text).AddDays(-i) + "' ");

                SqlCommand cmd = new SqlCommand(AbsentQuery);
                String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                double countAbsent = Convert.ToDouble(cmd.ExecuteScalar());
                con.Close();

                string PresentQuery = string.Format("select count(AttendanceStatus)as PresentCount from AnalyticsTeacher where AttendanceStatus='Present' and Date='" + DateTime.Parse(txtDate.Text).AddDays(-i) + "' ");

                SqlCommand cmd1 = new SqlCommand(PresentQuery);

                SqlConnection con1 = new SqlConnection(constr);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con1;
                con1.Open();
                double countPresent = Convert.ToDouble(cmd1.ExecuteScalar());
                con1.Close();

                if (countAbsent != 0 || countPresent != 0)
                {
                    double AbsentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countAbsent * 100 / (countPresent + countAbsent))));
                    double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (countPresent + countAbsent))));

                    sbAbsent.Append(AbsentPercent + ",");
                    sbPresent.Append(PresentPercent + ",");
                    // sbAbsent.Append("['" + DateTime.Parse(txtDate.Text).AddDays(-i).ToShortDateString() + "', " + AbsentPercent + "],");

                    sbDates.Append("'" + DateTime.Parse(txtDate.Text).AddDays(-i).ToShortDateString() + "',");
                }
                else
                {

                }
            }
            if (sbPresent.Length > 0)
            {
                //AbsentSeriesforLineChart = "[" + sbAbsent.ToString().Substring(0, sbAbsent.Length - 1) + "]";
                string[] PresentArray = sbPresent.ToString().Substring(0, sbPresent.Length - 1).Split(',');
                PresentArray = PresentArray.Reverse().ToArray();
                PresentSeriesforLineChartTeacher = string.Empty;
                foreach (string item in PresentArray)
                {
                    PresentSeriesforLineChartTeacher += item + ",";
                }
                PresentSeriesforLineChartTeacher = "[" + PresentSeriesforLineChartTeacher.Substring(0, PresentSeriesforLineChartTeacher.Length - 1) + "]";

                string[] DateArray = sbDates.ToString().Substring(0, sbDates.Length - 1).Split(',');
                DateArray = DateArray.Reverse().ToArray();
                DateSeriesTeacher = string.Empty;
                foreach (string date in DateArray)
                {
                    DateSeriesTeacher += date + ",";
                }
                DateSeriesTeacher = "[" + DateSeriesTeacher.Substring(0, DateSeriesTeacher.Length - 1) + "]";


                // DateSeries = "[" + sbDates.ToString().Substring(0, sbDates.Length - 1) + "]";


            }
        }
        private void BindChart()
        {

            System.Text.StringBuilder sbAbsent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            for (int i = 0; i <= 10; i++)
            {
                string AbsentQuery = string.Format("select count(AttendanceStatus)as AbsentCount from Analytics where AttendanceStatus='Absent' and Date='" + DateTime.Parse(txtDate.Text).AddDays(-i) + "' ");

                SqlCommand cmd = new SqlCommand(AbsentQuery);
                String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                double countAbsent = Convert.ToDouble(cmd.ExecuteScalar());
                con.Close();

                string PresentQuery = string.Format("select count(AttendanceStatus)as PresentCount from Analytics where AttendanceStatus='Present' and Date='" + DateTime.Parse(txtDate.Text).AddDays(-i) + "' ");

                SqlCommand cmd1 = new SqlCommand(PresentQuery);

                SqlConnection con1 = new SqlConnection(constr);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con1;
                con1.Open();
                double countPresent = Convert.ToDouble(cmd1.ExecuteScalar());
                con1.Close();

                if (countAbsent != 0 || countPresent != 0)
                {
                    double AbsentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countAbsent * 100 / (countPresent + countAbsent))));
                    double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (countPresent + countAbsent))));

                    sbAbsent.Append("['" + DateTime.Parse(txtDate.Text).AddDays(-i).ToShortDateString() + "', " + AbsentPercent + "],");
                    sbPresent.Append("['" + DateTime.Parse(txtDate.Text).AddDays(-i).ToShortDateString() + "', " + PresentPercent + "],");

                }
                else
                {

                }
            }
            if (sbAbsent.Length > 0)
            {
                AbsentSeries = "[" + sbAbsent.ToString().Substring(0, sbAbsent.Length - 1) + "]";
                PresentSeries = "[" + sbPresent.ToString().Substring(0, sbPresent.Length - 1) + "]";
            }
        }
        private void BindGraph()
        {
            string AbsentQuery = string.Format("select count(AttendanceStatus)as AbsentCount from Analytics where AttendanceStatus='Absent' and Date='" + DateTime.Parse(txtDate.Text) + "' ");

            SqlCommand cmd = new SqlCommand(AbsentQuery);
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            double countAbsent = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();

            string PresentQuery = string.Format("select count(AttendanceStatus)as PresentCount from Analytics where AttendanceStatus='Present' and Date='" + DateTime.Parse(txtDate.Text) + "' ");

            SqlCommand cmd1 = new SqlCommand(PresentQuery);

            SqlConnection con1 = new SqlConnection(constr);
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con1;
            con1.Open();
            double countPresent = Convert.ToDouble(cmd1.ExecuteScalar());
            con1.Close();

            if (countAbsent != 0 || countPresent != 0)
            {
                double AbsentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countAbsent * 100 / (countPresent + countAbsent))), 2);
                double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (countPresent + countAbsent))), 2);
                PerAbsent = AbsentPercent;
                PerPresent = PresentPercent;
                DateSelected = Convert.ToDateTime(txtDate.Text).ToShortDateString();
                //DataTable dt = new DataTable();
                //dt.Columns.Add("AttendanceStatus", typeof(string));
                //dt.Columns.Add("Percent", typeof(double));
                //DataRow drPresent = dt.NewRow();
                //drPresent["AttendanceStatus"] = "Present";
                //drPresent["Percent"] = PresentPercent;
                //dt.Rows.Add(drPresent);
                //DataRow drAbsent = dt.NewRow();
                //drAbsent["AttendanceStatus"] = "Absent";
                //drAbsent["Percent"] = AbsentPercent;
                //dt.Rows.Add(drAbsent);

                //string[] x = new string[dt.Rows.Count];
                //double[] y = new double[dt.Rows.Count];
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    x[i] = dt.Rows[i][0].ToString();
                //    y[i] = Convert.ToDouble(dt.Rows[i][1]);
                //}
                //Chart1.Width = 400;
                //Chart1.Series[0].Points.DataBindXY(x, y);
                //Chart1.Series["Default"].Label = "#VALY" + "%";
                //Chart1.Series["Default"].LegendText = "#VALX";

                //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                //Chart1.Legends[0].Enabled = true;
                //Chart1.Visible = true;
            }
            else
            {
                //Chart1.Visible = false;
                //General.ShowAlertMessage("No data found Please select another date!");
            }
        }
        private void BindGraphTeacher()
        {
            string AbsentQuery = string.Format("select count(AttendanceStatus)as AbsentCount from AnalyticsTeacher where AttendanceStatus='Absent' and Date='" + DateTime.Parse(txtDate.Text) + "' ");

            SqlCommand cmd = new SqlCommand(AbsentQuery);
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            double countAbsent = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();

            string PresentQuery = string.Format("select count(AttendanceStatus)as PresentCount from AnalyticsTeacher where AttendanceStatus='Present' and Date='" + DateTime.Parse(txtDate.Text) + "' ");

            SqlCommand cmd1 = new SqlCommand(PresentQuery);

            SqlConnection con1 = new SqlConnection(constr);
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con1;
            con1.Open();
            double countPresent = Convert.ToDouble(cmd1.ExecuteScalar());
            con1.Close();

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

            BindGraph();
            BindGraphTeacher();
            gvDistrictLevel.DataSource = null;
            gvDistrictLevel.DataBind();
            gvSchoolLevel.DataSource = null;
            gvSchoolLevel.DataBind();
            BindDistrictData();
            BindGenderChart();
            BindCasteChart();
            //BindChart();
            BindTrendLineChart();
            BindTrendLineChartTeacher();

        }
       
        protected void ddlTrendsOption_select(object sender, EventArgs e)
        {
            System.Text.StringBuilder sbAbsent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbDates = new System.Text.StringBuilder();
            for (int i = 1; i <= DateTime.Now.Day; i++)
            {
                string AbsentQuery = string.Format("select count(AttendanceStatus)as AbsentCount from Analytics where AttendanceStatus='Absent' and Month(Date)=12");//'" + DateTime.Parse(txtDate.Text).AddDays(-i) + "' ");

                SqlCommand cmd = new SqlCommand(AbsentQuery);
                String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                double countAbsent = Convert.ToDouble(cmd.ExecuteScalar());
                con.Close();

                string PresentQuery = string.Format("select count(AttendanceStatus)as PresentCount from Analytics where AttendanceStatus='Present' and Month(Date)=12");// + DateTime.Parse(txtDate.Text).AddDays(-i) + "' ");

                SqlCommand cmd1 = new SqlCommand(PresentQuery);

                SqlConnection con1 = new SqlConnection(constr);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con1;
                con1.Open();
                double countPresent = Convert.ToDouble(cmd1.ExecuteScalar());
                con1.Close();

                if (countAbsent != 0 || countPresent != 0)
                {
                    double AbsentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countAbsent * 100 / (countPresent + countAbsent))));
                    double PresentPercent = Math.Round(Convert.ToDouble(Convert.ToDouble(countPresent * 100 / (countPresent + countAbsent))));

                    sbAbsent.Append(AbsentPercent + ",");
                    sbPresent.Append(PresentPercent + ",");
                    // sbAbsent.Append("['" + DateTime.Parse(txtDate.Text).AddDays(-i).ToShortDateString() + "', " + AbsentPercent + "],");

                    sbDates.Append("'" + DateTime.Parse(txtDate.Text).AddDays(-i).ToShortDateString() + "',");
                }
                else
                {

                }
            }
            if (sbAbsent.Length > 0)
            {
                AbsentSeriesforLineChart = "[" + sbAbsent.ToString().Substring(0, sbAbsent.Length - 1) + "]";
                PresentSeriesforLineChart = "[" + sbPresent.ToString().Substring(0, sbPresent.Length - 1) + "]";
                DateSeries = "[" + sbDates.ToString().Substring(0, sbDates.Length - 1) + "]";
            }
        }
        protected void gvDistrictLevel_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton LinkDistrict = e.Row.FindControl("LinkDistrict") as LinkButton;
                Label lblTotalStudentDistrict = e.Row.FindControl("lblTotalStudentDistrict") as Label;
                Label lblTotalPresentDistrict = e.Row.FindControl("lblTotalPresentDistrict") as Label;
                Label lblTotalAbsentDistrict = e.Row.FindControl("lblTotalAbsentDistrict") as Label;
                Label lblPercentageDistrict = e.Row.FindControl("lblPercentageDistrict") as Label;

                DataView dvToFilter = view;
                dvToFilter.RowFilter = "District = '" + LinkDistrict.Text + "'";
                int TotalStudents = dvToFilter.Count;
                dvToFilter.RowFilter = "District = '" + LinkDistrict.Text + "'AND AttendanceStatus = 'Present'";
                DataTable dt = (dvToFilter).ToTable();
                double TotalPresent = dt.Rows.Count;
                double TotalAbsent = TotalStudents - TotalPresent;
                double Percentage = Math.Round((TotalPresent * 100 / TotalStudents), 2);
                lblTotalStudentDistrict.Text = TotalStudents.ToString();
                lblTotalPresentDistrict.Text = TotalPresent.ToString();

                lblTotalAbsentDistrict.Text = TotalAbsent.ToString();
                lblPercentageDistrict.Text = Percentage.ToString() + "%";

                //Teachers


                Label lblTotalTeacherDistrict = e.Row.FindControl("lblTotalTeacherDistrict") as Label;
                Label lblTotalTeacherPresentDistrict = e.Row.FindControl("lblTotalTeacherPresentDistrict") as Label;
                Label lblTotalTeacherAbsentDistrict = e.Row.FindControl("lblTotalTeacherAbsentDistrict") as Label;
                Label lblPercentageTeacherDistrict = e.Row.FindControl("lblPercentageTeacherDistrict") as Label;

                DataView dvToFilterTeacher = viewTeacher;
                dvToFilterTeacher.RowFilter = "District = '" + LinkDistrict.Text + "'";
                int TotalTeachers = dvToFilterTeacher.Count;
                if (TotalTeachers > 0)
                {
                    dvToFilterTeacher.RowFilter = "District = '" + LinkDistrict.Text + "'AND AttendanceStatus = 'Present'";
                    DataTable dtTeacher = (dvToFilterTeacher).ToTable();
                    double TotalTeacherPresent = dtTeacher.Rows.Count;
                    double TotalTeacherAbsent = TotalTeachers - TotalTeacherPresent;
                    double TeacherPercentage = Math.Round((TotalTeacherPresent * 100 / TotalTeachers), 2);
                    lblTotalTeacherDistrict.Text = TotalTeachers.ToString();
                    lblTotalTeacherPresentDistrict.Text = TotalTeacherPresent.ToString();

                    lblTotalTeacherAbsentDistrict.Text = TotalTeacherAbsent.ToString();
                    lblPercentageTeacherDistrict.Text = TeacherPercentage.ToString() + "%";
                }
            }
        }
        protected void gvDistrictLevel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                gvClusterLevel.DataSource = null;
                gvClusterLevel.DataBind();
                gvBlockLevel.DataSource = null;
                gvBlockLevel.DataBind();
                gvSchoolLevel.DataSource = null;
                gvSchoolLevel.DataBind();
                gvClassLevel.DataSource = null;
                gvClassLevel.DataBind();
                litDistrict.Text = e.CommandArgument.ToString();
                litBlock.Text = string.Empty;
                litCluster.Text = string.Empty;
                litScholl.Text = string.Empty;

                DataView dvToFilter = Session["StudentView"] as DataView;
                DataView dvToFilterTeacher = Session["TeacherView"] as DataView;
                if (dvToFilterTeacher != null)
                {
                    dvToFilterTeacher.RowFilter = "District = '" + e.CommandArgument.ToString() + "'";
                    viewTeacher = dvToFilterTeacher;

                }
                if (dvToFilter != null)
                {
                    dvToFilter.RowFilter = "District = '" + e.CommandArgument.ToString() + "'";
                    view = dvToFilter;
                    DataTable Blocks = dvToFilter.ToTable(true, "Block");
                    gvBlockLevel.DataSource = Blocks;
                    gvBlockLevel.DataBind();

                }
            }
        }
        protected void gvBlockLevel_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton LinkBlock = e.Row.FindControl("LinkBlock") as LinkButton;
                Label lblTotalStudentDistrict = e.Row.FindControl("lblTotalStudentDistrict") as Label;
                Label lblTotalPresentDistrict = e.Row.FindControl("lblTotalPresentDistrict") as Label;
                Label lblTotalAbsentDistrict = e.Row.FindControl("lblTotalAbsentDistrict") as Label;
                Label lblPercentageDistrict = e.Row.FindControl("lblPercentageDistrict") as Label;

                DataView dvToFilter = view;
                if (dvToFilter != null)
                {
                    dvToFilter.RowFilter = "Block = '" + LinkBlock.Text + "'";
                    int TotalStudents = dvToFilter.Count;
                    dvToFilter.RowFilter = "Block = '" + LinkBlock.Text + "'AND AttendanceStatus = 'Present'";
                    DataTable dt = (dvToFilter).ToTable();
                    double TotalPresent = dt.Rows.Count;
                    double TotalAbsent = TotalStudents - TotalPresent;
                    double Percentage = Math.Round((TotalPresent * 100 / TotalStudents), 2);
                    lblTotalStudentDistrict.Text = TotalStudents.ToString();
                    lblTotalPresentDistrict.Text = TotalPresent.ToString();

                    lblTotalAbsentDistrict.Text = TotalAbsent.ToString();
                    lblPercentageDistrict.Text = Percentage.ToString() + "%";
                }
                //Teachers


                Label lblTotalTeacherDistrict = e.Row.FindControl("lblTotalTeacherDistrict") as Label;
                Label lblTotalTeacherPresentDistrict = e.Row.FindControl("lblTotalTeacherPresentDistrict") as Label;
                Label lblTotalTeacherAbsentDistrict = e.Row.FindControl("lblTotalTeacherAbsentDistrict") as Label;
                Label lblPercentageTeacherDistrict = e.Row.FindControl("lblPercentageTeacherDistrict") as Label;

                DataView dvToFilterTeacher = viewTeacher;
                if (dvToFilterTeacher != null)
                {
                    dvToFilterTeacher.RowFilter = "Block = '" + LinkBlock.Text + "'";
                    int TotalTeachers = dvToFilterTeacher.Count;
                    if (TotalTeachers > 0)
                    {
                        dvToFilterTeacher.RowFilter = "Block = '" + LinkBlock.Text + "'AND AttendanceStatus = 'Present'";
                        DataTable dtTeacher = (dvToFilterTeacher).ToTable();
                        double TotalTeacherPresent = dtTeacher.Rows.Count;
                        double TotalTeacherAbsent = TotalTeachers - TotalTeacherPresent;
                        double TeacherPercentage = Math.Round((TotalTeacherPresent * 100 / TotalTeachers), 2);
                        lblTotalTeacherDistrict.Text = TotalTeachers.ToString();
                        lblTotalTeacherPresentDistrict.Text = TotalTeacherPresent.ToString();

                        lblTotalTeacherAbsentDistrict.Text = TotalTeacherAbsent.ToString();
                        lblPercentageTeacherDistrict.Text = TeacherPercentage.ToString() + "%";
                    }
                }
            }
        }
        protected void gvBlockLevel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                gvClusterLevel.DataSource = null;
                gvClusterLevel.DataBind();
                gvSchoolLevel.DataSource = null;
                gvSchoolLevel.DataBind();
                gvClassLevel.DataSource = null;
                gvClassLevel.DataBind();
                litBlock.Text = e.CommandArgument.ToString();
                litScholl.Text = string.Empty;
                litCluster.Text = string.Empty;
                DataView dvToFilter = Session["StudentView"] as DataView;
                DataView dvToFilterTeacher = Session["TeacherView"] as DataView;
                if (dvToFilterTeacher != null)
                {
                    dvToFilterTeacher.RowFilter = "Block = '" + e.CommandArgument.ToString() + "'";
                    viewTeacher = dvToFilterTeacher;

                }
                if (dvToFilter != null)
                {
                    dvToFilter.RowFilter = "Block = '" + e.CommandArgument.ToString() + "'";
                    view = dvToFilter;
                    DataTable Clusters = dvToFilter.ToTable(true, "Cluster");

                    gvClusterLevel.DataSource = Clusters;
                    gvClusterLevel.DataBind();
                }
            }
        }
        protected void gvClusterLevel_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton LinkCluster = e.Row.FindControl("LinkCluster") as LinkButton;
                Label lblTotalStudentDistrict = e.Row.FindControl("lblTotalStudentDistrict") as Label;
                Label lblTotalPresentDistrict = e.Row.FindControl("lblTotalPresentDistrict") as Label;
                Label lblTotalAbsentDistrict = e.Row.FindControl("lblTotalAbsentDistrict") as Label;
                Label lblPercentageDistrict = e.Row.FindControl("lblPercentageDistrict") as Label;

                DataView dvToFilter = view;
                if (dvToFilter != null)
                {
                    dvToFilter.RowFilter = "Cluster = '" + LinkCluster.Text + "'";
                    int TotalStudents = dvToFilter.Count;
                    dvToFilter.RowFilter = "Cluster = '" + LinkCluster.Text + "'AND AttendanceStatus = 'Present'";
                    DataTable dt = (dvToFilter).ToTable();
                    double TotalPresent = dt.Rows.Count;
                    double TotalAbsent = TotalStudents - TotalPresent;
                    double Percentage = Math.Round((TotalPresent * 100 / TotalStudents), 2);
                    lblTotalStudentDistrict.Text = TotalStudents.ToString();
                    lblTotalPresentDistrict.Text = TotalPresent.ToString();

                    lblTotalAbsentDistrict.Text = TotalAbsent.ToString();
                    lblPercentageDistrict.Text = Percentage.ToString() + "%";
                }
                //Teachers


                Label lblTotalTeacherDistrict = e.Row.FindControl("lblTotalTeacherDistrict") as Label;
                Label lblTotalTeacherPresentDistrict = e.Row.FindControl("lblTotalTeacherPresentDistrict") as Label;
                Label lblTotalTeacherAbsentDistrict = e.Row.FindControl("lblTotalTeacherAbsentDistrict") as Label;
                Label lblPercentageTeacherDistrict = e.Row.FindControl("lblPercentageTeacherDistrict") as Label;

                DataView dvToFilterTeacher = viewTeacher;
                if (dvToFilterTeacher != null)
                {
                    dvToFilterTeacher.RowFilter = "Cluster = '" + LinkCluster.Text + "'";
                    int TotalTeachers = dvToFilterTeacher.Count;
                    if (TotalTeachers > 0)
                    {
                        dvToFilterTeacher.RowFilter = "Cluster = '" + LinkCluster.Text + "'AND AttendanceStatus = 'Present'";
                        DataTable dtTeacher = (dvToFilterTeacher).ToTable();
                        double TotalTeacherPresent = dtTeacher.Rows.Count;
                        double TotalTeacherAbsent = TotalTeachers - TotalTeacherPresent;
                        double TeacherPercentage = Math.Round((TotalTeacherPresent * 100 / TotalTeachers), 2);
                        lblTotalTeacherDistrict.Text = TotalTeachers.ToString();
                        lblTotalTeacherPresentDistrict.Text = TotalTeacherPresent.ToString();

                        lblTotalTeacherAbsentDistrict.Text = TotalTeacherAbsent.ToString();
                        lblPercentageTeacherDistrict.Text = TeacherPercentage.ToString() + "%";
                    }
                }
            }
        }
        protected void gvClusterLevel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {

                gvSchoolLevel.DataSource = null;
                gvSchoolLevel.DataBind();
                gvClassLevel.DataSource = null;
                gvClassLevel.DataBind();
                litCluster.Text = e.CommandArgument.ToString();
                litScholl.Text = string.Empty;
                DataView dvToFilter = Session["StudentView"] as DataView;
                DataView dvToFilterTeacher = Session["TeacherView"] as DataView;
                if (dvToFilterTeacher != null)
                {
                    dvToFilterTeacher.RowFilter = "Cluster = '" + e.CommandArgument.ToString() + "'";
                    viewTeacher = dvToFilterTeacher;

                }
                if (dvToFilter != null)
                {
                    dvToFilter.RowFilter = "Cluster = '" + e.CommandArgument.ToString() + "'";
                    view = dvToFilter;
                    DataTable Schools = dvToFilter.ToTable(true, "School");

                    gvSchoolLevel.DataSource = Schools;
                    gvSchoolLevel.DataBind();
                }




            }
        }



        protected void gvSchoolLevel_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton LinkSchool = e.Row.FindControl("LinkSchool") as LinkButton;
                Label lblTotalStudentDistrict = e.Row.FindControl("lblTotalStudentDistrict") as Label;
                Label lblTotalPresentDistrict = e.Row.FindControl("lblTotalPresentDistrict") as Label;
                Label lblTotalAbsentDistrict = e.Row.FindControl("lblTotalAbsentDistrict") as Label;
                Label lblPercentageDistrict = e.Row.FindControl("lblPercentageDistrict") as Label;

                DataView dvToFilter = view;
                if (dvToFilter != null)
                {
                    dvToFilter.RowFilter = "School = '" + LinkSchool.Text + "'";
                    int TotalStudents = dvToFilter.Count;
                    dvToFilter.RowFilter = "School = '" + LinkSchool.Text + "'AND AttendanceStatus = 'Present'";
                    DataTable dt = (dvToFilter).ToTable();
                    double TotalPresent = dt.Rows.Count;
                    double TotalAbsent = TotalStudents - TotalPresent;
                    double Percentage = Math.Round((TotalPresent * 100 / TotalStudents), 2);
                    lblTotalStudentDistrict.Text = TotalStudents.ToString();
                    lblTotalPresentDistrict.Text = TotalPresent.ToString();

                    lblTotalAbsentDistrict.Text = TotalAbsent.ToString();
                    lblPercentageDistrict.Text = Percentage.ToString() + "%";
                }
                //Teachers


                Label lblTotalTeacherDistrict = e.Row.FindControl("lblTotalTeacherDistrict") as Label;
                Label lblTotalTeacherPresentDistrict = e.Row.FindControl("lblTotalTeacherPresentDistrict") as Label;
                Label lblTotalTeacherAbsentDistrict = e.Row.FindControl("lblTotalTeacherAbsentDistrict") as Label;
                Label lblPercentageTeacherDistrict = e.Row.FindControl("lblPercentageTeacherDistrict") as Label;

                DataView dvToFilterTeacher = viewTeacher;
                if (dvToFilterTeacher != null)
                {
                    dvToFilterTeacher.RowFilter = "School = '" + LinkSchool.Text + "'";
                    int TotalTeachers = dvToFilterTeacher.Count;
                    if (TotalTeachers > 0)
                    {
                        dvToFilterTeacher.RowFilter = "School = '" + LinkSchool.Text + "'AND AttendanceStatus = 'Present'";
                        DataTable dtTeacher = (dvToFilterTeacher).ToTable();
                        double TotalTeacherPresent = dtTeacher.Rows.Count;
                        double TotalTeacherAbsent = TotalTeachers - TotalTeacherPresent;
                        double TeacherPercentage = Math.Round((TotalTeacherPresent * 100 / TotalTeachers), 2);
                        lblTotalTeacherDistrict.Text = TotalTeachers.ToString();
                        lblTotalTeacherPresentDistrict.Text = TotalTeacherPresent.ToString();

                        lblTotalTeacherAbsentDistrict.Text = TotalTeacherAbsent.ToString();
                        lblPercentageTeacherDistrict.Text = TeacherPercentage.ToString() + "%";
                    }
                }
            }
        }
        protected void gvSchoolLevel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                gvClassLevel.DataSource = null;
                gvClassLevel.DataBind();
                litScholl.Text = e.CommandArgument.ToString();
                DataView dvToFilter = Session["StudentView"] as DataView;
                DataView dvToFilterTeacher = Session["TeacherView"] as DataView;
                if (dvToFilterTeacher != null)
                {
                    dvToFilterTeacher.RowFilter = "School = '" + e.CommandArgument.ToString() + "'";
                    viewTeacher = dvToFilterTeacher;

                }
                if (dvToFilter != null)
                {
                    dvToFilter.RowFilter = "School = '" + e.CommandArgument.ToString() + "'";
                    view = dvToFilter;
                    DataTable Classes = dvToFilter.ToTable(true, "Class");
                    Classes.DefaultView.Sort = "Class ASC";
                    gvClassLevel.DataSource = Classes;
                    gvClassLevel.DataBind();
                }




            }
        }
        protected void gvClassLevel_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblClass = e.Row.FindControl("lblClass") as Label;
                Label lblTotalStudentDistrict = e.Row.FindControl("lblTotalStudentDistrict") as Label;
                Label lblTotalPresentDistrict = e.Row.FindControl("lblTotalPresentDistrict") as Label;
                Label lblTotalAbsentDistrict = e.Row.FindControl("lblTotalAbsentDistrict") as Label;
                Label lblPercentageDistrict = e.Row.FindControl("lblPercentageDistrict") as Label;

                DataView dvToFilter = view;
                if (dvToFilter != null)
                {
                    dvToFilter.RowFilter = "School='" + litScholl.Text + "' AND Class = '" + lblClass.Text + "'";
                    int TotalStudents = dvToFilter.Count;
                    dvToFilter.RowFilter = "School='" + litScholl.Text + "' AND Class = '" + lblClass.Text + "'AND AttendanceStatus = 'Present'";
                    DataTable dt = (dvToFilter).ToTable();
                    double TotalPresent = dt.Rows.Count;
                    double TotalAbsent = TotalStudents - TotalPresent;
                    double Percentage = Math.Round((TotalPresent * 100 / TotalStudents), 2);
                    lblTotalStudentDistrict.Text = TotalStudents.ToString();
                    lblTotalPresentDistrict.Text = TotalPresent.ToString();

                    lblTotalAbsentDistrict.Text = TotalAbsent.ToString();
                    lblPercentageDistrict.Text = Percentage.ToString() + "%";
                }

            }
        }
    }
}