using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;

namespace DataObjects
{
    public interface IAttendanceCodeDao
    {
        int UpdateOfflineAttendanceCodeTimeOfUse(int GroupID, DateTime Date, DateTime UsedDateTime);
        int CreateOfflineAttendanceCode(BusinessObjects.OfflineAttendanceCode attendanceCode);

        IList<OfflineAttendanceCode> GetOfflineAttendanceCodes(string UserID, DateTime FromDate);
        IList<OfflineAttendanceCode> GetOfflineAttendanceCodes(string UserID, string GroupIDs, DateTime FromDate);

        int CreateAttendanceCode(BusinessObjects.AttendanceCode attendanceCode);
        string DeleteAttendanceCode(int GroupID, DateTime date);
        int VerifyAttendanceCode(int GroupID, DateTime Date);
        BusinessObjects.AttendanceCode GetAttendanceCode(int GroupID, DateTime Date);
        string AddLeave(string UserID, string LeaveType, DateTime FromDate, DateTime ToDate, int DaysCount,string Reason);

        string AddUserToGroup(int GroupId, int ClientId, string MobileNo, string Session, bool IsAdmin);

        DataSet BackgroundNotificationTask();
    }
}
