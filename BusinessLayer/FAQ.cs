using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "FAQ", Namespace = "http://www.yourcompany.com/types/")]

    public class FAQ : BusinessObject
    {
        public FAQ()
        {
            AddRule(new ValidateId("FAQID"));
            Version = _versionDefault;
        }

        public FAQ(string _FAQID, string _FaqOption, string _Question, string _Answer, DateTime _Date, string _Custom1, string _Custom2, string _Custom3)
            : this()
        {
            FAQID = _FAQID;
            FaqOption = _FaqOption;
            Answer = _Answer;
            Question = _Question;
            Date = _Date;
            Custom1 = _Custom1; //Custom1 used as category
            Custom2 = _Custom2;
            Custom3 = _Custom3;
        }

        [DataMember]
        public string FAQID { get; set; }

        [DataMember]
        public string FaqOption { get; set; }

        [DataMember]
        public string Question { get; set; }

        [DataMember]
        public string Answer { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]

        public string Custom1 { get; set; }//Custom1 used as category

        [DataMember]
        public string Custom2 { get; set; }

        [DataMember]
        public string Custom3 { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}