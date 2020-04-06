using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Account
{
    public partial class ImportAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Context.User.Identity.IsAuthenticated && Context.User.Identity.Name == "e1bb3a61-5bab-4b36-88ab-5c4920d57828")
            //{

            //}
            //else
            //{
            //    Response.Redirect("~/default");
            //}
        }
        public void UploadData(string ExcelFilePath, string SelectQuery, string SQLTableName)
        {
            string sexcelconnectionstring = @"provider=Microsoft.ACE.OLEDB.12.0;data source=" + ExcelFilePath + ";extended properties=" + "\"excel 12.0;hdr=yes;IMEX=1;\"";

            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(SelectQuery, oledbconn);
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            try
            {           
           
            SqlBulkCopy bulkcopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            bulkcopy.DestinationTableName = SQLTableName;
            while (dr.Read())
            {
                bulkcopy.WriteToServer(dr);
            }
            dr.Close();
            oledbconn.Close();
            }
            catch (Exception ex)
            {

                dr.Close();
                oledbconn.Close();
                throw ex;
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuUploadAttendance.HasFile)
            {
                if (fuUploadAttendance.FileName.EndsWith(".xls") || fuUploadAttendance.FileName.EndsWith(".xlsx"))
                {
                    fuUploadAttendance.PostedFile.SaveAs(Server.MapPath("~/AttendanceUpload/" + fuUploadAttendance.PostedFile.FileName));
                    string AttendanceFile = Server.MapPath("~/AttendanceUpload/" + fuUploadAttendance.PostedFile.FileName);
                    //var ConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties =Excel 12.0;", AttendanceFile);
                    //var adapter = new OleDbDataAdapter("select Name,Gender,Cast, Class,GroupName as School,Cluster,District,Block as Cluster,AttendanceDate,AttendanceStatus,Count from[Students$]", ConnectionString);

                    // make sure your sheet name is correct, here sheet name is sheet1, 
                    //so you can change your sheet name if have    different
                    string Studentexceldataquery = "select [Name],Gender,[Cast],Group as Class,GroupName as School,Cluster,District,Block as Division,AttendanceDate,AttendanceStatus,[Count],[UserID] from[Students$]";
                    string Teacherexceldataquery = "select [Name],Gender,[Cast],Group as Class,GroupName as School,Cluster,District,Block as Division,AttendanceDate,AttendanceStatus,[Count],[UserID] from[Teachers$]";
                    try
                    {

                        UploadData(AttendanceFile, Studentexceldataquery, "Analytics");
                        UploadData(AttendanceFile, Teacherexceldataquery, "AnalyticsTeacher");

                        General.ShowAlertMessage("Success");
                    }
                    catch (Exception ex)
                    {
                        General.ShowAlertMessage(ex.Message + " Something is wrong with file Please check and try again!");
                    }
                }
            }
            else
            {
                General.ShowAlertMessage("Please select a valid excel file!");
            }
        }
    }
}