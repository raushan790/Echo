namespace DataObjects
{
    public interface IUserGroupMappingDao
    {
        int CreateMapping(BusinessObjects.UserGroupMapping c);

        BusinessObjects.UserGroupMapping UserGroupMapp(int _Group_MappingID);

        System.Collections.Generic.List<BusinessObjects.UserGroupMapping> UserGroupMappings(string _UserID);

        System.Collections.Generic.List<BusinessObjects.UserGroupMapping> UserGroupMappings(int _UserGroupID);

        int DeleteMapping(string _UserID);

        int DeleteMapping(string _UserID, int _UserGroupID);
    }
}