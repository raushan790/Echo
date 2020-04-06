using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "DeepLinking", Namespace = "http://www.yourcompany.com/types/")]
    public class DeepLinking
    {
        public DeepLinking()
        { }

        public DeepLinking(string _Url, int _GroupID, DateTime _CreateDate,
           DateTime _ModifiedDate, string _Custom1, string _Custom2, string _CreatedBy)

        {
            Url = _Url;
            GroupID = _GroupID;
            CreateDate = _CreateDate;
            ModifiedDate = _ModifiedDate;
            Custom1 = _Custom1;
            Custom2 = _Custom2;
            CreatedBy = _CreatedBy;
        }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public string Custom1 { get; set; }
        [DataMember]
        public string Custom2 { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
}
