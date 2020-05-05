using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessObjects;
using System.IO;

namespace EchoClassic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [Serializable]
    [DataContract(Name = "AppVersion", Namespace = "http://www.yourcompany.com/types/")]

    public class AppVersion
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Platform { get; set; }

        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
    }
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetWelcomeMessage", BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        String GetWelcomeMessage();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/ChkHindiFont")]
        string ChkHindiFont(string HindiName);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/RegisterFaceID")]
        string RegisterFaceID(string UserID, string FaceID);
        #region New Dashboard
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/AttendanceLiveCounter")]
        int AttendanceLiveCounter(int ClientID);
        #endregion
        #region DeepLinking
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/CreateDeepLinking")]
        int CreateDeepLinking(DeepLinking link);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/DeleteDeepLinking")]
        int DeleteDeepLinking(string Url);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/GetDeepLinkingByUrl")]
        DeepLinking GetDeepLinkingByUrl(string Url);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/GetDeepLinkingByCreatedBy/{CreatedBy}")]
        DeepLinking GetDeepLinkingByCreatedBy(string CreatedBy);
        #endregion
        #region Notice
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/SendPushNotificationAndroid")]
        string SendPushNotificationAndroid(string DeviceToken, string Title, string Message);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/SendPushDataAndroid")]
        string SendPushDataAndroid(string DeviceToken, dynamic Data);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/SendPushNotificationIOS")]
        string SendPushNotificationIOS(string DeviceToken, string Title, string Message);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/CreateNotice")]
        int CreateNotice(int GroupID, IList<string> UserIDs, string NoticeTitle, string NoticeDetail, string Createdby, string NoticeDate,string FileName,int FileType=0,int ParentId=0, int IsSms=0, int IsReply=0, string strdeepLink="");

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/CreateNoticeV1")]
        Notice CreateNoticeV1(Stream StreamWithData);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/DeleteNotice")]
        int DeleteNotice(int NoticeID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetDeletedNotice")]
        List<int> GetDeletedNotice(string UserID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetUnreadNoticeCount")]
        Dictionary<int, string> GetUnreadNoticeCount(string UserID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/ConfirmDeleteNotice")]
        int ConfirmDeleteNotice(List<int> NoticeIDs,string UserID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/SeenNotice")]
        bool SeenNotice(int NoticeID,string UserID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "/GetNoticePagingByID")]
        IList<Notice> GetNoticePagingByID(int NoticeID, int PageSize, int GroupID, string UserID, bool isAdmin);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "/GetNoticeByID")]
        IList<Notice> GetNoticeByID(int NoticeId, int PageIndex, int GroupID, string UserID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "/GetNoticePaging")]
        IList<Notice> GetNoticePaging(int PageIndex, int PageSize, int GroupID, string UserID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/GetNoticePagingAdmin")]
        IList<Notice> GetNoticePagingAdmin(int PageIndex, int PageSize, int GroupID, string UserID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
              UriTemplate = "/GetNoticePagingCommon")]
        IList<Notice> GetNoticePagingCommon(int PageIndex, int PageSize, int GroupID, string UserID, bool isAdmin);

        #endregion
        #region AppVersion
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/SaveAppVersion")]
        bool SaveAppVersion(string Platform, string Version, string Date);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/GetAppVersion/{Platform}")]
        string GetAppVersion(string Platform);

        #endregion

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/SaveClientInfo")]
        string SaveClientInfo(Stream ImageData);

        #region Clients
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/CheckFaceIDAllowed")]
        bool CheckFaceIDAllowed(int ClientID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/CreateClient")]
        string CreateClient(Clients cl);
        #endregion
        #region AttendanceCode
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetOfflineAttendanceCodes")]
        IList<OfflineAttendanceCode> GetOfflineAttendanceCodes(string UserID, string FromDate);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetOfflineAttendanceCodesForSelectedGroups")]
        IList<OfflineAttendanceCode> GetOfflineAttendanceCodesForSelectedGroups(string UserID, string GroupIDs, string FromDate);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/GetAttendanceCode")]
        AttendanceCode GetAttendanceCode(int GroupID, string Date);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/CreateAttendanceCode")]
        int CreateAttendanceCode(int GroupID, string Date);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "DELETE",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/DeleteAttendanceCode")]
        string DeleteAttendanceCode(int GroupID, string Date);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetAttendanceCountForAUser")]
        int GetAttendanceCountForAUser(string UserID, int GroupID, string AttendanceDate);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/MarkSelfAttendanceType4")]
        string MarkSelfAttendanceType4(MemberAttendance a, string EmailList, int GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/MarkSelfAttendanceType5")]
        bool MarkSelfAttendanceType5(MemberAttendance a, string EmailList, int GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/MarkSelfAttendanceType3")]
        bool MarkSelfAttendanceType3(MemberAttendance a, string EmailList, int GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/MarkSelfAttendance")]
        bool MarkSelfAttendance(MemberAttendance a, string EmailList, int GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID, int AttendanceCode);
        #endregion


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/GetDistrictLevelDataForADate")]
        IList<BusinessObjects.FilterAttendance> GetDistrictLevelDataForADate(string date, int ClientID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/GetBlockLevelDataForADate")]
        IList<BusinessObjects.FilterAttendance> GetBlockLevelDataForADate(string date, string District, int ClientID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/GetClusterLevelDataForADate")]
        IList<BusinessObjects.FilterAttendance> GetClusterLevelDataForADate(string date, string District, string Block, int ClientID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/GetSchoolLevelDataForADate")]
        IList<BusinessObjects.FilterAttendance> GetSchoolLevelDataForADate(string date, string District, string Block, string Cluster, int ClientID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/GetClassLevelDataForADate")]
        IList<BusinessObjects.FilterAttendance> GetClassLevelDataForADate(string date, string District, string Block, string Cluster, string School, int ClientID);



        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/GetDashboardSummary")]
        DashboardSummary GetDashboardSummary(string date, int ClientID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetMemberAttendances")]
        IList<MemberAttendance> GetMemberAttendances(int GroupID, string Date);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/PostDefaultAttendanceOfGroup")]
        string PostDefaultAttendanceOfGroup(int GroupID, string Date);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/PostAttendanceList")]
        string PostAttendanceList(List<MemberAttendance> AttendanceList, string EmailList, string GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID, int FlowType, string WIFI_ID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "/PostAttendance")]
        string PostAttendance(MemberAttendance A);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/chkService")]
        string chkService(string s);

        [OperationContract]
        [WebInvoke(
            BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetOTPForgotPassword")]
        String GetOTPForgotPassword(string Username, string RecoveryNo);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetOTP", BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
           ResponseFormat = WebMessageFormat.Json)]
        String GetOTP();

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetCoupon", BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
          ResponseFormat = WebMessageFormat.Json)]
        String GetCoupon();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/PostSMS")]
        string PostSMS(string mobile, string message);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/PostEmail")]
        string PostEmail(string ToEmail, string Subject, string Body);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/CreateAttendance")]
        string CreateAttendance(string Attendance);
        // string CreateAttendance(string AttendanceDate, string UserID, string GroupID, string AttendanceStatus,string UDF1);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/CreateUserGroupMapping")]
        int CreateUserGroupMapping(UserGroupMapping mapping);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/DeleteGroup")]
        string DeleteGroup(int GroupID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/UpdateGroup")]
        UserGroups UpdateGroup(UserGroups group);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/CreateGroup")]
        UserGroups CreateGroup(UserGroups group);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetUserLogin")]
        User GetUserLogin(string UserName, string Password, string DeviceToken, string Platform);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/CreateUserDeviceTokenMapping")]
        int CreateUserDeviceTokenMapping(string UserID, string DeviceToken, string Platform);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "/GetAllGroupMembersForAGroup/{GroupID}")]
        IList<User> GetAllGroupMembersForAGroup(string GroupID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/GetGroupMembers/{GroupID}")]
        IList<User> GetGroupMembers(string GroupID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/GetUserGroup/{GroupID}")]
        UserGroups GetUserGroup(string GroupID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetUserbyCouponCode/{CouponCode}")]
        User GetUserbyCouponCode(string CouponCode);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "/GetUser/{UserName}/{Password}")]
        User GetUser(string UserName, string Password);



        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "/GetUserbyID/{UserID}")]
        User GetUserbyID(string UserID);
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/DeleteUser")]
        string DeleteUser(string UserID, int GroupID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/FirstTimeUpdatePassword")]
        string FirstTimeUpdatePassword(string UserID, string Password, string RecoveryNo);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/UpdatePassword")]
        string UpdatePassword(string UserID, string Password);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/UpdateUserV1")]
        User UpdateUserV1(User u, int GroupID, bool IsAdmin);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/CreateUserV1")]
        User CreateUserV1(User u, int GroupID, bool IsAdmin, string Session, int ClientID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/SetUser")]
        string SetUser(Stream StreamWithData);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/UpdateUser")]
        string UpdateUser(User u, int GroupID, bool IsAdmin);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/CreateUser")]
        string CreateUser(User u, int GroupID, bool IsAdmin, string Session, int ClientID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddLeave")]
        string AddLeave(string UserID, string LeaveType, string FromDate, string ToDate, int DaysCount,string Reason);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddUserToGroup")]
        string AddUserToGroup(int GroupId, int ClientId, string MobileNo, string Session, bool IsAdmin);

        
       [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "Post",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Lastmess")]
        string Lastmess(string GroupId);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/GetLastmessage/{GroupID}")]
        string GetLastmessage(string GroupId);



        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "/GetReadUsers/{GroupID}")]
        User GetReadUsers(string GroupID);
    }
}
