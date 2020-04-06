using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "DashboardSummary", Namespace = "http://www.yourcompany.com/types/")]

    public class DashboardSummary
    {
        public DashboardSummary()
        { }

        [DataMember]
        public string TotalStudents { get; set; }

        [DataMember]
        public string TotalMale { get; set; }

        [DataMember]
        public string TotalFemale { get; set; }

        [DataMember]
        public string TotalStudentsPresent { get; set; }

        [DataMember]
        public string TotalMalePresent { get; set; }

        [DataMember]
        public string TotalFemalePresent { get; set; }

        [DataMember]
        public string TotalClasses { get; set; }

        [DataMember]
        public string TotalTeachers { get; set; }

        [DataMember]
        public string TotalTeachersPresent { get; set; }
        [DataMember]
        public List<FilterAttendance> Trends { get; set; }
        [DataMember]
        public IList<KeyValue> TopFive { get; set; }
        [DataMember]
        public IList<KeyValue> BottomFive { get; set; }

    }
}

