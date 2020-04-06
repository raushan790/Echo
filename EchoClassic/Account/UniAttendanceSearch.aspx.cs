
using System;
using DataObjects.AdoNet;
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

namespace EchoClassic.Account
{
    public partial class UniAttendanceSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClass();
                BindSubject();
                BindAttendanceStatus();
            }
        }

        private void BindClass()
        {
            string Query = string.Format("Select distinct groupname from usergroups where ClientID=2");

            SqlCommand cmd = new SqlCommand(Query);
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlClass.DataSource = ds.Tables[0];
            ddlClass.DataValueField = "groupname";
            ddlClass.DataTextField = "groupname";
            ddlClass.DataBind();


        }
        private void BindSubject()
        {
            string Query = string.Format("Select distinct groupID, Description from usergroups where GroupName='" + ddlClass.SelectedValue + "' and ClientID=2 order by Description");

            SqlCommand cmd = new SqlCommand(Query);
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlSubject.DataSource = ds.Tables[0];

            ddlSubject.DataValueField = "groupID";
            ddlSubject.DataTextField = "Description";
            ddlSubject.DataBind();
        }
        protected void ddlClassSelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject();
            BindAttendanceStatus();
        }
        protected void ddlSubjectSelectedIndexChanged(object sender, EventArgs e)
        {
            BindAttendanceStatus();
        }

        private void BindAttendanceStatus()
        {
            if (txtDate.Text != string.Empty)
            {
                gvAttendanceDetails.DataSource = null;
                gvAttendanceDetails.DataBind();


                string Query = string.Format("select UserID,UDF2,AttendanceStatus,AttendanceTime,Device,DeviceLocation as Location from attendance where GroupID='" + Convert.ToInt32(ddlSubject.SelectedValue) + "' and AttendanceDate='" + DateTime.Parse(txtDate.Text) + "'");

                SqlCommand cmd = new SqlCommand(Query);
                String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvAttendanceDetails.DataSource = ds;
                gvAttendanceDetails.DataBind();

            }
        }
        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDate.Text != "")
            {
                try
                {
                    if (txtDate.Text != string.Empty)
                    {
                        BindAttendanceStatus();
                    }
                }
                catch
                {

                }
            }
        }
    }
}