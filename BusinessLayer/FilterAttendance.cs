using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "FilterAttendance", Namespace = "http://www.yourcompany.com/types/")]

    public class FilterAttendance
    {
        public FilterAttendance()
        { }
      

        [DataMember]
        public string PrimaryColoumn { get; set; }

        [DataMember]
        public string TotalStudent { get; set; }

        [DataMember]
        public string TotalStudentPresent { get; set; }

        [DataMember]
        public string TotalTeacher { get; set; }

        [DataMember]
        public string TotalTeacherPresent { get; set; }

       
    }
}

