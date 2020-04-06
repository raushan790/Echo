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

namespace EchoClassic
{
    public partial class AttendanceExportPaging : System.Web.UI.Page
    {
        private static int PageSize = 10000;
        private static decimal Count;
        public static int CurrentPage;
        private static int TotalPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/default");
            }
            if (!IsPostBack)
            {
                pagenavigation.Visible = false;
                CurrentPage = 1;
            }
                //    CurrentPage = 1;

                //    if (PageID > 0)
                //    {
                //        CurrentPage = PageID;
                //        bindGvAttendance(PageID);
                //    }
                //    else
                //        bindGvAttendance(CurrentPage);

                //    gvAttendance.PageSize = PageSize;
                //    LoadPageing();
                //}
            }
        private void LoadPageing()
        {
            int PCount = TotalPage;
            lblPages.Text = PCount.ToString();
            DDLPage.Items.Clear();
            for (int i = 0; i < PCount; i++)
            {
                int pageNumber = i + 1;
                ListItem item = new ListItem(pageNumber.ToString(), pageNumber.ToString());
                if (i == (CurrentPage - 1))
                {
                    item.Selected = true;
                }
                DDLPage.Items.Add(item);
            }

            if (CurrentPage == 1 && PCount > 1)
            {
                btnFirst.Enabled = false;
                btnFirst.Visible = false;
                btnPrev.Enabled = false;
                btnPrev.Visible = false;
                btnLast.Enabled = true;
                btnLast.Visible = true;
                btnNext.Enabled = true;
                btnNext.Visible = true;
            }
            else if (CurrentPage == PCount && PCount > 1)
            {
                btnFirst.Enabled = true;
                btnFirst.Visible = true;
                btnPrev.Enabled = true;
                btnPrev.Visible = true;

                btnLast.Enabled = false;
                btnLast.Visible = false;
                btnNext.Enabled = false;
                btnNext.Visible = false;
            }
            else if (CurrentPage == PCount && PCount == 1)
            {
                btnFirst.Enabled = false;
                btnFirst.Visible = false;
                btnPrev.Enabled = false;
                btnPrev.Visible = false;

                btnLast.Enabled = false;
                btnLast.Visible = false;
                btnNext.Enabled = false;
                btnNext.Visible = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnFirst.Visible = true;
                btnPrev.Enabled = true;
                btnPrev.Visible = true;

                btnLast.Enabled = true;
                btnLast.Visible = true;
                btnNext.Enabled = true;
                btnNext.Visible = true;
            }
        }
        public int PageID
        {
            get
            {
                return General.QueryStringInt("PageID");
            }
        }
        private void bindGvAttendance(int _PageIndex)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("ExportAttendance_betweenTwoDates1", conn);
            cmd.Parameters.AddWithValue("@DateFrom", string.IsNullOrEmpty(txtdtFrom.Text) ? DateTime.MinValue : Convert.ToDateTime(txtdtFrom.Text));
            cmd.Parameters.AddWithValue("@DateTo", string.IsNullOrEmpty(txtdtTo.Text) ? DateTime.MinValue : Convert.ToDateTime(txtdtTo.Text));
            cmd.Parameters.AddWithValue("@PageIndex", _PageIndex);
            cmd.Parameters.AddWithValue("@PageSize", PageSize);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                int pageCount = Convert.ToInt32(dt.Rows[1]["totalrecord"]);
                Count = Convert.ToDecimal(pageCount / PageSize);
                decimal pageModulas = Convert.ToDecimal(pageCount % PageSize);

                if (pageModulas > 0)
                {
                    Count++;
                }

                TotalPage = Convert.ToInt32(Count);
                
                 
                gvAttendance.DataSource = dt;
                gvAttendance.DataBind();
                if (pageCount > PageSize)
                {
                    pagenavigation.Visible = true;
                    LoadPageing();
                }
            }
            else
            {
                 pagenavigation.Visible = false;
                General.ShowAlertMessage("No Data Found !");
                gvAttendance.DataSource = null;
                gvAttendance.DataBind();
            }

        }

        protected void DDLPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPage = Convert.ToInt32(DDLPage.SelectedIndex) + 1;
            bindGvAttendance(CurrentPage);
            LoadPageing();
        }



        //for Previous pages
        protected void btnPrev_OnClick(object sender, EventArgs e)
        {
            if ((CurrentPage - 1) <= TotalPage && CurrentPage > 1)
            {
                CurrentPage = CurrentPage - 1;
                bindGvAttendance(CurrentPage);
                LoadPageing();
            }
        }

        //for next page
        protected void btnNext_OnClick(object sender, EventArgs e)
        {
            if ((CurrentPage + 1) <= TotalPage)
            {
                CurrentPage = CurrentPage + 1;
                bindGvAttendance(CurrentPage);
                LoadPageing();
            }
        }

        // for First Page
        protected void btnFirst_OnClick(object sender, EventArgs e)
        {
            CurrentPage = 1;
            bindGvAttendance(CurrentPage);
            LoadPageing();
        }

        // for Last Page
        protected void btnLast_OnClick(object sender, EventArgs e)
        {
            CurrentPage = TotalPage;
            bindGvAttendance(CurrentPage);
            LoadPageing();
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
                bindGvAttendance(1);
                LoadPageing();
            }

        }

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Attendance for date" + DateTime.Now + ".xls";
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