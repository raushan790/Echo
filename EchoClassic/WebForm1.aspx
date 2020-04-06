<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EchoWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet">
    <script type="text/javascript" src="jquery.countdownTimer.js"></script>
    <link rel="stylesheet" type="text/css" href="jquery.countdownTimer.css" />
    <script>
        // Set the date we're counting down to
        var countDownDate = new Date("Jan 5, 2019 15:37:25").getTime();

        // Update the count down every 1 second
        var x = setInterval(function () {

            // Get todays date and time
            var now = new Date().getTime();

            // Find the distance between now and the count down date
            var distance = countDownDate - now;

            // Time calculations for days, hours, minutes and seconds
            var days = Math.floor(distance / (1000 * 60 * 60 * 24));
            var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            var seconds = Math.floor((distance % (1000 * 60)) / 1000);

            // Display the result in the element with id="demo"
            document.getElementById("demo").innerHTML = days + "d " + hours + "h "
            + minutes + "m " + seconds + "s ";

            // If the count down is finished, write some text 
            if (distance < 0) {
                clearInterval(x);
                document.getElementById("demo").innerHTML = "EXPIRED";
            }
        }, 1000);
    </script>
    <%--<script>
        function makeTimer() {

            var endTime = new Date("29 April 2018 9:56:00 GMT+01:00");
            endTime = (Date.parse(endTime) / 1000);

            var now = new Date();
            now = (Date.parse(now) / 1000);

            var timeLeft = endTime - now;

            var days = Math.floor(timeLeft / 86400);
            var hours = Math.floor((timeLeft - (days * 86400)) / 3600);
            var minutes = Math.floor((timeLeft - (days * 86400) - (hours * 3600)) / 60);
            var seconds = Math.floor((timeLeft - (days * 86400) - (hours * 3600) - (minutes * 60)));

            if (hours < "10") { hours = "0" + hours; }
            if (minutes < "10") { minutes = "0" + minutes; }
            if (seconds < "10") { seconds = "0" + seconds; }

            $("#days").html(days + "<span>Days</span>");
            $("#hours").html(hours + "<span>Hours</span>");
            $("#minutes").html(minutes + "<span>Minutes</span>");
            $("#seconds").html(seconds + "<span>Seconds</span>");

        }

        setInterval(function () { makeTimer(); }, 1000);
    </script>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Titillium+Web:400,200,200italic,300,300italic,900,700italic,700,600italic,600,400italic);

        div {
            display: inline-block;
            line-height: 1;
        }

        span {
            display: block;
            font-size: 20px;
            color: white;
        }

        #days {
            font-size: 100px;
            color: #db4844;
        }

        #hours {
            font-size: 100px;
            color: #f07c22;
        }

        #minutes {
            font-size: 100px;
            color: #f6da74;
        }

        #seconds {
            font-size: 50px;
            color: #abcd58;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row">
                    <br />
                </div>
                <div class="row">
                    <div class="col-md-5 col-sm-5 col-xs-5">
                        <img src="images/echo123.png" alt="echo" class="img-responsive" />
                        <img src="images/echo1234.png" alt="echo" class="img-responsive" />
                    </div>
                    <div class="col-md-7 col-sm-7 col-xs-7">
                        <div style="padding-top: 50px; padding-bottom: 50px">
                            <img src="images/echo12345.png" alt="echo" class="img-responsive" />
                        </div>
                        <div style="text-align: center; font-weight: 700; font-size: 80px">
                            <p id="demo"></p>
                            <%-- <div id="timer">
                               
                                <div id="hours"></div>
                                <div id="minutes"></div>
                                <div id="seconds"></div>
                            </div>--%>
                        </div>
                        <div style="text-align: center; padding-top: 30px">
                            <img src="images/112.png" alt="echo" class="img-responsive" />
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" Text="Mobile"></asp:TextBox>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-6">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Text="Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
