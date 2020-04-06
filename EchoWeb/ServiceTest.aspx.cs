using BusinessObjects;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace EchoClassic
{
    public partial class ServiceTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User chkUserDetails = new User();
            try
            {
                //string Password = "123456";
                string UserName = "7738919680";
                chkUserDetails = DataAccess.UserDao.GetUserForLoginByMobile(UserName, "ZWzDGC55ny0=");
                if (chkUserDetails != null)
                {
                    IList<UserGroups> type1GroupAsMember = chkUserDetails.UserGroup.Where(ss => ss.isAdmin == false && ss.FlowType == 1).ToList();

                }
            }
            catch (Exception ex)
            {

            }
        }
        //        public User GetUserForLoginByMobile(string _Mobile, string _PWD)
        //{
        //    try
        //    {
        //        SqlParameter[] m = new SqlParameter[2];
        //        m[0] = new SqlParameter("@Mobile", _Mobile);
        //        m[1] = new SqlParameter("@PWD", _PWD);
        //        DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_LoginByMobile", m);

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            DataRow row = ds.Tables[0].Rows[0];
        //            if (row == null) return null;

        //            return MakeUser(row);

        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }

    public class Encryption
    {
        private static byte[] key = { };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string EncryptionKey = "218026abC123@#";

        public Encryption()
        {

        }

        public static string Decrypt(string Input)
        {
            Input = Input.Replace(' ', '+');

            Byte[] inputByteArray = new Byte[Input.Length];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes
    (EncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(Input);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream
    (ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());

            }
            catch (Exception EX)
            {
                //HttpContext.Current.Response.Redirect("~/Error.aspx?ERID=150");
                return "";
            }

        }
        public static string Encrypt(string Input)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes
    (EncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Encoding.UTF8.GetBytes(Input);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream
    (ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception EX)
            {
                return "";
            }
        }
    }

}