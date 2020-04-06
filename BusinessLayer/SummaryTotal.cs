using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "SummaryTotal", Namespace = "http://www.yourcompany.com/types/")]

    public class SummaryTotal
    {
        public SummaryTotal()
        { }

        [DataMember]
        public int TotalStudents { get; set; }

        [DataMember]
        public int TotalMale { get; set; }

        [DataMember]
        public int TotalFemale { get; set; }
        [DataMember]
        public int TotalTeachers { get; set; }
        [DataMember]
        public int TotalClasses { get; set; }       
       
    }
}

