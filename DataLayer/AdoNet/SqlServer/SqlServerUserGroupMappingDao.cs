using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessObjects;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerUserGroupMappingDao : IUserGroupMappingDao
    {
        public List<UserGroupMapping> UserGroupMappings(string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", _UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "UserGroupMapping_Select", m);

                return MakeMappings(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserGroupMapping> UserGroupMappings(int _UserGroupID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserGroupID", _UserGroupID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_UserGroupMapping_SelectGroupID", m);

                return MakeMappings(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserGroupMapping UserGroupMapp(int _Group_MappingID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Group_MappingID", _Group_MappingID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_UserGroupMapping_SelectOne", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeMapping(row);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateMapping(UserGroupMapping c)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[5];
                m[0] = new SqlParameter("@UserGroupID", c.UserGroupID);
                m[1] = new SqlParameter("@UserID", c.UserID);
                m[2] = new SqlParameter("@Group_MappingID", SqlDbType.Int);
                m[3] = new SqlParameter("@isAdmin", c.isAdmin);
                m[4] = new SqlParameter("@SerialNoForGroup", c.SerialNoForGroup);
                
                m[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "UserGroupMapping_Insert", m);
                object ivalue = m[2].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteMapping(string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", _UserID);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "LP_UserGroupMapping_DeleteByUserID", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteMapping(string _UserID, int _UserGroupID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@UserID", _UserID);
                m[1] = new SqlParameter("@GroupId", _UserGroupID);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "UserGroupMapping_DeleteByUserIDAndGroupID", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<UserGroupMapping> MakeMappings(DataTable dt)
        {
            List<UserGroupMapping> list = new List<UserGroupMapping>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeMapping(row));

            return list;
        }

        private UserGroupMapping MakeMapping(DataRow dr)
        {
            try
            {
                int _Group_MappingID = Convert.ToInt32(dr["GroupMappingID"]);
                string _UserID = Convert.ToString(dr["UserID"]);
                int _UserGroupID = Convert.ToInt32(dr["UserGroupID"]);
                bool _isAdmin = false;
                string _SerialNoForGroup = Convert.ToString(dr["SerialNoForGroup"]); 
                return new UserGroupMapping { UserGroupID = _UserGroupID, Group_MappingID = _Group_MappingID, UserID = _UserID,isAdmin=_isAdmin };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}