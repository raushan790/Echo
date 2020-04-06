using System.Configuration;

namespace DataObjects
{
    public static class DataAccess
    {
        private static readonly string connectionStringName = System.Convert.ToString(ConfigurationManager.AppSettings.Get("ConnectionStringName"));
        private static readonly DaoFactory factory = DaoFactories.GetFactory(connectionStringName);
        public static IDeepLinking DeepLinkingDao
        {
            get { return factory.DeepLinkingDao; }
        }
        public static INoticeDao NoticeDao
        {
            get { return factory.NoticeDao; }
        }
        public static IDashboardDao DashboardDao
        {
            get { return factory.DashboardDao; }
        }
        public static IAttendanceCodeDao AttendanceCodeDao
        {
            get { return factory.AttendanceCodeDao; }
        }
        public static IKeyValueDao KeyValueDao
        {
            get { return factory.KeyValueDao; }
        }
        public static IAddressDao AddressDao
        {
            get { return factory.AddressDao; }
        }

        public static IUserDao UserDao
        {
            get { return factory.UserDao; }
        }

        public static IUserGroupsDao UserGroupsDao
        {
            get { return factory.UserGroupsDao; }
        }

        public static IRoleDao RoleDao
        {
            get { return factory.RoleDao; }
        }

        public static IRoleMappingDao RoleMappingDao
        {
            get { return factory.RoleMappingDao; }
        }

        public static IUserGroupMappingDao UserGroupMappingDao
        {
            get { return factory.userGroupMappingDao; }
        }

        public static IMemberAttendanceDao MemberAttendanceDao
        {
            get { return factory.MemberAttendanceDao; }
        }
        public static IClientsDao ClientsDao
        {
            get { return factory.ClientsDao; }
        }
        public static IAnalyticsDao AnalyticsDao
        {
            get { return factory.AnalyticsDao; }
        }

    }
}