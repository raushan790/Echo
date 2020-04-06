using BusinessObjects;
using Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.Account
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // BindGroups();
            }
        }

        //private void BindGroups()
        //{
        //    gvGroups.DataSource = new UserController().GetUserGroupsByOwner(Context.User.Identity.Name).Where(ss => ss.IsRole == false);
        //    gvGroups.DataBind();
        //}
        //protected void CreateGroup_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //string folderPath = Server.MapPath("~/EchoClassic/images/GroupImages/");
        //        //if (!Directory.Exists(folderPath))
        //        //{
        //        //    Directory.CreateDirectory(folderPath);
        //        //}
        //        //fuImage.SaveAs(folderPath + Path.GetFileName(fuImage.FileName));
        //        //if (fuImage.HasFile)
        //        //{
        //        string img = string.Empty;
        //        string filename = Guid.NewGuid().ToString();
        //        string extn = Path.GetExtension(fuImage.PostedFile.FileName);
        //        fuImage.PostedFile.SaveAs(Server.MapPath("~/images/GroupImages/" + filename + extn));
        //        img = filename + extn;


        //        string groupID = string.Empty;
        //        UserGroups group = new UserGroups
        //        {

        //            Group_Name = txtName.Text,
        //            Description = txtDesc.Text,
        //            Image = img,
        //            Owner = Context.User.Identity.Name,
        //            IsRole = false,
        //            IsDeleted = false,
        //            IsActive = true,
        //            CreateDate = DateTime.Now,
        //            ModifiedDate = DateTime.Now

        //        };
        //        groupID = new UserController().CreateUserGroup(group);
        //        BindGroups();
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorMessage.Text = ex.Message;
        //    }
        //}
    }
}