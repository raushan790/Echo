using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessObjects;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerRoleDao : IRoleDao
    {
        public IList<Role> GetRoles()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Role_SelectAll");
                return MakeRoles(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Role GetRole(int _RoleID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@RoleID", _RoleID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Role_SelectOne", m);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeRole(row);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<Role> MakeRoles(DataTable dt)
        {
            IList<Role> list = new List<Role>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeRole(row));

            return list;
        }

        private Role MakeRole(DataRow dr)
        {
            try
            {
                int _RoleID = int.Parse(dr["RoleID"].ToString());
                string _RoleName = dr["RoleName"].ToString();
                DateTime _CreateDate = DateTime.Parse(dr["DisplayOrder"].ToString());

                return new Role(_RoleID, _RoleName, _CreateDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}