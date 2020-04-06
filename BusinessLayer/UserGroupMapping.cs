using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "UserGroupMapping", Namespace = "http://www.yourcompany.com/types/")]
    public class UserGroupMapping
    {
        public UserGroupMapping()
        {
           
        }

        public UserGroupMapping(int _Group_MappingID, string _UserID, int _UserGroupID,bool _isAdmin,string _SerialNoForGroup)
            : this()
        {
            Group_MappingID = _Group_MappingID;
            UserGroupID = _UserGroupID;
            UserID = _UserID;
            isAdmin = _isAdmin;
            SerialNoForGroup = _SerialNoForGroup;
        }

        [DataMember]
        public int Group_MappingID { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public int UserGroupID { get; set; }

        [DataMember]
        public bool isAdmin { get; set; }
        [DataMember]
        public string SerialNoForGroup { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}