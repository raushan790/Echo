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
    class SqlServerAnalyticsDao : IAnalyticsDao
    {
        public IList<BusinessObjects.FilterAttendance> GetTrends(DateTime fromDate, DateTime toDate, int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@FromDate", fromDate);
                m[1] = new SqlParameter("@ToDate", toDate);
                m[2] = new SqlParameter("@ClientID", ClientID);
                DataSet dsTrends = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAttendanceDataBetweenTwoDatesForTrends1", m);

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
                    throw new Exception("No record found");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetDistrictLevelDataForADate(DateTime Date, int ClientID)
        {
            try
            {


                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@ClientID", ClientID);
                DataSet d = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelDataForADate", m);

                DataTable ds = d.Tables[0]; //SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = d.Tables[1]; //SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelTotalStudentPresentForADate", m).Tables[0];
                DataTable ds2 = d.Tables[2]; //SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelTotalTeacherForADate", m).Tables[0];
                DataTable ds3 = d.Tables[3];//SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DistrictLevelTotalTeacherPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["District"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["District"] };
                ds2.PrimaryKey = new DataColumn[] { ds2.Columns["District"] };
                ds3.PrimaryKey = new DataColumn[] { ds3.Columns["District"] };
                ds.Merge(ds1);
                ds.Merge(ds2);
                ds.Merge(ds3);
                if (ds.Rows.Count > 0)
                {
                    return MakeFilters(ds);
                }
                else
                    throw new Exception("No record found");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetBlockLevelDataForADate(DateTime Date, string District, int ClientID)
        {
            try
            {


                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@District", District);
                m[2] = new SqlParameter("@ClientID", ClientID);
                DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BlockLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BlockLevelTotalStudentPresentForADate", m).Tables[0];
                DataTable ds2 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BlockLevelTotalTeacherForADate", m).Tables[0];
                DataTable ds3 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BlockLevelTotalTeacherPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["Block"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["Block"] };
                ds2.PrimaryKey = new DataColumn[] { ds2.Columns["Block"] };
                ds3.PrimaryKey = new DataColumn[] { ds3.Columns["Block"] };
                ds.Merge(ds1);
                ds.Merge(ds2);
                ds.Merge(ds3);
                if (ds.Rows.Count > 0)
                {
                    return MakeFilters(ds);
                }
                else
                    throw new Exception("No record found");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetClusterLevelDataForADate(DateTime Date, string District, string Block, int ClientID)
        {
            try
            {


                SqlParameter[] m = new SqlParameter[4];
                m[0] = new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@District", District);
                m[2] = new SqlParameter("@Block", Block);
                m[3] = new SqlParameter("@ClientID", ClientID);
                DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClusterLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClusterLevelTotalStudentPresentForADate", m).Tables[0];
                DataTable ds2 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClusterLevelTotalTeacherForADate", m).Tables[0];
                DataTable ds3 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClusterLevelTotalTeacherPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["Cluster"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["Cluster"] };
                ds2.PrimaryKey = new DataColumn[] { ds2.Columns["Cluster"] };
                ds3.PrimaryKey = new DataColumn[] { ds3.Columns["Cluster"] };
                ds.Merge(ds1);
                ds.Merge(ds2);
                ds.Merge(ds3);
                if (ds.Rows.Count > 0)
                {
                    return MakeFilters(ds);
                }
                else
                    throw new Exception("No record found");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetSchoolLevelDataForADate(DateTime Date, string District, string Block, string Cluster, int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[5];
                m[0] = new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@District", District);
                m[2] = new SqlParameter("@Block", Block);
                m[3] = new SqlParameter("@Cluster", Cluster);
                m[4] = new SqlParameter("@ClientID", ClientID);
                DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SchoolLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SchoolLevelTotalStudentPresentForADate", m).Tables[0];
                DataTable ds2 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SchoolLevelTotalTeacherForADate", m).Tables[0];
                DataTable ds3 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SchoolLevelTotalTeacherPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["GroupName"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["GroupName"] };
                ds2.PrimaryKey = new DataColumn[] { ds2.Columns["GroupName"] };
                ds3.PrimaryKey = new DataColumn[] { ds3.Columns["GroupName"] };
                ds.Merge(ds1);
                ds.Merge(ds2);
                ds.Merge(ds3);
                if (ds.Rows.Count > 0)
                {
                    return MakeFilters(ds);
                }
                else
                    throw new Exception("No record found");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<BusinessObjects.FilterAttendance> GetClassLevelDataForADate(DateTime Date, string District, string Block, string Cluster, string School, int ClientID)
        {
            try
            {


                SqlParameter[] m = new SqlParameter[6];
                m[0] = new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@District", District);
                m[2] = new SqlParameter("@Block", Block);
                m[3] = new SqlParameter("@Cluster", Cluster);
                m[4] = new SqlParameter("@GroupName", School);
                m[5] = new SqlParameter("@ClientID", ClientID);
                DataTable ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClassLevelTotalStudentForADate", m).Tables[0];
                DataTable ds1 = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "ClassLevelTotalStudentPresentForADate", m).Tables[0];
                ds.PrimaryKey = new DataColumn[] { ds.Columns["Description"] };
                ds1.PrimaryKey = new DataColumn[] { ds1.Columns["Description"] };

                ds.Merge(ds1);
                if (ds.Rows.Count > 0)
                {
                    return MakeFilters(ds);
                }
                else
                    throw new Exception("No record found");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DashboardSummary GetDashboardSummary(DateTime date, int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Date", date);
                m[1] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetDashboardSummary1", m);
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

                    //_DashboardSummary.TotalDistrict = ds.Tables[0].Rows[0]["TotalDistrict"].ToString();
                    //_DashboardSummary.TotalSchool = ds.Tables[0].Rows[0]["TotalSchools"].ToString();
                    //_DashboardSummary.DistrictLevelData = GetDistrictLevelDataForADate(date, ClientID).ToList();
                    _DashboardSummary.Trends = GetTrends(date.AddDays(-11), date.AddDays(-1), ClientID).ToList();
                    //_DashboardSummary.TopFive = new SqlServerKeyValueDao().GetTopFiveSchoolForADate(date, ClientID).ToList();
                    //_DashboardSummary.BottomFive = new SqlServerKeyValueDao().GetBottomFiveSchoolForADate(date, ClientID).ToList();
                    //_DashboardSummary.Caste = new SqlServerKeyValueDao().GetCastWiseDataForADate(date, ClientID).ToList();


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

        public DashboardSummary GetDashboardSummaryForSchool(DateTime date, string Owner, int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@Date", date);
                m[1] = new SqlParameter("@Owner", Owner);
                m[2] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetDashboardSummaryForSchool", m);
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

                    //_DashboardSummary.TotalDistrict = ds.Tables[0].Rows[0]["TotalDistrict"].ToString();
                    //_DashboardSummary.TotalSchool = ds.Tables[0].Rows[0]["TotalSchools"].ToString();
                    //try
                    //{
                    //    _DashboardSummary.DistrictLevelData = GetDistrictLevelDataForADate(date,ClientID).ToList();
                    //}
                    //catch
                    //{ }
                    try
                    {
                        _DashboardSummary.Trends = GetTrends(date.AddDays(-11), date.AddDays(-1), ClientID).ToList();
                    }
                    catch
                    { }
                    try
                    {
                        _DashboardSummary.TopFive = new SqlServerKeyValueDao().GetTopFiveSchoolForADate(date, ClientID).ToList();
                    }
                    catch
                    { }
                    try
                    {
                        _DashboardSummary.BottomFive = new SqlServerKeyValueDao().GetBottomFiveSchoolForADate(date, ClientID).ToList();
                    }
                    catch
                    { }
                    try
                    {
                      //  _DashboardSummary.Caste = new SqlServerKeyValueDao().GetCastWiseDataForADate(date, ClientID).ToList();
                    }
                    catch
                    { }



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
        public IList<Analytics> GetAnalytics()
        {
            throw new NotImplementedException();
        }

        public Analytics GetAnalytics(string _UserId)
        {
            throw new NotImplementedException();
        }
        public IList<Analytics> GetAnalytics(DateTime _FromDate, DateTime _ToDate)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@FromDate", _FromDate);
                m[1] = new SqlParameter("@ToDate", _ToDate);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetAnalytics_BetweenTwoDates", m);
                return MakeAnalyticsData(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Analytics> GetAnalyticsByDate(DateTime _Date)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Date", _Date);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "AttendanceSelectForADate", m);
                return MakeAnalyticsData(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Analytics> GetAnalyticsTeacherByDate(DateTime _Date)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Date", _Date);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "AttendanceTeacherSelectForADate", m);
                return MakeAnalyticsData(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Analytics MakeAnalytics(DataRow row)
        {
            try
            {
                string _UserID = row["UserID"].ToString();
                string _Name = row["Name"].ToString();
                string _Gender = row["Gender"].ToString();
                string _Cast = row["Cast"].ToString();
                string _Class = row["Class"].ToString();
                string _School = row["School"].ToString();
                string _Cluster = row["Cluster"].ToString();
                string _District = row["District"].ToString();
                string _Block = row["Block"].ToString();
                DateTime _Date = Convert.ToDateTime(row["Date"].ToString());
                string _AttendanceStatus = row["AttendanceStatus"].ToString();
                float _Count = Convert.ToInt32(row["Count"].ToString());
                return new Analytics(_UserID, _Name, _Gender, _Cast, _Class, _School, _Cluster, _District, _Block, _Date, _AttendanceStatus, _Count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private IList<Analytics> MakeAnalyticsData(DataTable dt)
        {
            IList<Analytics> list = new List<Analytics>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeAnalytics(row));

            return list;
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
    }
}
