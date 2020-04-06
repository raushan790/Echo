using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessObjects;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerRoleMappingDao : IRoleMappingDao
    {
        public IList<RoleMapping> GetRoleMappings(string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", _UserID);

                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_RoleMapping_SelectAll", m);
                return MakeRoleMappings(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<RoleMapping> GetRoleMappings(int _RoleID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@RoleID", _RoleID);

                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_RoleMapping_SelectAll_RoleID", m);
                return MakeRoleMappings(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RoleMapping GetRoleMapping(int _RoleID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@MapID", _RoleID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_RoleMapping_SelectOne", m);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeRoleMapping(row);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateRoleMapping(RoleMapping c)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[4];
                m[0] = new SqlParameter("@UserID", c.UserID);
                m[1] = new SqlParameter("@RoleID", c.RoleID);
                m[2] = new SqlParameter("@MappedDate", c.MappedDate);
                m[3] = new SqlParameter("@MapID", SqlDbType.Int);
                m[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "LP_Coupon_Insert", m);
                object ivalue = m[3].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteRoleMapping(string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", _UserID);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "LP_RoleMapping_Delete", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<RoleMapping> MakeRoleMappings(DataTable dt)
        {
            IList<RoleMapping> list = new List<RoleMapping>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeRoleMapping(row));

            return list;
        }

        private RoleMapping MakeRoleMapping(DataRow dr)
        {
            try
            {
                int _MapID = int.Parse(dr["MapID"].ToString());
                int _RoleID = int.Parse(dr["RoleID"].ToString());
                string _UserID = dr["UserID"].ToString();
                DateTime _MappedDate = DateTime.Parse(dr["MappedDate"].ToString());

                Role _role = new SqlServerRoleDao().GetRole(_RoleID);
                return new RoleMapping(_MapID, _UserID, _RoleID, _MappedDate, _role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}