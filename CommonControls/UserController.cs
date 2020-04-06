using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DataObjects;
using BusinessObjects;

namespace Controllers
{
    /// <summary>
    /// Summary description for UserController
    /// </summary>
    [DataObject(true)]
    public class UserController : ControllerBase
    {
        #region User
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool Verify_byNameAndMobile(string _Mobile, string Name)
        {
            return DataAccess.UserDao.Verify_byNameAndMobile(_Mobile, Name);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool Verify_Mobile(string _Mobile)
        {
            return DataAccess.UserDao.Verify_Mobile(_Mobile);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool Verify_CouponCode(string _Coupon)
        {
            return DataAccess.UserDao.Verify_CouponCode(_Coupon);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUserListbyCreatedBy(string _UserID)
        {
            return DataAccess.UserDao.GetUsersByCreatedBy(_UserID);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUserByCouponCode(string _CouponCode)
        {
            return DataAccess.UserDao.GetUserByCouponCode(_CouponCode);
        }
        /// <summary>
        /// GEt all User List
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUserList()
        {
            return DataAccess.UserDao.GetUsers();
        }


        /// <summary>
        /// GEt Messaged User List
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetMessagedUserList(int _MessageID)
        {
            return DataAccess.UserDao.GetMessagedUsers(_MessageID);
        }


        /// <summary>
        /// Get User list by User roleID
        /// </summary>
        /// <param name="_RoleID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUserList(int _RoleID)
        {
            return DataAccess.UserDao.GetUsers(_RoleID);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetAllAdminsForAClient(int ClientID)
        {
            return DataAccess.UserDao.GetAllAdminsForAClient(ClientID);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUserListGroup(int _UserGroupID)
        {
            return DataAccess.UserDao.GetUsersByGroup(_UserGroupID);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetGroupAdmins(int _UserGroupID)
        {
            return DataAccess.UserDao.SelectGroupAdmins(_UserGroupID);
        }

        /// <summary>
        /// Get User list by PageIndex
        /// </summary>
        /// <param name="_PageIndex"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUserList_Paging(int _PageIndex, int _PageSize)
        {
            return DataAccess.UserDao.GetUsers_Pageing(_PageIndex, _PageSize);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUsers_PageingSearch(int _PageIndex, int _PageSize, string _SearchText)
        {
            return DataAccess.UserDao.GetUsers_PageingSearch(_PageIndex, _PageSize, _SearchText);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUsers_PageingSearch_SalonUsers(int _PageIndex, int _PageSize, string _SearchText)
        {
            return DataAccess.UserDao.GetUsers_PageingSearch_SalonUsers(_PageIndex, _PageSize, _SearchText);
        }

        /// <summary>
        /// Get User list by PageIndex
        /// </summary>
        /// <param name="_PageIndex"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUserList_Paging(int _RoleID, int _PageIndex, int _PageSize)
        {
            return DataAccess.UserDao.GetUsers_Pageing(_RoleID, _PageIndex, _PageSize);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUserList_Paging(string _StrConditon, int _PageIndex, int _PageSize)
        {
            return DataAccess.UserDao.GetUsers_Pageing(_StrConditon, _PageIndex, _PageSize);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUser_byNameAndMobile(string Mobile, string Name)
        {
            return DataAccess.UserDao.GetUser_byNameAndMobile(Mobile, Name);
        }
        /// <summary>
        /// GetUser
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUser(string _UserID)
        {
            return DataAccess.UserDao.GetUser(_UserID);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUserbyEmail(string _Email)
        {
            return DataAccess.UserDao.GetUserbyEmail(_Email);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUserbyMobile(string _Mobile)
        {
            return DataAccess.UserDao.GetUserbyMobile(_Mobile);
        }

        /// <summary>
        /// Get User Details with emailid (loginid) an password
        /// </summary>
        /// <param name="_Email"></param>
        /// <param name="_Password"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUser(string _Email, string _Password)
        {
            return DataAccess.UserDao.GetUser(_Email, _Password);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public User GetUserForLoginByMobile(string _Mobile, string _Password)
        {
            return DataAccess.UserDao.GetUserForLoginByMobile(_Mobile, _Password);
        }

        /// <summary>
        /// Add new User ( User ) return userid
        /// </summary>
        /// <param name="_User"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public string CreateUser(User _User)
        {
            return DataAccess.UserDao.CreateUser(_User);
        }
        public int CreateMemberAttendance(MemberAttendance _MemberAttendance)
        {
            return DataAccess.MemberAttendanceDao.CreateMemberAttendance(_MemberAttendance);
        }
        /// <summary>
        /// Update User Data with user ID
        /// </summary>
        /// <param name="_User"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public string UpdateUser(User _User)
        {
            if (!IsGuid(_User.UserID))
                throw new Exception("Invalid UserID, [for data update, User ID is a requered field]");

            return DataAccess.UserDao.UpdateUser(_User).ToString();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="_UserID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public int DeleteUser(string _UserID)
        {
            if (!IsGuid(_UserID))
                throw new Exception("Invalid UserID,[ for delete , a valid user id is a requered field]");

            return DataAccess.UserDao.DeleteUser(_UserID);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public int ChangePassword(string _UserID, string _Password)
        {
            if (!IsGuid(_UserID))
                throw new Exception("Invalid UserID,[ for delete , a valid user id is a requered field]");

            return DataAccess.UserDao.ChangePassword(_UserID, _Password);
        }

        /// <summary>
        /// Lock or unlock User
        /// </summary>
        /// <param name="_UserID"></param>
        /// <param name="_IsLockedOut"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public int LockUser(string _UserID, bool _IsLockedOut)
        {
            if (!IsGuid(_UserID))
                throw new Exception("Invalid UserID,[ for delete , a valid user id is a requered field]");

            return DataAccess.UserDao.UserIsLock(_UserID, _IsLockedOut);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool Verify_Email(string _Email)
        {
            if (!IsValidEmail(_Email))
                throw new Exception("Invalid Email Address");

            return DataAccess.UserDao.Verify_Email(_Email);
        }

        #endregion

        public static bool IsValidEmail(string inputEmail)
        {
            //string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            //      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            //      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            string strRegex = "(?<user>[^@]+)@(?<host>.+)";

            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        #region User Group
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public string DeleteUserGroup(int GroupID)
        {
            return DataAccess.UserGroupsDao.DeleteUserGroup(GroupID);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<UserGroups> GetUserGroupsList()
        {
            return DataAccess.UserGroupsDao.GetUserGroups();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<UserGroups> GetUserGroupsByOwner(string Owner)
        {
            return DataAccess.UserGroupsDao.GetUserGroupsByOwner(Owner);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<UserGroups> GetUserRoleList()
        {
            return DataAccess.UserGroupsDao.GetUserRoles();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public UserGroups GetUserGroup(int _UserGroupID)
        {
            return DataAccess.UserGroupsDao.GetUserGroup(_UserGroupID);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public UserGroups GetUserGroupGuest()
        {
            return DataAccess.UserGroupsDao.GetUserGroupGuest();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public string CreateUserGroup(UserGroups _UserGroup)
        {
            return DataAccess.UserGroupsDao.CreateUserGroup(_UserGroup).ToString();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public string UpdateUserGroup(UserGroups _UserGroup)
        {
            if (_UserGroup.UserGroupID <= 0)
                throw new Exception("Invalid User group id");

            return DataAccess.UserGroupsDao.UpdateUserGroup(_UserGroup).ToString();
        }

        #endregion

        #region User Group Mapping

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<UserGroupMapping> GetUserGroupMapping(string _UserID)
        {
            return DataAccess.UserGroupMappingDao.UserGroupMappings(_UserID);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public string CreateUserGroupMapping(UserGroupMapping _Mapping)
        {
            return DataAccess.UserGroupMappingDao.CreateMapping(_Mapping).ToString();
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public string DeleteUserGroupMapping(string _UserID)
        {
            if (string.IsNullOrEmpty(_UserID))
                throw new Exception("Invalid UserID");

            return DataAccess.UserGroupMappingDao.DeleteMapping(_UserID).ToString();
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public string DeleteUserGroupMapping(string _UserID, int _UserGroupID)
        {
            if (string.IsNullOrEmpty(_UserID))
                throw new Exception("Invalid UserID");

            return DataAccess.UserGroupMappingDao.DeleteMapping(_UserID, _UserGroupID).ToString();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public string FirstTimeUpdatePassword(string UserID, string Password, string MobileNo)
        {

            return DataAccess.UserDao.FirstTimeUpdatePassword(UserID, Password, MobileNo).ToString();
        }
        #endregion





        /// <summary>
        /// User search by text ,date range ,User group or without these parameters
        /// </summary>
        /// <param name="_PageIndex"></param>
        /// <param name="_PageSize"></param>
        /// <param name="_SearchText"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<User> GetUsers_PageingSearch(int _PageIndex, int _PageSize, string _SearchText, DateTime _FromDate, DateTime _ToDate, int _UserGroupID)
        {
            return DataAccess.UserDao.GetUsers_PageingSearch(_PageIndex, _PageSize, _SearchText, _FromDate, _ToDate, _UserGroupID);
        }
    }
}