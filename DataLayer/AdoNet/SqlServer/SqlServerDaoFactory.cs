using System;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerDaoFactory : DaoFactory
    {
        public override IDeepLinking DeepLinkingDao
        {
            get
            {
                return new SqlServerDeepLinkingDao();
            }
        }
        public override INoticeDao NoticeDao
        {
            get { return new SqlServerNoticeDao(); }
        }
        public override IDashboardDao DashboardDao
        {
            get { return new SqlServerDashboardDao(); }
        }
        public override IAttendanceCodeDao AttendanceCodeDao
        {
            get { return new SqlServerAttendanceCodeDao(); }
        }
        public override IKeyValueDao KeyValueDao
        {
            get { return new SqlServerKeyValueDao(); }
        }
        public override IAddressDao AddressDao
        {
            get { return new SqlServerAddressDao(); }
        }

        public override IMemberAttendanceDao MemberAttendanceDao
        {
            get { return new SqlServerMemberAttendanceDao(); }
        }

        public override IUserDao UserDao
        {
            get { return new SqlServerUserDao(); }
        }

        public override IUserGroupsDao UserGroupsDao
        {
            get { return new SqlServerUserGroupsDao(); }
        }

        public override IRoleDao RoleDao
        {
            get { return new SqlServerRoleDao(); }
        }

        public override IRoleMappingDao RoleMappingDao
        {
            get { return new SqlServerRoleMappingDao(); }
        }

        public override IUserGroupMappingDao userGroupMappingDao
        {
            get { return new SqlServerUserGroupMappingDao(); }
        }
        public override IClientsDao ClientsDao
        {
            get { return new SqlServerClientsDao(); }
        }
        public override IAnalyticsDao AnalyticsDao
        {
            get { return new SqlServerAnalyticsDao(); }
        }
    }
}