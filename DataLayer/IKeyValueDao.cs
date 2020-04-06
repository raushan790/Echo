using System;
namespace DataObjects
{
    public interface IKeyValueDao
    {
        System.Collections.Generic.IList<BusinessObjects.KeyValue> GetCastWiseDataForADateForSchool(DateTime date,string Owner,int ClientID);
        System.Collections.Generic.IList<BusinessObjects.KeyValue> GetCastWiseDataForADate(DateTime date,int ClientID);
        System.Collections.Generic.IList<BusinessObjects.KeyValue>GetTopFiveSchoolForADate(DateTime date,int ClientID);
        System.Collections.Generic.IList<BusinessObjects.KeyValue> GetBottomFiveSchoolForADate(DateTime date,int ClientID);

    }
}