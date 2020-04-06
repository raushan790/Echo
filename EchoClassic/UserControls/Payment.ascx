<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Payment.ascx.cs" Inherits="EchoClassic.UserControls.Payment" %>
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
    <%--<input type="submit" value="Click Here to Pay" class="razorpay-payment-button" />--%>
    <input type="hidden" value="Hidden Element" name="hidden" />
</form>
