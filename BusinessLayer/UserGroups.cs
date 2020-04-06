using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "UserGroups", Namespace = "http://www.yourcompany.com/types/")]
    public class UserGroups
    {
        public UserGroups()
        {

        }

        public UserGroups(int _UserGroupID, string _Group_Name, string _Description,string _Image, string _Owner, bool _IsRole, bool _IsDeleted, bool _IsActive, DateTime _CreateDate, 
            DateTime _ModifiedDate,bool _isAdmin,int _ClientID,  int _FlowType,int _AttendanceOption,string _AttendanceOptionValue,string _StartTime, string _EndTime, int _GraceTime, 
            string _Department,  string _SubDepartment,string _NoOfClasses)
        {
            UserGroupID = _UserGroupID;
            Group_Name = _Group_Name;
            Description = _Description;
            Image = _Image;
            Owner = _Owner;
            IsRole = _IsRole;
            IsDeleted = _IsDeleted;
            IsActive = _IsActive;
            CreateDate = _CreateDate;
            ModifiedDate = _ModifiedDate;
            isAdmin = _isAdmin;
            ClientID = _ClientID;
            FlowType = _FlowType;
            AttendanceOption = _AttendanceOption;
            AttendanceOptionValue = _AttendanceOptionValue;
            StartTime = _StartTime;
            EndTime = _EndTime;
            GraceTime = _GraceTime;
            Department = _Department;
            SubDepartment = _SubDepartment;
            NoOfClasses = _NoOfClasses;
        }

        [DataMember]
        public int UserGroupID { get; set; }

        [DataMember]
        public string Group_Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public string Owner { get; set; }

        [DataMember]
        public bool IsRole { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public DateTime ModifiedDate { get; set; }

        [DataMember]
        public bool isAdmin { get; set; }
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public int FlowType { get; set; }
        [DataMember]
        public int AttendanceOption { get; set; }
        [DataMember]
        public string AttendanceOptionValue { get; set; }
        [DataMember]
        public string StartTime { get; set; }
        [DataMember]
        public string EndTime { get; set; }
        [DataMember]
        public int GraceTime { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string SubDepartment { get; set; }

        [DataMember]
        public string NoOfClasses { get; set; }
    }
}