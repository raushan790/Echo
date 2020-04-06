namespace DataObjects
{
    public interface IRoleMappingDao
    {
        int CreateRoleMapping(BusinessObjects.RoleMapping RoleMapping);

        int DeleteRoleMapping(string _UserID);

        BusinessObjects.RoleMapping GetRoleMapping(int _RoleID);

        System.Collections.Generic.IList<BusinessObjects.RoleMapping> GetRoleMappings(string _UserID);

        System.Collections.Generic.IList<BusinessObjects.RoleMapping> GetRoleMappings(int _RoelID);
    }
}