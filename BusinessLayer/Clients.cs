using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "Clients", Namespace = "http://www.yourcompany.com/types/")]
    public class Clients
    {
        public Clients()
        { }

        public Clients(int _ID, string _OrganizationName, string _ContactPersonName, string _MobileNo, string _Email, string _Address, string _City, string _State, int _MemberCount, string _UserAllowed, string _UDF1, string _UDF2, DateTime _CreateDate, DateTime _ModifiedDate,string _GoverningId)
        : this()
        {
            ID = _ID;
            OrganizationName = _OrganizationName;
            ContactPersonName = _ContactPersonName;
            MobileNo = _MobileNo;
            Email = _Email;
            Address = _Address;
            City = _City;
            State = _State;
            MemberCount = _MemberCount;
            UserAllowed = _UserAllowed;
            UDF1 = _UDF1;
            UDF2 = _UDF2;
            CreateDate = _CreateDate;
            ModifiedDate = _ModifiedDate;
            GoverningId = _GoverningId;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string OrganizationName { get; set; }
        [DataMember]
        public string ContactPersonName { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public int MemberCount { get; set; }
        [DataMember]
        public string UserAllowed { get; set; }
        [DataMember]
        public string UDF1 { get; set; }
        [DataMember]
        public string UDF2 { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public string GoverningId { get; set; }
        
    }
}
