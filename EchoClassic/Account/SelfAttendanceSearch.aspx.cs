
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
    public partial class SelfAttendanceSearch : System.Web.UI.Page
    {
        public double PerAbsent = 0.0;
        public double PerPresent = 0.0;
        public double TotalClasses = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // string ss = Encryption.Decrypt("3KWwZcjy36E=");
            if (!Context.User.Identity.IsAuthenticated || Context.User.Identity.Name == string.Empty)
                Response.Redirect("~/default?echotgt=" + Request.RawUrl);
            if (!IsPostBack)
            {
                try
                {


                    User u = new UserController().GetUser(Context.User.Identity.Name);
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
                    litUserName.Text = u.FirstName;
                    BindClass(u.ClientID);
                    BindSubject(u.ClientID);
                    BindAttendanceStatus();
                }
                catch (Exception)
                {

                    General.ShowAlertMessage("Please check if you are authrized for this page!", "~/logout");
                }
            }
        }

        private void BindClass(int ClientID)
        {
            string Query = string.Format("Select distinct groupname from usergroups where ClientID=" + ClientID + "and GroupID in (select usergroupid from usergroupmapping where UserID='" + Context.User.Identity.Name + "')");

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
        private void BindSubject(int ClientID)
        {
            ddlSubject.DataSource = null;

            ddlSubject.DataBind();
            string Query = string.Format("Select distinct groupID, Description from usergroups where GroupName='" + ddlClass.SelectedValue + "' and ClientID=" + ClientID + " and isdeleted=0 and isactive=1 and GroupID in (select usergroupid from usergroupmapping where UserID='" + Context.User.Identity.Name + "') order by Description");

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
            BindSubject(Convert.ToInt32(litClientID.Text));
            BindAttendanceStatus();
        }
        protected void ddlSubjectSelectedIndexChanged(object sender, EventArgs e)
        {
            BindAttendanceStatus();
        }

        private void BindAttendanceStatus()
        {
            IList<MemberAttendance> alist = new AttendanceController().GetMemberAttendances(Convert.ToInt32(ddlSubject.SelectedValue), Context.User.Identity.Name);

            string TotalClassesQuery = string.Format("Select  OverallClasses as CountTotalClasses from usergroups where groupid='" + ddlSubject.SelectedValue + "' ");


            String constr1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlCommand cmd1 = new SqlCommand(TotalClassesQuery);
            SqlConnection con1 = new SqlConnection(constr1);
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con1;
            con1.Open();
            try
            {
                TotalClasses = Convert.ToDouble(cmd1.ExecuteScalar());

            }
            catch
            {


            }
            con1.Close();
            if (TotalClasses == 0)
            {
                TotalClassesQuery = string.Format("Select  COUNT(distinct Attendance.AttendanceDate)as CountTotalClasses from attendance where GroupID=" + Convert.ToInt32(ddlSubject.SelectedValue) + " and Session='" + General.GetCurrentSession + "' ");
                cmd1 = new SqlCommand(TotalClassesQuery);
                con1 = new SqlConnection(constr1);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con1;
                con1.Open();
                TotalClasses = Convert.ToDouble(cmd1.ExecuteScalar());
                con1.Close();
            }

            gvAttendanceDetails.DataSource = null;
            gvAttendanceDetails.DataBind();

            //string Query = string.Format("select distinct AttendanceDate, AttendanceStatus,AttendanceTime,Device,DeviceLocation as Location from attendance where GroupID=" + Convert.ToInt32(ddlSubject.SelectedValue) + " and UserID='" + Context.User.Identity.Name + "'");

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
                TotalClassesQuery = string.Format("Select  COUNT(distinct Attendance.AttendanceDate)as CountTotalClasses from attendance where GroupID=" + Convert.ToInt32(ddlSubject.SelectedValue) + " and Session='" + General.GetCurrentSession + "' and AttendanceDate >= '" + Convert.ToDateTime(txtDateFrom.Text).Date + "' and AttendanceDate <= '" + Convert.ToDateTime(txtDateTo.Text).Date + "' ");
                cmd1 = new SqlCommand(TotalClassesQuery);
                con1 = new SqlConnection(constr1);
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con1;
                con1.Open();
                TotalClasses = Convert.ToDouble(cmd1.ExecuteScalar());
                con1.Close();
                alist = alist.Where(ss => ss.AttendanceDate >= Convert.ToDateTime(txtDateFrom.Text).Date && ss.AttendanceDate <= Convert.ToDateTime(txtDateTo.Text).Date).ToList();
                //Query = string.Format("select distinct AttendanceDate, AttendanceStatus,AttendanceTime,Device,DeviceLocation as Location from attendance where GroupID=" + Convert.ToInt32(ddlSubject.SelectedValue) + " and UserID='" + Context.User.Identity.Name + "'and AttendanceDate>= '" + Convert.ToDateTime(txtDateFrom.Text) + "' and AttendanceDate<= '" + Convert.ToDateTime(txtDateTo.Text) + "'");
            }
            try
            {
                PerPresent = Convert.ToDouble(alist.Where(ss => ss.AttendanceStatus == "Present").Count()) / TotalClasses * 100.0;
                PerAbsent = 100.0 - PerPresent;
            }
            catch
            {


            }
            //SqlCommand cmd = new SqlCommand(Query);
            //String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //SqlConnection con = new SqlConnection(constr);
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            gvAttendanceDetails.DataSource = alist;
            gvAttendanceDetails.DataBind();


        }
        protected void ToDateChanged(object sender, EventArgs e)
        {
            gvAttendanceDetails.DataSource = null;
            gvAttendanceDetails.DataBind();
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
                BindAttendanceStatus();
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
            gvAttendanceDetails.DataSource = null;
            gvAttendanceDetails.DataBind();
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
                BindAttendanceStatus();
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