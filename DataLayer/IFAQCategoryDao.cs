using System.Collections.Generic;
using BusinessObjects;

namespace DataObjects
{
    public interface IFQACategoryDao
    {
        IList<FAQCategory> GetFAQCategories();

        FAQCategory GetFAQCategories(int _FAQID);

        int CreateFAQCategory(FAQCategory _FAQCategory);

        string UpdateFAQCategory(FAQCategory _FAQCategory);

        int DeleteCategory(FAQCategory _FAQCategory);
    }
}