using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataObjects.AdoNet.SqlServer
{
    class SqlServerKeyValueDao : IKeyValueDao
    {
        public IList<KeyValue> GetCastWiseDataForADateForSchool(DateTime Date,string Owner,int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@Owner", Owner);
                m[2] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetCastWiseDataForADateForSchool", m);
                return MakeKeyValueData(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<KeyValue> GetCastWiseDataForADate(DateTime Date,int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0]= new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "GetCastWiseDataForADate", m);
                return MakeKeyValueData(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<KeyValue> GetTopFiveSchoolForADate(DateTime Date,int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "TopFiveDistrictForADate", m);
                return MakeKeyValueData(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<KeyValue> GetBottomFiveSchoolForADate(DateTime Date,int ClientID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Date", Date);
                m[1] = new SqlParameter("@ClientID", ClientID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "BottomFiveDistrictForADate", m);
                return MakeKeyValueData(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private KeyValue MakeKeyValue(DataRow row)
        {
            try
            {
                string _Key = row["Key"].ToString();
                string _Value = row["Value"].ToString();
                
                return new KeyValue(_Key,_Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private IList<KeyValue> MakeKeyValueData(DataTable dt)
        {
            IList<KeyValue> list = new List<KeyValue>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeKeyValue(row));

            return list;
        }
    }
}
