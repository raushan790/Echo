using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects
{
    public interface IDeepLinking
    {
        int CreateDeepLinking(BusinessObjects.DeepLinking dl);
        int DeleteDeepLinking(string Url);
        BusinessObjects.DeepLinking GetDeepLinkingbyUrl(string _Url);
        BusinessObjects.DeepLinking GetDeepLinkingbyCreatedBy(string _CreatedBy);
        //System.Collections.Generic.IList<BusinessObjects.DeepLinking> GetDeepLinksingbyCreatedBy(string _CreatedBy);
        //System.Collections.Generic.IList<BusinessObjects.DeepLinking> GetDeepLinkingsbyUrl(string _Url);
    }
}
