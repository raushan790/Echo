namespace DataObjects
{
    public interface IRoleDao
    {
        BusinessObjects.Role GetRole(int _RoleID);

        System.Collections.Generic.IList<BusinessObjects.Role> GetRoles();
    }
}