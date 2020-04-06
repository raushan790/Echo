using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BusinessObjects;
namespace DataObjects.AdoNet.SqlServer
{
    class SqlServerDashboardDao : IDashboardDao
    {
        public IList<BusinessObjects.FilterAttendance> GetTrends(DateTime fromDate, DateTime toDate, int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@FromDate", fromDate.Date);
                m[1] = new SqlParameter("@ToDate", toDate.Date);
                m[2] = new SqlParameter("@ClientID", ClientID);
                DataSet dsTrends = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesForTrends2", m);

                DataTable ds = dsTrends.Tables[0];// SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesForTrends1", m).Tables[0];
                DataTable ds1 = dsTrends.Tables[1];//SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesForTrendsPresent", m).Tables[0];
                DataTable ds2 = dsTrends.Tables[2];//SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesTeachersForTrends", m).Tables[0];
                DataTable ds3 = dsTrends.Tables[3];//SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesTeachersPresentForTrends", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["AttendanceDate"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["AttendanceDate"] };
                ds2.PrimaryKey = new DataColumn[] { ds2.Columns["AttendanceDate"] };
                ds3.PrimaryKey = new DataColumn[] { ds3.Columns["AttendanceDate"] };
                ds.Merge(ds1);
                ds.Merge(ds2);
                ds.Merge(ds3);
                if (ds.Rows.Count > 0)
                {
                    return MakeFilters(ds);
                }

                else
                {

                    return null;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private FilterAttendance MakeFilter(DataRow row)
        {
            try
            {
                FilterAttendance fa = new FilterAttendance();
                fa.PrimaryColoumn = row[0].ToString();
                fa.TotalStudent = string.IsNullOrEmpty(row["TotalStudent"].ToString()) ? "0" : row["TotalStudent"].ToString();
                fa.TotalStudentPresent = string.IsNullOrEmpty(row["TotalStudentPresent"].ToString()) ? "0" : row["TotalStudentPresent"].ToString();
                try
                {
                    fa.TotalTeacher = string.IsNullOrEmpty(row["TotalTeacher"].ToString()) ? "0" : row["TotalTeacher"].ToString();
                }
                catch
                { }
                try
                {
                    fa.TotalTeacherPresent = string.IsNullOrEmpty(row["TotalTeacherPresent"].ToString()) ? "0" : row["TotalTeacherPresent"].ToString();
                }
                catch
                { }


                return fa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private IList<FilterAttendance> MakeFilters(DataTable dt)
        {
            IList<FilterAttendance> list = new List<FilterAttendance>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeFilter(row));

            return list;
        }
        public int AttendanceLiveCounter(int ClientID, string Session, DateTime Date)
        {
            SqlParameter[] m = new SqlParameter[3];
            m[0] = new SqlParameter("@ClientID", ClientID);

            m[1] = new SqlParameter("@Session", Session);
            m[2] = new SqlParameter("@CreateDate", Date);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(Connection.Connection_string, CommandType.StoredProcedure, "AttendanceLiveCounter", m));

        }
        public DashboardSummary GetDashboardSummaryAttendance(int ClientID, DateTime FromDate, DateTime Todate)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@ClientID", ClientID);
                m[1] = new SqlParameter("@FromDate", FromDate);
                m[2] = new SqlParameter("@Todate", Todate);

                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetDashboardSummary2", m);
                DashboardSummary _DashboardSummary = new DashboardSummary();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _DashboardSummary.TotalStudents = ds.Tables[0].Rows[0]["TotalStudent"].ToString();
                    _DashboardSummary.TotalMale = ds.Tables[0].Rows[0]["TotalMale"].ToString();
                    _DashboardSummary.TotalFemale = ds.Tables[0].Rows[0]["TotalFemale"].ToString();
                    _DashboardSummary.TotalTeachers = ds.Tables[0].Rows[0]["TotalTeacher"].ToString();

                    _DashboardSummary.TotalStudentsPresent = ds.Tables[0].Rows[0]["TotalPresent"].ToString();
                    _DashboardSummary.TotalMalePresent = ds.Tables[0].Rows[0]["TotalMalePresent"].ToString();
                    _DashboardSummary.TotalFemalePresent = ds.Tables[0].Rows[0]["TotalFemalePresent"].ToString();
                    _DashboardSummary.TotalTeachersPresent = ds.Tables[0].Rows[0]["TotalTeacherPresent"].ToString();

                    _DashboardSummary.TotalClasses = ds.Tables[0].Rows[0]["TotalClasses"].ToString();
                    try
                    {
                        _DashboardSummary.Trends = GetTrends(FromDate.AddDays(-11).Date, FromDate.AddDays(-1).Date, ClientID).ToList();

                    }
                    catch
                    {
                    }
                    _DashboardSummary.TopFive = null;// new SqlServerKeyValueDao().GetTopFiveSchoolForADate(date, ClientID).ToList();
                    _DashboardSummary.BottomFive = null;// new SqlServerKeyValueDao().GetBottomFiveSchoolForADate(date, ClientID).ToList();


                }
                else
                {
                    _DashboardSummary = null;
                }
                return _DashboardSummary;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<AdminMemberSummaryByGroup> GetAdminMemberSummaryByGroup(int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAdminMemberSummaryByGroup", m);
                return MakeAdminMemberSummaryByGroupData(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SummaryTotal GetSummaryTotal(int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetSummaryTotalForAClient", m);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return MakeGetSummaryTotal(ds.Tables[0].Rows[0]);
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private SummaryTotal MakeGetSummaryTotal(DataRow row)
        {
            try
            {
                SummaryTotal SummaryTotal = new SummaryTotal();
                SummaryTotal.TotalClasses = Convert.ToInt32(row["TotalClasses"]);

                SummaryTotal.TotalFemale = Convert.ToInt32(row["TotalFemale"]);
                SummaryTotal.TotalMale = Convert.ToInt32(row["TotalMale"]);
                SummaryTotal.TotalStudents = Convert.ToInt32(row["TotalStudents"]);
                SummaryTotal.TotalTeachers = Convert.ToInt32(row["TotalTeachers"]);
                return SummaryTotal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private AdminMemberSummaryByGroup MakeAdminMemberSummaryByGroup(DataRow row)
        {
            try
            {
                AdminMemberSummaryByGroup AMemberSummaryByGroup = new AdminMemberSummaryByGroup();
                AMemberSummaryByGroup.GroupID = Convert.ToInt32(row["GroupID"]);
                AMemberSummaryByGroup.GroupName = row["GroupName"].ToString();
                AMemberSummaryByGroup.GroupDescription = row["GroupDescription"].ToString();

                AMemberSummaryByGroup.CountMember = Convert.ToInt32(row["CountMember"]);
                AMemberSummaryByGroup.CountAdmin = Convert.ToInt32(row["CountAdmin"]);
                return AMemberSummaryByGroup;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private IList<AdminMemberSummaryByGroup> MakeAdminMemberSummaryByGroupData(DataTable dt)
        {
            IList<AdminMemberSummaryByGroup> list = new List<AdminMemberSummaryByGroup>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeAdminMemberSummaryByGroup(row));

            return list;
        }
    }
}
