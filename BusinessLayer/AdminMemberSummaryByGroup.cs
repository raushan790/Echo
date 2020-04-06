using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "AdminMemberSummaryByGroup", Namespace = "http://www.yourcompany.com/types/")]

    public class AdminMemberSummaryByGroup
    {
        public AdminMemberSummaryByGroup()
        { }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string GroupDescription { get; set; }
        [DataMember]
        public int CountMember { get; set; }
        [DataMember]
        public int CountAdmin { get; set; }

    }
}

