using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "FAQCategory", Namespace = "http://www.yourcompany.com/types/")]

    public class FAQCategory : BusinessObject
    {
        public FAQCategory()
        {
            AddRule(new ValidateId("FAQID"));
            AddRule(new ValidateId("FAQCategoryName"));
            AddRule(new ValidateRequired("FAQDisaplayOrder"));
            AddRule(new ValidateRequired("FAQAddedDate"));
            Version = _versionDefault;
        }

        public FAQCategory(int _FAQID, string _FAQCategoryName, int _FAQDisaplayOrder, DateTime _FAQAddedDate,
          string _Custome1, string _Custome2)
        {
            FAQID = _FAQID;
            FAQCategoryName = _FAQCategoryName;
            FAQDisaplayOrder = _FAQDisaplayOrder;
            FAQAddedDate = _FAQAddedDate;
            Custome1 = _Custome1;
            Custome2 = _Custome2;
        }

        [DataMember]
        public int FAQID { get; set; }

        [DataMember]
        public string FAQCategoryName { get; set; }

        [DataMember]
        public int FAQDisaplayOrder { get; set; }

        [DataMember]
        public DateTime FAQAddedDate { get; set; }

        [DataMember]
        public string Custome1 { get; set; }

        [DataMember]
        public string Custome2 { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}