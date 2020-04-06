using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data;
using System.Data.SqlClient;
using DataObjects.AdoNet;

namespace DataObjects.AdoNet.SqlServer
{
    class SqlServerAttendanceCodeDao : IAttendanceCodeDao
    {
        public int UpdateOfflineAttendanceCodeTimeOfUse(int GroupID, DateTime DateOfUse, DateTime UsedDateTime)
        {
            SqlParameter[] m = new SqlParameter[3];
            m[0] = new SqlParameter("@GroupID", GroupID);
            m[1] = new SqlParameter("@DateOfUse", DateOfUse);
            m[2] = new SqlParameter("@UsedDateTime", UsedDateTime);
            return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "UpdateOfflineAttendanceCodeTimeOfUse", m);

        }
        public int CreateOfflineAttendanceCode(BusinessObjects.OfflineAttendanceCode attendanceCode)
        {
            SqlParameter[] m = new SqlParameter[3];
            m[0] = new SqlParameter("@GroupId", attendanceCode.GroupId);
            m[1] = new SqlParameter("@AttendanceCode", attendanceCode.AttendanceCode);
            m[2] = new SqlParameter("@DateofUse", attendanceCode.DateofUse);
            return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "OfflineAttendanceCode_Insert", m);

        }

        public IList<OfflineAttendanceCode> GetOfflineAttendanceCodes(string UserID, DateTime FromDate)
        {
            SqlParameter[] m = new SqlParameter[2];
            m[0] = new SqlParameter("@UserID", UserID);
            m[1] = new SqlParameter("@FromDate", FromDate);
            DataSet d = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "OfflineAttendanceCode_SelectByUserId", m);
            if (d.Tables[0].Rows.Count > 0)
            {
                return MakeOfflineAttendanceCodeData(d.Tables[0]);
            }
            else
                return null;

        }
        public IList<OfflineAttendanceCode> GetOfflineAttendanceCodes(string UserID, string GroupIDs, DateTime FromDate)
        {
            SqlParameter[] m = new SqlParameter[3];
            m[0] = new SqlParameter("@UserID", UserID);
            m[1] = new SqlParameter("@GroupIDs", GroupIDs);
            m[2] = new SqlParameter("@FromDate", FromDate);
            DataSet d = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "OfflineAttendanceCode_SelectByUserIdAndGroupIDs", m);
            if (d.Tables[0].Rows.Count > 0)
            {
                return MakeOfflineAttendanceCodeData(d.Tables[0]);
            }
            else
                return null;
        }

        public AttendanceCode GetAttendanceCode(int GroupID, DateTime Date)
        {
            SqlParameter[] m = new SqlParameter[2];
            m[0] = new SqlParameter("@GroupID", GroupID);
            m[1] = new SqlParameter("@AttendanceDate", Date);
            DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectAttendanceCode", m);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return MakeAttendanceCode(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        public int CreateAttendanceCode(AttendanceCode attendanceCode)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[5];
                m[0] = new SqlParameter("@ID", SqlDbType.Int);
                m[1] = new SqlParameter("@GroupID", attendanceCode.GroupID);
                m[2] = new SqlParameter("@AttendanceDate", attendanceCode.AttendanceDate);
                m[3] = new SqlParameter("@AttendanceCode", attendanceCode.Code);
                m[4] = new SqlParameter("@CreateDate", attendanceCode.CreateDate);

                m[0].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "AttendanceCodeInsert", m);
                object ivalue = m[0].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int VerifyAttendanceCode(int GroupID, DateTime Date)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@GroupID", GroupID);
                m[1] = new SqlParameter("@AttendanceDate", Date);
                m[2] = new SqlParameter("@Chk", SqlDbType.Int);
                m[2].Direction = ParameterDirection.Output;
                int ds = 0;
                SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "VerifyAttendanceCode", m);
                ds = Convert.ToInt32(m[2].Value);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteAttendanceCode(int GroupID, DateTime date)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];

                m[0] = new SqlParameter("@GroupID", GroupID);
                m[1] = new SqlParameter("@AttendanceDate", date);



                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "AttendanceCodeDelete", m);

                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AttendanceCode MakeAttendanceCode(DataRow dr)
        {
            int _ID = Convert.ToInt32(dr["ID"]);
            int _GroupID = Convert.ToInt32(dr["GroupID"]);
            DateTime _AttendanceDate = Convert.ToDateTime(dr["AttendanceDate"]);
            int _Code = Convert.ToInt32(dr["AttendanceCode"]);
            DateTime _CreateDate = Convert.ToDateTime(dr["CreateDate"]);
            return new AttendanceCode(_ID, _GroupID, _AttendanceDate, _Code, _CreateDate);

        }
        private IList<OfflineAttendanceCode> MakeOfflineAttendanceCodeData(DataTable dt)
        {
            IList<OfflineAttendanceCode> list = new List<OfflineAttendanceCode>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeOfflineAttendanceCode(row));

            return list;
        }
        public OfflineAttendanceCode MakeOfflineAttendanceCode(DataRow dr)
        {
            int GroupId = Convert.ToInt32(dr["GroupID"]);
            string AttendanceCode = dr["AttendanceCode"].ToString();
            string DateofUse = Convert.ToDateTime(dr["DateofUse"]).ToShortDateString();
            return new OfflineAttendanceCode(GroupId, AttendanceCode, DateofUse);

        }

        public string AddLeave(string UserID, string LeaveType, DateTime FromDate, DateTime ToDate, int DaysCount,string Reason)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[6];
                m[0] = new SqlParameter("@UserID", UserID);
                m[1] = new SqlParameter("@LeaveType", LeaveType);
                m[2] = new SqlParameter("@FromDate", FromDate);
                m[3] = new SqlParameter("@ToDate", ToDate);
                m[4] = new SqlParameter("@DaysCount", DaysCount);
                m[5] = new SqlParameter("@Reason", Reason);
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "AddLeave", m);
                return "success";
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
                SqlParameter[] m = new SqlParameter[6];
                m[0] = new SqlParameter("@GroupId", GroupId);
                m[1] = new SqlParameter("@ClientId", ClientId);
                m[2] = new SqlParameter("@MobileNo", MobileNo);
                m[3] = new SqlParameter("@Session", Session);
                m[4] = new SqlParameter("@IsAdmin", IsAdmin);
                m[5] = new SqlParameter("@ReturnValue", SqlDbType.VarChar,100);
                m[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "AddUserGroup", m);
                var retVal = m[5].Value.ToString();
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BackgroundNotificationTask()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetNotificationsList");
                return ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}
