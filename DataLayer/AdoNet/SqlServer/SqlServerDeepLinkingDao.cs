using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerDeepLinkingDao : IDeepLinking
    {
        public int CreateDeepLinking(DeepLinking dl)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[7];
                m[0] = new SqlParameter("@Url", dl.Url);
                m[1] = new SqlParameter("@GroupId", dl.GroupID);
                m[2] = new SqlParameter("@CreateDate", DateTime.Now.ToShortDateString());
                m[3] = new SqlParameter("@ModifiedDate", dl.ModifiedDate);
                m[4] = new SqlParameter("@Custom1", dl.Custom1);
                m[5] = new SqlParameter("@Custom2", dl.Custom2);
                m[6] = new SqlParameter("@Createdby", dl.CreatedBy);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DeepLinking_Insert", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteDeepLinking(string Url)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Url", Url);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "DeepLinking_Delete", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeepLinking GetDeepLinkingbyCreatedBy(string _CreatedBy)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Createdby", _CreatedBy);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DeepLinking_SelectByCreatedBy", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeDeepLinking(row);
                }
                else
                    return null; ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeepLinking GetDeepLinkingbyUrl(string _Url)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Url", _Url);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "DeepLinking_SelectByUrl", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeDeepLinking(row);
                }
                else
                    return null; ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<DeepLinking> MakeLinkings(DataTable dt)
        {
            List<DeepLinking> list = new List<DeepLinking>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeDeepLinking(row));

            return list;
        }
        private DeepLinking MakeDeepLinking(DataRow dr)
        {
            try
            {
                string _Url = Convert.ToString(dr["Url"]);
                int _GroupID = Convert.ToInt32(dr["GroupId"]);
                DateTime _CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                DateTime _ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
                string _Custom1 = Convert.ToString(dr["Custom1"]);
                string _Custom2 = Convert.ToString(dr["Custom2"]);
                string _CreatedBy = Convert.ToString(dr["Createdby"]);
                return new DeepLinking { Url = _Url, GroupID = _GroupID, CreateDate = _CreateDate, ModifiedDate = _ModifiedDate, Custom1 = _Custom1, Custom2 = _Custom2, CreatedBy = _CreatedBy };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
