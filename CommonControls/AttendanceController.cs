using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using DataObjects;
using BusinessObjects;
using Controllers;

namespace Controllers
{
    [DataObject(true)]
    public class AttendanceController : ControllerBase
    {
        #region AttendanceCode
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int CreateAttendanceCode(AttendanceCode _AttendanceCode)
        {
            return DataAccess.AttendanceCodeDao.CreateAttendanceCode(_AttendanceCode);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public string DeleteAttendanceCode(int GroupID, DateTime Date)
        {
            return DataAccess.AttendanceCodeDao.DeleteAttendanceCode(GroupID, Date);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int VerifyAttendanceCode(int GroupID, DateTime AttendanceDate)
        {
            return DataAccess.AttendanceCodeDao.VerifyAttendanceCode(GroupID, AttendanceDate);
        }
        #endregion
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int CheckMemberAttendance(int GroupID, DateTime Date)
        {
            return DataAccess.MemberAttendanceDao.CheckMemberAttendance(GroupID, Date);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public int GetAttendanceCountByUser(string UserID, int GroupID, DateTime Date)
        {
            return DataAccess.MemberAttendanceDao.GetAttendanceCountByUser(UserID, GroupID, Date);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<BusinessObjects.MemberAttendance> GetMemberAttendances(int GroupID, string UserID)
        {
            return DataAccess.MemberAttendanceDao.GetMemberAttendances(GroupID, UserID);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<MemberAttendance> GetMemberAttendances(int GroupID, DateTime Date)
        {
            return DataAccess.MemberAttendanceDao.GetMemberAttendances(GroupID, Date);
        }
        /// <summary>
        /// Add new User ( MemberAttendance ) return userid
        /// </summary>
        /// <param name="_MemberAttendance"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int CreateMemberAttendance(MemberAttendance _MemberAttendance)
        {
            return DataAccess.MemberAttendanceDao.CreateMemberAttendance(_MemberAttendance);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateMemberAttendance(string UserID, int GroupID, DateTime AttendanceDate, string AttendanceStatus, int Count, string AttendanceTime, string Device, string DeviceIDOrName, string DeviceLocation, string MarkedBy)
        {
            return DataAccess.MemberAttendanceDao.UpdateMemberAttendance(UserID, GroupID, AttendanceDate, AttendanceStatus, Count, AttendanceTime, Device, DeviceIDOrName, DeviceLocation, MarkedBy);
        }
    }
}
