using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controllers;

namespace EchoClassic.Account
{
    public partial class ManageAdmin : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                // CheckboxStatus();
            }
        }
        private void BindgvAdmin()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Manage_GroupAdmin", con))
                {
                    cmd.Parameters.AddWithValue("@Mobile", txtUserID.Text.Trim());
                    DataTable dt = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            gvAdmin.DataSource = dt;
                            gvAdmin.DataBind();
                        }

                    }
                }
            }
        }

        protected void updateButtonText(object sender, EventArgs e)
        {
            // CheckboxStatus();
        }
        //protected void btnchk_Click(object sender, EventArgs e)
        //{
        //    foreach (GridViewRow grow in gvAdmin.Rows)
        //    {
        //        CheckBox chkAdmin = (CheckBox)grow.FindControl("chkSelect");
        //        Button ctrlbtn = (Button)grow.FindControl("btnchk");
        //        if (chkAdmin.Checked == true)
        //        {
        //            chkAdmin.Checked = false;
        //            ctrlbtn.Text = "Disabled";
        //        }
        //        else
        //        {
        //            chkAdmin.Checked = true;
        //            ctrlbtn.Text = "Enabled";
        //        }
        //    }
        //}
        protected void btnSearch_click(object sender, EventArgs e)
        {
            BindgvAdmin();
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("UPDATE UserGroupMapping SET isAdmin = @IsSelected WHERE UserID = @UserID");
            //cmd.Connection = conn;
            //conn.Open();
            //foreach (GridViewRow grow in gvAdmin.Rows)
            //{
            //    bool b;
            //    string lblUserid = gvAdmin.DataKeys[grow.RowIndex].Values[0].ToString();
            //    CheckBox chkadmin = (CheckBox)grow.FindControl("chkSelect");
            //    if (chkadmin.Checked)
            //    {
            //        b = true;
            //    }
            //    else
            //    {
            //        b = false;
            //    }
            //    // bool isSelected = (grow.FindControl("chkSelect") as CheckBox).Checked;
            //    cmd.Parameters.Clear();
            //    cmd.Parameters.AddWithValue("@UserID", lblUserid);
            //    cmd.Parameters.AddWithValue("@IsSelected", b);
            //    cmd.ExecuteNonQuery();
            //}
            //conn.Close();
            //BindgvAdmin();
        }

        protected void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            this.BindgvAdmin();
        }

        protected void gvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ResetPwd")
            {
                string UserID = Convert.ToString(e.CommandArgument.ToString());
                Button btnResetPwd = e.CommandSource as Button;
                string pwd = GeneratePassword();

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "update Users set ChangedPassword=0 , pwd='" + Encryption.Encrypt(pwd) + "' where UserID='" + UserID + "'";
                        cmd.Connection = con;
                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    BindgvAdmin();
                }
                General.ShowAlertMessage("Please note down, Password is " + pwd);
            }
            if (e.CommandName == "DeleteUser")
            {
                string UserID = Convert.ToString(e.CommandArgument.ToString());

                int i = new UserController().DeleteUser(UserID);

                General.ShowAlertMessage("Success");
                BindgvAdmin();
            }
        }

        public string GeneratePassword()
        {
            // string pwd = string.Empty;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int length = 8;
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();


            // return pwd;
        }

        protected void gvAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // DataRowView dv = (DataRowView)e.Row.DataItem;
                Label lblPwd = e.Row.FindControl("lblPwd") as Label;
                string pwd = lblPwd.Text;
                lblPwd.Text = Encryption.Decrypt(pwd);
            }
        }
    }
}