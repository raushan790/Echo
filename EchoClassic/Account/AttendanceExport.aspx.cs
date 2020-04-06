using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace EchoClassic.Account
{
    public partial class AttendanceExport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/default?echotgt=" + Request.RawUrl);
            }
            if (!Page.IsPostBack)
            {
                bindddlClient();
            }
        }
        private void bindddlClient()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetAllClients", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlClients.DataSource = dt;
                ddlClients.DataTextField = "ClientName";
                ddlClients.DataValueField = "ClientID";
                ddlClients.DataBind();
            }
        }
        private void bindGvAttendance()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("ExportAttendance_betweenTwoDates", conn);
            cmd.Parameters.AddWithValue("@DateFrom", string.IsNullOrEmpty(txtdtFrom.Text) ? DateTime.MinValue : Convert.ToDateTime(txtdtFrom.Text));
            cmd.Parameters.AddWithValue("@DateTo", string.IsNullOrEmpty(txtdtTo.Text) ? DateTime.MinValue : Convert.ToDateTime(txtdtTo.Text));
            cmd.Parameters.AddWithValue("@ClientId", ddlClients.SelectedItem.Value);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvAttendance.DataSource = dt;
                gvAttendance.DataBind();
            }
            else
            {
                General.ShowAlertMessage("No Data Found !");
                gvAttendance.DataSource = null;
                gvAttendance.DataBind();
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtdtFrom.Text == "")
            {
                General.ShowAlertMessage("Please select a start date");
                txtdtFrom.Focus();
            }
            else if (txtdtTo.Text == "")
            {
                General.ShowAlertMessage("Please select end date");
                txtdtTo.Focus();
            }
            else
            {
                bindGvAttendance();
            }

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
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    //To Export all pages
            //    gvAttendance.AllowPaging = false;
            //    this.bindGvAttendance();

            //    gvAttendance.HeaderRow.BackColor = Color.White;
            //    foreach (TableCell cell in gvAttendance.HeaderRow.Cells)
            //    {
            //        cell.BackColor = gvAttendance.HeaderStyle.BackColor;
            //    }
            //    foreach (GridViewRow row in gvAttendance.Rows)
            //    {
            //        row.BackColor = Color.White;
            //        foreach (TableCell cell in row.Cells)
            //        {
            //            if (row.RowIndex % 2 == 0)
            //            {
            //                cell.BackColor = gvAttendance.AlternatingRowStyle.BackColor;
            //            }
            //            else
            //            {
            //                cell.BackColor = gvAttendance.RowStyle.BackColor;
            //            }
            //            cell.CssClass = "textmode";
            //        }
            //    }

            //    //gvAttendance.RenderControl(hw);

            //    //style to format numbers to string
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
        }
    }
}

