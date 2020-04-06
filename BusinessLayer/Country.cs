using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "Country", Namespace = "http://www.yourcompany.com/types/")]
    public class Country : BusinessObject
    {
        public Country()
        {
            AddRule(new ValidateId("CountryID"));
            AddRule(new ValidateLength("Name", 0, 100));
            Version = _versionDefault;
        }

        public Country(int _CountryID, string _Name, bool _AllowsRegistration, bool _AllowsBilling, bool _AllowsShipping, string _TwoLetterISOCode, string _ThreeLetterISOCode, int _NumericISOCode, bool _IsPublished, int _DisplayOrder)
            : this()
        {
            CountryID = _CountryID;
            Name = _Name;
            AllowsRegistration = _AllowsRegistration;
            AllowsBilling = _AllowsBilling;
            AllowsShipping = _AllowsShipping;
            TwoLetterISOCode = _TwoLetterISOCode;
            ThreeLetterISOCode = _ThreeLetterISOCode;
            NumericISOCode = _NumericISOCode;
            IsPublished = _IsPublished;
            DisplayOrder = _DisplayOrder;
        }

        [DataMember]
        public int CountryID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool AllowsRegistration { get; set; }

        [DataMember]
        public bool AllowsBilling { get; set; }

        [DataMember]
        public bool AllowsShipping { get; set; }

        [DataMember]
        public string TwoLetterISOCode { get; set; }

        [DataMember]
        public string ThreeLetterISOCode { get; set; }

        [DataMember]
        public int NumericISOCode { get; set; }

        [DataMember]
        public bool IsPublished { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}