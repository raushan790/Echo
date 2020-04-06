using BusinessObjects;
using Controllers;
using DataObjects.AdoNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Admin
{
    public partial class ExportAttendance : System.Web.UI.Page
    {
        public string CurrentDate = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            calEFromDate.EndDate = DateTime.UtcNow.AddHours(5.5);
            CalETodate.EndDate = DateTime.UtcNow.AddHours(5.5);
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

                    CurrentDate = DateTime.UtcNow.AddHours(5.5).ToShortDateString();


                    txtDateFrom.Text = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                    txtDateTo.Text = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                    LoadAttendanceSummeryForDateRange();
                    GetCountUsersChangedPassword();
                }
                else
                    Response.Redirect("~/Default?echotgt=" + Request.RawUrl);

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
                }
            }

        }
        protected void GetCountUsersChangedPassword()
        {
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ClientID", Convert.ToInt32(litClientID.Text));
            litInstallationReport.Text = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "SelectCountUsersChangedPassword", m).ToString();

        }

        private void bindGvAttendance()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("ExportNormalAttendance_betweenTwoDates", conn);
            cmd.Parameters.AddWithValue("@DateFrom", string.IsNullOrEmpty(txtDateFrom.Text) ? DateTime.MinValue : Convert.ToDateTime(txtDateFrom.Text));
            cmd.Parameters.AddWithValue("@DateTo", string.IsNullOrEmpty(txtDateTo.Text) ? DateTime.MinValue : Convert.ToDateTime(txtDateTo.Text).AddDays(1));
            cmd.Parameters.AddWithValue("@ClientId", litClientID.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvAttendance.DataSource = dt;
                gvAttendance.DataBind();
                pnlNormalAttendance.Visible = true;
                Button1.Visible = true;
            }
            else
            {
                
                gvAttendance.DataSource = null;
                gvAttendance.DataBind();
                pnlNormalAttendance.Visible = false;
                Button1.Visible = false;
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtDateFrom.Text == "")
            {
                General.ShowAlertMessage("Please select a start date");
                txtDateFrom.Focus();
            }
            else if (txtDateTo.Text == "")
            {
                General.ShowAlertMessage("Please select end date");
                txtDateTo.Focus();
            }

            else
            {
                int datediff = (Convert.ToDateTime(txtDateTo.Text) - Convert.ToDateTime(txtDateFrom.Text)).Days;
                if (datediff < 0)
                {
                    General.ShowAlertMessage("Please select the dates properly!");

                }
                else
                bindGvAttendance();
                BindCheckinCheckoutData();
            }

        }
        private void ExportCheckinCheckoutToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Attendance" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvCheckinCheckoutData.GridLines = GridLines.Both;
            gvCheckinCheckoutData.HeaderStyle.Font.Bold = true;
            gvCheckinCheckoutData.Columns[1].Visible = false;
            gvCheckinCheckoutData.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
            gvCheckinCheckoutData.Columns[1].Visible = true;
        }
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Attendance" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvAttendance.GridLines = GridLines.Both;
            gvAttendance.HeaderStyle.Font.Bold = true;
            gvAttendance.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ExportCheckinCheckoutToExcel();
        }

        private void BindCheckinCheckoutData()
        {
           
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("ExportCheckinCheckoutAttendanceBetweenDates", conn);
                cmd.Parameters.AddWithValue("@DateFrom", string.IsNullOrEmpty(txtDateFrom.Text) ? DateTime.MinValue : Convert.ToDateTime(txtDateFrom.Text));
                cmd.Parameters.AddWithValue("@DateTo", string.IsNullOrEmpty(txtDateTo.Text) ? DateTime.MinValue : Convert.ToDateTime(txtDateTo.Text).AddDays(1));
                cmd.Parameters.AddWithValue("@ClientId", litClientID.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                gvCheckinCheckoutData.DataSource = dt;
                gvCheckinCheckoutData.DataBind();
            
            
            pnlCheckinCheckout.Visible = false;
            Button2.Visible = false;
            if (gvCheckinCheckoutData.Rows.Count > 0)
            {
                pnlCheckinCheckout.Visible = true;
                Button2.Visible = true;
            }

        }
        protected void gvCheckinCheckoutData_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCheckin = e.Row.FindControl("lblCheckin") as Label;
                Label lblCheckout = e.Row.FindControl("lblCheckout") as Label;
                Label lblWorkingHours = e.Row.FindControl("lblWorkingHours") as Label;

                try
                {
                    int totalHour = Math.Abs((Convert.ToDateTime(lblCheckout.Text) - Convert.ToDateTime(lblCheckin.Text)).Hours);

                    int totalMin = Math.Abs((Convert.ToDateTime(lblCheckout.Text) - Convert.ToDateTime(lblCheckin.Text)).Minutes);
                    string LoginHours = totalHour + " Hour(s) " + totalMin + " Min(s)";
                    lblWorkingHours.Text = LoginHours;
                }
                catch
                {


                }

            }

        }

    }
}