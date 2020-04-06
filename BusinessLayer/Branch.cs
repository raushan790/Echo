using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "AttributeValue", Namespace = "http://www.yourcompany.com/types/")]

    public class Branch : BusinessObject
    {
        public Branch()
        {
            AddRule(new ValidateId("BranchID"));
            AddRule(new ValidateRequired("BranchMame"));
            AddRule(new ValidateRequired("BranchThemes"));
            AddRule(new ValidateLength("BranchSEOHeader", 0, 100));
            Version = _versionDefault;
        }

        public Branch(int _BranchID, string _BranchMame, string _BranchSEOHeader,
            string _BranchSEOURL, string _BranchThemes)
        {
            BranchID = _BranchID;
            BranchMame = _BranchMame;
            BranchSEOHeader = _BranchSEOHeader;
            BranchSEOURL = _BranchSEOURL;
            BranchThemes = _BranchThemes;
        }

        [DataMember]
        public int BranchID { get; set; }

        [DataMember]
        public string BranchMame { get; set; }

        [DataMember]
        public string BranchSEOHeader { get; set; }

        [DataMember]
        public string BranchSEOURL { get; set; }

        [DataMember]
        public string BranchThemes { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}