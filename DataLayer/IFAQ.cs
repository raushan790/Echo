using System.Collections.Generic;

namespace DataObjects
{
    public interface IFAQ
    {
        int CreateFAQ(BusinessObjects.FAQ faq);

        int DeleteFAQ(string _FAQID);

        int UpdateFAQ(BusinessObjects.FAQ faq);

        IList<BusinessObjects.FAQ> GetFAQ();

        BusinessObjects.FAQ GetFAQ(string _FAQID);
    }
}