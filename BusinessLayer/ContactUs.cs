using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "ContactUs", Namespace = "http://www.yourcompany.com/types/")]
    public class ContactUs : BusinessObject
    {
        public ContactUs()
        {
            AddRule(new ValidateRequired("FName"));
            AddRule(new ValidateRequired("LName"));
            Version = _versionDefault;
        }

        public ContactUs(int _ID, string _FName, string _LName, string _City, int _StateID, string _ZipCode, string _Email, string _Comments, bool _IsRead,
            string _Custom1, string _Custom2, string _Custom3, string _Custom4, string _Custom5, bool _Option, DateTime _SubmitDate,
            int _CountryID, int _TotalRecord)
        {
            ID = _ID;
            FName = _FName;
            LName = _LName;
            City = _City;
            StateID = _StateID;
            ZipCode = _ZipCode;
            Email = _Email;
            Comments = _Comments;
            Custom1 = _Custom1;
            Custom2 = _Custom2;
            Custom3 = _Custom3;
            Custom4 = _Custom4;
            Custom5 = _Custom5;
            IsRead = _IsRead;
            Option = _Option;
            SubmitDate = _SubmitDate;
            CountryID = _CountryID;
            TotalRecord = _TotalRecord;
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string FName { get; set; }

        [DataMember]
        public string LName { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public int StateID { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public bool IsRead { get; set; }

        [DataMember]
        public bool Option { get; set; }

        [DataMember]
        public DateTime SubmitDate { get; set; }

        [DataMember]
        public int CountryID { get; set; }

        [DataMember]
        public string Custom1 { get; set; }

        [DataMember]
        public string Custom2 { get; set; }

        [DataMember]
        public string Custom3 { get; set; }

        [DataMember]
        public string Custom4 { get; set; }

        [DataMember]
        public string Custom5 { get; set; }

        [DataMember]
        public int TotalRecord { get; set; }


        [DataMember]
        public string Version { get; set; }
    }
}