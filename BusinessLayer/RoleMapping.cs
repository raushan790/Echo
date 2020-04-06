using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.BusinessRules;
using System.Runtime.Serialization;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "RoleMapping", Namespace = "http://www.yourcompany.com/types/")]
    public class RoleMapping : BusinessObject
    {

        public RoleMapping()
        {
            AddRule(new ValidateId("MapID"));
            AddRule(new ValidateId("RoleID"));
            AddRule(new ValidateRequired("UserID"));
            AddRule(new ValidateRequired("RoleID"));
            Version = _versionDefault;
        }

        public RoleMapping(int _MapID, string _UserID, int _RoleID, DateTime _MappedDate, Role _Role)
            : this()
        {
            MapID = _MapID;
            UserID = _UserID;
            RoleID = _RoleID;
            MappedDate = _MappedDate;
            Role = _Role;
        }

        [DataMember]
        public int MapID { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public int RoleID { get; set; }

        [DataMember]
        public DateTime MappedDate { get; set; }

        [DataMember]
        public Role Role { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}
