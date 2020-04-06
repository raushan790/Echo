using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerClientsDao : IClientsDao
    {
        public int CreateClient(Clients c)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[14];
                m[0] = new SqlParameter("@ID", SqlDbType.Int);
                m[1] = new SqlParameter("@OrganizationName", c.OrganizationName);
                m[2] = new SqlParameter("@ContactPersonName", c.ContactPersonName);
                m[3] = new SqlParameter("@MobileNo", c.MobileNo);
                m[4] = new SqlParameter("@Email", c.Email);
                m[5] = new SqlParameter("@Address", c.Address);
                m[6] = new SqlParameter("@City", c.City);
                m[7] = new SqlParameter("@State", c.State);
                m[8] = new SqlParameter("@MemberCount", c.MemberCount);
                m[9] = new SqlParameter("@UserAllowedCount", c.UserAllowed);
                m[10] = new SqlParameter("@UDF1", c.UDF1);
                m[11] = new SqlParameter("@UDF2", c.UDF2);
                m[12] = new SqlParameter("@CreateDate", c.CreateDate);
                m[13] = new SqlParameter("@GoverningId", c.GoverningId);
                m[0].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Client_Insert", m);
                object ivalue = m[0].Value;
                return (int)ivalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateClient(Clients c)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[13];
                m[0] = new SqlParameter("@ID", c.ID);
                m[1] = new SqlParameter("@OrganizationName", c.OrganizationName);
                m[2] = new SqlParameter("@ContactPersonName", c.ContactPersonName);
                m[3] = new SqlParameter("@MobileNo", c.MobileNo);
                m[4] = new SqlParameter("@Email", c.Email);
                m[5] = new SqlParameter("@Address", c.Address);
                m[6] = new SqlParameter("@City", c.City);
                m[7] = new SqlParameter("@State", c.State);
                m[8] = new SqlParameter("@MemberCount", c.MemberCount);
                m[9] = new SqlParameter("@UserAllowedCount", c.UserAllowed);
                m[10] = new SqlParameter("@UDF1", c.UDF1);
                m[11] = new SqlParameter("@UDF2", c.UDF2);
                m[12] = new SqlParameter("@GoverningId", c.GoverningId);



                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Client_Update", m);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteClients(int _ID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@ID", _ID);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "Client_Delete", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Clients GetClient(int _ClientID)
        {
            throw new NotImplementedException();
        }

        public Clients GetClientbyCreateDate(DateTime _CreateDate)
        {
            throw new NotImplementedException();
        }

        public Clients GetClientbyEmail(string _Email)
        {
            throw new NotImplementedException();
        }

        public Clients GetClientbyMobile(string _Mobile)
        {
            throw new NotImplementedException();
        }

        public List<Clients> GetClients()
        {
            throw new NotImplementedException();
        }

        public IList<Clients> GetClients(int ClientID)
        {
            throw new NotImplementedException();
        }

        
    }
}
