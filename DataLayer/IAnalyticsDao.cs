using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public interface IAnalyticsDao
    {
        IList<BusinessObjects.FilterAttendance> GetTrends(DateTime fromDate,DateTime toDate,int ClientID);
        IList<BusinessObjects.FilterAttendance> GetDistrictLevelDataForADate(DateTime Date, int ClientID);
        IList<BusinessObjects.FilterAttendance> GetBlockLevelDataForADate(DateTime Date, string District, int ClientID);
        IList<BusinessObjects.FilterAttendance> GetClusterLevelDataForADate(DateTime Date, string District, string Block, int ClientID);
        IList<BusinessObjects.FilterAttendance> GetSchoolLevelDataForADate(DateTime Date, string District, string Block, string Cluster, int ClientID);
        IList<BusinessObjects.FilterAttendance> GetClassLevelDataForADate(DateTime Date, string District, string Block, string Cluster, string School, int ClientID);
        BusinessObjects.DashboardSummary GetDashboardSummaryForSchool(DateTime date,string GroupOwner, int ClientID);
        BusinessObjects.DashboardSummary GetDashboardSummary(DateTime date, int ClientID);
        System.Collections.Generic.IList<BusinessObjects.Analytics> GetAnalytics();

        System.Collections.Generic.IList<BusinessObjects.Analytics> GetAnalytics(DateTime _FromDate, DateTime _ToDate);

        BusinessObjects.Analytics GetAnalytics(string _UserId);
        System.Collections.Generic.IList<BusinessObjects.Analytics> GetAnalyticsByDate(DateTime Date);
        System.Collections.Generic.IList<BusinessObjects.Analytics> GetAnalyticsTeacherByDate(DateTime Date);
    }
}
