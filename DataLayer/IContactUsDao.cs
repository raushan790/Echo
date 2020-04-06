using System;

namespace DataObjects
{
    public interface IContactUsDao
    {
        int CreateContactUs(BusinessObjects.ContactUs c);

        int CreateContactUs_Read(int _ID, bool _IsRead);

        System.Collections.Generic.IList<BusinessObjects.ContactUs> GetContactUs();

        System.Collections.Generic.IList<BusinessObjects.ContactUs> GetContactUs(DateTime _FromDate, DateTime _ToDate);

        BusinessObjects.ContactUs GetContact(int _ID);

        System.Collections.Generic.IList<BusinessObjects.ContactUs> GetContactUs(bool _IsRead);

        System.Collections.Generic.IList<BusinessObjects.ContactUs> GetContactUs(int _PageIndex, int _PageSize, string _SearchText, DateTime _FromDate, DateTime _ToDate, int _RoleID);

        System.Collections.Generic.IList<BusinessObjects.ContactUs> GetENewsLetter(int _PageIndex, int _PageSize, string _WhereClause);

        int DeleteContactUs(int _ContactUsID);
    }
}