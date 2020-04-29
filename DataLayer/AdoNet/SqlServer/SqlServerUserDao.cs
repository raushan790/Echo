using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerUserDao : IUserDao
    {
        public int CreateUserDeviceTokenMapping(string UserID, string DeviceToken, string Platform, DateTime CreateDate, DateTime ModifiedDate, string Custom1, string Custom2, string Custom3)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[8];
                m[0] = new SqlParameter("@UserID", UserID);
                m[1] = new SqlParameter("@DeviceToken", DeviceToken);
                m[2] = new SqlParameter("@Platform", Platform);
                m[3] = new SqlParameter("@CreateDate", CreateDate);
                m[4] = new SqlParameter("@ModifiedDate", ModifiedDate);
                m[5] = new SqlParameter("@Custom1", Custom1);
                m[6] = new SqlParameter("@Custom2", Custom2);
                m[7] = new SqlParameter("@Custom3", Custom3);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "UserDeviceTokenMappingInsert", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetAllAdminsForAClient(int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAllAdminsForAClient", m);
                return MakeUsersWithoutGroup(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUser_byNameAndMobile(string Mobile, string Name)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Mobile", Mobile);
                m[1] = new SqlParameter("@Name", Name);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectUser_byNameAndMobile", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUser(row);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Verify_byNameAndMobile(string Mobile, string Name)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@Mobile", Mobile);
                m[1] = new SqlParameter("@Name", Name);

                m[2] = new SqlParameter("@iCount", SqlDbType.Int);
                m[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_byNameAndMobile", m);
                object ivalue = m[2].Value;
                int icount = (int)ivalue;

                if (icount > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Verify_Mobile(string _Mobile)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Mobile", _Mobile);
                m[1] = new SqlParameter("@iCount", SqlDbType.Int);
                m[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_CheckMobile", m);
                object ivalue = m[1].Value;
                int icount = (int)ivalue;

                if (icount > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Verify_CouponCode(string _Coupon)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Coupon", _Coupon);
                m[1] = new SqlParameter("@iCount", SqlDbType.Int);
                m[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_CheckCoupon", m);
                object ivalue = m[1].Value;
                int icount = (int)ivalue;

                if (icount > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserByCouponCode(string CouponCode)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@CouponCode", CouponCode);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetUserByCouponCode", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUser(row);
                }
                else
                    throw new Exception("Invalid Coupon code!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<BusinessObjects.User> GetUsersByCreatedBy(string CreatedBy)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@CreatedBy", CreatedBy);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetUsersByCreatedBy", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<User> GetUsers()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectAll");
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsers_Pageing(int _PageIndex, int _PageSize)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@PageIndex", _PageIndex);
                m[1] = new SqlParameter("@PageSize", _PageSize);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectAll_Paging", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsers_PageingSearch(int _PageIndex, int _PageSize, string _SearchText)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@PageIndex", _PageIndex);
                m[1] = new SqlParameter("@PageSize", _PageSize);
                m[2] = new SqlParameter("@SearchText", _SearchText);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectAll_Search", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsers_PageingSearch_SalonUsers(int _PageIndex, int _PageSize, string _SearchText)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@PageIndex", _PageIndex);
                m[1] = new SqlParameter("@PageSize", _PageSize);
                m[2] = new SqlParameter("@SearchText", _SearchText);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectAll_Search_SalonUsers", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsers_Pageing(int _RoleID, int _PageIndex, int _PageSize)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@PageIndex", _PageIndex);
                m[1] = new SqlParameter("@PageSize", _PageSize);
                m[2] = new SqlParameter("@RoleID", _RoleID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_RoleID_Paging", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsers_Pageing(string _strCondition, int _PageIndex, int _PageSize)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@WhereClause", _strCondition);
                m[1] = new SqlParameter("@PageIndex", _PageIndex);
                m[2] = new SqlParameter("@PageSize", _PageSize);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_Filter_Paging", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserPassword(string _EmailID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@EmailID", _EmailID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ForgotPassword", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUser(row);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsers(string _SortExpression)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectAll");
                IList<User> tempCusts = MakeUsers(ds.Tables[0]);
                IEnumerable<User> sortedEnum = tempCusts.OrderBy(f => _SortExpression);
                IList<User> sortedList = sortedEnum.ToList();
                return sortedList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsers(int _RoleID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@RoleID", _RoleID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectByRoleID", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsersByGroup(int _UserGroupID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GroupID", _UserGroupID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectByGroupID", m);
                return MakeUsersWithoutGroup(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<User> SelectGroupAdmins(int _UserGroupID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GroupID", _UserGroupID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectGroupAdmins", m);
                return MakeUsersWithoutGroup(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsersByGroup(int _PageIndex, int _PageSize, int _UserGroupID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@PageIndex", _PageIndex);
                m[1] = new SqlParameter("@PageSize", _PageSize);
                m[2] = new SqlParameter("@UserGroupID", _UserGroupID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_GroupID_Search", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetUsers(int _RoleID, string _SortExpression)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@RoleID", _RoleID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectByRoleID", m);
                IList<User> tempCusts = MakeUsers(ds.Tables[0]);
                IEnumerable<User> sortedEnum = tempCusts.OrderBy(f => _SortExpression);
                IList<User> sortedList = sortedEnum.ToList();
                return sortedList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetMessagedUsers(int _MessageID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@MessageID", _MessageID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectAll_Messaged", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUser(string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", _UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_SelectOne", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUser(row);
                }
                else
                    throw new Exception("UserID does not exist in database");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserbyEmail(string _Email)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Email", _Email);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectUserbyEmail", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUser(row);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserbyMobile(string _Mobile)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Mobile", _Mobile);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectUserbyMobile", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUser(row);
                }
                else
                    return null; ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserForLoginByMobile(string _Mobile, string _PWD)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Mobile", _Mobile);
                m[1] = new SqlParameter("@PWD", _PWD);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_LoginByMobile", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUser(row);

                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUser(string _EMail, string _PWD)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@EMail", _EMail);
                m[1] = new SqlParameter("@PWD", _PWD);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "User_Login", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUser(row);

                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidateUser(string _Email, string _Password)
        {
            SqlParameter[] m = new SqlParameter[3];
            m[0] = new SqlParameter("@Email", _Email);
            m[1] = new SqlParameter("@Password", _Password);
            m[2] = new SqlParameter("@iCount", SqlDbType.NVarChar, 256);
            m[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_ValidateUser", m);
            object ivalue = m[2].Value;
            return Convert.ToString(ivalue);
        }

        public string CreateUser(User _User)
        {
            try
            {
                string _UserID = Guid.NewGuid().ToString();

                SqlParameter[] m = new SqlParameter[28];
                m[0] = new SqlParameter("@UserID", _UserID);
                m[1] = new SqlParameter("@RoleID", _User.RoleID);
                m[2] = new SqlParameter("@FirstName", _User.FirstName);
                m[3] = new SqlParameter("@LastName", _User.LastName);
                m[4] = new SqlParameter("@DOB", _User.DOB);
                m[5] = new SqlParameter("@EMail", _User.EMail);
                m[6] = new SqlParameter("@PWD", _User.PWD);
                m[7] = new SqlParameter("@IsDeleted", _User.IsDeleted);

                m[8] = new SqlParameter("@IsLockedOut", _User.IsLockedOut);
                m[9] = new SqlParameter("@CreateDate", _User.CreateDate);
                m[10] = new SqlParameter("@LastLoginDate", _User.LastLoginDate);
                m[11] = new SqlParameter("@LastLockoutDate", _User.LastLockoutDate);
                m[12] = new SqlParameter("@LastPasswordChangedDate", _User.LastPasswordChangedDate);
                m[13] = new SqlParameter("@MobileNo", _User.MobileNo);
                m[14] = new SqlParameter("@Custom1", _User.Custom1);
                m[15] = new SqlParameter("@Custom2", _User.Custom2);
                m[16] = new SqlParameter("@Custom3", _User.Custom3);
                m[17] = new SqlParameter("@Custom4", _User.Custom4);
                m[18] = new SqlParameter("@Custom5", _User.Custom5);
                m[19] = new SqlParameter("@ImageID", _User.ImageID);

                m[20] = new SqlParameter("@Facebook", _User.Facebook == null ? "" : _User.Facebook);
                m[21] = new SqlParameter("@Twitter", _User.Twitter == null ? "" : _User.Twitter);
                m[22] = new SqlParameter("@LinkedIn", _User.LinkedIn == null ? "" : _User.LinkedIn);
                m[23] = new SqlParameter("@MySpace", _User.MySpace == null ? "" : _User.MySpace);
                m[24] = new SqlParameter("@CouponCode", _User.CouponCode == null ? "" : _User.CouponCode);
                m[25] = new SqlParameter("@CreatedBy", _User.CreatedBy == null ? "" : _User.CreatedBy);

                m[26] = new SqlParameter("@Session", _User.Session);
                m[27] = new SqlParameter("@ClientID", _User.ClientID);
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_Insert", m);
                return _UserID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
       public int setUserDetails(User _User)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[9];
                m[0] = new SqlParameter("@UserID", _User.UserID);
                m[1] = new SqlParameter("@FirstName", _User.FirstName);
                m[2] = new SqlParameter("@LastName", _User.LastName);
                m[3] = new SqlParameter("@EMail", _User.EMail);
                m[4] = new SqlParameter("@MobileNo", _User.MobileNo);
                m[5] = new SqlParameter("@ImageID", _User.ImageID);
                m[6] = new SqlParameter("@Facebook", _User.Facebook == null ? "" : _User.Facebook);
                m[7] = new SqlParameter("@Twitter", _User.Twitter == null ? "" : _User.Twitter);
                m[8] = new SqlParameter("@LinkedIn", _User.LinkedIn == null ? "" : _User.LinkedIn);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Set_user", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int UpdateUser(User _User)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[19];
                m[0] = new SqlParameter("@UserID", _User.UserID);
                m[1] = new SqlParameter("@RoleID", _User.RoleID);
                m[2] = new SqlParameter("@FirstName", _User.FirstName);
                m[3] = new SqlParameter("@LastName", _User.LastName);
                m[4] = new SqlParameter("@DOB", _User.DOB);
                m[5] = new SqlParameter("@EMail", _User.EMail);

                m[6] = new SqlParameter("@MobileNo", _User.MobileNo);
                m[7] = new SqlParameter("@IsLockedOut", _User.IsLockedOut);
                m[8] = new SqlParameter("@Custom1", _User.Custom1);
                m[9] = new SqlParameter("@Custom2", _User.Custom2);
                m[10] = new SqlParameter("@Custom3", _User.Custom3);
                m[11] = new SqlParameter("@Custom4", _User.Custom4);
                m[12] = new SqlParameter("@Custom5", _User.Custom5);
                m[13] = new SqlParameter("@ImageID", _User.ImageID);
                m[14] = new SqlParameter("@AlowCredit", _User.AlowCredit);
                m[15] = new SqlParameter("@Facebook", _User.Facebook == null ? "" : _User.Facebook);
                m[16] = new SqlParameter("@Twitter", _User.Twitter == null ? "" : _User.Twitter);
                m[17] = new SqlParameter("@LinkedIn", _User.LinkedIn == null ? "" : _User.LinkedIn);
                m[18] = new SqlParameter("@MySpace", _User.MySpace == null ? "" : _User.MySpace);
                // m[19] = new SqlParameter("@CreatedBy", _User.CreatedBy == null ? "" : _User.CreatedBy);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_Update", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteUser(string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", _UserID);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_Delete", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ChangePassword(string _UserID, string _Password)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@UserID", _UserID);
                m[1] = new SqlParameter("@Password", _Password);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_Update_Password", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int FirstTimeUpdatePassword(string _UserID, string _Password, string _RecoveryNo)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@UserID", _UserID);
                m[1] = new SqlParameter("@Password", _Password);
                m[2] = new SqlParameter("@RecoveryNo", _RecoveryNo);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "FirstTime_User_Update_Password", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UserIsLock(string _UserID, bool _IsLock)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@UserID", _UserID);
                m[1] = new SqlParameter("@IsLockedOut", _IsLock);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_IsLock", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Verify_Email(string _EmailID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Email", _EmailID);
                m[1] = new SqlParameter("@iCount", SqlDbType.Int);
                m[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "User_CheckEmail", m);
                object ivalue = m[1].Value;
                int icount = (int)ivalue;

                if (icount > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<User> MakeUsers(DataTable dt)
        {
            IList<User> list = new List<User>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeUser(row));

            return list;
        }
        private IList<User> MakeUsersWithoutGroup(DataTable dt)
        {
            IList<User> list = new List<User>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeUserWithoutGroups(row));

            return list;
        }

        private User MakeUserWithoutGroups(DataRow row)
        {
            try
            {
                int _TotalRecord = 0;
                string _UserID = row["UserID"].ToString();
                int _RoleID = int.Parse(row["RoleID"].ToString());
                string _FirstName = row["FirstName"].ToString();
                string _LastName = row["LastName"].ToString();
                DateTime _DOB = Convert.ToDateTime(row["DOB"].ToString());
                string _EMail = row["EMail"].ToString();
                string _PWD = row["PWD"].ToString();
                bool _IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                bool _IsLockedOut = Convert.ToBoolean(row["IsLockedOut"].ToString());
                string _CouponCode = row["CouponCode"].ToString();
                string _CreatedBy = row["CreatedBy"].ToString();
                DateTime _CreateDate = Convert.ToDateTime(row["CreateDate"].ToString());
                DateTime _LastLoginDate = Convert.ToDateTime(row["LastLoginDate"].ToString());
                DateTime _LastLockoutDate = Convert.ToDateTime(row["LastLockoutDate"].ToString());
                bool _ChangedPassword = false;
                try
                {
                    _ChangedPassword = Convert.ToBoolean(row["ChangedPassword"].ToString());
                }
                catch
                {


                }

                DateTime _LastPasswordChangedDate = Convert.ToDateTime(row["LastPasswordChangedDate"].ToString());
                string _Custom1 = row["Custom1"].ToString();
                string _Custom2 = row["Custom2"].ToString();
                string _Custom3 = row["Custom3"].ToString();
                string _Custom4 = row["Custom4"].ToString();
                string _Custom5 = row["Custom5"].ToString();
                string _ImageID = row["ImageID"].ToString();

                string _MobileNo = row["MobileNo"].ToString();
                try
                {
                    _TotalRecord = int.Parse(row["TotalRecord"].ToString());
                }
                catch (Exception)
                {
                    _TotalRecord = 0;
                }



                bool AlowCredit = false;

                try
                {
                    AlowCredit = row["AlowCredit"] == DBNull.Value ? false : Convert.ToBoolean(row["AlowCredit"]);
                }
                catch
                {

                }
                bool IsAdmin = false;
                try
                {
                    IsAdmin = row["IsAdmin"] == DBNull.Value ? false : Convert.ToBoolean(row["IsAdmin"]);
                }
                catch
                {

                }

                string _faceID = "";
                string _Facebook = Convert.ToString(row["Facebook"]);
                string _Twitter = Convert.ToString(row["Twitter"]);
                string _LinkedIn = Convert.ToString(row["LinkedIn"]);
                string _MySpace = Convert.ToString(row["MySpace"]);
                string _Session = Convert.ToString(row["Session"]);
                int _ClientID = row["ClientID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ClientID"]);
                List<UserGroups> _UserGroup = null;// new SqlServerUserGroupsDao().GetUserGroups(_UserID);



                return new User(_UserID, _RoleID, _FirstName, _LastName, _DOB, _EMail, _PWD, _IsDeleted, _IsLockedOut, _CouponCode, _CreatedBy, _CreateDate, _LastLoginDate, _LastLockoutDate, _ChangedPassword, _LastPasswordChangedDate, _MobileNo, _TotalRecord, _UserGroup, _ImageID, _Custom1, _Custom2, _Custom3, _Custom4, _Custom5, AlowCredit, _Facebook, _Twitter, _LinkedIn, _MySpace, _Session, _ClientID, IsAdmin,_faceID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private User MakeUser(DataRow row)
        {
            try
            {
                int _TotalRecord = 0;
                string _UserID = row["UserID"].ToString();
                int _RoleID = int.Parse(row["RoleID"].ToString());
                string _FirstName = row["FirstName"].ToString();
                string _LastName = row["LastName"].ToString();
                DateTime _DOB = Convert.ToDateTime(row["DOB"].ToString());
                string _EMail = row["EMail"].ToString();
                string _PWD = row["PWD"].ToString();
                bool _IsDeleted = Convert.ToBoolean(row["IsDeleted"].ToString());

                bool _IsLockedOut = Convert.ToBoolean(row["IsLockedOut"].ToString());
                string _CouponCode = row["CouponCode"].ToString();
                string _CreatedBy = row["CreatedBy"].ToString();
                DateTime _CreateDate = Convert.ToDateTime(row["CreateDate"].ToString());
                DateTime _LastLoginDate = Convert.ToDateTime(row["LastLoginDate"].ToString());
                DateTime _LastLockoutDate = Convert.ToDateTime(row["LastLockoutDate"].ToString());
                bool _ChangedPassword = false;
                try
                {
                    _ChangedPassword = Convert.ToBoolean(row["ChangedPassword"].ToString());
                }
                catch
                {


                }

                DateTime _LastPasswordChangedDate = Convert.ToDateTime(row["LastPasswordChangedDate"].ToString());
                string _Custom1 = row["Custom1"].ToString();
                string _Custom2 = row["Custom2"].ToString();
                string _Custom3 = row["Custom3"].ToString();
                string _Custom4 = row["Custom4"].ToString();
                string _Custom5 = row["Custom5"].ToString();
                string _ImageID = row["ImageID"].ToString();

                string _MobileNo = row["MobileNo"].ToString();
                try
                {
                    _TotalRecord = int.Parse(row["TotalRecord"].ToString());
                }
                catch (Exception)
                {
                    _TotalRecord = 0;
                }



                bool AlowCredit = false;

                try
                {
                    AlowCredit = row["AlowCredit"] == DBNull.Value ? false : Convert.ToBoolean(row["AlowCredit"]);
                }
                catch
                {

                }
                bool IsAdmin = false;
                try
                {
                    IsAdmin = row["IsAdmin"] == DBNull.Value ? false : Convert.ToBoolean(row["IsAdmin"]);
                }
                catch
                {

                }
                string _faceID = "";
                if (row["faceID"] != null)
                {
                    _faceID = Convert.ToString(row["faceID"]);
                }
                string _Facebook = Convert.ToString(row["Facebook"]);
                string _Twitter = Convert.ToString(row["Twitter"]);
                string _LinkedIn = Convert.ToString(row["LinkedIn"]);
                string _MySpace = Convert.ToString(row["MySpace"]);
                string _Session = Convert.ToString(row["Session"]);
                int _ClientID = row["ClientID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ClientID"]);
                List<UserGroups> _UserGroup = new SqlServerUserGroupsDao().GetUserGroups(_UserID);



                return new User(_UserID, _RoleID, _FirstName, _LastName, _DOB, _EMail, _PWD, _IsDeleted, _IsLockedOut, _CouponCode, _CreatedBy, _CreateDate, _LastLoginDate, _LastLockoutDate, _ChangedPassword, _LastPasswordChangedDate, _MobileNo, _TotalRecord, _UserGroup, _ImageID, _Custom1, _Custom2, _Custom3, _Custom4, _Custom5, AlowCredit, _Facebook, _Twitter, _LinkedIn, _MySpace, _Session, _ClientID, IsAdmin, _faceID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static System.Data.SqlTypes.SqlString Md5Hash(System.Data.SqlTypes.SqlString input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(input.Value));

            StringBuilder s_builder = new StringBuilder();

            foreach (byte b in data)
            {
                s_builder.Append(b.ToString("x2"));
            }

            // Return the hexadecimal string.
            return (System.Data.SqlTypes.SqlString)s_builder.ToString();
        }

        #region DASH BOARD

        public int GetMTDUser()
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GeneralCustoemrCount", SqlDbType.Int);
                m[0].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DashBoardMTDUser", m);
                object ivalue = m[0].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetLastMonthUser()
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GeneralUser", SqlDbType.Int);
                m[0].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DashBoardLastMonthUser", m);
                object ivalue = m[0].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetMTDWholeSeller()
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GeneralWholeSellerCount", SqlDbType.Int);
                m[0].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DashBoardMTDWholeSeller", m);
                object ivalue = m[0].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetYTDWholeSeller()
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GeneralWholeSellerCount", SqlDbType.Int);
                m[0].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DashBoardYTDWholeSeller", m);
                object ivalue = m[0].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetYTDUser()
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GeneralCustoemrCount", SqlDbType.Int);
                m[0].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DashBoardYTDUser", m);
                object ivalue = m[0].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion DASH BOARD

        public IList<User> GetUsers_PageingSearch(int _PageIndex, int _PageSize, string _SearchText, DateTime _FromDate, DateTime _ToDate, int _UserGroupID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[6];
                m[0] = new SqlParameter("@PageIndex", _PageIndex);
                m[1] = new SqlParameter("@PageSize", _PageSize);
                m[2] = new SqlParameter("@SearchText", _SearchText);
                m[3] = new SqlParameter("@FromDate", _FromDate);
                m[4] = new SqlParameter("@ToDate", _ToDate);
                m[5] = new SqlParameter("@UserGroupID", _UserGroupID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "usp_User_SelectAll_SearchBy_ByDateRange_GroupBy", m);
                return MakeUsers(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}