using System.Collections.Generic;
using BusinessObjects;

namespace DataObjects
{
    public interface IAddressDao
    {
        IList<Address> GetAddressList(bool _IsBillingAddress, string _UserID);

        IList<Address> GetAddressSearch(string SearchString, AddressType _AddressType);

        IList<Address> GetAddressList(string _UserID, AddressType _AddressType);

        IList<Address> GetAddressList(bool _IsBillingAddress, bool _IsDefault, string _UserID);

        IList<Address> GetAddressList(bool _IsBillingAddress, string _UserID, string _SortExpression);

        IList<Address> GetAddressSearch(int _PageIndex, int _PageSize, string _SearchString, AddressType _AddressType);

        Address GetAddress(int _AddressID);

        int CreateAddresss(Address _Address);

        int UpdateAddress(Address _Address);

        int DeleteAddress(int _AddressID);
    }
}