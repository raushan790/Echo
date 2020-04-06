using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using BusinessObjects;
using Controllers;
using System.ComponentModel;

namespace Controllers
{
    [DataObject(true)]
    public class DashboardController : ControllerBase
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DashboardSummary GetDashboardSummaryAttendance(int ClientID, DateTime FromDate, DateTime Todate)
        {
            return DataAccess.DashboardDao.GetDashboardSummaryAttendance(ClientID, FromDate, Todate);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<AdminMemberSummaryByGroup> GetAdminMemberSummaryByGroup(int ClientID)
        {
            return DataAccess.DashboardDao.GetAdminMemberSummaryByGroup(ClientID);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public SummaryTotal GetSummaryTotal(int ClientID)
        {
            return DataAccess.DashboardDao.GetSummaryTotal(ClientID);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Analytics> GetAnalytics(DateTime FromDate, DateTime ToDate)
        {
            return DataAccess.AnalyticsDao.GetAnalytics(FromDate, ToDate);
        }
        public IList<Analytics> GetAnalyticsByDate(DateTime Date)
        {
            return DataAccess.AnalyticsDao.GetAnalyticsByDate(Date);
        }

        public IList<Analytics> GetAnalyticsTeacherByDate(DateTime Date)
        {
            return DataAccess.AnalyticsDao.GetAnalyticsTeacherByDate(Date);
        }
    }
}
