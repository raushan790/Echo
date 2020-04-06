namespace DataObjects
{
    public interface IUserGroupsDao
    {
        int CreateUserGroup(BusinessObjects.UserGroups c);

        BusinessObjects.UserGroups GetUserGroup(int _UserGroupID);

        BusinessObjects.UserGroups GetUserGroupGuest();

        System.Collections.Generic.List<BusinessObjects.UserGroups> GetUserGroups();
        System.Collections.Generic.List<BusinessObjects.UserGroups> GetUserGroupsByOwner(string Owner);

        System.Collections.Generic.List<BusinessObjects.UserGroups> GetUserGroups(string _UserID);

        System.Collections.Generic.List<BusinessObjects.UserGroups> GetUserRoles();

        int UpdateUserGroup(BusinessObjects.UserGroups c);
        string DeleteUserGroup(int GroupID);
    }
}