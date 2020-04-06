namespace DataObjects
{
    public abstract class DaoFactory
    {
        public abstract IDeepLinking DeepLinkingDao { get; }
        public abstract INoticeDao NoticeDao { get; }
        public abstract IDashboardDao DashboardDao { get; }
        public abstract IAttendanceCodeDao AttendanceCodeDao { get; }
        public abstract IKeyValueDao KeyValueDao { get; }
        public abstract IAddressDao AddressDao { get; }

        public abstract IUserDao UserDao { get; }

        public abstract IUserGroupsDao UserGroupsDao { get; }

        public abstract IMemberAttendanceDao MemberAttendanceDao { get; }

        public abstract IClientsDao ClientsDao { get; }

        public abstract IRoleDao RoleDao { get; }

        public abstract IRoleMappingDao RoleMappingDao { get; }

        public abstract IUserGroupMappingDao userGroupMappingDao { get; }
        public abstract IAnalyticsDao AnalyticsDao { get; }








    }
}