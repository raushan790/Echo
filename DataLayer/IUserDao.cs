using System;

namespace DataObjects
{
    public interface IUserDao
    {
        int CreateUserDeviceTokenMapping(string UserID, string DeviceToken, string Platform, DateTime CreateDate, DateTime ModifiedDate, string Custom1, string Custom2, string Custom3);
       
        System.Collections.Generic.IList<BusinessObjects.User> GetAllAdminsForAClient(int ClientID);
        int FirstTimeUpdatePassword(string _UserID, string _Password, string _RecoveryNo);
        BusinessObjects.User GetUser_byNameAndMobile(string Mobile, string Name);
        bool Verify_byNameAndMobile(string Name, string Mobile);
        string CreateUser(BusinessObjects.User c);

        int UserIsLock(string _UserID, bool _IsLock);

        int DeleteUser(string _UserID);

        BusinessObjects.User GetUser(string _EMail, string _PWD);
        BusinessObjects.User GetUserForLoginByMobile(string _Mobile, string _PWD);
        BusinessObjects.User GetUserByCouponCode(string CouponCode);
        System.Collections.Generic.IList<BusinessObjects.User> GetUsersByCreatedBy(string CreatedBy);

        BusinessObjects.User GetUser(string _UserID);
        BusinessObjects.User GetUserbyEmail(string _Email);
        BusinessObjects.User GetUserbyMobile(string _Mobile);
        System.Collections.Generic.IList<BusinessObjects.User> GetUsers();

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers_PageingSearch_SalonUsers(int _PageIndex, int _PageSize, string _SearchText);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers_PageingSearch(int _PageIndex, int _PageSize, string _SearchText);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers_Pageing(int _PageIndex, int _PageSize);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers_Pageing(string _strCondition, int _PageIndex, int _PageSize);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers_Pageing(int _RoleID, int _PageIndex, int _PageSize);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers(string _SortExpression);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers(int _RoleID, string _SortExpression);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers(int _RoleID);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsersByGroup(int _UserGroupID);
        System.Collections.Generic.IList<BusinessObjects.User> SelectGroupAdmins(int _UserGroupID); 
        System.Collections.Generic.IList<BusinessObjects.User> GetUsersByGroup(int _PageIndex, int _PageSize, int _UserGroupID);

        System.Collections.Generic.IList<BusinessObjects.User> GetMessagedUsers(int _MessageID);

        BusinessObjects.User GetUserPassword(string _EmailID);

        System.Collections.Generic.IList<BusinessObjects.User> GetUsers_PageingSearch(int _PageIndex, int _PageSize, string _SearchText, DateTime _FromDate, DateTime _ToDate, int _UserGroupID);

        int UpdateUser(BusinessObjects.User c);

        bool Verify_Email(string _EmailID);
        bool Verify_Mobile(string _Mobile);
        bool Verify_CouponCode(string _Coupon);

        string ValidateUser(string _Email, string _Password);

        int ChangePassword(string _UserID, string _Password);
        int setUserDetails(BusinessObjects.User c);

        int GetMTDUser();

        int GetLastMonthUser();

        int GetMTDWholeSeller();

        int GetYTDWholeSeller();

        int GetYTDUser();
    }
}