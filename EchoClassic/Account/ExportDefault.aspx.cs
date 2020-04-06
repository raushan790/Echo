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

namespace EchoClassic.Account
{
    public partial class ExportDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }
        private void bindGvAttendance()
        {
            try
            {
                string query = string.Empty;
                if (ddlOption.SelectedValue == "1")
                {
                    query = "select distinct owner as UDICE_Code, groupname as School from usergroups where ClientID=1 and owner not in (select distinct owner from UserGroups inner join attendance on UserGroups.GroupID = Attendance.GroupID where usergroups.ClientID = 1 and Attendance.AttendanceDate = '" + DateTime.Now.ToShortDateString() + "')";
                }
                if (ddlOption.SelectedValue == "2")
                {
                    query = "select distinct owner as UDICE_Code, groupname as School from usergroups where ClientID=1 and owner in (select distinct owner from UserGroups inner join attendance on UserGroups.GroupID = Attendance.GroupID where usergroups.ClientID = 1 and Attendance.AttendanceDate = '" + DateTime.Now.ToShortDateString() + "')";
                }
                if (ddlOption.SelectedValue == "3")
                {
                    query = "select distinct u.MobileNo as UDICE_Code,ug.GroupName as School  from Users u inner join UserGroups ug on u.MobileNo = ug.Owner where u.ChangedPassword = 0";
                }
                lblMessage.Text = "";
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView gv = new GridView();
                    gv.DataSource = dt;
                    gv.DataBind();
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "YourData.xls"));
                    Response.ContentType = "application/ms-excel";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    gv.RenderControl(htw);
                    Response.Write(sw.ToString());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                General.ShowAlertMessage("Invalid query! Please check your query.");
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            bindGvAttendance();
        }
    }
}