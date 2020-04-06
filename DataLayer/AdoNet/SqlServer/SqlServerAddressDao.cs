using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BusinessObjects;

namespace DataObjects.AdoNet.SqlServer
{
    public class SqlServerAddressDao : IAddressDao
    {
        public IList<Address> GetAddressList(bool _IsBillingAddress, string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@IsBillingAddress", _IsBillingAddress);
                m[1] = new SqlParameter("@UserID", _UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_Select", m);
                return MakeAddress(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Address> GetAddressList(bool _IsBillingAddress, bool _IsDefault, string _UserID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[3];
                m[0] = new SqlParameter("@IsDefault", _IsDefault);
                m[1] = new SqlParameter("@IsBillingAddress", _IsBillingAddress);
                m[2] = new SqlParameter("@UserID", _UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_Select_Default", m);
                return MakeAddress(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Address> GetAddressList(string _UserID, AddressType _AddressType)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                int iValue = (int)_AddressType;
                m[0] = new SqlParameter("@type", iValue.ToString());
                m[1] = new SqlParameter("@UserID", _UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_SelectBytype", m);
                return MakeAddress(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Address> GetAddressSearch(string _SearchString, AddressType _AddressType)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                int iValue = (int)_AddressType;
                m[0] = new SqlParameter("@type", Convert.ToString(iValue));
                m[1] = new SqlParameter("@SearchString", _SearchString);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_Search", m);
                return MakeAddress(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Address> GetAddressSearch(int _PageIndex, int _PageSize, string SearchString, AddressType _AddressType)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[4];
                int iValue = (int)_AddressType;
                m[0] = new SqlParameter("@type", iValue.ToString());
                m[1] = new SqlParameter("@SearchString", SearchString);
                m[2] = new SqlParameter("@PageSize", _PageSize);
                m[3] = new SqlParameter("@PageNumber", _PageIndex);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_Search_Paging", m);
                return MakeAddress(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Address> GetAddressList(bool _IsBillingAddress, string _UserID, string _SortExpression)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@IsBillingAddress", _IsBillingAddress);
                m[1] = new SqlParameter("@UserID", _UserID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_Select", m);
                IList<Address> objAddresses = MakeAddress(ds.Tables[0]);
                IEnumerable<Address> sortedAddress = objAddresses.OrderBy(f => _SortExpression);
                IList<Address> sortedList = sortedAddress.ToList();
                return sortedList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Address GetAddress(int _AddressID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[1];
                m[0] = new SqlParameter("@AddressID", _AddressID);
                DataSet ds = SqlHelper.ExecuteDataset(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_SelectOne", m);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row == null) return null;

                    return MakeAddres(row);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateAddresss(Address _Address)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[34];
                m[0] = new SqlParameter("@IsBillingAddress", _Address.IsBillingAddress);
                m[1] = new SqlParameter("@FirstName", _Address.FirstName);
                m[2] = new SqlParameter("@LastName", _Address.LastName);
                m[3] = new SqlParameter("@PhoneNumber", _Address.PhoneNumber);
                m[4] = new SqlParameter("@Email", _Address.Email);
                m[5] = new SqlParameter("@FaxNumber", _Address.FaxNumber);
                m[6] = new SqlParameter("@Company", _Address.Company);
                m[7] = new SqlParameter("@Address1", _Address.Address1);
                m[8] = new SqlParameter("@Address2", _Address.Address2);
                m[9] = new SqlParameter("@City", _Address.City);
                m[10] = new SqlParameter("@StateProvinceID", _Address.StateProvinceID);
                m[11] = new SqlParameter("@ZipPostalCode", _Address.ZipPostalCode);
                m[12] = new SqlParameter("@CountryID", _Address.CountryID);
                m[13] = new SqlParameter("@CreatedOn", _Address.CreatedOn);
                m[14] = new SqlParameter("@UserID", _Address.UserID);
                m[15] = new SqlParameter("@IsDefault", _Address.IsDefault);
                m[16] = new SqlParameter("@Custom1", _Address.Custom1);
                m[17] = new SqlParameter("@Custom2", _Address.Custom2);
                m[18] = new SqlParameter("@Custom3", _Address.Custom3);
                m[19] = new SqlParameter("@Custom4", _Address.Custom4);
                m[20] = new SqlParameter("@Custom5", _Address.Custom5);
                m[21] = new SqlParameter("@Type", _Address.Type);
                m[22] = new SqlParameter("@IsActive", _Address.IsActive);
                m[23] = new SqlParameter("@Facebook", _Address.Facebook == null ? "" : _Address.Facebook);
                m[24] = new SqlParameter("@Twitter", _Address.Twitter == null ? "" : _Address.Twitter);
                m[25] = new SqlParameter("@LinkedIn", _Address.LinkedIn == null ? "" : _Address.LinkedIn);
                m[26] = new SqlParameter("@Myspace", _Address.MySpace == null ? "" : _Address.MySpace);
                m[27] = new SqlParameter("@ShowMyName", _Address.ShowMyName == null ? false : _Address.ShowMyName);
                m[28] = new SqlParameter("@Custom6", _Address.Custom6 == null ? "" : _Address.Custom6);
                m[29] = new SqlParameter("@Custom7", _Address.Custom7 == null ? "" : _Address.Custom7);
                m[30] = new SqlParameter("@Custom8", _Address.Custom8 == null ? "" : _Address.Custom8);
                m[31] = new SqlParameter("@CompanyID", _Address.CompanyID);
                m[32] = new SqlParameter("@LocationID", _Address.LocationID);
                m[33] = new SqlParameter("@AddressID", SqlDbType.Int);
                m[33].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_Insert", m);
                object value = m[33].Value;
                return (int)value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateAddress(Address _Address)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[34];
                m[0] = new SqlParameter("@IsBillingAddress", _Address.IsBillingAddress);
                m[1] = new SqlParameter("@FirstName", _Address.FirstName);
                m[2] = new SqlParameter("@LastName", _Address.LastName);
                m[3] = new SqlParameter("@PhoneNumber", _Address.PhoneNumber);
                m[4] = new SqlParameter("@Email", _Address.Email);
                m[5] = new SqlParameter("@FaxNumber", _Address.FaxNumber);
                m[6] = new SqlParameter("@Company", _Address.Company);
                m[7] = new SqlParameter("@Address1", _Address.Address1);
                m[8] = new SqlParameter("@Address2", _Address.Address2);
                m[9] = new SqlParameter("@City", _Address.City);
                m[10] = new SqlParameter("@StateProvinceID", _Address.StateProvinceID);
                m[11] = new SqlParameter("@ZipPostalCode", _Address.ZipPostalCode);
                m[12] = new SqlParameter("@CountryID", _Address.CountryID);
                m[13] = new SqlParameter("@CreatedOn", _Address.CreatedOn);
                m[14] = new SqlParameter("@UserID", _Address.UserID);
                m[15] = new SqlParameter("@AddressID", _Address.AddressId);
                m[16] = new SqlParameter("@IsDefault", _Address.IsDefault);
                m[17] = new SqlParameter("@Custom1", _Address.Custom1);
                m[18] = new SqlParameter("@Custom2", _Address.Custom2);
                m[19] = new SqlParameter("@Custom3", _Address.Custom3);
                m[20] = new SqlParameter("@Custom4", _Address.Custom4);
                m[21] = new SqlParameter("@Custom5", _Address.Custom5);
                m[22] = new SqlParameter("@IsActive", _Address.IsActive);
                m[23] = new SqlParameter("@Facebook", _Address.Facebook == null ? "" : _Address.Facebook);
                m[24] = new SqlParameter("@Twitter", _Address.Twitter == null ? "" : _Address.Twitter);
                m[25] = new SqlParameter("@LinkedIn", _Address.LinkedIn == null ? "" : _Address.LinkedIn);
                m[26] = new SqlParameter("@MySpace", _Address.MySpace == null ? "" : _Address.MySpace);
                m[27] = new SqlParameter("@ShowMyName", _Address.ShowMyName == null ? false : _Address.ShowMyName);
                m[28] = new SqlParameter("@Custom6", _Address.Custom6 == null ? "" : _Address.Custom6);
                m[29] = new SqlParameter("@Custom7", _Address.Custom7 == null ? "" : _Address.Custom7);
                m[30] = new SqlParameter("@Custom8", _Address.Custom8 == null ? "" : _Address.Custom8);
                m[31] = new SqlParameter("@CompanyID", _Address.CompanyID);
                m[32] = new SqlParameter("@LocationID", _Address.LocationID);
                m[33] = new SqlParameter("@Type", _Address.Type == null ? 0 : _Address.Type);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_Update", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteAddress(int _AddressID)
        {
            try
            {
                SqlParameter[] m = new SqlParameter[2];
                m[0] = new SqlParameter("@AddressID", _AddressID);
                return SqlHelper.ExecuteNonQuery(Connection.Connection_string, CommandType.StoredProcedure, "LP_Address_Deleteing", m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<Address> MakeAddress(DataTable dt)
        {
            IList<Address> list = new List<Address>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeAddres(row));

            return list;
        }

        private Address MakeAddres(DataRow dr)
        {
            try
            {
                string _Address1 = Convert.ToString(dr["Address1"]);
                string _Address2 = Convert.ToString(dr["Address2"]);
                int _AddressID = Convert.ToInt32(dr["AddressID"]);
                string _City = Convert.ToString(dr["City"]);
                string _Company = Convert.ToString(dr["Company"]);
                int _CountryID = Convert.ToInt32(dr["CountryID"]);
                DateTime _CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                string _Email = Convert.ToString(dr["Email"]);
                string _FaxNumber = Convert.ToString(dr["FaxNumber"]);
                string _FirstName = Convert.ToString(dr["FirstName"]);
                bool _IsBillingAddress = Convert.ToBoolean(dr["IsBillingAddress"]);
                string _LastName = Convert.ToString(dr["LastName"]);
                string _PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                int _StateProvinceID = Convert.ToInt32(dr["StateProvinceID"]);
                string _UserID = Convert.ToString(dr["UserID"]);
                string _ZipPostalCode = Convert.ToString(dr["ZipPostalCode"]);
                string _Country = Convert.ToString(dr["Country"]);
                string _TwoLetterISOCode = Convert.ToString(dr["TwoLetterISOCode"]);
                string _StateProvince = Convert.ToString(dr["StateProvinceID"]);
                bool _IsDefault = Convert.ToBoolean(dr["isDefault"]);
                string _Custom1 = Convert.ToString(dr["Custom1"]);
                string _Custom2 = Convert.ToString(dr["Custom2"]);
                string _Custom3 = Convert.ToString(dr["Custom3"]);
                string _Custom4 = Convert.ToString(dr["Custom4"]);
                string _Custom5 = Convert.ToString(dr["Custom5"]);
                int _Type = Convert.ToInt32(dr["Type"]);
                bool _IsActive = Convert.ToBoolean(dr["IsActive"]);
                AddressType _AddressType = (AddressType)Enum.Parse(typeof(AddressType), Convert.ToString(_Type), true);
                string _Facebook = Convert.ToString(dr["Facebook"]);
                string _Twitter = Convert.ToString(dr["Twitter"]);
                string _LinkedIn = Convert.ToString(dr["LinkedIn"]);
                string _MySpace = Convert.ToString(dr["MySpace"]);
                bool _ShowMyName = false;

                try
                {
                    _ShowMyName = Convert.ToBoolean(dr["ShowMyName"]);
                }
                catch
                {

                }

                string _CompanyID = string.Empty;
                try
                {
                    _CompanyID = Convert.ToString(dr["CompanyID"]);
                }
                catch
                {

                }

                #region Temp Fields

                int _TotalRecord = 0;
                int _Pages = 0;
                try
                {
                    _TotalRecord = Convert.ToInt32(dr["TotalRecord"]);
                }
                catch
                {
                    _TotalRecord = 0;
                }

                try
                {
                    _Pages = Convert.ToInt32(dr["Pages"]);
                }
                catch
                {
                    _Pages = 0;
                }
                string _Longitude = string.Empty;
                try
                {
                    _Longitude = dr["Longitude"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Longitude"]);
                }
                catch
                {
                    _Longitude = string.Empty;
                }
                string _Latitude = string.Empty;
                try
                {
                    _Latitude = dr["Latitude"] == DBNull.Value ? "" : Convert.ToString(dr["Latitude"]);
                }
                catch
                {
                    _Latitude = string.Empty;
                }

                #endregion Temp Fields

                string _Custom6 = string.Empty;
                if (dr.Table.Columns.Contains("Custom6"))
                    _Custom6 = Convert.ToString(dr["Custom6"]);

                string _Custom7 = string.Empty;
                if (dr.Table.Columns.Contains("Custom7"))
                    _Custom7 = Convert.ToString(dr["Custom7"]);

                string _Custom8 = string.Empty;
                if (dr.Table.Columns.Contains("Custom8"))
                    _Custom8 = Convert.ToString(dr["Custom8"]);

                string _LocationID = Convert.ToString(dr["LocationID"]);

                return new Address(_AddressID, _IsBillingAddress, _FirstName, _LastName, _PhoneNumber, _Email, _FaxNumber, _Company, _Address1, _Address2, _City, _StateProvinceID, _ZipPostalCode, _CountryID, _CreatedOn, _UserID, _TwoLetterISOCode, _StateProvince, _Country, _IsDefault, _Custom1, _Custom2, _Custom3, _Custom4, _Custom5, _AddressType, _Pages, _TotalRecord, _Latitude, _Longitude, _IsActive, _Facebook, _Twitter, _LinkedIn, _MySpace, _ShowMyName, _CompanyID, _Custom6, _Custom7, _Custom8, _LocationID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}