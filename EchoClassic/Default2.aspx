<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="EchoClassic.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test WebForm</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style>
        * {
            box-sizing: border-box;
        }

        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        /* Style the header */
        header {
            background-color: #666;
            padding-bottom: 1px;
            padding-top: 19px;
            text-align: center;
            font-size: 15px;
            color: black;
            /*padding-left: 10px;
            padding-right: 10px;*/
        }

        /* Container for flexboxes */
        section {
            display: -webkit-flex;
            display: flex;
        }

        /* Style the navigation menu */
        nav {
            -webkit-flex: 1;
            -ms-flex: 1;
            flex: 1;
            background: #ccc;
            padding: 10px;
        }

            /* Style the list inside the menu */
            nav ul {
                list-style-type: none;
                padding: 0;
                font-size: 13px;
            }

        /* Style the content */
        article {
            -webkit-flex: 3;
            -ms-flex: 3;
            flex: 3;
            background-color: #f1f1f1;
            padding: 10px;
        }

        /* Style the footer */
        footer {
            background-color: #777;
            padding: 13px;
            text-align: center;
            color: white;
        }

        .topnav {
            overflow: hidden;
            background-color: #333;
        }

            .topnav a {
                float: left;
                display: block;
                color: #f2f2f2;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
                font-size: 17px;
            }

                .topnav a:hover {
                    background-color: #ddd;
                    color: black;
                }

        .active {
            background-color: #8c8686;
            color: white;
        }

        .topnav .icon {
            display: none;
        }

        @media screen and (max-width: 600px) {
            .topnav a:not(:first-child) {
                display: none;
            }

            .topnav a.icon {
                float: right;
                display: block;
            }
        }

        @media screen and (max-width: 600px) {
            .topnav.responsive {
                position: relative;
            }

                .topnav.responsive .icon {
                    position: absolute;
                    right: 0;
                    top: 0;
                }

                .topnav.responsive a {
                    float: none;
                    display: block;
                    text-align: left;
                }
        }
    </style>
    <script>
        function myFunction() {
            var x = document.getElementById("myTopnav");
            if (x.className === "topnav") {
                x.className += " responsive";
            } else {
                x.className = "topnav";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header style="margin-top: 1px">
                <nav class="navbar navbar-default">
                    <div class="row">
                        <div class="col-md-2">
                            <a href="#" style="font-size: 20px; font-weight: bold; text-decoration: none">
                                <img src="images/echo.PNG" alt="imgLogo" style="margin: 2px 2px 2px 42px; height: 65px" />&nbsp ECHO
                            </a>
                        </div>
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-4">&nbsp</div>
                        <div class="col-md-4">
                            <div class="container-fluid">
                                <div class="navbar-header">
                                </div>
                                <div class="topnav" id="myTopnav">
                                    <a href="#home" class="active">Home</a>
                                    <a href="#news">News</a>
                                    <a href="#contact">Contact</a>
                                    <a href="#about">About</a>
                                    <a href="javascript:void(0);" class="icon" onclick="myFunction()">
                                        <i class="fa fa-bars"></i>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr style="margin-top: 4px">
                    <div class="row">
                        <div class="col-md-4">
                            &nbsp
                        </div>
                        <div class="col-md-3">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-2 control-label">Email</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="inputEmail3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="inputPassword3" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="CheckBox1" />
                                                <asp:Label runat="server">Remember me?</asp:Label>
                                            </label>
                                            <button type="submit" class="btn btn-default">Sign in</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </nav>
            </header>
            <br />
            <div class="container">
                <section>
                    <div class="row" style="text-align: center;">
                        <div class="col-md-5">
                            <img src="images/echo-default1.PNG" style="width: 80%" />
                            <div class="row">
                                <div class="col-md-1">&nbsp;</div>
                                <div class="col-md-10">
                                    <h2>CREATE CLASSES</h2>
                                    <p style="text-align: justify">
                                        Create as many classes/groups for attendance as you need from your contacts or by 
                uploading an Excel file. No group should have more than 60 members. 
                Up to 5 members can be given admin rights to record attendance
                                    </p>
                                </div>
                            </div>
                            <img src="images/echo-default1.PNG" style="width: 80%" />
                            <div class="row">
                                <div class="col-md-1">&nbsp;</div>
                                <div class="col-md-10">
                                    <h2>DAILY REPORT</h2>
                                    <p style="text-align: justify">
                                        Once the app is connected to the internet, the app emails report automatically to all the users registered as admin.
                             If attendance is taken more than once for the same group, both reports are shared.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <img src="images/echo-default2.PNG" style="width: 80%" />
                            <div class="row">
                                <div class="col-md-1">&nbsp</div>
                                <div class="col-md-10">
                                    <h2>TAKE ATTENDANCE</h2>
                                    <p style="text-align: justify">
                                        Any admin member can take attendance during the day. Each class/section/group will have the same facility. Once the attendance is submitted, it cannot be altered. No Internet connection is needed for marking attendance.
                                    </p>

                                </div>
                            </div>
                            <img src="images/echo-default2.PNG" style="width: 80%" />
                            <div class="row">
                                <div class="col-md-1">&nbsp;</div>
                                <div class="col-md-10">
                                    <h2>MONTHLY REPORT</h2>
                                    <p style="text-align: justify">
                                        On the last day of the calendar month, a report is shared for the whole month. 
                            A lot of intuitive analytical reports are also provided along so that it helps the management to take necessary decisions with right inputs.
                                    </p>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-2" style="background-color: gainsboro; height: 830px">

                            <%--<h2>Add Section</h2>
                <p style="text-align: justify">
                    Create as many classes/groups for attendance as you need from your contacts or by 
                uploading an Excel file. No group should have more than 60 members. 
                Up to 5 members can be given admin rights to record attendance
                </p>--%>
                        </div>
                </section>
            </div>
            <footer>
                <div class="row" style="text-align: left; color: white">
                    <div class="col-md-3">
                        <h5 style="margin-left: 36px">WHATSAPP</h5>
                        <ul style="list-style-type: none;">
                            <li>Features</li>
                            <li>Security</li>
                            <li>Download</li>
                            <li>Whatsapp Web</li>
                            <li>Business</li>
                        </ul>
                    </div>
                    <div class="col-md-3">
                        <h5 style="margin-left: 36px">COMPANY</h5>
                        <ul style="list-style-type: none;">
                            <li>About</li>
                            <li>Careers</li>
                            <li>Brand Certer</li>
                            <li>Get in touch</li>
                            <li>Blog</li>
                        </ul>
                    </div>
                    <div class="col-md-3">
                        <h5 style="margin-left: 36px">DOWNLOAD</h5>
                        <ul style="list-style-type: none;">
                            <li>Mac/PC</li>
                            <li>Android</li>
                            <li>iPhone</li>
                            <li>Windows Phone</li>
                            <li>Nokia</li>
                        </ul>
                    </div>
                    <div class="col-md-3">
                        <h5 style="margin-left: 36px">HELP</h5>
                        <ul style="list-style-type: none;">
                            <li>FAQ</li>
                            <li>Twitter</li>
                            <li>Facebook</li>
                        </ul>
                    </div>
                </div>
                <div class="row" style="text-align: right;">
                    <div class="col-md-8">
                        &nbsp
                    </div>
                    <div class="col-md-3">
                        <p style="color: white; font-size: 10px; margin-left: 100px">&copy; <%: DateTime.Now.Year %> - Echo Application</p>
                    </div>
                    <div class="col-md-1">
                        &nbsp
                    </div>
                </div>
            </footer>
        </div>
    </form>
</body>
</html>
