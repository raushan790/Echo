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
    public partial class Dashboard : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                CurrentDate = DateTime.Now.ToShortDateString();
            }
        }

        public string MaleSeries = string.Empty;
        public string FemaleSeries = string.Empty;
        private void BindTop5(DashboardSummary d)
        {
            IList<KeyValue> topFive = d.TopFive;// new KeyValueController().GetTopFiveSchoolForADate(Convert.ToDateTime(txtDate.Text),Convert.ToInt32(Session["ClientID"]));
            if (topFive.Count > 0)
            {
                Top1 = topFive.FirstOrDefault().Key;
                if (topFive.Count > 1)
                { Top2 = topFive[1].Key; }
                if (topFive.Count > 2)
                {
                    Top3 = topFive[2].Key;
                }
                if (topFive.Count > 3)
                {
                    Top4 = topFive[3].Key;
                }
                if (topFive.Count > 4)
                {
                    Top5 = topFive[4].Key;
                }

                divTopFive.Visible = true;
            }

        }

        private void BindBottom5(DashboardSummary d)
        {
            IList<KeyValue> BottomFive = d.BottomFive;// new KeyValueController().GetBottomFiveSchoolForADate(Convert.ToDateTime(txtDate.Text),Convert.ToInt32(Session["ClientID"]));
            if (BottomFive.Count > 0)
            {
                Bottom1 = BottomFive.FirstOrDefault().Key;
                if (BottomFive.Count > 1)
                {
                    Bottom2 = BottomFive[1].Key;
                }
                if (BottomFive.Count > 2)
                {
                    Bottom3 = BottomFive[2].Key;
                }
                if (BottomFive.Count > 3)
                {
                    Bottom4 = BottomFive[3].Key;
                }
                if (BottomFive.Count > 4)
                {
                    Bottom5 = BottomFive[4].Key;
                }
                divBottom5.Visible = true;
            }

        }
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

        public string CasteSeries = string.Empty;
        private void BindCasteChart(DashboardSummary d)
        {
          //  System.Text.StringBuilder sbGen = new System.Text.StringBuilder();
          //  System.Text.StringBuilder sbObc = new System.Text.StringBuilder();
          //  System.Text.StringBuilder sbSC = new System.Text.StringBuilder();
          //  System.Text.StringBuilder sbST = new System.Text.StringBuilder();
          //  System.Text.StringBuilder sbMinority = new System.Text.StringBuilder();
          //  System.Text.StringBuilder sbOther = new System.Text.StringBuilder();
          ////  IList<KeyValue> CastWiseDataForADate = d.Caste;// new KeyValueController().GetCastWiseDataForADate(Convert.ToDateTime(txtDate.Text), Convert.ToInt32(Session["ClientID"]));
          //  int TotalStudents = TotalStudentsPresentonDate;
          //  if (TotalStudents > 0)
          //  {
          //      double TotalGen = 0;
          //      try
          //      {
          //          TotalGen = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "Gen") == null) ? 0 :
          //                         Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "Gen").FirstOrDefault().Value));
          //      }
          //      catch
          //      {
          //      }
          //      double GenPercentage = Math.Round((TotalGen * 100 / TotalStudents));

          //      double TotalObc = 0;
          //      try
          //      {
          //          TotalObc = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "OBC") == null) ? 0 :
          //           Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "OBC").FirstOrDefault().Value));
          //      }
          //      catch
          //      {
          //      }

          //      double ObcPercentage = Math.Round((TotalObc * 100 / TotalStudents));
          //      double TotalSC = 0;
          //      try
          //      {
          //          TotalSC = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "SC") == null) ? 0 :
          //           Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "SC").FirstOrDefault().Value));
          //      }
          //      catch
          //      {
          //      }

          //      double SCPercentage = Math.Round((TotalSC * 100 / TotalStudents));
          //      double TotalST = 0;
          //      try
          //      {
          //          TotalST = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "ST") == null) ? 0 :
          //           Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "ST").FirstOrDefault().Value));
          //      }
          //      catch
          //      {
          //      }

          //      double STPercentage = Math.Round((TotalST * 100 / TotalStudents));
          //      double TotalMinority = 0;
          //      try
          //      {
          //          TotalMinority = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "Minority") == null) ? 0 :
          //                         Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "Minority").FirstOrDefault().Value));
          //      }
          //      catch
          //      {
          //      }

          //      double MinorityPercentage = Math.Round((TotalMinority * 100 / TotalStudents));

          //      double TotalOther = 0;
          //      try
          //      {
          //          TotalOther = Convert.ToDouble((CastWiseDataForADate.Where(ss => ss.Key == "Other") == null) ? 0 :
          //                 Convert.ToInt32(CastWiseDataForADate.Where(ss => ss.Key == "Other").FirstOrDefault().Value));
          //      }
          //      catch
          //      {
          //      }

          //      double OtherPercentage = Math.Round((TotalOther * 100 / TotalStudents));

          //      sbGen.Append(",['Gen', " + GenPercentage + "]");
          //      sbObc.Append(",['Obc', " + ObcPercentage + "]");
          //      sbSC.Append(",['SC', " + SCPercentage + "]");
          //      sbST.Append(",['ST', " + STPercentage + "]");
          //      sbMinority.Append(",['Minority', " + MinorityPercentage + "]");
          //      sbOther.Append(",['Other', " + OtherPercentage + "]");

          //      CasteSeries = "[" + sbGen.ToString() + "" + sbObc.ToString() + "" + sbSC.ToString() + "" + sbST.ToString() + "" + sbMinority.ToString() + "" + sbOther.ToString() + "]";
          //  }

        }

        private void BindDistrictData(DashboardSummary d)
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
            //SqlParameter[] m = new SqlParameter[1];
            //m[0] = new SqlParameter("@Date", txtDate.Text);

            //DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelTotalStudentForADate", m).Tables[0];
            //DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelTotalStudentPresentForADate", m).Tables[0];
            //DataTable ds2 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelTotalTeacherForADate", m).Tables[0];
            //DataTable ds3 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelTotalTeacherPresentForADate", m).Tables[0];
            //ds.PrimaryKey = new DataColumn[] { ds.Columns["District"] };
            //ds1.PrimaryKey = new DataColumn[] { ds1.Columns["District"] };
            //ds2.PrimaryKey = new DataColumn[] { ds2.Columns["District"] };
            //ds3.PrimaryKey = new DataColumn[] { ds3.Columns["District"] };
            //ds.Merge(ds1);
            //ds.Merge(ds2);
            //ds.Merge(ds3);
           // gvDistrictLevel.DataSource = d.DistrictLevelData;
            gvDistrictLevel.DataBind();
        }

        private void BindTrendLineChart(DashboardSummary d)
        {
            System.Text.StringBuilder sbPresent = new System.Text.StringBuilder();
            System.Text.StringBuilder sbDates = new System.Text.StringBuilder();

            
            List<FilterAttendance> ds = d.Trends;// SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesForTrends", m).Tables[0];
            
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
            //if (txtDate.Text != "")
            //{
            //    DashboardSummary d = new AnalyticsController().GetDashboardSummary(Convert.ToDateTime(txtDate.Text),Convert.ToInt32(Session["ClientID"]));
            //    if (d!=null)
            //    {
            //        TotalStudentsonDate = string.IsNullOrEmpty(d.TotalStudents) ? 0 : Convert.ToInt32(d.TotalStudents);
            //        TotalMaleonDate = Convert.ToInt32(d.TotalMale);
            //        TotalFemaleonDate = Convert.ToInt32(d.TotalFemale);
            //        TotalStudentsPresentonDate = Convert.ToInt32(d.TotalStudentsPresent);
            //        TotalMalePresentonDate = Convert.ToInt32(d.TotalMalePresent);
            //        TotalFemalePresentonDate = Convert.ToInt32(d.TotalFemalePresent);
            //        TotalDistrictonDate = Convert.ToInt32(d.TotalDistrict);
            //        TotalSchoolonDate = Convert.ToInt32(d.TotalSchool);
            //        TotalTeacheronDate = Convert.ToInt32(d.TotalTeachers);
            //        TotalTeacherPresentonDate = Convert.ToInt32(d.TotalTeachersPresent);
            //        BindGraph(d);
            //        BindGraphTeacher(d);
            //        BindGenderChart(d);
            //        BindCasteChart(d);
            //        BindTop5(d);
            //        BindBottom5(d);
            //        gvDistrictLevel.DataSource = null;
            //        gvDistrictLevel.DataBind();
            //        BindDistrictData(d);
            //    }
                
                
            //    BindTrendLineChart(d);
            //    BindTrendLineChartTeacher(d);
                
            //}
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
                Label lblTotalTeacherDistrict = e.Row.FindControl("lblTotalTeacherDistrict") as Label;
                Label lblTotalTeacherPresentDistrict = e.Row.FindControl("lblTotalTeacherPresentDistrict") as Label;
                Label lblTotalTeacherAbsentDistrict = e.Row.FindControl("lblTotalTeacherAbsentDistrict") as Label;
                Label lblPercentageTeacherDistrict = e.Row.FindControl("lblPercentageTeacherDistrict") as Label;

                try
                {

                    lblTotalTeacherAbsentDistrict.Text = Convert.ToString(Convert.ToInt32(lblTotalTeacherDistrict.Text) - Convert.ToInt32(lblTotalTeacherPresentDistrict.Text));
                    lblPercentageTeacherDistrict.Text = Convert.ToString(Math.Round((Convert.ToDouble(lblTotalTeacherPresentDistrict.Text) * 100) / Convert.ToDouble(lblTotalTeacherDistrict.Text), 2));

                }
                catch
                {


                }

                // lblTotalStudentDistrict.Text = TotalStudents.ToString();
                // lblTotalPresentDistrict.Text = TotalPresent.ToString();

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

                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@Date", txtDate.Text);
                m[1] = new SqlParameter("@District", litDistrict.Text);
                m[2] = new SqlParameter("@ClientID", Convert.ToInt32(Session["ClientID"]));
                DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BlockLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BlockLevelTotalStudentPresentForADate", m).Tables[0];
                DataTable ds2 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BlockLevelTotalTeacherForADate", m).Tables[0];
                DataTable ds3 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BlockLevelTotalTeacherPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["Block"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["Block"] };
                ds2.PrimaryKey = new DataColumn[] { ds2.Columns["Block"] };
                ds3.PrimaryKey = new DataColumn[] { ds3.Columns["Block"] };
                ds.Merge(ds1);
                ds.Merge(ds2);
                ds.Merge(ds3);
                gvBlockLevel.DataSource = ds;
                gvBlockLevel.DataBind();
            }
        }
        protected void gvBlockLevel_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblTotalStudentBlock = e.Row.FindControl("lblTotalStudentBlock") as Label;
                Label lblTotalPresentBlock = e.Row.FindControl("lblTotalPresentBlock") as Label;
                Label lblTotalAbsentBlock = e.Row.FindControl("lblTotalAbsentBlock") as Label;
                Label lblPercentageBlock = e.Row.FindControl("lblPercentageBlock") as Label;
                try
                {
                    lblTotalAbsentBlock.Text = Convert.ToString(Convert.ToInt32(lblTotalStudentBlock.Text) - Convert.ToInt32(lblTotalPresentBlock.Text));
                    lblPercentageBlock.Text = Convert.ToString(Math.Round((Convert.ToDouble(lblTotalPresentBlock.Text) * 100) / Convert.ToDouble(lblTotalStudentBlock.Text), 2));
                }
                catch
                {
                }

                try
                {
                    Label lblTotalTeacherBlock = e.Row.FindControl("lblTotalTeacherBlock") as Label;
                    Label lblTotalTeacherPresentBlock = e.Row.FindControl("lblTotalTeacherPresentBlock") as Label;
                    Label lblTotalTeacherAbsentBlock = e.Row.FindControl("lblTotalTeacherAbsentBlock") as Label;
                    Label lblPercentageTeacherBlock = e.Row.FindControl("lblPercentageTeacherBlock") as Label;

                    lblTotalTeacherAbsentBlock.Text = Convert.ToString(Convert.ToInt32(lblTotalTeacherBlock.Text) - Convert.ToInt32(lblTotalTeacherPresentBlock.Text));
                    lblPercentageTeacherBlock.Text = Convert.ToString(Math.Round((Convert.ToDouble(lblTotalTeacherPresentBlock.Text) * 100) / Convert.ToDouble(lblTotalTeacherBlock.Text), 2));

                }
                catch
                {


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
                SqlParameter[] m = new SqlParameter[4];
                m[0] = new SqlParameter("@Date", txtDate.Text);
                m[1] = new SqlParameter("@District", litDistrict.Text);
                m[2] = new SqlParameter("@Block", litBlock.Text);
                m[3] = new SqlParameter("@ClientID", Convert.ToInt32(Session["ClientID"]));
                DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClusterLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClusterLevelTotalStudentPresentForADate", m).Tables[0];
                DataTable ds2 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClusterLevelTotalTeacherForADate", m).Tables[0];
                DataTable ds3 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClusterLevelTotalTeacherPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["Cluster"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["Cluster"] };
                ds2.PrimaryKey = new DataColumn[] { ds2.Columns["Cluster"] };
                ds3.PrimaryKey = new DataColumn[] { ds3.Columns["Cluster"] };
                ds.Merge(ds1);
                ds.Merge(ds2);
                ds.Merge(ds3);
                gvClusterLevel.DataSource = ds;
                gvClusterLevel.DataBind();
            }
        }
        protected void gvClusterLevel_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblTotalStudentCluster = e.Row.FindControl("lblTotalStudentCluster") as Label;
                Label lblTotalPresentCluster = e.Row.FindControl("lblTotalPresentCluster") as Label;
                Label lblTotalAbsentCluster = e.Row.FindControl("lblTotalAbsentCluster") as Label;
                Label lblPercentageCluster = e.Row.FindControl("lblPercentageCluster") as Label;
                try
                {
                    lblTotalAbsentCluster.Text = Convert.ToString(Convert.ToInt32(lblTotalStudentCluster.Text) - Convert.ToInt32(lblTotalPresentCluster.Text));
                    lblPercentageCluster.Text = Convert.ToString(Math.Round((Convert.ToDouble(lblTotalPresentCluster.Text) * 100) / Convert.ToDouble(lblTotalStudentCluster.Text), 2));
                }
                catch
                {
                }
                Label lblTotalTeacherCluster = e.Row.FindControl("lblTotalTeacherCluster") as Label;
                Label lblTotalTeacherPresentCluster = e.Row.FindControl("lblTotalTeacherPresentCluster") as Label;
                Label lblTotalTeacherAbsentCluster = e.Row.FindControl("lblTotalTeacherAbsentCluster") as Label;
                Label lblPercentageTeacherCluster = e.Row.FindControl("lblPercentageTeacherCluster") as Label;

                try
                {

                    lblTotalTeacherAbsentCluster.Text = Convert.ToString(Convert.ToInt32(lblTotalTeacherCluster.Text) - Convert.ToInt32(lblTotalTeacherPresentCluster.Text));
                    lblPercentageTeacherCluster.Text = Convert.ToString(Math.Round((Convert.ToDouble(lblTotalTeacherPresentCluster.Text) * 100) / Convert.ToDouble(lblTotalTeacherCluster.Text), 2));

                }
                catch
                {


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
                SqlParameter[] m = new SqlParameter[5];
                m[0] = new SqlParameter("@Date", txtDate.Text);
                m[1] = new SqlParameter("@District", litDistrict.Text);
                m[2] = new SqlParameter("@Block", litBlock.Text);
                m[3] = new SqlParameter("@Cluster", litCluster.Text);
                m[4] = new SqlParameter("@ClientID", Convert.ToInt32(Session["ClientID"]));
                DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SchoolLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SchoolLevelTotalStudentPresentForADate", m).Tables[0];
                DataTable ds2 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SchoolLevelTotalTeacherForADate", m).Tables[0];
                DataTable ds3 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SchoolLevelTotalTeacherPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["GroupName"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["GroupName"] };
                ds2.PrimaryKey = new DataColumn[] { ds2.Columns["GroupName"] };
                ds3.PrimaryKey = new DataColumn[] { ds3.Columns["GroupName"] };
                ds.Merge(ds1);
                ds.Merge(ds2);
                ds.Merge(ds3);
                gvSchoolLevel.DataSource = ds;
                gvSchoolLevel.DataBind();
            }
        }
        protected void gvSchoolLevel_Databound(object sender, GridViewRowEventArgs e)
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
                Label lblTotalTeacherDistrict = e.Row.FindControl("lblTotalTeacherDistrict") as Label;
                Label lblTotalTeacherPresentDistrict = e.Row.FindControl("lblTotalTeacherPresentDistrict") as Label;
                Label lblTotalTeacherAbsentDistrict = e.Row.FindControl("lblTotalTeacherAbsentDistrict") as Label;
                Label lblPercentageTeacherDistrict = e.Row.FindControl("lblPercentageTeacherDistrict") as Label;

                try
                {

                    lblTotalTeacherAbsentDistrict.Text = Convert.ToString(Convert.ToInt32(lblTotalTeacherDistrict.Text) - Convert.ToInt32(lblTotalTeacherPresentDistrict.Text));
                    lblPercentageTeacherDistrict.Text = Convert.ToString(Math.Round((Convert.ToDouble(lblTotalTeacherPresentDistrict.Text) * 100) / Convert.ToDouble(lblTotalTeacherDistrict.Text), 2));

                }
                catch
                {


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

                SqlParameter[] m = new SqlParameter[6];
                m[0] = new SqlParameter("@Date", txtDate.Text);
                m[1] = new SqlParameter("@District", litDistrict.Text);
                m[2] = new SqlParameter("@Block", litBlock.Text);
                m[3] = new SqlParameter("@Cluster", litCluster.Text);
                m[4] = new SqlParameter("@GroupName", litScholl.Text);
                m[5] = new SqlParameter("@ClientID", Convert.ToInt32(Session["ClientID"]));
                DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClassLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClassLevelTotalStudentPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["Description"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["Description"] };

                ds.Merge(ds1);

                gvClassLevel.DataSource = ds;
                gvClassLevel.DataBind();
            }
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
    }
}
