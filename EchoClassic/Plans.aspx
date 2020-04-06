<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plans.aspx.cs" Inherits="EchoClassic.Plans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet">
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
    <style>
        .razorpay-payment-button {
            display: inline-block;
            padding: 6px 12px;
            margin-bottom: 0;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            border-radius: 5px;
            background-color: #5cb85c;
            border-color: #4cae4c;
            color: white;
        }
    </style>
</head>
<body>
    <form action="Charge.aspx" method="post">
        <%--<input type="submit" style="width: 148px" value="Click Here to Pay" class="razorpay-payment-button" />--%>
        <script src="https://checkout.razorpay.com/v1/checkout.js"
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
        <input type="hidden" value="Hidden Element" name="hidden" />
        <div>
            <header style="height: 10px;"></header>
            <div class="shopping_cart" style="width: 95%; margin-left: 33px;">
                <div class="form-horizontal" role="form" id="payment-form">
                    <div class="panel-group" id="accordion">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Review
                                                Your Order</a>
                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <div class="items">
                                        <div class="col-md-7">
                                            <table class="table table-striped">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="2">
                                                            <a class="btn btn-warning btn-sm pull-right" href="http://www.startajobboard.com/" title="Remove Item">X</a>
                                                            <b>Product Name1 Product Name2 Product Name3 </b></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ul>
                                                                <li>One Job Posting Credit</li>
                                                                <li>Job Distribution*</li>
                                                                <li>Social Media Distribution</li>
                                                            </ul>
                                                        </td>
                                                        <td>Unit Price:
                                                                <b>$147.00</b>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="col-md-2">
                                            <div style="text-align: center;">
                                                <h3>Quantity</h3>
                                                <h3><span style="color: green;">14</span></h3>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div style="text-align: center;">
                                                <h3>Order Total</h3>
                                                <h3><span style="color: green;">$147.00</span></h3>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <input type="submit" style="width: auto; margin-top: 30px" value="Buy" class="razorpay-payment-button" />
                                        </div>
                                    </div>
                                    <div class="items">
                                        <div class="col-md-7">
                                            <table class="table table-striped">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="2">
                                                            <a class="btn btn-warning btn-sm pull-right" href="http://www.startajobboard.com/" title="Remove Item">X</a>
                                                            <b>Product Name1 Product Name2 Product Name3 </b></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ul>
                                                                <li>One Job Posting Credit</li>
                                                                <li>Job Distribution*</li>
                                                                <li>Social Media Distribution</li>
                                                            </ul>
                                                        </td>
                                                        <td>Unit Price:
                                                                <b>$147.00</b>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="col-md-2">
                                            <div style="text-align: center;">
                                                <h3>Quantity</h3>
                                                <h3><span style="color: green;">14</span></h3>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div style="text-align: center;">
                                                <h3>Order Total</h3>
                                                <h3><span style="color: green;">$147.00</span></h3>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <input type="submit" style="width: auto; margin-top: 30px" value="Buy" class="razorpay-payment-button" />
                                        </div>
                                    </div>
                                    <div class="items">
                                        <div class="col-md-7">
                                            <table class="table table-striped">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="2">
                                                            <a class="btn btn-warning btn-sm pull-right" href="http://www.startajobboard.com/" title="Remove Item">X</a>
                                                            <b>Product Name1 Product Name2 Product Name3 </b></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ul>
                                                                <li>One Job Posting Credit</li>
                                                                <li>Job Distribution*</li>
                                                                <li>Social Media Distribution</li>
                                                            </ul>
                                                        </td>
                                                        <td>Unit Price:
                                                                <b>$147.00</b>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="col-md-2">
                                            <div style="text-align: center;">
                                                <h3>Quantity</h3>
                                                <h3><span style="color: green;">14</span></h3>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div style="text-align: center;">
                                                <h3>Order Total</h3>
                                                <h3><span style="color: green;">$147.00</span></h3>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <input type="submit" style="width: auto; margin-top: 30px" value="Buy" class="razorpay-payment-button" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="panel panel-default" style="display: none;">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <div style="text-align: center; width: 100%;">
                                    <a style="width: 100%;" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" class=" btn btn-success" onclick="$(this).fadeOut(); $('#payInfo').fadeIn();">Continue
                                            to Billing Information»</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
