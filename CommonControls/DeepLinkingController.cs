using BusinessObjects;
using Controllers;
using DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonControls
{
   public class DeepLinkingController : ControllerBase
    {
        [DataObject(true)]
        public class ClientController : ControllerBase
        {
            [DataObjectMethod(DataObjectMethodType.Insert)]
            public int CreateDeepLinking(DeepLinking _NewLink)
            {
                return DataAccess.DeepLinkingDao.CreateDeepLinking(_NewLink);
            }
            [DataObjectMethod(DataObjectMethodType.Delete)]
            public int DeleteDeepLinking(string Url)
            {
                return DataAccess.DeepLinkingDao.DeleteDeepLinking(Url);
            }
            [DataObjectMethod(DataObjectMethodType.Select)]
            public DeepLinking GetDeepLinkingByUrl(string _Url)
            {
                return DataAccess.DeepLinkingDao.GetDeepLinkingbyUrl(_Url);
            }
            [DataObjectMethod(DataObjectMethodType.Select)]
            public DeepLinking GetDeepLinkingByCreatedBy(string _CreatedBy)
            {
                return DataAccess.DeepLinkingDao.GetDeepLinkingbyCreatedBy(_CreatedBy);
            }
        }
    }
}
