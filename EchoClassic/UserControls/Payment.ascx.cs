using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EchoClassic.UserControls
{
    public partial class Payment : System.Web.UI.UserControl
    {
        public string orderId;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 1000); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");
            input.Add("payment_capture", 1);

            string key = "rzp_test_WWMX02RJxJbpRZ";
            string secret = "9Zg6KhCALHF5fGBtmn54xo6S";

            RazorpayClient client = new RazorpayClient(key, secret);

            Razorpay.Api.Order order = client.Order.Create(input);
            orderId = order["id"].ToString();
        }
    }
}