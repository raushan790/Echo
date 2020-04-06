using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public interface IDashboardDao
    {
        int AttendanceLiveCounter(int ClientID, string Session, DateTime Date);
        BusinessObjects.DashboardSummary GetDashboardSummaryAttendance(int ClientID, DateTime FromDate, DateTime Todate);
        BusinessObjects.SummaryTotal GetSummaryTotal(int ClientID);
        IList<BusinessObjects.AdminMemberSummaryByGroup> GetAdminMemberSummaryByGroup(int ClientID);

    }
}
