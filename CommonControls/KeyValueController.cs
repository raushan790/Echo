using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Net;
using System.IO;
using BusinessObjects;
using DataObjects;

namespace Controllers
{
    [DataObject(true)]
    public class KeyValueController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<KeyValue> GetCastWiseDataForADate(DateTime Date,string Owner,int ClientID)
        {
            return DataAccess.KeyValueDao.GetCastWiseDataForADateForSchool(Date,Owner,ClientID);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<KeyValue> GetCastWiseDataForADate(DateTime Date,int ClientID)
        {
            return DataAccess.KeyValueDao.GetCastWiseDataForADate(Date,ClientID);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<KeyValue> GetTopFiveSchoolForADate(DateTime Date,int ClientID)
        {
            return DataAccess.KeyValueDao.GetTopFiveSchoolForADate(Date,ClientID);
        }

        public IList<KeyValue> GetBottomFiveSchoolForADate(DateTime Date,int ClientID)
        {
            return DataAccess.KeyValueDao.GetBottomFiveSchoolForADate(Date,ClientID);
        }


    }
}
