using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "AttendanceCode", Namespace = "http://www.yourcompany.com/types/")]

    public class AttendanceCode
    {
        public AttendanceCode()
        { }
        public AttendanceCode(int _ID, int _GroupID, DateTime _AttendanceDate, int _Code, DateTime _CreateDate)
        :this()
        {
            ID = _ID;
            GroupID = _GroupID;
            AttendanceDate = _AttendanceDate;
            Code = _Code;
            CreateDate = _CreateDate;
        }
        [DataMember]
        public int     ID { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public DateTime AttendanceDate { get; set; }
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }


    }
}

