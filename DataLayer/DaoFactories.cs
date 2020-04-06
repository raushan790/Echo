namespace DataObjects
{
    public class DaoFactories
    {
        public static DaoFactory GetFactory(string dataProvider)
        {
            // Return the requested DaoFactory
            switch (dataProvider)
            {
                case "ADO.NET.SqlExpress": return new AdoNet.SqlServer.SqlServerDaoFactory();
                case "ADO.NET.SqlServer": return new AdoNet.SqlServer.SqlServerDaoFactory();
                //case "ADO.NET.Oracle": return new AdoNet.Oracle.OracleDaoFactory();

                //case "LinqToSql.SqlExpress": return new Linq.LinqImplementation.LinqDaoFactory();
                //case "LinqToSql.SqlServer": return new Linq.LinqImplementation.LinqDaoFactory();
                //case "ADO.NET.Access": return new AdoNet.Access.AccessDaoFactory();

                default: return new AdoNet.SqlServer.SqlServerDaoFactory();
            }
        }
    }
}