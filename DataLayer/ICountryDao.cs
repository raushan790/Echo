namespace DataObjects
{
    public interface ICountryDao
    {
        System.Collections.Generic.IList<BusinessObjects.Country> GetCountrys(bool _ShowAll);

        BusinessObjects.Country GetCountry(int _CountryID);

        System.Collections.Generic.IList<BusinessObjects.Country> GetStoreCountrys();
    }
}