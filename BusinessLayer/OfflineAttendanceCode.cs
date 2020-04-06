using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "OfflineAttendanceCode", Namespace = "http://www.yourcompany.com/types/")]
    public class OfflineAttendanceCode
    {
        public OfflineAttendanceCode()
        { }

        public OfflineAttendanceCode(int _GroupId, string _AttendanceCode, string _DateofUse)
        : this()
        {
            GroupId = _GroupId;
            AttendanceCode = _AttendanceCode;
            DateofUse = _DateofUse;
           
        }
        [DataMember]
        public int GroupId { get; set; }
        [DataMember]
        public string AttendanceCode { get; set; }
        [DataMember]
        public string DateofUse { get; set; }
          
    }
}
