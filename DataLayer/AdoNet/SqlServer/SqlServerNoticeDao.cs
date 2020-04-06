using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerNoticeDao : INoticeDao
    {

        public int CreateNoticeDetail(string NoticeTitle, string NoticeDetail, string Createdby, DateTime NoticeDate, string FileName, int FileType, int ParentId, int IsSms, int IsReply)
        {
            bool _IsSms = Convert.ToBoolean(IsSms);
            bool _IsReply = Convert.ToBoolean(IsReply);
            SqlParameter[] m = new SqlParameter[10];
            m[0] = new SqlParameter("@NoticeID", SqlDbType.Int);
            m[1] = new SqlParameter("@NoticeTitle", NoticeTitle);
            m[2] = new SqlParameter("@NoticeDetail", NoticeDetail);
            m[3] = new SqlParameter("@NoticeDate", NoticeDate);
            m[4] = new SqlParameter("@CreatedBy", Createdby);
            m[5] = new SqlParameter("@FileName", FileName);
            m[6] = new SqlParameter("@FileType", FileType);
            m[7] = new SqlParameter("@ParentId", ParentId);
            m[8] = new SqlParameter("@IsSms", _IsSms);
            m[9] = new SqlParameter("@IsReply", _IsReply);
            m[0].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "InsertNoticeDetail", m);
            object ivalue = m[0].Value;
            return (int)ivalue;

        }
        public int CreateNotice(int GroupID, IList<string> UserIDs, string NoticeTitle, string NoticeDetail, string Createdby, DateTime NoticeDate, string FileName, int FileType=0, int ParentId=0, int IsSms=0, int IsReply=0)
        {
            try
            {
                int NoticeID = CreateNoticeDetail(NoticeTitle, NoticeDetail, Createdby, NoticeDate, FileName, FileType, ParentId, IsSms, IsReply);
                if (NoticeID > 0)
                {

                    if (UserIDs != null)
                    {
                        foreach (string UserID in UserIDs)
                        {
                            SqlParameter[] m = new SqlParameter[4];
                            m[0] = new SqlParameter("@ID", SqlDbType.Int);
                            m[1] = new SqlParameter("@NoticeID", NoticeID);
                            m[2] = new SqlParameter("@GroupID", GroupID);
                            m[3] = new SqlParameter("@UserID", UserID);
                            m[0].Direction = ParameterDirection.Output;
                            SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "InsertNotice", m);
                            object ivalue = m[0].Value;
                        }

                    }
                    else
                    {
                        if (GroupID > 0)
                        {
                            IList<User> userList = DataAccess.UserDao.GetUsersByGroup(GroupID).ToList();
                            if (userList.Count > 0)
                            {
                                foreach (User u in userList)
                                {
                                    SqlParameter[] m = new SqlParameter[4];
                                    m[0] = new SqlParameter("@ID", SqlDbType.Int);
                                    m[1] = new SqlParameter("@NoticeID", NoticeID);
                                    m[2] = new SqlParameter("@GroupID", GroupID);
                                    m[3] = new SqlParameter("@UserID", u.UserID);
                                    m[0].Direction = ParameterDirection.Output;
                                    SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "InsertNotice", m);
                                    object ivalue = m[0].Value;
                                }
                            }
                        }
                    }

                }
                return NoticeID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DeleteNotice(int NoticeID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@NoticeID", NoticeID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DeleteNotice", m);
                return ds;
                //return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DeleteNotice", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUnreadNoticeCount(string UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectUnreadNoticeCount", m);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int> GetDeletedNotice(string UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetDeletedNotice", m);
                List<int> NoticeIdlist = ds.Tables[0].Rows.OfType<DataRow>().Select(dr => dr.Field<int>("NoticeId")).ToList();
                return NoticeIdlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ConfirmDeleteNotice(List<int> NoticeIDs, string UserID) {
            try
            {
                string notId = string.Join(",", NoticeIDs.Select(i => i.ToString()).ToArray());
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@NoticeIDs", notId);
                m[1] = new SqlParameter("@UserID", UserID);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "ConfirmDeleteNotice", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SeenNotice(int NoticeID,string UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@NoticeID", NoticeID);
                m[1] = new SqlParameter("@UserID", UserID);
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "SeenNotice", m);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IList<Notice> GetNoticePagingAdmin(int PageIndex, int PageSize, int GroupID, string UserID)
        {
            SqlParameter[] m = new SqlParameter[4];
            m[0] = new SqlParameter("@PageIndex", PageIndex);
            m[1] = new SqlParameter("@PageSize", PageSize);
            m[2] = new SqlParameter("@GroupID", GroupID);
            m[3] = new SqlParameter("@UserID", UserID);
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectNoticePagingAdmin", m);

            return MakeNotices(ds.Tables[0]);

        }
        public IList<Notice> GetNoticePagingAdminByID(int NoticeID, int PageSize, int GroupID, string UserID)
        {
            SqlParameter[] m = new SqlParameter[4];
            m[0] = new SqlParameter("@NoticeID", NoticeID);
            m[1] = new SqlParameter("@PageSize", PageSize);
            m[2] = new SqlParameter("@GroupID", GroupID);
            m[3] = new SqlParameter("@UserID", UserID);
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectNoticePagingAdminByID", m);

            return MakeNotices(ds.Tables[0]);

        }
        public IList<Notice> GetNoticePagingByID(int NoticeID, int PageSize, int GroupID, string UserID)
        {
            SqlParameter[] m = new SqlParameter[4];
            m[0] = new SqlParameter("@NoticeID", NoticeID);
            m[1] = new SqlParameter("@PageSize", PageSize);
            m[2] = new SqlParameter("@GroupID", GroupID);
            m[3] = new SqlParameter("@UserID", UserID);
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectNoticePagingByID", m);

            return MakeNotices(ds.Tables[0]);

        }

        public IList<Notice> GetNoticeByID(int NoticeID,int PageIndex, int GroupID, string UserID)
        {
            SqlParameter[] m = new SqlParameter[4];
            m[0] = new SqlParameter("@NoticeID", NoticeID);
            m[1] = new SqlParameter("@PageIndex", PageIndex);
            m[2] = new SqlParameter("@GroupID", GroupID);
            m[3] = new SqlParameter("@UserID", UserID);
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectNoticeByID", m);

            return MakeNotices(ds.Tables[0]);

        }

        public IList<Notice> GetNoticePaging(int PageIndex, int PageSize, int GroupID, string UserID)
        {
            SqlParameter[] m = new SqlParameter[4];
            m[0] = new SqlParameter("@PageIndex", PageIndex);
            m[1] = new SqlParameter("@PageSize", PageSize);
            m[2] = new SqlParameter("@GroupID", GroupID);
            m[3] = new SqlParameter("@UserID", UserID);
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectNoticePaging", m);

            return MakeNotices(ds.Tables[0]);

        }
        private List<Notice> MakeNotices(DataTable dt)
        {
            List<Notice> list = new List<Notice>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeNotice(row));

            return list;
        }

        private Notice MakeNotice(DataRow dr)
        {
            try
            {
                int _NoticeID = Convert.ToInt32(dr["NoticeID"]);
                string _UserID = Convert.ToString(dr["UserID"]);
                string _UserName = Convert.ToString(dr["UserName"]);
                int _GroupID = Convert.ToInt32(dr["GroupID"]);
                string _NoticeTitle = Convert.ToString(dr["NoticeTitle"]);
                string _NoticeData = Convert.ToString(dr["NoticeDetail"]); 
                string _NoticeDate = Convert.ToDateTime(dr["NoticeDate"]).ToString("dd-MM-yyyy hh:mm tt");
                int _ReadCount = Convert.ToInt32(dr["ReadCount"]);
                int _DeliveryCount = Convert.ToInt32(dr["DeliveryCount"]);
                int _ReplyCount = Convert.ToInt32(dr["ReplyCount"]);
                int _ReplyReadPendingCount = Convert.ToInt32(dr["ReplyReadPendingCount"]);
                int _ParentId = Convert.ToInt32(dr["ParentId"]);
                int _IsSms = Convert.ToInt32(dr["IsSms"]);
                int _IsReply = Convert.ToInt32(dr["IsReply"]);
                string _FileName = string.Empty;
                int _FileType = 0;
                try
                {
                    _FileName = Convert.ToString(dr["FileName"]);
                }
                catch 
                {
                }
                try
                {
                    _FileType = Convert.ToInt32(dr["FileType"]);
                }
                catch
                {
                }

                bool _IsRead = false;
                try
                {
                     _IsRead = Convert.ToBoolean(dr["IsRead"]);

                }
                catch
                {                   
                } 
                return new Notice { NoticeID = _NoticeID, GroupID = _GroupID, UserID = _UserID, NoticeTitle= _NoticeTitle, NoticeData=_NoticeData, NoticeDate = _NoticeDate,FileName=_FileName,FileType=_FileType,IsRead=_IsRead,UserName=_UserName,ReadCount=_ReadCount,DeliveryCount=_DeliveryCount,ReplyCount=_ReplyCount,ParentId=_ParentId,IsSms=_IsSms,IsReply=_IsReply,ReplyReadPendingCount=_ReplyReadPendingCount };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
