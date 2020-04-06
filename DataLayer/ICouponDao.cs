using System;

namespace DataObjects
{
    public interface ICouponDao
    {
        string UpdateCoupon(BusinessObjects.Coupon c);

        int CreateCoupon(BusinessObjects.Coupon c);

        int DeleteCoupon(int _Coupon_ID);

        BusinessObjects.Coupon GetCoupon(int _Coupon_ID);

        BusinessObjects.Coupon GetCoupon(String _CouponCode);

        System.Collections.Generic.IList<BusinessObjects.Coupon> GetCoupons(int _PageIndex, int _PageSize, string _WhereClause, bool _IsUsed);

        System.Collections.Generic.IList<BusinessObjects.Coupon> GetCoupons(bool _IsUsed, int _Coupon_Type);

        System.Collections.Generic.IList<BusinessObjects.Coupon> GetCoupons(bool _IsUsed, string _SortExpression);

        System.Collections.Generic.IList<BusinessObjects.Coupon> GetCouponsIsActive(bool _IsActive, string _SortExpression);

        System.Collections.Generic.IList<BusinessObjects.Coupon> GetCouponsIsActive(bool _IsActive);

        System.Collections.Generic.IList<BusinessObjects.Coupon> GetCouponsIsActive(bool _IsActive, int _Coupon_Type);

        int SetCouponIsActive(int _Coupon_ID, bool _IsActive);

        int UpdateUseCount(string _Coupon_Code);

        int SetCouponIsUsed(int _Coupon_ID, bool _IsUsed);

        bool Check_Coupon(string _Coupon_Code);
    }
}