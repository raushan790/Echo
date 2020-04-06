using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
//using CommonControls.ActionServiceReference;
using System.Runtime.InteropServices;
using DataObjects;
using BusinessObjects;
using ShippingManager;
using Cart;


namespace Controllers
{
    [DataObject(true)]
    public class CartController : ControllerBase
    {
        private string SessionName = "__MyVirtualCart__";
        private string GenCountryCode = "US";
        public CartController()
        {





        }

        public ShoppingCart Current
        {
            get
            {
                ShoppingCart session =
                  (ShoppingCart)HttpContext.Current.Session[SessionName];
                if (session == null)
                {
                    session = new ShoppingCart();
                    HttpContext.Current.Session[SessionName] = session;
                }
                return session;
            }
        }

        public bool New(string CountryCode)
        {
            try
            {
                ShoppingCart iCart = Current;
                iCart.CountryCode = CountryCode;
                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool New()
        {
            try
            {
                ShoppingCart iCart = Current;
                iCart.CountryCode = GenCountryCode;
                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Add(ShoppingCartItem _CartItem)
        {
            try
            {
                ShoppingCart iCart = Current;
                iCart.AddItem(_CartItem);
                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateQuantity(int id, int quantity, string _Size)
        {
            try
            {
                ShoppingCart iCart = Current;
                iCart.UpdateQuantity(id, quantity, _Size);
                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateQuantity(int id, int quantity, string _Size, string _SKU, int _ProductVariantId)
        {
            try
            {
                ShoppingCart iCart = Current;
                iCart.UpdateQuantity(id, quantity, _Size, _SKU, _ProductVariantId);
                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateQuantity(int id, int quantity, string _Size, string _SKU, int _VariantId, double _UnitPrice, IList<CustomCartItem> _CustomCart)
        {
            try
            {
                ShoppingCart iCart = Current;
                iCart.UpdateQuantity(id, quantity, _Size, _SKU, _VariantId, _UnitPrice, _CustomCart);
                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool UpdateQuantity(int id, int quantity, string _Size, string _SKU, int _VariantId, double _UnitPrice, IList<CustomCartItem> _CustomCart,
            bool IsCustomSize, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6)
        {
            try
            {
                ShoppingCart iCart = Current;
                iCart.UpdateQuantity(id, quantity, _Size, _SKU, _VariantId, _UnitPrice, _CustomCart, IsCustomSize, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6);
                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool SetFinal(string _ShippingMethodName, string _ShipToZip, double shipping, string _Coupon, double _CouponValue, double _TotalTax)
        {
            try
            {
                ShoppingCart iCart = Current;

                iCart.ShippingMethodName = _ShippingMethodName;
                iCart.ShipToZip = _ShipToZip;
                iCart.ShippingCharge = shipping;
                iCart.Coupon = _Coupon;
                iCart.CouponValue = _CouponValue;
                iCart.TotalTax = _TotalTax;
                HttpContext.Current.Session[SessionName] = iCart;
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetFinal(string _ShippingMethodName, string _ShipToZip, double shipping, string _Coupon, double _CouponValue, double _TotalTax, double _TotalDiscount)
        {
            try
            {

                ShoppingCart iCart = Current;

                iCart.ShippingMethodName = _ShippingMethodName;
                iCart.ShipToZip = _ShipToZip;
                iCart.ShippingCharge = shipping;
                iCart.Coupon = _Coupon;
                iCart.CouponValue = _CouponValue;
                iCart.TotalTax = _TotalTax;
                iCart.TotalDiscount = _TotalDiscount;
                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveItem(int _id)
        {
            try
            {

                ShoppingCart iCart = Current;

                if (iCart.Items == null)
                    return false;

                iCart.RemoveItem(_id);
            

                HttpContext.Current.Session[SessionName] = iCart;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CartController(string _ShipToZipCode)
        {
            ShipToZipCode = _ShipToZipCode;
            CountryTwoLetterCode = "US";
        }

        /// <summary>
        /// Gets the user's cart.
        /// </summary>
        /// <returns>Shopping cart.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public ShoppingCart GetCart()
        {
            try
            {

                ShoppingCart cart = new ShoppingCart();

                return cart;
                 
                /*CartRequest request = new CartRequest();
                request.RequestId = NewRequestId;
                request.AccessToken = AccessToken;
                request.ClientTag = ClientTag;

                request.CartAction = CartAction.Read;// .Action = "Read";

                CartResponse response = ActionServiceClient.GetCart(request);

                if (response.IsError)
                    throw new Exception(response.ErrorMessage);

                if (request.RequestId != response.CorrelationId)
                    throw new ApplicationException("GetCart: Request and CorrelationId do not match.");

                return response.Cart;*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Adds an item to the shopping cart.
        /// </summary>
        /// <param name="productId">Unique product identifier or item.</param>
        /// <param name="name">Item name.</param>
        /// <param name="quantity">Quantity of items.</param>
        /// <param name="unitPrice">Unit price for each item.</param>
        /// <returns>Updated shopping cart.</returns>
        public ShoppingCart AddItem(int productId, string name,
                int quantity, double unitPrice, decimal productheight, decimal productlength, decimal prodictweight,
                decimal productwidth, string shipto, int shiptoid, Address _ShippingAddress,
                decimal _Discount_Percentage, decimal _DiscountValue, int _ProductID, int _ProductVariantId,
                decimal _ShippingCost, decimal _Tax_Percentage, decimal _TaxValue, int _UnitType, string _Image, string _Description, string _Size, string _SKU,
                string _ItemType,int _TaxID)
                {
                    try
                    {


                        return null;

                        /*IList<CustomCartItem> cItem = new List<CustomCartItem>();
                        CartRequest request = new CartRequest();
                        request.RequestId = NewRequestId;
                        request.AccessToken = AccessToken;
                        request.ClientTag = ClientTag;

                        request.CartAction = CartAction.Create;// .Action = "Create";
                        request.CartItem =
                            new ShoppingCartItem
                            {
                                Id = productId,
                                Name = name,
                                Quantity = quantity,
                                UnitPrice = unitPrice,
                                ProductHeight = productheight,
                                ProductLength = productlength,
                                ProductWidth = productwidth,
                                ShipTo = shipto,
                                ShipToId = shiptoid,
                                ProdictWeight = prodictweight,
                                ShippingAddress = _ShippingAddress,
                                Discount_Percentage = _Discount_Percentage,
                                DiscountValue = _DiscountValue,
                                ProductID = _ProductID,
                                ProductVariantId = _ProductVariantId,
                                ShippingCost = _ShippingCost,
                                Tax_Percentage = _Tax_Percentage,
                                TaxValue = _TaxValue,
                                UnitType = _UnitType,
                                isCustom = false,
                                Custom_IsDouble = false,
                                Size = _Size,
                                Custom_Strap = "",
                                LeftCustomItem = null,
                                RightCustomItem = null,
                                Image = _Image,
                                Description = _Description,
                                CItems = cItem.ToArray(),
                                Image2 = "",
                                FreeShipping = false,
                                SKU = _SKU,
                                ItemType = _ItemType,
                                TaxID = _TaxID
                            };


                        request.ShippingAddress = _ShippingAddress;
                        request.ShipToZip = ShipToZipCode;

                        CartResponse response = ActionServiceClient.SetCart(request);

                        if (response.IsError)
                            throw new Exception(response.ErrorMessage);



                        if (request.RequestId != response.CorrelationId)
                            throw new ApplicationException("AddItem: Request and CorrelationId do not match.");

                        return response.Cart;
                        */
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

        public ShoppingCart AddItem(int productId, string name,
                int quantity, double unitPrice, decimal productheight, decimal productlength, decimal prodictweight,
                decimal productwidth, string shipto, int shiptoid, Address _ShippingAddress,
                decimal _Discount_Percentage, decimal _DiscountValue, int _ProductID, int _ProductVariantId,
                decimal _ShippingCost, decimal _Tax_Percentage, decimal _TaxValue, int _UnitType, string _Image, string _Description, string _Size, string _SKU,
                string _ItemType, string _CustomField1, string _CustomField2, string _CustomField3, string _CustomField4, string _CustomField5)
            {
                try
                {
                    return null;
                    
                    /* IList<CustomItem> cItem = new List<CustomItem>();
                    CartRequest request = new CartRequest();
                    request.RequestId = NewRequestId;
                    request.AccessToken = AccessToken;
                    request.ClientTag = ClientTag;

                    request.CartAction = CartAction.Create;// .Action = "Create";
                    request.CartItem =
                        new ShoppingCartItem
                        {
                            Id = productId,
                            Name = name,
                            Quantity = quantity,
                            UnitPrice = unitPrice,
                            ProductHeight = productheight,
                            ProductLength = productlength,
                            ProductWidth = productwidth,
                            ShipTo = shipto,
                            ShipToId = shiptoid,
                            ProdictWeight = prodictweight,
                            ShippingAddress = _ShippingAddress,
                            Discount_Percentage = _Discount_Percentage,
                            DiscountValue = _DiscountValue,
                            ProductID = _ProductID,
                            ProductVariantId = _ProductVariantId,
                            ShippingCost = _ShippingCost,
                            Tax_Percentage = _Tax_Percentage,
                            TaxValue = _TaxValue,
                            UnitType = _UnitType,
                            isCustom = false,
                            Custom_IsDouble = false,
                            Size = _Size,
                            Custom_Strap = "",
                            LeftCustomItem = null,
                            RightCustomItem = null,
                            Image = _Image,
                            Description = _Description,
                            CItems = cItem.ToArray(),
                            Image2 = "",
                            FreeShipping = false,
                            SKU = _SKU,
                            ItemType = _ItemType,
                            CustomField1 = _CustomField1,
                            CustomField2 = _CustomField2,
                            CustomField3 = _CustomField3,
                            CustomField4 = _CustomField4,
                            CustomField5 = _CustomField5
                        };


                    request.ShippingAddress = _ShippingAddress;
                    request.ShipToZip = ShipToZipCode;

                    CartResponse response = ActionServiceClient.SetCart(request);

                    if (response.IsError)
                        throw new Exception(response.ErrorMessage);



                    if (request.RequestId != response.CorrelationId)
                        throw new ApplicationException("AddItem: Request and CorrelationId do not match.");

                    return response.Cart;*/
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        /// <summary>
        /// Add Cart Item With Custom Products
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="productheight"></param>
        /// <param name="productlength"></param>
        /// <param name="prodictweight"></param>
        /// <param name="productwidth"></param>
        /// <param name="shipto"></param>
        /// <param name="shiptoid"></param>
        /// <param name="_ShippingAddress"></param>
        /// <param name="_Discount_Percentage"></param>
        /// <param name="_DiscountValue"></param>
        /// <param name="_ProductID"></param>
        /// <param name="_ProductVariantId"></param>
        /// <param name="_ShippingCost"></param>
        /// <param name="_Tax_Percentage"></param>
        /// <param name="_TaxValue"></param>
        /// <param name="_UnitType"></param>
        /// <param name="_isCustom"></param>
        /// <param name="_Custom_Size"></param>
        /// <param name="_Custom_Strap"></param>
        /// <param name="_Custom_IsDouble"></param>
        /// <param name="_CustomItem"></param>
        /// <returns></returns>
        public ShoppingCart AddItem(int productId, string name,
                int quantity, double unitPrice, decimal productheight, decimal productlength, decimal prodictweight,
                decimal productwidth, string shipto, int shiptoid, Address _ShippingAddress,
                decimal _Discount_Percentage, decimal _DiscountValue, int _ProductID, int _ProductVariantId,
                decimal _ShippingCost, decimal _Tax_Percentage, decimal _TaxValue, int _UnitType,
                bool _isCustom, string _Size, string _Custom_Strap, bool _Custom_IsDouble,
                string _Image, string _Image2, string _Description, decimal _Custom_Embroidery, IList<CustomCartItem> _CItem, string _SKU, string _ItemType)
                {
                    try
                    {

                        return null;

                       /* CartRequest request = new CartRequest();
                        request.RequestId = NewRequestId;
                        request.AccessToken = AccessToken;
                        request.ClientTag = ClientTag;

                        request.CartAction = CartAction.Create;// .Action = "Create";

                        request.CartItem =
                            new ShoppingCartItem
                            {
                                Id = productId,
                                Name = name,
                                Quantity = quantity,
                                UnitPrice = unitPrice,
                                ProductHeight = productheight,
                                ProductLength = productlength,
                                ProductWidth = productwidth,
                                ShipTo = shipto,
                                ShipToId = shiptoid,
                                ProdictWeight = prodictweight,
                                ShippingAddress = _ShippingAddress,
                                Discount_Percentage = _Discount_Percentage,
                                DiscountValue = _DiscountValue,
                                ProductID = _ProductID,
                                ProductVariantId = _ProductVariantId,
                                ShippingCost = _ShippingCost,
                                Tax_Percentage = _Tax_Percentage,
                                TaxValue = _TaxValue,
                                UnitType = _UnitType,
                                isCustom = _isCustom == null ? false : _isCustom,
                                Custom_IsDouble = _Custom_IsDouble == null ? false : _Custom_IsDouble,
                                Size = _Size == null ? "" : _Size,
                                Custom_Strap = _Custom_Strap == string.Empty ? "" : _Custom_Strap,
                                Image = _Image,
                                Description = _Description,
                                Custom_Embroidery = _Custom_Embroidery,
                                CItems = _CItem.ToArray(),
                                Image2 = _Image2,
                                FreeShipping = false,
                                SKU = _SKU,
                                ItemType = _ItemType
                            };


                        request.ShippingAddress = _ShippingAddress;

                        request.ShipToZip = ShipToZipCode;

                        CartResponse response = ActionServiceClient.SetCart(request);

                        if (response.IsError)
                            throw new Exception(response.ErrorMessage);



                        if (request.RequestId != response.CorrelationId)
                            throw new ApplicationException("AddItem: Request and CorrelationId do not match.");

                        return response.Cart;*/
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }


        public ShoppingCart AddItem(int productId, string name,
               int quantity, double unitPrice, decimal productheight, decimal productlength, decimal prodictweight,
               decimal productwidth, string shipto, int shiptoid, Address _ShippingAddress,
               decimal _Discount_Percentage, decimal _DiscountValue, int _ProductID, int _ProductVariantId,
               decimal _ShippingCost, decimal _Tax_Percentage, decimal _TaxValue, int _UnitType,
               bool _isCustom, string _Size, string _Custom_Strap, bool _Custom_IsDouble,
               string _Image, string _Image2, string _Description, decimal _Custom_Embroidery, IList<CustomCartItem> _CItem, string _SKU, string _ItemType,
               bool IsCustomSize, string CustomField1, string CustomField2, string CustomField3, string CustomField4, string CustomField5, string CustomField6)
            {
                try
                {
                    return null;

                   /* CartRequest request = new CartRequest();
                    request.RequestId = NewRequestId;
                    request.AccessToken = AccessToken;
                    request.ClientTag = ClientTag;

                    request.CartAction = CartAction.Create;// .Action = "Create";

                    request.CartItem =
                        new ShoppingCartItem
                        {
                            Id = productId,
                            Name = name,
                            Quantity = quantity,
                            UnitPrice = unitPrice,
                            ProductHeight = productheight,
                            ProductLength = productlength,
                            ProductWidth = productwidth,
                            ShipTo = shipto,
                            ShipToId = shiptoid,
                            ProdictWeight = prodictweight,
                            ShippingAddress = _ShippingAddress,
                            Discount_Percentage = _Discount_Percentage,
                            DiscountValue = _DiscountValue,
                            ProductID = _ProductID,
                            ProductVariantId = _ProductVariantId,
                            ShippingCost = _ShippingCost,
                            Tax_Percentage = _Tax_Percentage,
                            TaxValue = _TaxValue,
                            UnitType = _UnitType,
                            isCustom = _isCustom == null ? false : _isCustom,
                            Custom_IsDouble = _Custom_IsDouble == null ? false : _Custom_IsDouble,
                            Size = _Size == null ? "" : _Size,
                            Custom_Strap = _Custom_Strap == string.Empty ? "" : _Custom_Strap,
                            Image = _Image,
                            Description = _Description,
                            Custom_Embroidery = _Custom_Embroidery,
                            CItems = _CItem.ToArray(),
                            Image2 = _Image2,
                            FreeShipping = false,
                            SKU = _SKU,
                            ItemType = _ItemType,
                            CustomSize = IsCustomSize,
                            CustomField1 = CustomField1,
                            CustomField2 = CustomField2,
                            CustomField3 = CustomField3,
                            CustomField4 = CustomField4,
                            CustomField5 = CustomField5,
                            CustomField6 = CustomField6
                        };


                    request.ShippingAddress = _ShippingAddress;

                    request.ShipToZip = ShipToZipCode;

                    CartResponse response = ActionServiceClient.SetCart(request);

                    if (response.IsError)
                        throw new Exception(response.ErrorMessage);



                    if (request.RequestId != response.CorrelationId)
                        throw new ApplicationException("AddItem: Request and CorrelationId do not match.");

                    return response.Cart;*/
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }


        //public ShoppingCart SetFinal(string _ShippingMethodName, string _ShipToZip, double shipping, string _Coupon, double _CouponValue, double _TotalTax)
        //{
        //    try
        //    {

        //        return null;
        //       /*CartRequest request = new CartRequest();
        //        request.RequestId = NewRequestId;
        //        request.AccessToken = AccessToken;
        //        request.ClientTag = ClientTag;
        //        request.CartAction = CartAction.SetFinal;// .Action = "SetFinal";

        //        request.ShippingMethodName = _ShippingMethodName;
        //        request.ShipToZip = _ShipToZip;
        //        request.Shipping = shipping;
        //        request.CouponValue = _CouponValue;
        //        request.Coupon = _Coupon;
        //        request.TotalTax = _TotalTax;
        //        request.TotalDiscount = 0;

        //        CartResponse response = ActionServiceClient.SetCart(request);

        //        if (response.IsError)
        //            throw new Exception(response.ErrorMessage);

        //        if (request.RequestId != response.CorrelationId)
        //            throw new ApplicationException("RemoveItem: Request and CorrelationId do not match.");

        //        return response.Cart;*/
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //public ShoppingCart SetFinal(string _ShippingMethodName, string _ShipToZip, double shipping, string _Coupon, double _CouponValue, double _TotalTax, double _TotalDiscount)
        //{
        //    try
        //    {

        //        return null;

        //       /* CartRequest request = new CartRequest();
        //        request.RequestId = NewRequestId;
        //        request.AccessToken = AccessToken;
        //        request.ClientTag = ClientTag;
        //        request.CartAction = CartAction.SetFinal;// .Action = "SetFinal";

        //        request.ShippingMethodName = _ShippingMethodName;
        //        request.ShipToZip = _ShipToZip;
        //        request.Shipping = shipping;
        //        request.CouponValue = _CouponValue;
        //        request.Coupon = _Coupon;
        //        request.TotalDiscount = _TotalDiscount;
        //        request.TotalTax = _TotalTax;

        //        CartResponse response = ActionServiceClient.SetCart(request);

        //        if (response.IsError)
        //            throw new Exception(response.ErrorMessage);

        //        if (request.RequestId != response.CorrelationId)
        //            throw new ApplicationException("RemoveItem: Request and CorrelationId do not match.");

        //        return response.Cart;*/
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        ///// <summary>
        ///// Removes a line item from the shopping cart.
        ///// </summary>
        ///// <param name="productId">The item to be removed.</param>
        ///// <returns>Updated shopping cart.</returns>
        //public ShoppingCart RemoveItem(int productId)
        //{
        //    try
        //    {


        //        return null;

        //       /* CartRequest request = new CartRequest();
        //        request.RequestId = NewRequestId;
        //        request.AccessToken = AccessToken;
        //        request.ClientTag = ClientTag;

        //        request.CartAction = CartAction.Delete;// .Action = "Delete";
        //        request.CartItem = new ShoppingCartItem { Id = productId };

        //        CartResponse response = ActionServiceClient.SetCart(request);

        //        if (response.IsError)
        //            throw new Exception(response.ErrorMessage);

        //        if (request.RequestId != response.CorrelationId)
        //            throw new ApplicationException("RemoveItem: Request and CorrelationId do not match.");

        //        return response.Cart;*/
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public bool EmptyCart()
        {
            try
            {
                return true;

                /*CartRequest request = new CartRequest();
                request.RequestId = NewRequestId;
                request.AccessToken = AccessToken;
                request.ClientTag = ClientTag;

                request.CartAction = CartAction.EmptyCart;// .Action = "EmptyCart";

                CartResponse response = ActionServiceClient.SetCart(request);

                if (response.IsError)
                    throw new Exception(response.ErrorMessage);

                if (request.RequestId != response.CorrelationId)
                    throw new ApplicationException("RemoveItem: Request and CorrelationId do not match.");

                return response.IsError;*/
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Updates a line item in the shopping cart with a new quantity.
        /// </summary>
        /// <param name="productId">Unique product line item.</param>
        /// <param name="quantity">New quantity.</param>
        /// <returns>Updated shopping cart.</returns>
        //public ShoppingCart UpdateQuantity(int productId, int quantity, string _Size)
        //{
        //    try
        //    {

        //        return null;

        //        /*CartRequest request = new CartRequest();
        //        request.RequestId = NewRequestId;
        //        request.AccessToken = AccessToken;
        //        request.ClientTag = ClientTag;

        //        request.CartAction = CartAction.Update;
        //        request.CartItem = new ShoppingCartItem { Id = productId, Quantity = quantity, Size = _Size };

        //        request.ShipToZip = ShipToZipCode;


        //        CartResponse response = ActionServiceClient.SetCart(request);

        //        if (response.IsError)
        //            throw new Exception(response.ErrorMessage);

        //        if (request.RequestId != response.CorrelationId)
        //            throw new ApplicationException("UpdateItem: Request and CorrelationId do not match.");

        //        return response.Cart;*/
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public ShoppingCart UpdateQuantity(int productId, int quantity, string _Size, string _SKU, int _ProductVariantId)
        //{
        //    try
        //    {

        //        return null;

        //       /* CartRequest request = new CartRequest();
        //        request.RequestId = NewRequestId;
        //        request.AccessToken = AccessToken;
        //        request.ClientTag = ClientTag;

        //        request.CartAction = CartAction.Update_Sku;
        //        request.CartItem = new ShoppingCartItem { Id = productId, Quantity = quantity, Size = _Size, SKU = _SKU, ProductVariantId = _ProductVariantId };

        //        request.ShipToZip = ShipToZipCode;


        //        CartResponse response = ActionServiceClient.SetCart(request);

        //        if (response.IsError)
        //            throw new Exception(response.ErrorMessage);

        //        if (request.RequestId != response.CorrelationId)
        //            throw new ApplicationException("UpdateItem: Request and CorrelationId do not match.");

        //        return response.Cart;*/
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public ShoppingCart UpdateQuantity(int productId, int quantity, string _Size, string _SKU, int _VariantId, double _UnitPrice, IList<CustomCartItem> _CItem)
        //{
        //    try
        //    {

        //        return null;

        //       /* CartRequest request = new CartRequest();
        //        request.RequestId = NewRequestId;
        //        request.AccessToken = AccessToken;
        //        request.ClientTag = ClientTag;

        //        request.CartAction = CartAction.Update_CustomItem;
        //        request.CartItem = new ShoppingCartItem
        //        {
        //            Id = productId,
        //            Quantity = quantity,
        //            Size = _Size,
        //            SKU = _SKU,
        //            ProductVariantId = _VariantId,
        //            UnitPrice = _UnitPrice,
        //            CItems = _CItem.ToArray()
        //        };

        //        request.ShipToZip = ShipToZipCode;


        //        CartResponse response = ActionServiceClient.SetCart(request);

        //        if (response.IsError)
        //            throw new Exception(response.ErrorMessage);

        //        if (request.RequestId != response.CorrelationId)
        //            throw new ApplicationException("UpdateItem: Request and CorrelationId do not match.");

        //        return response.Cart;*/
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
       
        //public ShoppingCart UpdateQuantity(int productId, int quantity, string _Size, string _SKU, int
        //    _VariantId, double _UnitPrice, IList<CustomCartItem> _CItem,
        //    [Optional]bool IsCustomSize, [Optional]string CustomField1, [Optional]string CustomField2, [Optional]string CustomField3, [Optional]string CustomField4, [Optional]string CustomField5, [Optional]string CustomField6)
        //{
        //    try
        //    {
        //        return null;

        //       /* CartRequest request = new CartRequest();
        //        request.RequestId = NewRequestId;
        //        request.AccessToken = AccessToken;
        //        request.ClientTag = ClientTag;

        //        request.CartAction = CartAction.Update_CustomItem;
        //        request.CartItem = new ShoppingCartItem();
        //        request.CartItem.Id = productId;
        //        request.CartItem.Quantity = quantity;
        //        request.CartItem.Size = _Size;
        //        request.CartItem.ProductVariantId = _VariantId;
        //        request.CartItem.UnitPrice = _UnitPrice;
        //        request.CartItem.CItems = _CItem.ToArray();

        //        request.CartItem.CustomSize = IsCustomSize;
        //        request.CartItem.CustomField1 = CustomField1;
        //        request.CartItem.CustomField2 = CustomField2;
        //        request.CartItem.CustomField3 = CustomField3;
        //        request.CartItem.CustomField4 = CustomField4;
        //        request.CartItem.CustomField5 = CustomField5;
        //        request.CartItem.CustomField6 = CustomField6;




        //        request.ShipToZip = ShipToZipCode;


        //        CartResponse response = ActionServiceClient.SetCart(request);

        //        if (response.IsError)
        //            throw new Exception(response.ErrorMessage);

        //        if (request.RequestId != response.CorrelationId)
        //            throw new ApplicationException("UpdateItem: Request and CorrelationId do not match.");

        //        return response.Cart;*/
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        /// <summary>
        /// Sets shipping method used to compute shipping charges.
        /// </summary>
        /// <param name="shippingMethod">The name of the shipper.</param>
        /// <returns>Updated shopping cart.</returns>
        //public ShoppingCart SetShippingMethod(string shippingMethod)
        //{
        //    try
        //    {


        //        CartRequest request = new CartRequest();
        //        request.RequestId = NewRequestId;
        //        request.AccessToken = AccessToken;
        //        request.ClientTag = ClientTag;

        //        request.Action = "Update";
        //        request.ShippingMethod = shippingMethod;

        //        request.CountryTwoLetterCode = CountryTwoLetterCode;
        //        request.ShipToZip = ShipToZipCode;

        //        CartResponse response = ActionServiceClient.SetCart(request);

        //        if (response.IsError)
        //            throw new Exception(response.ErrorMessage);



        //        if (request.RequestId != response.CorrelationId)
        //            throw new ApplicationException("SetShippingMethod: Request and CorrelationId do not match.");

        //        return response.Cart;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public ShoppingCart SetShippingMethod(string _ZipCode)
        {
            try
            {
                return null;

               /* CartRequest request = new CartRequest();
                request.RequestId = NewRequestId;
                request.AccessToken = AccessToken;
                request.ClientTag = ClientTag;

                request.CartAction = CartAction.ShipCalculate;// .Action = "ShipCalculate";
                //request.ShippingMethod = shippingMethod;

                request.CountryTwoLetterCode = CountryTwoLetterCode;
                request.ShipToZip = _ZipCode;

                CartResponse response = ActionServiceClient.SetCart(request);

                if (response.IsError)
                    throw new Exception(response.ErrorMessage);



                if (request.RequestId != response.CorrelationId)
                    throw new ApplicationException("SetShippingMethod: Request and CorrelationId do not match.");

                return response.Cart;*/
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ShoppingCart SetShippingMethod(string _ZipCode, string _CountryTwoLetterCode)
        {
            try
            {

                return null;

                /*CartRequest request = new CartRequest();
                request.RequestId = NewRequestId;
                request.AccessToken = AccessToken;
                request.ClientTag = ClientTag;

                request.CartAction = CartAction.ShipCalculate; // .Action = "ShipCalculate";
                //request.ShippingMethod = shippingMethod;

                request.CountryTwoLetterCode = _CountryTwoLetterCode;
                request.ShipToZip = _ZipCode;

                CartResponse response = ActionServiceClient.SetCart(request);

                if (response.IsError)
                    throw new Exception(response.ErrorMessage);



                if (request.RequestId != response.CorrelationId)
                    throw new ApplicationException("SetShippingMethod: Request and CorrelationId do not match.");

                return response.Cart;*/
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ShipToZipCode { get; set; }
        private string CountryTwoLetterCode { get; set; }

    }
}

