using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerCouponDao : ICouponDao
    {
        public bool Check_Coupon(string _Coupon_Code)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@Email", _Coupon_Code);
                m[1] = new SqlParameter("@UseCount", SqlDbType.Int);
                m[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "", m);
                object ivalue = m[1].Value;
                int icount = (int)ivalue;

                if (icount > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int CreateCoupon(Coupon c)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[19];
                m[0] = new SqlParameter("@Coupon_ID", c.Coupon_ID);
                m[1] = new SqlParameter("@Coupon_Type", c.Coupon_Type);
                m[2] = new SqlParameter("@Coupon_Code", c.Coupon_Code);
                m[3] = new SqlParameter("@Start_date", c.Start_date);
                m[4] = new SqlParameter("@End_Date", c.End_Date);
                m[5] = new SqlParameter("@Entry_Date", c.Entry_Date);
                m[6] = new SqlParameter("@Amount", c.Amount);
                m[7] = new SqlParameter("@IsActive", c.IsActive);
                m[8] = new SqlParameter("@IsUsed", c.IsUsed);
                m[9] = new SqlParameter("@IsPercentage", c.IsPercentage);
                m[10] = new SqlParameter("@CustomCoupon", c.CustomCoupon);
                m[11] = new SqlParameter("@MaxReUseCount", c.MaxReUseCount);
                m[12] = new SqlParameter("@UseCount", c.UseCount);
                m[13] = new SqlParameter("@TotalRecord", c.TotalRecord);
                m[14] = new SqlParameter("@Custom1", c.Custom1);
                m[15] = new SqlParameter("@Custom2", c.Custom2);
                m[16] = new SqlParameter("@Custom3", c.Custom3);
                m[17] = new SqlParameter("@Custom4", c.Custom4);
                m[18] = new SqlParameter("@Custom5", c.Custom5);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteCoupon(int _Coupon_ID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@Coupon_ID", _Coupon_ID);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Coupon GetCoupon(string _CouponCode)
        {
            throw new NotImplementedException();
        }

        public Coupon GetCoupon(int _Coupon_ID)
        {
            throw new NotImplementedException();
        }

        public IList<Coupon> GetCoupons(bool _IsUsed, string _SortExpression)
        {
            throw new NotImplementedException();
        }

        public IList<Coupon> GetCoupons(bool _IsUsed, int _Coupon_Type)
        {
            throw new NotImplementedException();
        }

        public IList<Coupon> GetCoupons(int _PageIndex, int _PageSize, string _WhereClause, bool _IsUsed)
        {
            throw new NotImplementedException();
        }

        public IList<Coupon> GetCouponsIsActive(bool _IsActive)
        {
            throw new NotImplementedException();
        }

        public IList<Coupon> GetCouponsIsActive(bool _IsActive, int _Coupon_Type)
        {
            throw new NotImplementedException();
        }

        public IList<Coupon> GetCouponsIsActive(bool _IsActive, string _SortExpression)
        {
            throw new NotImplementedException();
        }

        public int SetCouponIsActive(int _Coupon_ID, bool _IsActive)
        {
            throw new NotImplementedException();
        }

        public int SetCouponIsUsed(int _Coupon_ID, bool _IsUsed)
        {
            throw new NotImplementedException();
        }

        public string UpdateCoupon(Coupon c)
        {
            throw new NotImplementedException();
        }

        public int UpdateUseCount(string _Coupon_Code)
        {
            throw new NotImplementedException();
        }
    }
}
