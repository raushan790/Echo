using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "MemberAttendance", Namespace = "http://www.yourcompany.com/types/")]
   public class MemberAttendance
    {
        public MemberAttendance()
        { }

        public MemberAttendance(int _Id, DateTime _AttendanceDate, string _UserID,int _GroupID, string _AttendanceStatus, DateTime _CreateDate, string _UDF1, string _UDF2, string _UDF3,string _AttendanceTime, string _Device, string _DeviceIDOrName, string _DeviceLocation,string _Session,int _ClientID)
        :this()
        {
            Id = _Id;
            AttendanceDate = _AttendanceDate;
            UserID = _UserID;
            GroupID = _GroupID;
            AttendanceStatus = _AttendanceStatus;
            CreateDate = _CreateDate;
            UDF1 = _UDF1;
            UDF2 = _UDF2;
            UDF3 = _UDF3;
            AttendanceTime = _AttendanceTime;
            Device = _Device;
            DeviceIDOrName = _DeviceIDOrName;
            DeviceLocation = _DeviceLocation;
            Session = _Session;
            ClientID = _ClientID;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime AttendanceDate { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public int GroupID { get; set; }

        [DataMember]
        public string AttendanceStatus { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string UDF1 { get; set; }

        [DataMember]
        public string UDF2 { get; set; }

        [DataMember]
        public string UDF3 { get; set; }
        [DataMember]
        public string AttendanceTime { get; set; }
        [DataMember]
        public string Device { get; set; }
        [DataMember]
        public string DeviceIDOrName { get; set; }
        [DataMember]
        public string DeviceLocation { get; set; }
        [DataMember]
        public string Session { get; set; }
        [DataMember]
        public int ClientID { get; set; }
    }
}
