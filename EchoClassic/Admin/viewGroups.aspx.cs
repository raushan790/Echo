using BusinessObjects;
using Controllers;
using DataObjects.AdoNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace EchoClassic.Admin
{
    public partial class viewGroups : System.Web.UI.Page
    {
        public string CurrentDate = string.Empty;
        public int TotalClasses = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            calEFromDate.EndDate = DateTime.UtcNow.AddHours(5.5);
            CalETodate.EndDate = DateTime.UtcNow.AddHours(5.5);
            if (!IsPostBack)
            {
                bindGrid(0);
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

                    BindClass(c.ClientID);
                    //BindSubject(c.ClientID);
                    txtDateFrom.Text = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                    //txtDateTo.Text = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                    LoadAttendanceSummeryForDateRange();
                    GetCountUsersChangedPassword();
                }
                else
                    Response.Redirect("~/Default?echotgt=" + Request.RawUrl);
            }

        }
        protected string strQuery(int groupID=0, string fromDate="", string toDate="")
        {
            if (ddlClass.SelectedValue == "" || ddlClass.SelectedValue=="-1")
            {
                groupID = 0;
            }
            else
            {
                groupID = Convert.ToInt32(ddlClass.SelectedValue);
            }
            StringBuilder strQuery = new StringBuilder(); 
            StringBuilder strQueryNotice = new StringBuilder();

            if (groupID == 0)
            {
                strQuery.Append("Select Distinct GroupName,Description,NoticeTitle,NoticeDetail, NoticeDate from Notice N " +
                                       " INNER JOIN NoticeDetails ND ON N.NoticeID = ND.NoticeID " +
                                       " Inner Join usergroups UG ON UG.GroupID = N.GroupID Where " +
                                       " Owner = '" + Context.User.Identity.Name + "' ");
            }
            else
            {
                strQuery.Append("Select Distinct GroupName,Description,NoticeTitle,NoticeDetail, NoticeDate  from Notice N " +
                        " INNER JOIN NoticeDetails ND ON N.NoticeID = ND.NoticeID " +
                        " Inner Join usergroups UG ON UG.GroupID = N.GroupID Where " +
                        " Owner = '" + Context.User.Identity.Name + "' and N.groupID = '" + ddlClass.SelectedValue + "' ");
            }
            string CountQuery = strQuery.ToString();
            string fromDateNew ="";
            string toDateNew = "";
            if (txtDateFrom.Text.Length!=10)
            {
                fromDateNew = "0" + txtDateFrom.Text;
            }
            else
            {
                fromDateNew = txtDateFrom.Text;
            }
            if (txtDateTo.Text.Length != 10)
            {
                toDateNew = "0" + txtDateTo.Text;
            }
            else
            {
                toDateNew = txtDateTo.Text;
            }
            strQueryNotice.Append("Select Distinct GroupName,Description,NoticeTitle,NoticeDetail,NoticeDate from Notice N " +
                                       " INNER JOIN NoticeDetails ND ON N.NoticeID = ND.NoticeID " +
                                       " Inner Join usergroups UG ON UG.GroupID = N.GroupID Where " +
                                       " Owner = '" + Context.User.Identity.Name + "' and N.groupID Not in " +
                                       " ( Select GroupID from Notice N   " +
                                       " INNER JOIN NoticeDetails ND ON N.NoticeID = ND.NoticeID) ");
            if (txtDateFrom.Text!="" && txtDateTo.Text!="" && txtDateFrom.Text == txtDateTo.Text)
            {
                strQuery.Append(" And NoticeDate >= '" + Convert.ToDateTime(fromDateNew) + "'");
                strQueryNotice.Append(" And NoticeDate >= '" + Convert.ToDateTime(fromDateNew) + "'");
            }
            else
            {
                if (txtDateFrom.Text != "")
                {
                    strQuery.Append(" And NoticeDate >= '" + Convert.ToDateTime(fromDateNew) + "'");
                    strQueryNotice.Append(" And NoticeDate >= '" + Convert.ToDateTime(fromDateNew) + "'");
                }
                if (txtDateTo.Text != "")
                {
                    strQuery.Append(" And NoticeDate <= '" + Convert.ToDateTime(toDateNew) + "'");
                    strQueryNotice.Append(" And NoticeDate <= '" + Convert.ToDateTime(toDateNew) + "'");
                }
            }
            strQuery.Append(" Order By NoticeDate desc");
            strQueryNotice.Append(" Order By NoticeDate desc");


            //string Query = "Select Distinct GroupName,Description,NoticeTitle,NoticeDetail,NoticeDate from Notice N " +
            //                           " INNER JOIN NoticeDetails ND ON N.NoticeID = ND.NoticeID " +
            //                           " Inner Join usergroups UG ON UG.GroupID = N.GroupID Where " +
            //                           " Owner = '" + Context.User.Identity.Name + "' and N.groupID Not in "+
            //                           " ( Select GroupID from Notice N   "+
            //                           " INNER JOIN NoticeDetails ND ON N.NoticeID = ND.NoticeID "+
            //                           " where CONVERT(VARCHAR,NoticeDate,103) = CONVERT(VARCHAR,GETDATE(),103))  Order By NoticeDate desc";
            
            return strQuery.ToString()+"~"+ strQueryNotice.ToString() + "~" + CountQuery;
        }

        protected void bindGrid(int groupID=0)
        {
            if (ddlClass.SelectedValue == "")
            {
                groupID = 0;
            }
            else
            {
                groupID = Convert.ToInt32(ddlClass.SelectedValue);
            }
            string Query = "";
            Query = strQuery(groupID);

            SqlCommand cmd = new SqlCommand(Query.Split('~')[0].ToString());


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


           cmd = new SqlCommand(Query.Split('~')[1].ToString());

            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            gvGroupDetails.DataSource = ds;
            gvGroupDetails.DataBind();
        }

        protected void ToDateChanged(object sender, EventArgs e)
        {
            try
            {
               bindGrid();
            }
            catch(Exception ex)
            {
                
            }
        }
        protected void FromDateChanged(object sender, EventArgs e)
        {
            try
            {
                bindGrid();
            }
            catch (Exception ex)
            {

            }
        }
        private void BindClass(int ClientID)
        {
            ddlClass.DataSource = null;
            ddlClass.DataBind();
            string Query = string.Format("Select distinct groupname +' '+ Description as groupname,GroupId from usergroups where ClientID=" + ClientID + "");

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
            ddlClass.DataValueField = "GroupId";
            ddlClass.DataTextField = "groupname";
            ddlClass.DataBind();
            ListItem li = new ListItem("Select Group", "-1");
            ddlClass.Items.Add(li);
            ddlClass.SelectedValue = "-1";
        }
        protected void GetCountUsersChangedPassword()
        {
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ClientID", Convert.ToInt32(litClientID.Text));
            litInstallationReport.Text = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "SelectCountUsersChangedPassword", m).ToString();

        }
        private void LoadAttendanceSummeryForDateRange()
        {
            string Query = "";
            Query= "Select count(*) from ("+ strQuery(0).Split('~')[2].ToString() + ") temp";

            SqlCommand cmd = new SqlCommand(Query);
            String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows[0].ItemArray[0] != null || ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                litNoticeCount.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }
        protected void gvAttendanceStatus_Databound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void ddlClassSelectedIndexChanged(object sender, EventArgs e)
        {
            bindGrid(Convert.ToInt32(ddlClass.SelectedValue));
        }
        protected void gvAttendanceStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
    }
}