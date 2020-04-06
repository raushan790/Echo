using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "Address", Namespace = "http://www.yourcompany.com/types/")]

    public class Address : BusinessObject
    {
        public Address()
        {
            AddRule(new ValidateId("AddressId"));
            AddRule(new ValidateRequired("AddressId"));
            AddRule(new ValidateRequired("IsBillingAddress"));
            AddRule(new ValidateRequired("UserID"));
            AddRule(new ValidateLength("FirstName", 0, 100));
            AddRule(new ValidateLength("LastName", 0, 100));
            Version = _versionDefault;
        }

        public Address(int _AddressId, bool _IsBillingAddress, string _FirstName, string _LastName, string _PhoneNumber, string _Email,
            string _FaxNumber, string _Company, string _Address1, string _Address2, string _City, int _StateProvinceID, string _ZipPostalCode,
            int _CountryID, DateTime _CreatedOn, string _UserID, string _TwoLetterISOCode, string _StateOrProvinceCode,
            string _Country, bool _IsDefault, string _Custom1, string _Custom2, string _Custom3, string _Custom4, string _Custom5, AddressType _Type, int _Pages,
            int _TotalRecord, string _Latitude, string _Longitude, bool _IsActive, string _Facebook, string _Twitter, string _LinkedIn, string _MySpace, bool _ShowMyName,
            string _CompanyID, string _Custom6, string _Custom7, string _Custom8, string _LocationID)
            : this()
        {
            AddressId = _AddressId;
            IsBillingAddress = _IsBillingAddress;
            FirstName = _FirstName;
            LastName = _LastName;
            PhoneNumber = _PhoneNumber;
            Email = _Email;
            FaxNumber = _FaxNumber;
            Company = _Company;
            Address1 = _Address1;
            Address2 = _Address2;
            City = _City;
            StateProvinceID = _StateProvinceID;
            ZipPostalCode = _ZipPostalCode;
            CountryID = _CountryID;
            CreatedOn = _CreatedOn;
            UserID = _UserID;
            TwoLetterISOCode = _TwoLetterISOCode;
            StateOrProvinceCode = _StateOrProvinceCode;
            Country = _Country;
            Type = _Type;
            IsDefault = _IsDefault;
            Pages = _Pages;
            TotalRecord = _TotalRecord;
            Latitude = _Latitude;
            Longitude = _Longitude;
            IsActive = _IsActive;
            Facebook = _Facebook;
            Twitter = _Twitter;
            LinkedIn = _LinkedIn;
            MySpace = _MySpace;
            ShowMyName = _ShowMyName;
            CompanyID = _CompanyID;
            Custom1 = _Custom1;
            Custom2 = _Custom2;
            Custom3 = _Custom3;
            Custom4 = _Custom4;
            Custom5 = _Custom5;
            Custom6 = _Custom6;
            Custom7 = _Custom7;
            Custom8 = _Custom8;
            LocationID = _LocationID;
        }

        [DataMember]
        public int AddressId { get; set; }

        [DataMember]
        public bool IsBillingAddress { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Email { set; get; }

        [DataMember]
        public string FaxNumber { get; set; }

        [DataMember]
        public string Company { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public int StateProvinceID { get; set; }

        [DataMember]
        public string ZipPostalCode { get; set; }

        [DataMember]
        public int CountryID { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string TwoLetterISOCode { get; set; }

        [DataMember]
        public string StateOrProvinceCode { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public AddressType Type { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public int TotalRecord { get; set; }

        [DataMember]
        public int Pages { get; set; }

        [DataMember]
        public string Latitude { get; set; }

        [DataMember]
        public string Longitude { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string Facebook { get; set; }

        [DataMember]
        public string Twitter { get; set; }

        [DataMember]
        public string LinkedIn { get; set; }

        [DataMember]
        public string MySpace { get; set; }

        [DataMember]
        public bool ShowMyName { get; set; }

        [DataMember]
        public string CompanyID { get; set; }

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
        public string Custom6 { get; set; }

        [DataMember]
        public string Custom7 { get; set; }

        [DataMember]
        public string Custom8 { get; set; }

        [DataMember]
        public string LocationID { get; set; }

        [DataMember]
        public string Version { get; set; }
    }

    public enum AddressType : int
    {
        Mailing = 1,
        Shipping = 2,
        Billing = 3,
        Residential = 4,
        Commercial = 5
    }
}