<%@ Page Language="C#" AutoEventWireup="true" codefile="Payment.aspx.cs" Inherits="EchoClassic.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Razorpay .Net Sample App</title>
    <style>
        .razorpay-payment-button {
            background-color: #999;
            width: 115px;
            height: 37px;
            border-radius: 5px;
            color: antiquewhite;
        }
    </style>
</head>
<body>
    <form action="Charge.aspx" method="post">
        <script
            src="https://checkout.razorpay.com/v1/checkout.js"
            data-key="rzp_test_WWMX02RJxJbpRZ"
            data-amount="10"
            data-name="Razorpay"
            data-description="Test Payment"
            data-order_id="<%=orderId%>"
            data-image="https://razorpay.com/favicon.png"
            data-prefill.name="ECR Technologies LLP"
            data-prefill.email="amit.sengupta@echocommunicator.com"
            data-prefill.contact="9953624768"
            data-theme.color="#999999"></script>
        <input type="submit" value="Click Here to Pay" class="razorpay-payment-button" />
        <input type="hidden" value="Hidden Element" name="hidden" />
    </form>
</body>
</html>
