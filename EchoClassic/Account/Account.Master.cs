using BusinessObjects;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Account
{
    public partial class Account : System.Web.UI.MasterPage
    {
        public String UserName = string.Empty;
        // public User CurrentUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated && Context.User.Identity.Name != string.Empty)
            {
                User c = new UserController().GetUser(Context.User.Identity.Name);
                //  CurrentUser = c;
                if (c.UserGroup.Count > 0)
                {

                    if (c.UserGroup.FirstOrDefault().isAdmin == true)
                    {
                        linkDashboard.NavigateUrl = "/admin/su-dashboard";
                    }
                    else
                    { linkDashboard.NavigateUrl = "/account/selfattendancesearch"; }


                    UserName = c.FirstName;
                    BindGroups(c);
                }

            }
            else
            {
                Response.Redirect("~/default?echotgt=" + Request.RawUrl);
            }



        }

        public void BindGroups(User u)
        {
            rpGroups.DataSource = u.UserGroup.Where(ss => ss.IsRole == false);
            rpGroups.DataBind();
        }

        protected void rpGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                UserGroups ug = e.Item.DataItem as UserGroups;
                Image imgGroup = e.Item.FindControl("imgGroup") as Image;
                Literal litGroupName = e.Item.FindControl("litGroupName") as Literal;
                Literal litDesc = e.Item.FindControl("litDesc") as Literal;
                // Literal litUserCount = e.Item.FindControl("litUserCount") as Literal;
                HyperLink linkViewGroup = e.Item.FindControl("linkViewGroup") as HyperLink;
                if (!string.IsNullOrEmpty(ug.Image))
                {
                    imgGroup.ImageUrl = "~/images/GroupImages/" + ug.Image;
                }
                litGroupName.Text = ug.Group_Name;
                litDesc.Text = ug.Description;
                if (ug.FlowType == 1)
                {
                    string url = Request.RawUrl;
                    url = url.Split(new[] { '?' })[0];
                    linkViewGroup.NavigateUrl = (url + "/?GroupID=" + ug.UserGroupID).Replace("//", "/");
                }
                if (ug.FlowType == 2)
                {
                    if (ug.isAdmin == true)
                    {
                        linkViewGroup.NavigateUrl = (Page.ResolveUrl("~/") + "account/managegroupstype2/?GroupID=" + ug.UserGroupID);
                    }
                    else
                    {
                        linkViewGroup.NavigateUrl = (Page.ResolveUrl("~/") + "account/selfattendance/?GroupID=" + ug.UserGroupID);
                    }

                }
                if (ug.FlowType == 3)
                {
                    if (ug.isAdmin == true)
                    {
                        linkViewGroup.NavigateUrl = (Page.ResolveUrl("~/") + "account/managegroupstype3/?GroupID=" + ug.UserGroupID);
                    }
                    else
                    {
                        linkViewGroup.NavigateUrl = (Page.ResolveUrl("~/") + "account/selfattendancetype3/?GroupID=" + ug.UserGroupID);
                    }
                }
                if (ug.FlowType == 4)
                {
                    if (ug.isAdmin == true)
                    {
                        linkViewGroup.NavigateUrl = "/admin/managegroupstype4/?GroupID=" + ug.UserGroupID;

                    }
                    else
                    {
                        linkViewGroup.NavigateUrl = (Page.ResolveUrl("~/") + "account/selfattendancetype4/?GroupID=" + ug.UserGroupID);
                    }
                }
            }

        }
    }
}

