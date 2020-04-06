using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "User", Namespace = "http://www.yourcompany.com/types/")]

    public class User
    {
        public User()
        { }

        public User(string _UserID, int _RoleID, string _FirstName, string _LastName, DateTime _DOB, string _EMail, string _PWD, bool _IsDeleted, bool _IsLockedOut, string _CouponCode, string _CreatedBy, DateTime _CreateDate, DateTime _LastLoginDate, DateTime _LastLockoutDate, bool _ChangedPassword, DateTime _LastPasswordChangedDate, string _MobileNo, int _TotalRecord, List<UserGroups> _UserGroup, string _ImageID, string _Custom1, string _Custom2, string _Custom3, string _Custom4, string _Custom5, bool _AlowCredit, string _Facebook, string _Twitter, string _LinkedIn, string _MySpace, string _Session, int _ClientID, bool _IsAdmin)
        : this()
        {
            UserID = _UserID;
            RoleID = _RoleID;
            FirstName = _FirstName;
            LastName = _LastName;
            DOB = _DOB;
            PWD = _PWD;
            EMail = _EMail;
            IsDeleted = _IsDeleted;

            IsLockedOut = _IsLockedOut;
            CouponCode = _CouponCode;
            CreatedBy = _CreatedBy;
            CreateDate = _CreateDate;
            LastLoginDate = _LastLoginDate;
            LastLockoutDate = _LastLockoutDate;
            ChangedPassword = _ChangedPassword;
            LastPasswordChangedDate = _LastPasswordChangedDate;
            MobileNo = _MobileNo;
            TotalRecord = _TotalRecord;
            UserGroup = _UserGroup;

            ImageID = _ImageID;
            Custom1 = _Custom1;
            Custom2 = _Custom2;
            Custom3 = _Custom3;
            Custom4 = _Custom4;
            Custom5 = _Custom5;

            AlowCredit = _AlowCredit;
            Facebook = _Facebook;
            Twitter = _Twitter;
            LinkedIn = _LinkedIn;
            MySpace = _MySpace;
            Session = _Session;
            ClientID = _ClientID;
            IsAdmin = _IsAdmin;
        }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public int RoleID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime DOB { get; set; }

        [DataMember]
        public string EMail { get; set; }

        [DataMember]
        public string PWD { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }



        [DataMember]
        public bool IsLockedOut { get; set; }
        [DataMember]
        public string CouponCode { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public DateTime LastLoginDate { get; set; }

        [DataMember]
        public DateTime LastLockoutDate { get; set; }
        [DataMember]
        public bool ChangedPassword { get; set; }

        [DataMember]
        public DateTime LastPasswordChangedDate { get; set; }

        [DataMember]
        public string MobileNo { get; set; }

        [DataMember]
        public string ImageID { get; set; }



        [DataMember]
        public bool AlowCredit { get; set; }

        [DataMember]
        public string Facebook { get; set; }

        [DataMember]
        public string Twitter { get; set; }

        [DataMember]
        public string LinkedIn { get; set; }

        [DataMember]
        public string MySpace { get; set; }

        [DataMember]
        public List<UserGroups> UserGroup { get; set; }



        [DataMember]
        public int TotalRecord { get; set; }

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
        public string Session { get; set; }
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
    }
}