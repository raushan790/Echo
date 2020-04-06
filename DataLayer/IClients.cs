using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public interface IClientsDao
    {
        int CreateClient(BusinessObjects.Clients c);
        BusinessObjects.Clients GetClient(int _ClientID);
        BusinessObjects.Clients GetClientbyEmail(string _Email);
        BusinessObjects.Clients GetClientbyMobile(string _Mobile);
        BusinessObjects.Clients GetClientbyCreateDate(DateTime _CreateDate);
        System.Collections.Generic.List<BusinessObjects.Clients> GetClients();
        System.Collections.Generic.IList<BusinessObjects.Clients> GetClients(int ClientID);
        int UpdateClient(BusinessObjects.Clients c);
        int DeleteClients(int _ID);
    }
}
