using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BusinessObjects;
namespace DataObjects.AdoNet.SqlServer
{
    class SqlServerMemberAttendanceDao : IMemberAttendanceDao
    {
        public int GetAttendanceCountByUser(string UserID,int GroupID, DateTime Date)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@UserID", UserID);
                m[1] = new SqlParameter("@GroupID", GroupID);
               
                m[2] = new SqlParameter("@AttendanceDate", Date);
                object count = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceCountByUser", m);
                return Convert.ToInt32(count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateLeave(Guid UserID, DateTime FromDate, DateTime ToDate, DateTime CreateDate, DateTime ModifiedDate, string Custom1, string Custom2, string Custom3)
        {
            return 0;
        }
        public int CreateMemberAttendance(MemberAttendance mat)
        {
            try
            {               
                SqlParameter[] m = new SqlParameter[15];
                m[0] = new SqlParameter("@Id", SqlDbType.Int);
                m[1] = new SqlParameter("@AttendanceDate", mat.AttendanceDate);
                m[2] = new SqlParameter("@UserID", mat.UserID);
                
                m[3] = new SqlParameter("@AttendanceStatus", mat.AttendanceStatus);

                m[4] = new SqlParameter("@CreateDate", mat.CreateDate);
                m[5] = new SqlParameter("@UDF1", mat.UDF1);
                m[6] = new SqlParameter("@UDF2", mat.UDF2);
                m[7] = new SqlParameter("@UDF3", mat.UDF3);
                m[8] = new SqlParameter("@GroupID", mat.GroupID);
                m[9] = new SqlParameter("@AttendanceTime", mat.AttendanceTime);
                m[10] = new SqlParameter("@Device", mat.Device);
                m[11] = new SqlParameter("@DeviceIDOrName", mat.DeviceIDOrName);
                m[12] = new SqlParameter("@DeviceLocation", mat.DeviceLocation);
                m[13] = new SqlParameter("@Session", mat.Session);
                m[14] = new SqlParameter("@ClientID", mat.ClientID);
                m[0].Direction = ParameterDirection.Output;                
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Attendance_Insert", m);
                object ivalue = m[0].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateMemberAttendance(string UserID, int GroupID, DateTime AttendanceDate, string AttendanceStatus,int Count,string AttendanceTime,string Device,string DeviceIDOrName, string DeviceLocation,string MarkedBy)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[10];
                m[0] = new SqlParameter("@UserID", UserID);
                m[1] = new SqlParameter("@GroupID", GroupID);
                m[2] = new SqlParameter("@AttendanceDate", AttendanceDate);
                m[3] = new SqlParameter("@AttendanceStatus", AttendanceStatus);
                m[4] = new SqlParameter("@AttendanceTime", AttendanceTime);
                m[5] = new SqlParameter("@Count", Count);
              
                m[6] = new SqlParameter("@Device", Device);
                m[7] = new SqlParameter("@DeviceIDOrName", @DeviceIDOrName);
                m[8] = new SqlParameter("@DeviceLocation", DeviceLocation);
                
                m[9] = new SqlParameter("@MarkedBy", MarkedBy);
                
               
               return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Attendance_Update", m);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteMemberAttendance(string _MemberID)
        {
            throw new NotImplementedException();
        }

        public MemberAttendance GetMemberAttendance(string _MemberId)
        {
            throw new NotImplementedException();
        }
        public int CheckMemberAttendance(int GroupID, DateTime Date)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@GroupID", GroupID);
                m[1] = new SqlParameter("@AttendanceDate", Date);
                object count = SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "Attendance_CheckForGroupAndDate", m);
                return Convert.ToInt32(count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public IList<BusinessObjects.MemberAttendance> GetMemberAttendances(int GroupID, string UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@GroupID", GroupID);
                m[1] = new SqlParameter("@UserID", UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "Attendance_SelectAllByGroupAndUser", m);
                return MakeMemberAttendances(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<MemberAttendance> GetMemberAttendances(int GroupID,DateTime Date)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@GroupID", GroupID);
                m[1] = new SqlParameter("@AttendanceDate", Date);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "Attendance_SelectAllByGroupAndDate", m);
                return MakeMemberAttendances(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<MemberAttendance> MakeMemberAttendances(DataTable dt)
        {
            IList<MemberAttendance> list = new List<MemberAttendance>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeMemberAttendance(row));

            return list;
        }
        private MemberAttendance MakeMemberAttendance(DataRow row)
        {
            try
            {
                
                int _Id = int.Parse( row["Id"].ToString());
                
                DateTime _AttendanceDate = Convert.ToDateTime(row["AttendanceDate"].ToString());
                string _UserID = row["UserID"].ToString();
                int _GroupID = int.Parse(row["GroupID"].ToString());
                string _AttendanceStatus = row["AttendanceStatus"].ToString();
                DateTime _CreateDate = Convert.ToDateTime(row["CreateDate"].ToString());
                string _UDF1 = row["UDF1"].ToString();
                string _UDF2 = row["UDF2"].ToString();
                string _UDF3 = row["UDF3"].ToString();
                string _AttendanceTime = row["AttendanceTime"].ToString();
                string _Device = row["Device"].ToString();
                string _DeviceIDOrName = row["DeviceIDOrName"].ToString();
                string _DeviceLocation = row["DeviceLocation"].ToString();
                string _Session = row["Session"].ToString();
                int _ClientID = row["ClientID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ClientID"]);

                return new MemberAttendance(_Id, _AttendanceDate, _UserID, _GroupID, _AttendanceStatus, _CreateDate, _UDF1, _UDF2, _UDF3, _AttendanceTime,_Device,_DeviceIDOrName,_DeviceLocation, _Session, _ClientID);
                    //, _FirstName, _LastName, _DOB, _EMail, _PWD, _IsDeleted, _IsLockedOut, _CouponCode, _CreatedBy, _CreateDate, _LastLoginDate, _LastLockoutDate, _LastPasswordChangedDate, _MobileNo, _TotalRecord, _UserGroup, _ImageID, _Custom1, _Custom2, _Custom3, _Custom4, _Custom5, AlowCredit, _Facebook, _Twitter, _LinkedIn, _MySpace);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<MemberAttendance> GetMemberAttendances()
        {
            throw new NotImplementedException();
        }
    }
}
