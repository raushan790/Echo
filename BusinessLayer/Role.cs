using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.BusinessRules;
using System.Runtime.Serialization;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "Role", Namespace = "http://www.yourcompany.com/types/")]
    public class Role : BusinessObject
    {
        public Role()
        {
            AddRule(new ValidateId("RoleID"));
            AddRule(new ValidateRequired("RoleName"));
            Version = _versionDefault;
        }

        public Role(int _RoleID, string _RoleName, DateTime _CreateDate)
            : this()
        {
            RoleID = _RoleID;
            RoleName = _RoleName;
            CreateDate = _CreateDate;
        }


        [DataMember]
        public int RoleID { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}
