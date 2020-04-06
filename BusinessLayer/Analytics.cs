using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "Analytics", Namespace = "http://www.yourcompany.com/types/")]

    public class Analytics
    {
        public Analytics()
        { }
        public Analytics(string _UserID, string _Name, string _Gender, string _Cast, string _Class, string _School, string _Cluster, string _District,string _Block,DateTime _Date,string _AttendanceStatus,float _Count)
        :this()
        {
            UserID = _UserID;
            Name = _Name;
            Gender = _Gender;
            Cast = _Cast;
            Class = _Class;
            School = _School;
            Cluster = _Cluster;
            District = _District;
            Block = _Block;
            Date = _Date;
            AttendanceStatus = _AttendanceStatus;
            Count = _Count;
        }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string Cast { get; set; }

        [DataMember]
        public string Class { get; set; }

        [DataMember]
        public string School { get; set; }

        [DataMember]
        public string Cluster { get; set; }

        [DataMember]
        public string District { get; set; }

        [DataMember]
        public string Block { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string AttendanceStatus { get; set; }

        [DataMember]
        public float Count { get; set; }
    }
}

