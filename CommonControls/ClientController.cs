using BusinessObjects;
using Controllers;
using DataObjects;
using System.ComponentModel;

namespace Controllers
{
    [DataObject(true)]
    public class ClientController : ControllerBase
    {
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int CreateNewClient(Clients _NewClient)
        {
            return DataAccess.ClientsDao.CreateClient(_NewClient);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateClient(Clients _Client)
        {
            return DataAccess.ClientsDao.UpdateClient(_Client);
        }
    }
}
