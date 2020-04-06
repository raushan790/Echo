using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "Coupon", Namespace = "http://www.yourcompany.com/types/")]
    public class Coupon : BusinessObject
    {
        public Coupon()
        {
            AddRule(new ValidateId("Coupon_ID"));
            AddRule(new ValidateLength("Coupon_Code", 0, 100));
            AddRule(new ValidateRequired("Coupon_Type"));
            AddRule(new ValidateRequired("Coupon_Code"));
            Version = _versionDefault;
        }

        public Coupon(int _Coupon_ID, int _Coupon_Type, string _Coupon_Code, DateTime _StartDate, DateTime _EndDate, DateTime _EntryDate,
           decimal _Amount, bool _IsActive, bool _IsUsed, bool _IsPercentage, string _CustomCoupon, int _MaxReUseCount, int _UseCount,
            string _Custom1, string _Custom2, string _Custom3, string _Custom4, string _Custom5, int _TotalRecord)
        {
            Coupon_ID = _Coupon_ID;
            Coupon_Type = _Coupon_Type;
            Coupon_Code = _Coupon_Code;
            Start_date = _StartDate;
            End_Date = _EndDate;
            Entry_Date = _EntryDate;
            Amount = _Amount;
            IsActive = _IsActive;
            IsUsed = _IsUsed;
            IsPercentage = _IsPercentage;
            CustomCoupon = _CustomCoupon;
            MaxReUseCount = _MaxReUseCount;
            UseCount = _UseCount;
            Custom1 = _Custom1;
            Custom2 = _Custom2;
            Custom3 = _Custom3;
            Custom4 = _Custom4;
            Custom5 = _Custom5;
            TotalRecord = _TotalRecord;
        }

        [DataMember]
        public int Coupon_ID { get; set; }

        [DataMember]
        public int Coupon_Type { get; set; }

        [DataMember]
        public string Coupon_Code { get; set; }

        [DataMember]
        public DateTime Start_date { get; set; }

        [DataMember]
        public DateTime End_Date { get; set; }

        [DataMember]
        public DateTime Entry_Date { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsUsed { get; set; }

        [DataMember]
        public bool IsPercentage { get; set; }

        [DataMember]
        public string CustomCoupon { get; set; }

        [DataMember]
        public int MaxReUseCount { get; set; }

        [DataMember]
        public int UseCount { get; set; }

        [DataMember]
        public string Custom1 { get; set; }

        [DataMember]
        public string Custom2 { get; set; }

        [DataMember]
        public string Custom3 { get; set; }

        [DataMember]
        public string Custom4 { get; set; }

        [DataMember]
        public string Custom5 { get; set; }

        [DataMember]
        public int TotalRecord { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}