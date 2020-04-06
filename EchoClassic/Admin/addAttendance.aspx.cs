using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace EchoClassic.Admin
{
    public partial class addAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(fuAddAttendance.PostedFile.FileName);
            fuAddAttendance.SaveAs(excelPath);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] {
                new DataColumn("No", typeof(int)),
                new DataColumn("TmNo", typeof(int)),
                new DataColumn("EnNo", typeof(int)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("InOut", typeof(int)),
                new DataColumn("Mode", typeof(int)),
                new DataColumn("Datetime", typeof(DateTime)),
                new DataColumn("Client", typeof(int)) });
            string csvData = File.ReadAllText(excelPath);
            bool isHeader = true;
            try { 
            foreach (string row in csvData.Split('\n'))
            {
                if (isHeader) { isHeader = false; continue; }
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }
            }catch(Exception ex)
            {
                General.ShowAlertMessage("Something went wrong while processing your file. Please check the file and try again");
                return;
            }
            //btnUpload.Text = "Total: "+dt.Rows.Count;
            DataTable fdt = new DataTable();
            fdt.Columns.AddRange(new DataColumn[15] {
                new DataColumn("AttendanceDate", typeof(DateTime)),
                new DataColumn("UserID", typeof(string)),
                new DataColumn("GroupID", typeof(int)),
                new DataColumn("AttendanceStatus", typeof(string)),
                new DataColumn("CreateDate", typeof(DateTime)),
                new DataColumn("UDF1", typeof(string)),
                new DataColumn("UDF2", typeof(string)),
                new DataColumn("UDF3", typeof(string)),
                new DataColumn("AttendanceTime", typeof(string)),
                new DataColumn("Device", typeof(string)),
                new DataColumn("DeviceIDOrName", typeof(string)),
                new DataColumn("DeviceLocation", typeof(string)),
                new DataColumn("Session", typeof(string)),
                new DataColumn("ClientID", typeof(int)),
                new DataColumn("ValidatedForFlowType5", typeof(bool)) });
            var groups = from DataRow dr in dt.Rows group dr by dr["Client"] into g select g;
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            foreach (var item in groups)
            {
                string userid = "", fname = "", session = "";
                int clientid= Convert.ToInt32(item.Key.ToString()) ;// item.FirstOrDefault().Field<int>("client");
                var eGroup = item.GroupBy(row => row["EnNo"].ToString());
                foreach (var eItem in eGroup)
                {

                
                string id = eItem.Key.ToString();
                string Query = string.Format("Select top 1 convert(nvarchar(50), UserId) as UserId, coalesce(FirstName,'') as FirstName, coalesce(Session,'') as Session from Users where Custom1='" + id + "' and ClientId="+ clientid+"");
                SqlCommand cmd = new SqlCommand(Query,con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userid = reader.GetString(0).ToString();
                    fname = reader.GetString(1).ToString();
                    session = reader.GetString(2).ToString();
                }
                reader.Close();
                if(userid!="" && fname != "") { 
                var group2 = eItem.OrderBy(r => r["Datetime"]).GroupBy(row => Convert.ToDateTime(row["Datetime"]).ToString("dd/MM/yyyy"));
                foreach (var g2 in group2)
                {
                    var list = g2.ToList();
                    var startDate = Convert.ToDateTime(list[0]["Datetime"]);
                    DataRow dr = fdt.NewRow();
                    dr["AttendanceDate"] = startDate.Date;//.ToString("yyyy-MM-dd");
                    dr["UserID"] = userid;
                    dr["GroupID"] = 0;
                    dr["AttendanceStatus"] = "Checkin";
                    dr["CreateDate"] = DateTime.Now;
                    dr["UDF1"] = "1";
                    dr["UDF2"] = fname;
                    dr["UDF3"] = fname;
                    dr["AttendanceTime"] = startDate.ToString("HH:mm:ss t");
                    dr["Device"] = "Biometric";
                    dr["DeviceIDOrName"] = "";
                    dr["DeviceLocation"] = "";
                    dr["Session"] = session;
                    dr["ClientID"] = clientid;
                    dr["ValidatedForFlowType5"] = false;
                    fdt.Rows.Add(dr);
                    if (list.Count > 1)
                    {
                        var endDate = Convert.ToDateTime(list[list.Count - 1]["Datetime"]);
                        //var d1 = item.AsEnumerable().OrderByDescending(x => Convert.ToDateTime(x["Datetime"])).Select(x => x).FirstOrDefault();
                        DataRow dr1 = fdt.NewRow();
                        dr1["AttendanceDate"] = endDate.Date;//.ToString("yyyy-MM-dd HH:mm:ss");
                        dr1["UserID"] = userid;
                        dr1["GroupID"] = 0;
                        dr1["AttendanceStatus"] = "Checkout";
                        dr1["CreateDate"] = DateTime.Now;
                        dr1["UDF1"] = "1";
                        dr1["UDF2"] = fname;
                        dr1["UDF3"] = fname;
                        dr1["AttendanceTime"] = endDate.ToString("HH:mm:ss t");
                        dr1["Device"] = "Biometric";
                        dr1["DeviceIDOrName"] = "";
                        dr1["DeviceLocation"] = "";
                        dr1["Session"] = session;
                        dr1["ClientID"] = clientid;
                        dr1["ValidatedForFlowType5"] = false;
                        fdt.Rows.Add(dr1);
                    }
                    continue;
                }
            
                }
                }
            }
            //con.Close();
            //return;
            //using (SqlConnection con = new SqlConnection(consString))
            //{
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set the database table name
                sqlBulkCopy.DestinationTableName = "dbo.attendance";

                //[OPTIONAL]: Map the Excel columns with that of the database table
                sqlBulkCopy.ColumnMappings.Add("AttendanceDate", "AttendanceDate");
                sqlBulkCopy.ColumnMappings.Add("UserID", "UserID");
                sqlBulkCopy.ColumnMappings.Add("GroupID", "GroupID");
                sqlBulkCopy.ColumnMappings.Add("AttendanceStatus", "AttendanceStatus");
                sqlBulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
                sqlBulkCopy.ColumnMappings.Add("UDF1", "UDF1");
                sqlBulkCopy.ColumnMappings.Add("UDF2", "UDF2");
                sqlBulkCopy.ColumnMappings.Add("UDF3", "UDF3");
                sqlBulkCopy.ColumnMappings.Add("AttendanceTime", "AttendanceTime");
                sqlBulkCopy.ColumnMappings.Add("Device", "Device");
                sqlBulkCopy.ColumnMappings.Add("DeviceIDOrName", "DeviceIDOrName");
                sqlBulkCopy.ColumnMappings.Add("DeviceLocation", "DeviceLocation");
                sqlBulkCopy.ColumnMappings.Add("Session", "Session");
                sqlBulkCopy.ColumnMappings.Add("ClientID", "ClientID");
                sqlBulkCopy.ColumnMappings.Add("ValidatedForFlowType5", "ValidatedForFlowType5");
                //con.Open();
                sqlBulkCopy.WriteToServer(fdt);
                con.Close();
            }
            General.ShowAlertMessage("Attendance successfully imported");
            //}
            //}

        }
    }
}