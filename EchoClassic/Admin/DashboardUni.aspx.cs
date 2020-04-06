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
    public partial class DashboardUni : System.Web.UI.Page
    {
        public int TotalClasses = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Context.User.Identity.IsAuthenticated)
            { Response.Redirect("~/Default?echotgt=" + Request.RawUrl); }
            if (!IsPostBack)
            {
                User u = new UserController().GetUser(Context.User.Identity.Name);
                if (u.Custom5 == "1" || u.UserGroup.FirstOrDefault().isAdmin == false)
                    General.ShowAlertMessage("You are not autorized!", "~/logout.aspx");
                imgGroup.ImageUrl = "../images/" + u.ClientID.ToString() + ".jpg";
                string Query = string.Format("Select OrganizationName from Clients where ID=" + u.ClientID + "");
                SqlCommand cmd = new SqlCommand(Query);
                String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                string ClientName = cmd.ExecuteScalar().ToString();
                con.Close();
                imgGroup.AlternateText = ClientName;
                litClientID.Text = u.ClientID.ToString();
                BindClass(u.ClientID);
                BindSubject(u.ClientID);
                BindAttendanceStatus(u.ClientID);
            }
        }
        private void BindClass(int ClientID)
        {
            string Query = string.Format("Select distinct groupname from usergroups where ClientID=" + ClientID + "");

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
            ListItem li = new ListItem("Select Group", "-1");
            ddlClass.Items.Add(li);
            ddlClass.SelectedValue = "-1";


        }
        private void BindSubject(int ClientID)
        {
            string Query = string.Format("Select distinct groupID, Description from usergroups where GroupName='" + ddlClass.SelectedValue + "' and ClientID=" + ClientID + " order by Description");

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
            ListItem li = new ListItem("Select Subgroup", "-1");
            ddlSubject.Items.Add(li);
            ddlSubject.SelectedValue = "-1";
        }
        private void BindAttendanceStatus(int ClientID)
        {
            gvAttendanceStatus.DataSource = null;
            gvAttendanceStatus.DataBind();
            gvAttendanceDetails.DataSource = null;
            gvAttendanceDetails.DataBind();

            string TotalClassesQuery = string.Format("Select  OverallClasses as CountTotalClasses from usergroups where ClientID=" + ClientID + " and groupid='" + ddlSubject.SelectedValue + "' ");


            String constr1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlCommand cmd1 = new SqlCommand(TotalClassesQuery);
            SqlConnection con1 = new SqlConnection(constr1);
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con1;
            con1.Open();
            try
            {
                TotalClasses = Convert.ToInt32(cmd1.ExecuteScalar());

            }
            catch
            {


            }
            con1.Close();
            if (TotalClasses == 0)
            {
                TotalClassesQuery = string.Format("Select  COUNT(distinct Attendance.AttendanceDate)as CountTotalClasses from attendance where ClientID=" + ClientID + " and groupid='" + ddlSubject.SelectedValue + "' ");
                cmd1 = new SqlCommand(TotalClassesQuery);
                con1 = new SqlConnection(constr1);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con1;
                con1.Open();
                TotalClasses = Convert.ToInt32(cmd1.ExecuteScalar());
                con1.Close();
            }

            string Query = string.Format("Select userid,udf2,groupid, COUNT(Attendance.UserID)as PresentCount from attendance where ClientID=" + ClientID + " and groupid='" + ddlSubject.SelectedValue + "' and AttendanceStatus='Present' group by Attendance.UserID,udf2,groupid");
            int datediff = 0;
            int changeQuery = 0;
            try
            {
                datediff = (Convert.ToDateTime(txtDateTo.Text) - Convert.ToDateTime(txtDateFrom.Text)).Days;
                changeQuery = 1;
            }
            catch
            {

            }
            if (datediff >= 0&& changeQuery==1)
            {
                Query = string.Format("Select userid,udf2,groupid, COUNT(Attendance.UserID)as PresentCount from attendance where ClientID=" + ClientID + " and groupid='" + ddlSubject.SelectedValue + "' and AttendanceDate>='" + Convert.ToDateTime(txtDateFrom.Text) + "' and AttendanceDate<='" + Convert.ToDateTime(txtDateTo.Text) + "' and AttendanceStatus='Present' group by Attendance.UserID,udf2,groupid");

            }
            SqlCommand cmd = new SqlCommand(Query);
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvAttendanceStatus.DataSource = ds;
            gvAttendanceStatus.DataBind();
        }


        protected void gvAttendanceStatus_Databound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTotalClasses = e.Row.FindControl("lblTotalClasses") as Label;
                LinkButton lblTotalPresent = e.Row.FindControl("lnkTotalPresent") as LinkButton;
                Label lblPercent = e.Row.FindControl("lblPercent") as Label;
                Label lblMin = e.Row.FindControl("lblMin") as Label;
                lblTotalClasses.Text = TotalClasses.ToString();
                double TotalPresent = Convert.ToDouble(lblTotalPresent.Text);
                double Per = 0;
                try
                {
                    Per = Math.Round((TotalPresent / Convert.ToDouble(TotalClasses)), 2) * 100;
                }
                catch
                {


                }
                if (Per < 75)
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                    e.Row.Font.Bold = true;
                    lblMin.Text = "No";
                }
                lblPercent.Text = Per.ToString();
            }

        }
        protected void ddlClassSelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubject(Convert.ToInt32(litClientID.Text));
            BindAttendanceStatus(Convert.ToInt32(litClientID.Text));
        }
        protected void ddlSubjectSelectedIndexChanged(object sender, EventArgs e)
        {
            BindAttendanceStatus(Convert.ToInt32(litClientID.Text));
        }

        protected void gvAttendanceStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gvAttendanceDetails.DataSource = null;
            gvAttendanceDetails.DataBind();
            if (e.CommandName == "ViewDetails")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lnkStudentName = (LinkButton)row.FindControl("lnkStudentName");
                litStudentName.Text = lnkStudentName.Text;
                string userID = e.CommandArgument.ToString();
                if (userID != string.Empty)
                {
                    string Query = string.Format("select AttendanceDate,AttendanceTime,Device,DeviceLocation as Location from attendance where attendancestatus='Present' and GroupID='" + Convert.ToInt32(ddlSubject.SelectedValue) + "' and UserID='" + userID + "'");
                    int datediff = 0;
                    try
                    {
                        datediff = (Convert.ToDateTime(txtDateTo.Text) - Convert.ToDateTime(txtDateFrom.Text)).Days;
                    }
                    catch
                    {

                    }
                    if (datediff > 0)
                    {
                        Query = string.Format("select AttendanceDate,AttendanceTime,Device,DeviceLocation as Location from attendance where attendancestatus='Present' and AttendanceDate>= '" + Convert.ToDateTime(txtDateFrom.Text) + "' and AttendanceDate<= '" + Convert.ToDateTime(txtDateTo.Text) + "' and GroupID='" + Convert.ToInt32(ddlSubject.SelectedValue) + "' and UserID='" + userID + "'");

                    }

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
        }

        protected void ToDateChanged(object sender, EventArgs e)
        {
            gvAttendanceStatus.DataSource = null;
            gvAttendanceStatus.DataBind();
            gvAttendanceDetails.DataSource = null;
            gvAttendanceDetails.DataBind();
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
            if (datediff > 0)
            {
                BindAttendanceStatus(Convert.ToInt32(litClientID.Text));
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
            gvAttendanceStatus.DataSource = null;
            gvAttendanceStatus.DataBind();
            gvAttendanceDetails.DataSource = null;
            gvAttendanceDetails.DataBind();
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
            if (datediff > 0)
            {
                BindAttendanceStatus(Convert.ToInt32(litClientID.Text));
            }
            else
            {
                if (showError == true)
                {
                    General.ShowAlertMessage("Please select the dates properly!");
                }

            }
        }
    }
}
