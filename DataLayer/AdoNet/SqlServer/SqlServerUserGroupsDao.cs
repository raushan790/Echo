using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BusinessObjects;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerUserGroupsDao : IUserGroupsDao
    {
        public List<BusinessObjects.UserGroups> GetUserGroupsByOwner(string Owner)
        {
            try
            {

                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Owner", Owner);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectGroupbyOwner", m);
                return MakeUserGroups(ds.Tables[0]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserGroups> GetUserGroups()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectAllGroups");
                return MakeUserGroups(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserGroups> GetUserRoles()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "UserGroups_SelectRoles");
                return MakeUserGroups(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserGroups> GetUserGroups(string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@UserID", _UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "UserGroups_SelectByUser", m);
                return MakeUserGroups(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserGroups GetUserGroup(int _UserGroupID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GroupID", _UserGroupID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "SelectGroupbyID", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUserGroup(row);
                }
                else
                    throw new Exception("UserGroupID does not exist in database");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserGroups GetUserGroupGuest()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "UserGroups_SelectGuest");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeUserGroup(row);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateUserGroup(UserGroups c)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[17];
                m[0] = new SqlParameter("@GroupName", c.Group_Name);
                m[1] = new SqlParameter("@Owner", c.Owner);
                m[2] = new SqlParameter("@IsRole", c.IsRole);
                m[3] = new SqlParameter("@IsDeleted", c.IsDeleted);
                m[4] = new SqlParameter("@IsActive", c.IsActive);
                m[5] = new SqlParameter("@CreateDate", c.CreateDate);
                m[6] = new SqlParameter("@ModifiedDate", c.ModifiedDate);
                m[7] = new SqlParameter("@Description", c.Description);
                m[8] = new SqlParameter("@GroupImage", c.Image);
                m[9] = new SqlParameter("@GroupID", SqlDbType.Int);
                m[10] = new SqlParameter("@ClientID", c.ClientID);
                m[11] = new SqlParameter("@FlowType", c.FlowType);
                m[12] = new SqlParameter("@AttendanceOption", c.AttendanceOption);
                m[13] = new SqlParameter("@AttendanceOptionValue", c.AttendanceOptionValue);
                m[14] = new SqlParameter("@StartTime", c.StartTime);
                m[15] = new SqlParameter("@EndTime", c.EndTime);
                m[16] = new SqlParameter("@GraceTime", c.GraceTime);
                m[9].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "CreateGroup", m);
                object ivalue = m[9].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateUserGroup(UserGroups c)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[17];
                m[0] = new SqlParameter("@GroupName", c.Group_Name);
                m[1] = new SqlParameter("@Owner", c.Owner);
                m[2] = new SqlParameter("@IsRole", c.IsRole);
                m[3] = new SqlParameter("@IsDeleted", c.IsDeleted);
                m[4] = new SqlParameter("@IsActive", c.IsActive);

                m[5] = new SqlParameter("@GroupID", c.UserGroupID);
                m[6] = new SqlParameter("@Description", c.Description);
                m[7] = new SqlParameter("@GroupImage", c.Image);
                m[8] = new SqlParameter("@FlowType", c.FlowType);
                m[9] = new SqlParameter("@AttendanceOption", c.AttendanceOption);
                m[10] = new SqlParameter("@AttendanceOptionValue", c.AttendanceOptionValue);
                m[11] = new SqlParameter("@StartTime", c.StartTime);
                m[12] = new SqlParameter("@EndTime", c.EndTime);
                m[13] = new SqlParameter("@GraceTime", c.GraceTime);
                m[14] = new SqlParameter("@Department", c.Department);
                m[15] = new SqlParameter("@SubDepartment", c.SubDepartment);
                m[16] = new SqlParameter("@NoOfClasses", c.NoOfClasses);


                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "UpdateGroup", m);
                object ivalue = m[5].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteUserGroup(int GroupID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@GroupID", GroupID);
                int r = SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DeleteUserGroup", m);
                return r.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private List<UserGroups> MakeUserGroups(DataTable dt)
        {
            List<UserGroups> list = new List<UserGroups>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeUserGroup(row));

            return list;
        }

        private UserGroups MakeUserGroup(DataRow dr)
        {
            try
            {
                int _UserGroupID = Convert.ToInt32(dr["GroupID"]);
                string _Group_Name = dr["GroupName"].ToString();
                string _Description = dr["Description"].ToString();
                string _Image = dr["GroupImage"].ToString();
                string _Owner = dr["Owner"].ToString();
                string _StartTime = dr["StartTime"].ToString();
                string _EndTime = dr["EndTime"].ToString();
                string _Department = dr["Department"].ToString(); 
                string _SubDepartment = dr["SubDepartment"].ToString();
                string _NoOfClasses = dr["NoOfClasses"].ToString();

                

                int _GraceTime = 0;
                try
                {
                    _GraceTime=int.Parse(dr["GraceTime"].ToString());
                }catch{}
                bool _IsRole = bool.Parse(dr["IsRole"].ToString());
                bool _IsDeleted = bool.Parse(dr["IsDeleted"].ToString());
                bool _IsActive = bool.Parse(dr["IsActive"].ToString());
                bool _IsAdmin = false;
                try
                {
                    _IsAdmin = bool.Parse(dr["isAdmin"].ToString());
                }
                catch
                {
                }

                int _FlowType = 0;
                try
                {
                    _FlowType = int.Parse(dr["FlowType"].ToString());
                }
                catch
                {
                }
                int _AttendanceOption = 0;
                try
                {
                    _AttendanceOption = int.Parse(dr["AttendanceOption"].ToString());
                }
                catch
                {
                }
                string _AttendanceOptionValue = string.Empty;
                try
                {
                    _AttendanceOptionValue = dr["AttendanceOptionValue"].ToString();
                }
                catch
                {
                }

                DateTime _CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                DateTime _ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
                int _ClientID = dr["ClientID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ClientID"]);

                return new UserGroups(_UserGroupID, _Group_Name, _Description, _Image, _Owner, _IsRole,
                    _IsDeleted, _IsActive, _CreateDate, _ModifiedDate, _IsAdmin, _ClientID, 
                    _FlowType, _AttendanceOption, _AttendanceOptionValue,_StartTime,_EndTime,_GraceTime,_Department,_SubDepartment, _NoOfClasses);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}