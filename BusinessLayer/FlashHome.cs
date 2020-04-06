using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "FlashHome", Namespace = "http://www.yourcompany.com/types/")]
    public class FlashHome : BusinessObject
    {
        public FlashHome()
        {
            AddRule(new ValidateId("ID"));
            Version = _versionDefault;
        }

        public FlashHome(int _ID, string _Link, bool _EnableStatus, int _SortOrder, DateTime _CreationDate, string _Custom1, string _Custom2, string _Custom3)
            : this()
        {
            ID = _ID;
            Link = _Link;
            EnableStatus = _EnableStatus;
            SortOrder = _SortOrder;
            CreationDate = _CreationDate;
            Custom1 = _Custom1;
            Custom2 = _Custom2;
            Custom3 = _Custom3;
        }

        public int ID { get; set; }
        public string Link { get; set; }
        public bool EnableStatus { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreationDate { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Version { get; set; }
    }
}
