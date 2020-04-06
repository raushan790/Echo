using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessObjects;
using DataObjects;
using System.Collections.Specialized;
using System.Web.Hosting;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using EchoClassic.DataContract;
using DataObjects.AdoNet;
using System.ServiceModel.Web;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;

namespace EchoClassic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    
        public String GetWelcomeMessage()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string s = "Hi , Welcome to Echo Service ";
            //List<string> li= new List<string>();
            //li.Add("f1fdf441-2858-430c-b314-97ab36d52d63");
            //CreateNotice(124343,li, "Test_Test", "Test Description", "f1fdf441-2858-430c-b314-97ab36d52d63", "2020-03-06", "", 0, 227, 1, 1);
            //var ss = GetNoticeByID(227, 227, 124343, "f1fdf441-2858-430c-b314-97ab36d52d63");
            //IDictionary<string, string> dict = new Dictionary<string, string>()
            //{
            //    {"Data1","One" },
            //    {"Data2","Two" },
            //    {"Data3","Three" }
            //};
            ///SendPushDataAndroid("dJTlfd-aGzE:APA91bFsB5xERtCNIFZ8ctR2V266xWFcXe-lVoASpVySx86Cl25OnIXdaZJoInXK1k6nLD1sHSnHzo-jSt_7qMML2p35-HLumvv6N0en0kzBsHLRyeTLPatPz4wXRzCuxqk3ZdpJSVRT", dict);
            int b=DeleteNotice(338);
            //int b1 = DeleteNotice(283);
            //var li = GetDeletedNotice("f1fdf441-2858-430c-b314-97ab36d52d63");
            //int b2 = ConfirmDeleteNotice(li, "f1fdf441-2858-430c-b314-97ab36d52d63");
            return s.ToString();
        }
        public string ChkHindiFont(string HindiName)
        {
            return HindiName;
            //string Query = string.Format("insert into test values('" + EnglishName + "','" + HindiName + "','" + HindiName + "')");
            ////string Query = string.Format("select*from test");
            ////values('" + s.RollNumber + "','" + s.Name + "','" + s.Address + "')");

            //SqlCommand cmd = new SqlCommand(Query);
            //String constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //SqlConnection con = new SqlConnection(constr);
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = con;
            //// SqlDataAdapter da = new SqlDataAdapter();
            //// da.SelectCommand = cmd;
            ////DataSet ds = new DataSet();
            //// da.Fill(ds);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            //string data = "I got Hindi " + HindiName + "and English" + EnglishName;
            //return data;
            //return (HindiName + " " + EnglishName);
        }

        public string RegisterFaceID(string UserID, string FaceID)
        {
            string result = string.Empty;
            SqlParameter[] m = new SqlParameter[2];
            m[0] = new SqlParameter("@UserID", UserID);
            m[1] = new SqlParameter("@FaceID", FaceID);
            try
            {
                int chk = Convert.ToInt32(SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "RegisterFaceID", m));
                if (chk == 1)
                {
                    result = "Success";
                }
            }
            catch (Exception ex)
            {

                result = "Failed "+ex.Message;
            }
            return result;
        }


        #region New Dashboard
        public int AttendanceLiveCounter(int ClientID)
        {
            return DataAccess.DashboardDao.AttendanceLiveCounter(ClientID, General.GetCurrentSession, DateTime.UtcNow.AddHours(5.5));
        }
        #endregion

        #region DeepLinking

        //public DeepLinking GetAttendanceCode(int GroupID, string Date)
        //{
        //    return DataAccess.AttendanceCodeDao.GetAttendanceCode(GroupID, DateTime.Parse(Date));
        //}

        public int CreateDeepLinking(DeepLinking link)
        {

            link.CreateDate = DateTime.UtcNow.AddHours(5.5);
            link.ModifiedDate = DateTime.UtcNow.AddHours(5.5);

            int url = DataAccess.DeepLinkingDao.CreateDeepLinking(link);
            return url;
        }
        public int DeleteDeepLinking(string Url)
        {
            return DataAccess.DeepLinkingDao.DeleteDeepLinking(Url);
        }
        public DeepLinking GetDeepLinkingByUrl(string Url)
        {
            DeepLinking DpLink = new DeepLinking();
            try
            {
                DpLink = DataAccess.DeepLinkingDao.GetDeepLinkingbyUrl(Url);
                return DpLink;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DeepLinking GetDeepLinkingByCreatedBy(string CreatedBy)
        {
            DeepLinking DpLink = new DeepLinking();
            try
            {
                DpLink = DataAccess.DeepLinkingDao.GetDeepLinkingbyCreatedBy(CreatedBy);
                return DpLink;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Notice

        public string SendPushNotificationAndroid(string DeviceToken, string Title, string Message)
        {
            try
            {
                return General.SendPushNotificationAndroid(DeviceToken, Title, Message);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string SendPushDataAndroid(string DeviceToken, dynamic Data)
        {
            try
            {
                return General.SendPushDataAndroid(DeviceToken, Data);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string SendPushNotificationIOS(string DeviceToken, string Title, string Message)
        {
            try
            {
                return General.SendPushNotificationIOS(DeviceToken, Title, Message);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<Notice> GetNoticePagingByID(int NoticeID, int PageSize, int GroupID, string UserID, bool isAdmin)
        {
            IList<Notice> noticeList = null;
            if (isAdmin)
            {
                noticeList = DataAccess.NoticeDao.GetNoticePagingAdminByID(NoticeID, PageSize, GroupID, UserID);

            }
            if (!isAdmin)
            {
                noticeList = DataAccess.NoticeDao.GetNoticePagingByID(NoticeID, PageSize, GroupID, UserID);

            }
            return noticeList;
        }

        public IList<Notice> GetNoticeByID(int NoticeId, int PageIndex, int GroupID, string UserID)
        {
            IList<Notice> noticeList = null;
            noticeList = DataAccess.NoticeDao.GetNoticeByID(NoticeId,PageIndex, GroupID, UserID);

            return noticeList;
        }

        public IList<Notice> GetNoticePagingCommon(int PageIndex, int PageSize, int GroupID, string UserID, bool isAdmin)
        {
            IList<Notice> noticeList = null;
            if (isAdmin)
            {
                noticeList = DataAccess.NoticeDao.GetNoticePagingAdmin(PageIndex, PageSize, GroupID, UserID);

            }
            if (!isAdmin)
            {
                noticeList = DataAccess.NoticeDao.GetNoticePaging(PageIndex, PageSize, GroupID, UserID);

            }
            return noticeList;

        }
        public IList<Notice> GetNoticePaging(int PageIndex, int PageSize, int GroupID, string UserID)
        {
            return DataAccess.NoticeDao.GetNoticePaging(PageIndex, PageSize, GroupID, UserID);
        }
        public IList<Notice> GetNoticePagingAdmin(int PageIndex, int PageSize, int GroupID, string UserID)
        {
            return DataAccess.NoticeDao.GetNoticePagingAdmin(PageIndex, PageSize, GroupID, UserID);
        }
        public int CreateNotice(int GroupID, IList<string> UserIDs, string NoticeTitle, string NoticeDetail, string Createdby, string NoticeDate, string FileName, int FileType=0,int ParentId = 0, int IsSms = 0, int IsReply=0)
        {
            int result = 0;
            try
            {
                result = DataAccess.NoticeDao.CreateNotice(GroupID, UserIDs, NoticeTitle, NoticeDetail, Createdby, DateTime.UtcNow.AddHours(5.5), FileName, FileType,ParentId,IsSms,IsReply);
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }
        public Notice CreateNoticeV1(Stream StreamWithData)
        {

            IList<string> UserIDList = null;
            int GroupID = 0;

            string UserIDs = string.Empty;
            string NoticeTitle = string.Empty;
            string NoticeDetail = string.Empty;
            string Createdby = string.Empty;
            string NoticeDate = string.Empty;
            string BinaryFileName = string.Empty;
            int FileType = 0;
            int ParentId = 0;
            int IsSms = 0;
            int IsReply = 0;
            Notice n = new Notice();
            try
            {
                byte[] buf = new byte[1024000];
                MultipartParser parser = new MultipartParser(StreamWithData);

                if (parser != null && parser.Success)
                {

                    foreach (var item in parser.MyContents)
                    {
                        //Check our requested fordata
                        if (item.PropertyName == "GroupID")
                        {
                            GroupID = Convert.ToInt32(item.StringData.Replace("\r", "").Trim());

                        }
                        if (item.PropertyName == "UserIDs")
                        {
                            UserIDs = item.StringData.Replace("\r", "").Trim();
                            if (UserIDs != string.Empty)
                            {
                                UserIDList = UserIDs.Split(',').ToList();
                            }
                            //parser.MyContents.Select(item.PropertyName);
                        }
                        if (item.PropertyName == "NoticeTitle")
                        {
                            NoticeTitle = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "NoticeDetail")
                        {
                            NoticeDetail = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "Createdby")
                        {
                            Createdby = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "NoticeDate")
                        {
                            NoticeDate = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "FileType")
                        {
                            FileType = Convert.ToInt32(item.StringData.Replace("\r", "").Trim());

                        }
                        if (item.PropertyName == "ParentId")
                        {
                            ParentId = Convert.ToInt32(item.StringData.Replace("\r", "").Trim());

                        }
                        if (item.PropertyName == "IsSms")
                        {
                            IsSms = Convert.ToInt32(item.StringData.Replace("\r", "").Trim());

                        }
                        if (item.PropertyName == "IsReply")
                        {
                            IsReply = Convert.ToInt32(item.StringData.Replace("\r", "").Trim());

                        }




                    }
                    if (parser.FileContents!=null)
                    {


                        if (parser.FileContents.Length > 0)
                        {
                            if (parser.Filename != string.Empty)
                            {
                                using (MemoryStream ms = new MemoryStream(parser.FileContents))
                                {
                                    int capacity = ms.Capacity;
                                    byte[] buffer = new byte[capacity];
                                    ms.Read(buffer, 0, buffer.Length);
                                    BinaryFileName = DateTime.UtcNow.AddHours(5.5).ToString("mmddyyyyhhmmss") + parser.Filename.Replace("\r", "");

                                    FileStream f = new FileStream(HostingEnvironment.MapPath("~/NoticeData/" + BinaryFileName), FileMode.OpenOrCreate);
                                    f.Write(buffer, 0, buffer.Length);
                                    f.Close();
                                    //BinaryFileName = parser.Filename.Replace("\r", "");
                                }
                            }

                        }
                    }
                }
                if (NoticeDetail != string.Empty && NoticeDate != string.Empty && GroupID != 0)
                {
                   int noticeID= CreateNotice(GroupID, UserIDList, NoticeTitle, NoticeDetail, Createdby, NoticeDate, BinaryFileName,FileType,ParentId,IsSms,IsReply);
                    
                    n.NoticeID = noticeID;
                    n.GroupID = GroupID;
                    n.UserID = Createdby;
                    n.NoticeData = NoticeDetail;
                    n.NoticeTitle = NoticeTitle;
                    n.NoticeDate = NoticeDate;
                    n.FileName = BinaryFileName;
                    n.FileType = FileType;
                    n.IsRead = true;
                    n.ParentId = ParentId;
                    n.IsSms = IsSms;
                    n.IsReply = IsReply;
                }


            }
            catch (Exception ex)
            {

                n= null;
            }
            return n;
        }
        public int DeleteNotice(int NoticeID)
        {
            DataSet ds= DataAccess.NoticeDao.DeleteNotice(NoticeID);
            Thread t = new Thread(() => sendNotification(ds, NoticeID));
            t.Start();
            //sendNotification(ds, NoticeID);
            if (ds.Tables[0].Rows.Count>0)
                return 1;
            return 0;
        }

        public Dictionary<int,int> GetUnreadNoticeCount(string UserId)
        {
            DataSet ds = DataAccess.NoticeDao.GetUnreadNoticeCount(UserId);
            Dictionary<int, int> NoticeCount = new Dictionary<int, int>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int groupID = dr.Field<int>("GroupID");
                    int count = dr.Field<int>("UnreadCount");
                    NoticeCount.Add(groupID, count);
                }
            }
            return NoticeCount;
        }

        private void sendNotification(DataSet ds,int NoticeId) {
            try
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr.Field<string>("Platform").Equals("Android"))
                    {
                        string deviceToken = dr.Field<string>("DeviceToken");
                        IDictionary<string, int> dict = new Dictionary<string, int>()
                        {
                            {"DeletedNoticeId",NoticeId }
                        };
                        General.SendPushDataAndroid(deviceToken, dict);
                        //General.SendPushDataAndroid("ebAwHp3A0Zw:APA91bFQ4QqEYrb76J6rUK9HJX9G1u6UZO7wgFvOZvONW103Cz-k2mprD_BVYkDQNreIajfXPjYtxO0OT0ISeS1ebEmk-x_8lDjCM56HvBP0j8qIVCk-cH9eb48xI0erMaaorv7eeRLp", dict);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<int> GetDeletedNotice(string UserID)
        {
            return DataAccess.NoticeDao.GetDeletedNotice(UserID);
        }

        public int ConfirmDeleteNotice(List<int> NoticeIDs, string UserID)
        {
            return DataAccess.NoticeDao.ConfirmDeleteNotice(NoticeIDs,UserID);
        }

        public bool SeenNotice(int NoticeID, string UserID)
        {
            return DataAccess.NoticeDao.SeenNotice(NoticeID,UserID);
        }
        #endregion
        #region AppVersion
        public bool SaveAppVersion(string Platform, string Version, string Date)
        {
            bool result = false;
            SqlParameter[] m = new SqlParameter[4];
            m[0] = new SqlParameter("@ID", SqlDbType.Int);
            m[1] = new SqlParameter("@Platform", Platform);
            m[2] = new SqlParameter("@Version", Version);
            m[3] = new SqlParameter("@Date", DateTime.Parse(Date).Date);

            m[0].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "AppVersion_Insert", m);
            object ivalue = m[0].Value;
            if ((int)ivalue > 0)
            {
                result = true;
            }
            return result;
        }

        public string GetAppVersion(string Platform)
        {
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@Platform", Platform);

            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAppVersion", m);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string av = string.Empty;
                av = ds.Tables[0].Rows[0]["Version"].ToString();
                return av;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion


        #region Clients
        //Method For Save Image File 
        public static bool SaveImageFile(byte[] ImageFileContent, string ClientID)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(ImageFileContent))
                {
                    int capacity = ms.Capacity;
                    byte[] buffer = new byte[capacity];
                    ms.Read(buffer, 0, buffer.Length);

                    FileStream f = new FileStream(HostingEnvironment.MapPath("~/images/" + ClientID.Replace("\r", "") + ".jpg"), FileMode.OpenOrCreate);
                    f.Write(buffer, 0, buffer.Length);
                    f.Close();

                }


                return true;
            }
            catch
            {
                //Do Code For Log or Handle Exception 
                return false;
            }
        }

        //ImageCodecInfo:- It provides the necessary storage members and methods to retrieve all pertinent information about the installed image codecs.
        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public string SaveClientInfo(Stream ImageData)
        {
            // https://stackoverflow.com/questions/9451141/uploading-an-image-using-wcf-restful-service-full-working-example
            string result = string.Empty;
            try
            {
                byte[] buf = new byte[1024000];

                MultipartParser parser = new MultipartParser(ImageData);


                if (parser != null && parser.Success)
                {
                    //Fetch Requested Formdata (content) 
                    //(for this example our requested formdata are UserName[String])
                    string ClientID = string.Empty;
                    Clients cl = new Clients();

                    foreach (var item in parser.MyContents)
                    {
                        //Check our request fordata
                        if (item.PropertyName == "OptedForFaceID")
                        {
                            cl.UDF1 = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "OrganizationName")
                        {
                            cl.OrganizationName = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "ContactPersonName")
                        {
                            cl.ContactPersonName = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "MobileNo")
                        {
                            cl.MobileNo = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "Email")
                        {
                            cl.Email = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "Password")
                        {
                            cl.UDF2 = item.StringData.Replace("\r", "").Trim();

                        }

                    }
                    result = CreateClient(cl);
                    if (result != "-1")
                    {
                        ClientID = result.Split(' ')[0];
                        if (parser.FileContents.Length > 0)
                        {
                            SaveImageFile(parser.FileContents, ClientID);
                        }
                    }
                }

                //result = SaveClientLogo(ImageData);
                //byte[] buffer = new byte[1024000];
                //ImageData.Read(buffer, 0, 1024000);
                //string GroupID = "chkimage";
                //FileStream f = new FileStream(HostingEnvironment.MapPath("~/images/" + GroupID + ".jpg"), FileMode.OpenOrCreate);
                //f.Write(buffer, 0, buffer.Length);
                //f.Close();
                //ImageData.Close();

                // result = "Success";
            }
            catch (Exception ex)
            {

                result = ex.Message;
            }
            return result;

        }
        public string CreateClient(Clients cl)
        {
            if (!isExist(cl.MobileNo))
            {

                cl.Address = string.Empty;
                cl.City = string.Empty;
                cl.State = string.Empty;

                cl.MemberCount = 0;
                cl.UserAllowed = string.Empty;
                cl.CreateDate = DateTime.UtcNow.AddHours(5.5);
                int ClientID = DataAccess.ClientsDao.CreateClient(cl);

                //Create super admin
                User u = new User();
                string strUserID = string.Empty;


                string CouponCode = string.Empty;
                u.FirstName = cl.ContactPersonName;
                u.EMail = cl.Email;
                u.MobileNo = cl.MobileNo;
                u.CreateDate = DateTime.Now;
                u.DOB = Convert.ToDateTime("1/1/1900");
                u.LastLockoutDate = DateTime.Now;
                u.LastLoginDate = DateTime.Now;
                u.LastPasswordChangedDate = DateTime.Now;
                u.CouponCode = CouponCode;
                u.IsDeleted = false;
                u.IsLockedOut = false;
                u.RoleID = 2;
                u.Custom1 = "0";
                u.Custom2 = string.Empty;
                u.Custom3 = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                u.Custom4 = "Super Admin";
                u.Custom5 = "3";
                u.PWD = Encryption.Encrypt(cl.UDF2);
                u.ChangedPassword = true;
                u.Session = General.GetCurrentSession;
                u.ClientID = ClientID;
                strUserID = DataAccess.UserDao.CreateUser(u);
                FirstTimeUpdatePassword(strUserID, cl.UDF2, u.MobileNo);
                return ClientID.ToString() + " " + strUserID;

            }
            else
            {
                return "-1";
            }
        }

        public bool CheckFaceIDAllowed(int ClientID)
        {
            bool result = false;
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ClientID", ClientID);
            try
            {
                int chk= Convert.ToInt32(SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "CheckFaceIDAllowedForClient", m));
                if(chk==1)
                {
                    result = true;
                }
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }
        #endregion
        #region AttendanceCode
        public int UpdateOfflineAttendanceCodeTimeOfUse(int GroupID, string Date, string Time)
        {
            DateTime DateOfUse = Convert.ToDateTime(Date);
            DateTime UsedDateTime = Convert.ToDateTime(Date + " " + Time);
            return DataAccess.AttendanceCodeDao.UpdateOfflineAttendanceCodeTimeOfUse(GroupID, DateOfUse, UsedDateTime);
        }

        public IList<OfflineAttendanceCode> GetOfflineAttendanceCodes(string UserID, string FromDate)
        {
            try
            {

                return DataAccess.AttendanceCodeDao.GetOfflineAttendanceCodes(UserID, Convert.ToDateTime(FromDate));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<OfflineAttendanceCode> GetOfflineAttendanceCodesForSelectedGroups(string UserID, string GroupIDs, string FromDate)
        {
            try
            {
                return DataAccess.AttendanceCodeDao.GetOfflineAttendanceCodes(UserID, GroupIDs, Convert.ToDateTime(FromDate));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int CreateAttendanceCode(int GroupID, string Date)
        {
            IList<MemberAttendance> attendanceForDate = DataAccess.MemberAttendanceDao.GetMemberAttendances(GroupID, DateTime.Parse(Date)).ToList();

            if (attendanceForDate.Count == 0)
            {
                IList<User> Members = GetGroupMembers(GroupID.ToString());
                if (Members.Count > 0)
                {
                    foreach (User u in Members)
                    {
                        MemberAttendance ma = new MemberAttendance();
                        ma.AttendanceDate = DateTime.Parse(Date);
                        ma.AttendanceStatus = "Absent";
                        ma.AttendanceTime = DateTime.UtcNow.AddHours(5.5).ToShortTimeString();
                        ma.ClientID = u.ClientID;
                        ma.CreateDate = DateTime.UtcNow.AddHours(5.5);
                        ma.Device = "Mobile";
                        ma.DeviceIDOrName = string.Empty;
                        ma.DeviceLocation = string.Empty;
                        ma.GroupID = GroupID;
                        ma.Session = General.GetCurrentSession;
                        ma.UDF1 = "0";
                        ma.UDF2 = u.FirstName;
                        ma.UDF3 = "Teacher";
                        ma.UserID = u.UserID;
                        DataAccess.MemberAttendanceDao.CreateMemberAttendance(ma);
                    }
                }
            }


            DeleteAttendanceCode(GroupID, Date);
            int Code = GetCodeForAttendance();
            AttendanceCode attendanceCode = new AttendanceCode();
            attendanceCode.AttendanceDate = DateTime.Parse(Date);
            attendanceCode.GroupID = GroupID;
            attendanceCode.Code = Code;
            attendanceCode.CreateDate = DateTime.UtcNow.AddHours(5.5);
            try
            {
                DataAccess.AttendanceCodeDao.CreateAttendanceCode(attendanceCode);
                return Code;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public string DeleteAttendanceCode(int GroupID, string Date)
        {

            return DataAccess.AttendanceCodeDao.DeleteAttendanceCode(GroupID, DateTime.Parse(Date));
        }
        public AttendanceCode GetAttendanceCode(int GroupID, string Date)
        {
            return DataAccess.AttendanceCodeDao.GetAttendanceCode(GroupID, DateTime.Parse(Date));
        }
        public int GetAttendanceCountForAUser(string UserID, int GroupID, string AttendanceDate)
        {
            int Count = 0;
            Count = DataAccess.MemberAttendanceDao.GetAttendanceCountByUser(UserID, GroupID, DateTime.Parse(AttendanceDate));
            return Count;
        }
        public string MarkSelfAttendanceType4(MemberAttendance a, string EmailList, int GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID)
        {
            int AttendanceCount = DataAccess.MemberAttendanceDao.GetAttendanceCountByUser(a.UserID, GroupID, DateTime.Parse(AttendanceDate));

            if (AttendanceCount % 2 == 0)
            {
                a.AttendanceStatus = "Checkin";
            }
            else
            {
                a.AttendanceStatus = "Checkout";
            }
            a.AttendanceDate = DateTime.Parse(AttendanceDate);
            a.GroupID = Convert.ToInt32(GroupID);
            a.UDF1 = UDF1;
            a.UDF3 = MarkedBy;
            a.CreateDate = DateTime.UtcNow.AddHours(5.5);
            a.AttendanceTime = Time;
            a.Device = Device;
            a.DeviceIDOrName = DeviceIDOrName;
            a.DeviceLocation = DeviceLocation;
            a.ClientID = ClientID;
            a.Session = Session;
            DataAccess.MemberAttendanceDao.CreateMemberAttendance(a);
            return a.AttendanceStatus;
        }
        public bool MarkSelfAttendanceType3(MemberAttendance a, string EmailList, int GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID)
        {
            int AttChk = DataAccess.MemberAttendanceDao.CheckMemberAttendance(GroupID, DateTime.Parse(AttendanceDate));
            if (AttChk == 0)
            {
                IList<User> Members = GetGroupMembers(GroupID.ToString());
                if (Members.Count > 0)
                {
                    foreach (User u in Members)
                    {
                        MemberAttendance ma = new MemberAttendance();
                        ma.AttendanceDate = DateTime.Parse(AttendanceDate);
                        ma.AttendanceStatus = "Absent";
                        ma.AttendanceTime = DateTime.UtcNow.AddHours(5.5).ToShortTimeString();
                        ma.ClientID = ClientID;
                        ma.CreateDate = DateTime.UtcNow.AddHours(5.5);
                        ma.Device = "Mobile";
                        ma.DeviceIDOrName = string.Empty;
                        ma.DeviceLocation = string.Empty;
                        ma.GroupID = GroupID;
                        ma.Session = General.GetCurrentSession;
                        ma.UDF1 = "0";
                        ma.UDF2 = u.FirstName;
                        ma.UDF3 = "Teacher";
                        ma.UserID = u.UserID;
                        DataAccess.MemberAttendanceDao.CreateMemberAttendance(ma);
                    }
                }
            }
            bool result = false;

            a.AttendanceDate = DateTime.Parse(AttendanceDate);
            a.GroupID = Convert.ToInt32(GroupID);
            a.UDF1 = UDF1;
            a.UDF3 = MarkedBy;
            a.CreateDate = DateTime.UtcNow.AddHours(5.5);
            a.AttendanceTime = Time;
            a.Device = Device;
            a.DeviceIDOrName = DeviceIDOrName;
            a.DeviceLocation = DeviceLocation;
            a.ClientID = ClientID;
            a.Session = Session;

            DataAccess.MemberAttendanceDao.UpdateMemberAttendance(a.UserID, Convert.ToInt32(GroupID), DateTime.Parse(AttendanceDate), a.AttendanceStatus, Convert.ToInt32(UDF1), Time, Device, DeviceIDOrName, DeviceLocation, MarkedBy).ToString();
            result = true;

            return result;
        }
        public bool MarkSelfAttendance(MemberAttendance a, string EmailList, int GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID, int AttendanceCode)
        {
            bool result = false;
            int Code = 0;// DataAccess.AttendanceCodeDao.VerifyAttendanceCode(GroupID, DateTime.Parse(AttendanceDate));
            AttendanceCode attendanceCode = DataAccess.AttendanceCodeDao.GetAttendanceCode(GroupID, DateTime.Parse(AttendanceDate));
            if (attendanceCode != null)
            {
                DateTime expiryDate = attendanceCode.CreateDate.AddSeconds(30);
                if (DateTime.UtcNow.AddHours(5.5) <= expiryDate)
                {
                    Code = attendanceCode.Code;
                }
                else
                {
                    DataAccess.AttendanceCodeDao.DeleteAttendanceCode(GroupID, DateTime.Parse(AttendanceDate));
                }
            }
            if (Code > 0 && Code == AttendanceCode)
            {
                a.AttendanceDate = DateTime.Parse(AttendanceDate);
                a.GroupID = Convert.ToInt32(GroupID);
                a.UDF1 = UDF1;
                a.UDF3 = MarkedBy;
                a.CreateDate = DateTime.UtcNow.AddHours(5.5);
                a.AttendanceTime = Time;
                a.Device = Device;
                a.DeviceIDOrName = DeviceIDOrName;
                a.DeviceLocation = DeviceLocation;
                a.ClientID = ClientID;
                a.Session = Session;

                int chk = DataAccess.MemberAttendanceDao.UpdateMemberAttendance(a.UserID, Convert.ToInt32(GroupID), DateTime.Parse(AttendanceDate), a.AttendanceStatus, Convert.ToInt32(UDF1), Time, Device, DeviceIDOrName, DeviceLocation, MarkedBy);


                // DataAccess.MemberAttendanceDao.CreateMemberAttendance(a).ToString();
                if (chk > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool MarkSelfAttendanceType5(MemberAttendance a, string EmailList, int GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID)
        {
            int AttChk = DataAccess.MemberAttendanceDao.CheckMemberAttendance(GroupID, DateTime.Parse(AttendanceDate));
            if (AttChk == 0)
            {
                IList<User> Members = GetGroupMembers(GroupID.ToString());
                if (Members.Count > 0)
                {
                    foreach (User u in Members)
                    {
                        MemberAttendance ma = new MemberAttendance();
                        ma.AttendanceDate = DateTime.Parse(AttendanceDate);
                        ma.AttendanceStatus = "Absent";
                        ma.AttendanceTime = DateTime.UtcNow.AddHours(5.5).ToShortTimeString();
                        ma.ClientID = ClientID;
                        ma.CreateDate = DateTime.UtcNow.AddHours(5.5);
                        ma.Device = "Mobile";
                        ma.DeviceIDOrName = string.Empty;
                        ma.DeviceLocation = string.Empty;
                        ma.GroupID = GroupID;
                        ma.Session = General.GetCurrentSession;
                        ma.UDF1 = "0";
                        ma.UDF2 = u.FirstName;
                        ma.UDF3 = MarkedBy;
                        ma.UserID = u.UserID;
                        DataAccess.MemberAttendanceDao.CreateMemberAttendance(ma);
                    }
                }
            }
            bool result = false;

            a.AttendanceDate = DateTime.Parse(AttendanceDate);
            a.GroupID = Convert.ToInt32(GroupID);
            a.UDF1 = UDF1;
            a.UDF3 = MarkedBy;
            a.CreateDate = DateTime.UtcNow.AddHours(5.5);
            a.AttendanceTime = Time;
            a.Device = Device;
            a.DeviceIDOrName = DeviceIDOrName;
            a.DeviceLocation = DeviceLocation;
            a.ClientID = ClientID;
            a.Session = Session;

            DataAccess.MemberAttendanceDao.UpdateMemberAttendance(a.UserID, Convert.ToInt32(GroupID), DateTime.Parse(AttendanceDate), a.AttendanceStatus, Convert.ToInt32(UDF1), Time, Device, DeviceIDOrName, DeviceLocation, MarkedBy).ToString();
            result = true;

            return result;
        }

        public int GetCodeForAttendance()
        {
            Random random = new Random();
            return random.Next(100001, 999999);
        }
        #endregion
        public IList<BusinessObjects.FilterAttendance> GetDistrictLevelDataForADate(string date, int ClientID)
        {
            try
            {
                return DataAccess.AnalyticsDao.GetDistrictLevelDataForADate(DateTime.Parse(date), ClientID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetBlockLevelDataForADate(string date, string District, int ClientID)
        {
            try
            {
                return DataAccess.AnalyticsDao.GetBlockLevelDataForADate(DateTime.Parse(date), District, ClientID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetClusterLevelDataForADate(string date, string District, string Block, int ClientID)
        {
            try
            {
                return DataAccess.AnalyticsDao.GetClusterLevelDataForADate(DateTime.Parse(date), District, Block, ClientID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetSchoolLevelDataForADate(string date, string District, string Block, string Cluster, int ClientID)
        {
            try
            {
                return DataAccess.AnalyticsDao.GetSchoolLevelDataForADate(DateTime.Parse(date), District, Block, Cluster, ClientID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetClassLevelDataForADate(string date, string District, string Block, string Cluster, string School, int ClientID)
        {
            try
            {
                return DataAccess.AnalyticsDao.GetClassLevelDataForADate(DateTime.Parse(date), District, Block, Cluster, School, ClientID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DashboardSummary GetDashboardSummary(string date, int ClientID)
        {
            try
            {
                return DataAccess.AnalyticsDao.GetDashboardSummary(DateTime.Parse(date), ClientID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IList<MemberAttendance> GetMemberAttendances(int GroupID, string Date)
        {
            IList<MemberAttendance> aList = DataAccess.MemberAttendanceDao.GetMemberAttendances(GroupID, DateTime.Parse(Date)).Where(ss => ss.AttendanceStatus == "Present").ToList();
            return aList;
        }
        public string PostDefaultAttendanceOfGroup(int GroupID, string Date)
        {
            try
            {
                IList<MemberAttendance> attendanceForDate = GetMemberAttendances(GroupID, Date);
                if (attendanceForDate.Count == 0)
                {
                    IList<User> Members = GetGroupMembers(GroupID.ToString());
                    if (Members.Count > 0)
                    {
                        foreach (User u in Members)
                        {
                            MemberAttendance ma = new MemberAttendance();
                            ma.AttendanceDate = DateTime.Parse(Date);
                            ma.AttendanceStatus = "Absent";
                            ma.AttendanceTime = DateTime.UtcNow.AddHours(5.5).ToShortTimeString();
                            ma.ClientID = 2;
                            ma.CreateDate = DateTime.UtcNow.AddHours(5.5);
                            ma.Device = "Mobile";
                            ma.DeviceIDOrName = string.Empty;
                            ma.DeviceLocation = string.Empty;
                            ma.GroupID = GroupID;
                            ma.Session = General.GetCurrentSession;
                            ma.UDF1 = "0";
                            ma.UDF2 = u.FirstName;
                            ma.UDF3 = "Teacher";
                            ma.UserID = u.UserID;
                            DataAccess.MemberAttendanceDao.CreateMemberAttendance(ma);
                        }

                    }
                }
                return "Success";
            }
            catch (Exception)
            {

                throw;
            }

        }
        public string PostAttendanceListUni(List<MemberAttendance> AttendanceList, string EmailList, string GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID, string WIFI_ID)
        {
            try
            {
                foreach (MemberAttendance a in AttendanceList)
                {
                    a.AttendanceDate = DateTime.Parse(AttendanceDate);
                    a.GroupID = Convert.ToInt32(GroupID);
                    a.UDF1 = "2";
                    a.UDF3 = MarkedBy;
                    a.CreateDate = DateTime.UtcNow.AddHours(5.5);
                    a.AttendanceTime = Time;
                    a.Device = Device;
                    a.DeviceIDOrName = DeviceIDOrName;
                    a.DeviceLocation = DeviceLocation;
                    a.ClientID = ClientID;
                    a.Session = Session;
                    DataAccess.MemberAttendanceDao.UpdateMemberAttendance(a.UserID, Convert.ToInt32(GroupID), DateTime.Parse(AttendanceDate), a.AttendanceStatus, Convert.ToInt32(a.UDF1), Time, Device, DeviceIDOrName, DeviceLocation, MarkedBy).ToString();
                }
                return "Success";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public string OfflinePostAttendanceListUni(List<MemberAttendance> AttendanceList, string EmailList, string GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID, string WIFI_ID)
        {
            try
            {
                int AttChk = DataAccess.MemberAttendanceDao.CheckMemberAttendance(Convert.ToInt32(GroupID), DateTime.Parse(AttendanceDate));
                if (AttChk == 0)
                {
                    foreach (MemberAttendance a in AttendanceList)
                    {
                        a.AttendanceDate = DateTime.Parse(AttendanceDate);
                        a.GroupID = Convert.ToInt32(GroupID);
                        a.UDF1 = "2";
                        a.UDF3 = MarkedBy;
                        a.CreateDate = DateTime.UtcNow.AddHours(5.5);
                        a.AttendanceTime = Time;
                        a.Device = Device;
                        a.DeviceIDOrName = DeviceIDOrName;
                        a.DeviceLocation = DeviceLocation;
                        a.ClientID = ClientID;
                        a.Session = Session;
                        DataAccess.MemberAttendanceDao.CreateMemberAttendance(a).ToString();
                    }
                }
                return "Success";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string PostAttendanceList(List<MemberAttendance> AttendanceList, string EmailList, string GroupID, string GroupName, string MarkedBy, string AttendanceDate, string Time, string UDF1, string Device, string DeviceIDOrName, string DeviceLocation, string Session, int ClientID, int FlowType, string WIFI_ID)
        {
            if (FlowType == 0)
            {
                return "-1";//This means App need to be Upgraded
            }
            else
            {
                if (FlowType != 1)
                {
                    if (FlowType == 5)
                        return OfflinePostAttendanceListUni(AttendanceList, EmailList, GroupID, GroupName, MarkedBy, AttendanceDate, Time, UDF1, Device, DeviceIDOrName, DeviceLocation, Session, ClientID, WIFI_ID);
                    else
                        return PostAttendanceListUni(AttendanceList, EmailList, GroupID, GroupName, MarkedBy, AttendanceDate, Time, UDF1, Device, DeviceIDOrName, DeviceLocation, Session, ClientID, WIFI_ID);
                }
                else
                {
                    try
                    {

                        foreach (MemberAttendance a in AttendanceList)
                        {
                            a.AttendanceDate = DateTime.Parse(AttendanceDate);
                            a.GroupID = Convert.ToInt32(GroupID);
                            a.UDF1 = UDF1;
                            a.UDF3 = MarkedBy;
                            a.CreateDate = DateTime.UtcNow.AddHours(5.5);
                            a.AttendanceTime = Time;
                            a.Device = Device;
                            a.DeviceIDOrName = DeviceIDOrName;
                            a.DeviceLocation = DeviceLocation;
                            a.ClientID = ClientID;
                            a.Session = Session;
                            DataAccess.MemberAttendanceDao.CreateMemberAttendance(a);

                        }
                        return "Success";
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }
        public IList<User> GetadminList(int GroupID)
        {
            IList<User> adminList = DataAccess.UserDao.SelectGroupAdmins(Convert.ToInt32(GroupID));
            return adminList;
        }
        public static string LoadHTML()
        {
            string file = HostingEnvironment.MapPath("~/EmailTemplates/Attendance.html");
            StreamReader objSR;
            FileInfo fi = new FileInfo(file);
            StringBuilder objSB = new StringBuilder();
            objSB.Append("");
            if (System.IO.File.Exists(file))
            {
                objSR = File.OpenText(file);
                objSB.Append(objSR.ReadToEnd());
                objSR.Close();
            }
            return Convert.ToString(objSB);
        }
        public string PostAttendance(MemberAttendance A)
        {
            return A.UserID + " this is return from service check";
        }
        public string chkService(string s)
        {
            return "this is return from service check";
        }
        public string PostSMS(string mobile, string message)
        {
            General.SendSMS(mobile, message);
            return string.Empty;
        }

        public string PostEmail(string ToEmail, string Subject, string Body)
        {
            return General.SendEmail(ToEmail, Subject, Body);
        }

        public string CreateAttendance(string Attendance)
        {
            return "success";
        }


        public int CreateUserGroupMapping(UserGroupMapping mapping)
        {
            int MappingID = 0;
            IList<UserGroupMapping> mlist = DataAccess.UserGroupMappingDao.UserGroupMappings(mapping.UserID);

            if (!mlist.Contains(mapping))
            {
                MappingID = DataAccess.UserGroupMappingDao.CreateMapping(mapping);

            }
            return MappingID;

        }
        public string DeleteGroup(int GroupID)
        {
            return DataAccess.UserGroupsDao.DeleteUserGroup(GroupID);
        }
        public UserGroups UpdateGroup(UserGroups group)
        {
            UserGroups ug = null;
            try
            {
                group.IsActive = true;
                int groupID = DataAccess.UserGroupsDao.UpdateUserGroup(group);
                ug = DataAccess.UserGroupsDao.GetUserGroup(group.UserGroupID);
                ug.isAdmin = true;
            }
            catch
            {

            }

            return ug;
        }


        public UserGroups CreateGroup(UserGroups group)
        {
            // string ss = Encryption.Decrypt("G3YBpw5wIooCTMFOUEGQiQ==");
            group.CreateDate = DateTime.UtcNow.AddHours(5.5);
            group.Image = string.Empty;
            group.IsActive = true;
            group.IsDeleted = false;
            group.IsRole = false;
            group.ModifiedDate = DateTime.UtcNow.AddHours(5.5);
            int groupID = DataAccess.UserGroupsDao.CreateUserGroup(group);

            string userID = string.Empty;
            SqlParameter[] m = new SqlParameter[1];
            m[0] = new SqlParameter("@ID", group.ClientID);
            SqlDataReader dr = SqlHelper.ExecuteReader(Connection.Connection_string, CommandType.StoredProcedure, "Client_Select", m);
            while (dr.Read())
            {
                m = new SqlParameter[2];
                m[0] = new SqlParameter("@ClientID", group.ClientID);
                m[1] = new SqlParameter("@Mobile", dr["MobileNo"].ToString());
                try
                {
                    userID = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "GetClientAdmin", m).ToString();
                }
                catch
                {
                }

            }
            if (userID != string.Empty)
            {
                UserGroupMapping objUserGroupMapping = new UserGroupMapping();
                objUserGroupMapping.UserGroupID = groupID;
                objUserGroupMapping.UserID = userID;
                objUserGroupMapping.isAdmin = true;
                objUserGroupMapping.SerialNoForGroup = "0";
                string strMsg = DataAccess.UserGroupMappingDao.CreateMapping(objUserGroupMapping).ToString();
            }
            group.UserGroupID = groupID;
            group.isAdmin = true;
            return group;
        }

        public IList<User> GetAllGroupMembersForAGroup(string GroupID)
        {
            IList<User> userList = DataAccess.UserDao.GetUsersByGroup(Convert.ToInt32(GroupID));

            return userList;
        }
        public IList<User> GetGroupMembers(string GroupID)
        {
            IList<User> userList = DataAccess.UserDao.GetUsersByGroup(Convert.ToInt32(GroupID));
            IList<User> AdminList = DataAccess.UserDao.SelectGroupAdmins(Convert.ToInt32(GroupID));
            var Students = userList.Where(o => !AdminList.Any(n => n.UserID == o.UserID)).ToList();

            return Students;
        }
        public UserGroups GetUserGroup(string GroupID)
        {
            UserGroups group = DataAccess.UserGroupsDao.GetUserGroup(Convert.ToInt32(GroupID));
            return group;
        }

        public User GetUserbyCouponCode(string CouponCode)
        {
            User chkUserDetails = new User();
            try
            {


                chkUserDetails = DataAccess.UserDao.GetUserByCouponCode(CouponCode);


                return chkUserDetails;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public User GetUser(string UserName, string Password)
        {
            User chkUserDetails = new User();
            try
            {
                bool isNumber = General.IsNumber(UserName.Trim());
                if (isNumber)
                {
                    chkUserDetails = DataAccess.UserDao.GetUserForLoginByMobile(UserName, Encryption.Encrypt(Password));

                }
                else
                {
                    chkUserDetails = DataAccess.UserDao.GetUser(UserName, Encryption.Encrypt(Password));

                }


                return chkUserDetails;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUserLogin(string UserName, string Password, string DeviceToken, string Platform)
        {
            //string ss= Encryption.Decrypt("cnlimnxsjeOwJQ6JT5CRxw==");
            User chkUserDetails = new User();
            try
            {
                chkUserDetails = DataAccess.UserDao.GetUserForLoginByMobile(UserName, Encryption.Encrypt(Password));
                if (chkUserDetails != null)
                {
                    IList<UserGroups> type1GroupAsMember = chkUserDetails.UserGroup.Where(ss => ss.isAdmin == false && ss.FlowType == 1).ToList();
                    if (type1GroupAsMember != null)
                    {
                        if (type1GroupAsMember.Count > 0)
                        {
                            foreach (UserGroups ug in type1GroupAsMember)
                            {
                                chkUserDetails.UserGroup.Remove(ug);

                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(DeviceToken) && !string.IsNullOrEmpty(Platform))
                    {
                        int i = DataAccess.UserDao.CreateUserDeviceTokenMapping(chkUserDetails.UserID, DeviceToken, Platform, DateTime.UtcNow.AddHours(5.5), DateTime.UtcNow.AddHours(5.5), string.Empty, string.Empty, string.Empty);

                    }
                }
                return chkUserDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int CreateUserDeviceTokenMapping(string UserID, string DeviceToken, string Platform)
        {
            int i = DataAccess.UserDao.CreateUserDeviceTokenMapping(UserID, DeviceToken, Platform, DateTime.UtcNow.AddHours(5.5), DateTime.UtcNow.AddHours(5.5), string.Empty, string.Empty, string.Empty);
            return i;
        }
        public string GenerateCoupon()

        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string Code = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();



            for (int i = 0; i < 12; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                Code += sTempChars;

            }
            bool verifyCoupon = DataAccess.UserDao.Verify_CouponCode(Code);

            if (verifyCoupon)
                GenerateCoupon();
            return Code;


        }
        public bool isExist(string Mobile)
        {
            bool isExist = false;
            User u = new User();
            if (Mobile != string.Empty)
            {
                u = DataAccess.UserDao.GetUserbyMobile(Mobile);
            }

            if (u != null)
            {
                isExist = true;
            }
            return isExist;
        }
        public string DeleteUser(string UserID, int GroupID)
        {
            try
            {

                return DataAccess.UserGroupMappingDao.DeleteMapping(UserID, GroupID).ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public User GetUserbyID(string UserID)
        {
            try
            {
                User chkUserDetails = new User();
                chkUserDetails = DataAccess.UserDao.GetUser(UserID);
                return chkUserDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string SetUser(Stream StreamWithData)
        {
            User chkUserDetails = new User();
            string BinaryFileName = string.Empty;

            try
            {
                byte[] buf = new byte[1024000];
                MultipartParser parser = new MultipartParser(StreamWithData);

                if (parser != null && parser.Success)
                {

                    foreach (var item in parser.MyContents)
                    {
                        //Check our requested fordata
                        if (item.PropertyName == "UserID")
                        {
                            chkUserDetails.UserID = Convert.ToString(item.StringData.Replace("\r", "").Trim());

                        }
                        if (item.PropertyName == "fname")
                        {
                            if (item.StringData.Replace("\r", "").Trim() != "")
                            {
                                chkUserDetails.FirstName = item.StringData.Replace("\r", "").Trim(); ;
                            }
                        }
                        if (item.PropertyName == "mobile")
                        {
                            if (item.StringData.Replace("\r", "").Trim() != "")
                            {
                                chkUserDetails.MobileNo = item.StringData.Replace("\r", "").Trim();
                            }
                        }

                        if (item.PropertyName == "email")
                        {
                            chkUserDetails.EMail = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "facebook")
                        {
                            chkUserDetails.Facebook = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "linkedin")
                        {
                            chkUserDetails.LinkedIn = item.StringData.Replace("\r", "").Trim();
                        }
                        if (item.PropertyName == "twitter")
                        {
                            chkUserDetails.Twitter = item.StringData.Replace("\r", "").Trim();
                        }
                        if (item.PropertyName == "Pimage")
                        {
                            chkUserDetails.ImageID = item.StringData.Replace("\r", "").Trim();
                        }
                    }
                    if (parser.FileContents != null)
                    {
                        if (parser.FileContents.Length > 0)
                        {
                            if (parser.Filename != string.Empty)
                            {
                                using (MemoryStream ms = new MemoryStream(parser.FileContents))
                                {
                                    int capacity = ms.Capacity;
                                    byte[] buffer = new byte[capacity];
                                    ms.Read(buffer, 0, buffer.Length);
                                    BinaryFileName = DateTime.UtcNow.AddHours(5.5).ToString("mmddyyyyhhmmss") + parser.Filename.Replace("\r", "");

                                    FileStream f = new FileStream(HostingEnvironment.MapPath("~/ProfilePic/" + BinaryFileName), FileMode.OpenOrCreate);
                                    f.Write(buffer, 0, buffer.Length);
                                    f.Close();
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                chkUserDetails = null;
            }
            var json = new JavaScriptSerializer().Serialize(chkUserDetails);
            return json;
        }


        public User SetUserNew(Stream StreamWithData)
        {
            User chkUserDetails = new User();
            string BinaryFileName = string.Empty;

            try
            {
                byte[] buf = new byte[1024000];
                MultipartParser parser = new MultipartParser(StreamWithData);

                if (parser != null && parser.Success)
                {

                    foreach (var item in parser.MyContents)
                    {
                        //Check our requested fordata
                        if (item.PropertyName == "UserID")
                        {
                            chkUserDetails.UserID = Convert.ToString(item.StringData.Replace("\r", "").Trim());

                        }
                        if (item.PropertyName == "fname")
                        {
                            if (item.StringData.Replace("\r", "").Trim() != "")
                            {
                                chkUserDetails.FirstName = item.StringData.Replace("\r", "").Trim(); ;
                            }
                        }
                        if (item.PropertyName == "mobile")
                        {
                            if (item.StringData.Replace("\r", "").Trim() != "")
                            {
                                chkUserDetails.MobileNo = item.StringData.Replace("\r", "").Trim();
                            }
                        }

                        if (item.PropertyName == "email")
                        {
                            chkUserDetails.EMail = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "facebook")
                        {
                            chkUserDetails.Facebook = item.StringData.Replace("\r", "").Trim();

                        }
                        if (item.PropertyName == "linkedin")
                        {
                            chkUserDetails.LinkedIn = item.StringData.Replace("\r", "").Trim();
                        }
                        if (item.PropertyName == "twitter")
                        {
                            chkUserDetails.Twitter = item.StringData.Replace("\r", "").Trim();
                        }
                        if (item.PropertyName == "Pimage")
                        {
                            chkUserDetails.ImageID = item.StringData.Replace("\r", "").Trim();
                        }
                    }
                    if (parser.FileContents != null)
                    {
                        if (parser.FileContents.Length > 0)
                        {
                            if (parser.Filename != string.Empty)
                            {
                                using (MemoryStream ms = new MemoryStream(parser.FileContents))
                                {
                                    int capacity = ms.Capacity;
                                    byte[] buffer = new byte[capacity];
                                    ms.Read(buffer, 0, buffer.Length);
                                    BinaryFileName = DateTime.UtcNow.AddHours(5.5).ToString("mmddyyyyhhmmss") + parser.Filename.Replace("\r", "");

                                    FileStream f = new FileStream(HostingEnvironment.MapPath("~/ProfilePic/" + BinaryFileName), FileMode.OpenOrCreate);
                                    f.Write(buffer, 0, buffer.Length);
                                    f.Close();
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                chkUserDetails = null;
            }
            return chkUserDetails;
            //    if(DataAccess.UserDao.setUserDetails(chkUserDetails).ToString()=="1")
            //    {
            //        return chkUserDetails;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }


        public string SetUser1(string UserID, string fname = "", string lname = "", string mobile = "", string email = "", string facebook = "", string linkedin = "", string twitter = "", string Pimage = "")
        {
            try
            {
                User chkUserDetails = new User();
                chkUserDetails.UserID = UserID;
                if (fname != "")
                {
                    chkUserDetails.FirstName = fname;
                }
                if (lname != "")
                {
                    chkUserDetails.LastName = lname;
                }
                if (mobile != "")
                {
                    chkUserDetails.MobileNo = mobile;
                }
                chkUserDetails.EMail = email;
                chkUserDetails.Facebook = facebook;
                chkUserDetails.LinkedIn = linkedin;
                chkUserDetails.Twitter = twitter;
                chkUserDetails.ImageID = Pimage;
                return DataAccess.UserDao.setUserDetails(chkUserDetails).ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string FirstTimeUpdatePassword(string UserID, string Password, string RecoveryNo)
        {
            try
            {
                Password = Encryption.Encrypt(Password);
                return DataAccess.UserDao.FirstTimeUpdatePassword(UserID, Password, RecoveryNo).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string UpdatePassword(string UserID, string Password)
        {
            try
            {
                Password = Encryption.Encrypt(Password);
                return DataAccess.UserDao.ChangePassword(UserID, Password).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User UpdateUserV1(User u, int GroupID, bool IsAdmin)
        {
            try
            {
                string CouponCode = string.Empty;
                u.CreateDate = DateTime.Now;
                u.DOB = Convert.ToDateTime("1/1/1900");
                u.LastLockoutDate = DateTime.Now;
                u.LastLoginDate = DateTime.Now;
                u.LastPasswordChangedDate = DateTime.Now;
                u.CouponCode = CouponCode;
                u.IsDeleted = false;
                u.IsLockedOut = false;
                u.RoleID = 4;
                UserGroups ug = DataAccess.UserGroupsDao.GetUserGroup(GroupID);
                if (ug.FlowType != 1)
                {
                    u.IsLockedOut = false;

                }
                //u.Custom5 = String.Empty;
                string userID = string.Empty;
                userID = DataAccess.UserDao.UpdateUser(u).ToString();
                UserGroupMapping m = new UserGroupMapping();
                m.UserID = u.UserID;
                m.UserGroupID = GroupID;
                m.isAdmin = IsAdmin;
                m.SerialNoForGroup = u.Custom1;
                DataAccess.UserGroupMappingDao.DeleteMapping(u.UserID, GroupID);
                DataAccess.UserGroupMappingDao.CreateMapping(m);
                u.IsAdmin = IsAdmin;
                return u;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public User CreateUserV1(User u, int GroupID, bool IsAdmin, string Session, int ClientID)
        {
            try
            {
                if (Session == string.Empty || ClientID == 0)
                    return null;

                //u.Session=
                string userID = string.Empty;

                User user = new User();
                if (u.MobileNo != string.Empty)
                {
                    user = DataAccess.UserDao.GetUserbyMobile(u.MobileNo);
                }

                if (user == null)
                {
                    string CouponCode = string.Empty;
                    u.CreateDate = DateTime.Now;
                    u.DOB = Convert.ToDateTime("1/1/1900");
                    u.LastLockoutDate = DateTime.Now;
                    u.LastLoginDate = DateTime.Now;
                    u.LastPasswordChangedDate = DateTime.Now;
                    u.CouponCode = CouponCode;
                    u.IsDeleted = false;
                    u.IsLockedOut = false;
                    u.RoleID = 4;

                    u.IsLockedOut = false;
                    u.PWD = "lkLi2AjNn34=";

                    u.Custom5 = String.Empty;
                    u.Session = Session;
                    u.ClientID = ClientID;
                    userID = DataAccess.UserDao.CreateUser(u);
                    u.UserID = userID;
                    u.IsAdmin = IsAdmin;
                    UserGroupMapping m = new UserGroupMapping();
                    m.UserID = userID;
                    m.UserGroupID = GroupID;
                    m.isAdmin = IsAdmin;
                    m.SerialNoForGroup = u.Custom1;
                    DataAccess.UserGroupMappingDao.CreateMapping(m);
                }
                else
                {
                    UserGroupMapping m = new UserGroupMapping();
                    m.UserID = user.UserID;
                    m.UserGroupID = GroupID;
                    m.isAdmin = IsAdmin;
                    m.SerialNoForGroup = u.Custom1;
                    DataAccess.UserGroupMappingDao.DeleteMapping(user.UserID, GroupID);
                    DataAccess.UserGroupMappingDao.CreateMapping(m);
                    u = user;
                    u.IsAdmin = IsAdmin;
                }
                return u;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string RegisterNewUser(User u)
        {
            string userID = string.Empty;
            try
            {
                //u.Session=
                //string userID = string.Empty;

                User user = new User();
                if (u.MobileNo != string.Empty)
                {
                    user = DataAccess.UserDao.GetUserbyMobile(u.MobileNo);
                }

                if (user == null)
                {
                    string CouponCode = string.Empty;
                    u.CreateDate = DateTime.Now;
                    u.DOB = Convert.ToDateTime("1/1/1900");
                    u.LastLockoutDate = DateTime.Now;
                    u.LastLoginDate = DateTime.Now;
                    u.LastPasswordChangedDate = DateTime.Now;
                    u.CouponCode = CouponCode;
                    u.IsDeleted = false;
                    u.IsLockedOut = false;
                    u.RoleID = 4;

                    u.IsLockedOut = false;

                    u.Custom1 = "0";
                    u.Custom3 = DateTime.UtcNow.AddHours(5.5).Date.ToShortDateString();
                    u.Custom4 = "Member";
                    u.Custom5 = String.Empty;
                    u.Session = General.GetCurrentSession;
                    u.ClientID = 0;
                    userID = DataAccess.UserDao.CreateUser(u);

                }
                else
                {
                    userID = "1";
                }
                return userID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateUser(User u, int GroupID, bool IsAdmin)
        {
            try
            {

                string CouponCode = string.Empty;
                u.CreateDate = DateTime.Now;
                u.DOB = Convert.ToDateTime("1/1/1900");
                u.LastLockoutDate = DateTime.Now;
                u.LastLoginDate = DateTime.Now;
                u.LastPasswordChangedDate = DateTime.Now;
                u.CouponCode = CouponCode;
                u.IsDeleted = false;
                u.IsLockedOut = true;
                if (IsAdmin)//making admin as default active
                    u.IsLockedOut = false;
                u.RoleID = 4;
                UserGroups ug = DataAccess.UserGroupsDao.GetUserGroup(GroupID);
                if (ug.FlowType != 1)
                {
                    u.IsLockedOut = false;

                }
                //u.Custom5 = String.Empty;
                string userID = string.Empty;
                userID = DataAccess.UserDao.UpdateUser(u).ToString();
                UserGroupMapping m = new UserGroupMapping();
                m.UserID = u.UserID;
                m.UserGroupID = GroupID;
                m.isAdmin = IsAdmin;
                m.SerialNoForGroup = u.Custom1;
                DataAccess.UserGroupMappingDao.DeleteMapping(u.UserID, GroupID);
                DataAccess.UserGroupMappingDao.CreateMapping(m);

                return userID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string CreateUser(User u, int GroupID, bool IsAdmin, string Session, int ClientID)
        {
            try
            {
                if (Session == string.Empty || ClientID == 0)
                    return "-1";

                //u.Session=
                string userID = string.Empty;

                if (!isExist(u.MobileNo))
                {
                    string CouponCode = string.Empty;
                    u.CreateDate = DateTime.Now;
                    u.DOB = Convert.ToDateTime("1/1/1900");
                    u.LastLockoutDate = DateTime.Now;
                    u.LastLoginDate = DateTime.Now;
                    u.LastPasswordChangedDate = DateTime.Now;
                    u.CouponCode = CouponCode;
                    u.IsDeleted = false;
                    u.IsLockedOut = true;
                    if (IsAdmin)//making admin as default active
                        u.IsLockedOut = false;
                    u.RoleID = 4;

                    u.IsLockedOut = false;
                    u.PWD = "lkLi2AjNn34=";

                    u.Custom5 = String.Empty;
                    u.Session = Session;
                    u.ClientID = ClientID;
                    userID = DataAccess.UserDao.CreateUser(u);
                    UserGroupMapping m = new UserGroupMapping();
                    m.UserID = userID;
                    m.UserGroupID = GroupID;
                    m.isAdmin = IsAdmin;
                    m.SerialNoForGroup = u.Custom1;
                    DataAccess.UserGroupMappingDao.CreateMapping(m);
                }
                else
                {
                    u = DataAccess.UserDao.GetUserbyMobile(u.MobileNo);
                    UserGroupMapping m = new UserGroupMapping();
                    m.UserID = u.UserID;
                    m.UserGroupID = GroupID;
                    m.isAdmin = IsAdmin;
                    m.SerialNoForGroup = u.Custom1;
                    DataAccess.UserGroupMappingDao.DeleteMapping(u.UserID, GroupID);

                    DataAccess.UserGroupMappingDao.CreateMapping(m);
                    userID = u.UserID;
                }
                return userID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public String GetOTPForgotPassword(string Username, string RecoveryNo)
        {
            User u = null;
            if (General.IsNumber(Username))
            {
                u = DataAccess.UserDao.GetUserbyMobile(Username);

            }

            if (u != null)
            {
                string OTP = GetOTP();
                General.SendSMS(Username, "The OTP is " + OTP.ToString());
                // General.SendEmail(u.EMail, "OTP from Echo", "The OTP is " + OTP.ToString());
                return OTP + " " + u.UserID;//OTP Send successful

            }
            else
            {
                return "1";//User is null
            }
        }
        public string GetOTP()
        {
            Random random = new Random();
            return random.Next(1001, 9999).ToString();
        }


        public string GetCoupon()
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string Code = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();



            for (int i = 0; i < 12; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                Code += sTempChars;

            }
            bool verifyCoupon = DataAccess.UserDao.Verify_CouponCode(Code);

            //if (verifyCoupon)
            //    GenerateCoupon();
            return Code;


        }

        public string AddLeave(string UserID, string LeaveType, string FromDate, string ToDate, int DaysCount,string Reason)
        {
            try
            {
                DateTime fromDate = DateTime.Parse(FromDate);
                DateTime toDate = DateTime.Parse(ToDate);
                string msg=DataAccess.AttendanceCodeDao.AddLeave(UserID, LeaveType, fromDate, toDate, DaysCount, Reason);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string AddUserToGroup(int GroupId, int ClientId, string MobileNo, string Session, bool IsAdmin)
        {
            try
            {
                string msg = DataAccess.AttendanceCodeDao.AddUserToGroup(GroupId, ClientId, MobileNo, Session, IsAdmin);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BackgroundJob()
        {
            try
            {
                DataSet ds=DataAccess.AttendanceCodeDao.BackgroundNotificationTask();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow v in ds.Tables[0].Rows)
                    {
                        if (v["guardianNumber"].ToString().Length == 10)
                            General.SendSMS(v["guardianNumber"].ToString(), v["guardianMsg"].ToString());
                        if (v["deviceToken"].ToString().Length > 20)
                            General.SendPushNotificationAndroid(v["deviceToken"].ToString(), "Attendance Added", v["msg"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}



