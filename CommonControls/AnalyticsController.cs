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
    public class AnalyticsController : ControllerBase
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DashboardSummary GetDashboardSummary(DateTime Date, string Owner,int ClientID)
        {
            return DataAccess.AnalyticsDao.GetDashboardSummaryForSchool(Date, Owner,ClientID);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public DashboardSummary GetDashboardSummary(DateTime Date,int ClientID)
        {
            return DataAccess.AnalyticsDao.GetDashboardSummary(Date,ClientID);
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
