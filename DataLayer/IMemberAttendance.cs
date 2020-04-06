using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
   public interface IMemberAttendanceDao
    {
        int GetAttendanceCountByUser(string UserID, int GroupID, DateTime Date);
        int CreateMemberAttendance(BusinessObjects.MemberAttendance mat);
        int UpdateMemberAttendance(string UserID, int GroupID, DateTime AttendanceDate, string AttendanceStatus, int Count, string AttendanceTime, string Device, string DeviceIDOrName, string DeviceLocation, string MarkedBy);
        int DeleteMemberAttendance(string _MemberID);
        int CheckMemberAttendance(int GroupID, DateTime Date);
        BusinessObjects.MemberAttendance GetMemberAttendance(string _MemberId);
        System.Collections.Generic.IList<BusinessObjects.MemberAttendance> GetMemberAttendances(int GroupID, string UserID);

        System.Collections.Generic.IList<BusinessObjects.MemberAttendance> GetMemberAttendances(int GroupID,DateTime Date);
        System.Collections.Generic.IList<BusinessObjects.MemberAttendance> GetMemberAttendances();
        int CreateLeave(Guid UserID, DateTime FromDate, DateTime ToDate, DateTime CreateDate, DateTime ModifiedDate, string Custom1, string Custom2,string Custom3);

    }
}
