<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EchoClassic._Default" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.6.0/slick.js"></script>
    <style>
        h2 {
            text-align: center;
            padding: 20px;
        }
        /* Slider */

        .slick-slide {
            margin: 0px 20px;
        }

            .slick-slide img {
                width: 100%;
            }

        .slick-slider {
            position: relative;
            display: block;
            box-sizing: border-box;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            -webkit-touch-callout: none;
            -khtml-user-select: none;
            -ms-touch-action: pan-y;
            touch-action: pan-y;
            -webkit-tap-highlight-color: transparent;
        }

        .slick-list {
            position: relative;
            display: block;
            overflow: hidden;
            margin: 0;
            padding: 0;
        }

            .slick-list:focus {
                outline: none;
            }

            .slick-list.dragging {
                cursor: pointer;
                cursor: hand;
            }

        .slick-slider .slick-track,
        .slick-slider .slick-list {
            -webkit-transform: translate3d(0, 0, 0);
            -moz-transform: translate3d(0, 0, 0);
            -ms-transform: translate3d(0, 0, 0);
            -o-transform: translate3d(0, 0, 0);
            transform: translate3d(0, 0, 0);
        }

        .slick-track {
            position: relative;
            top: 0;
            left: 0;
            display: block;
        }

            .slick-track:before,
            .slick-track:after {
                display: table;
                content: '';
            }

            .slick-track:after {
                clear: both;
            }

        .slick-loading .slick-track {
            visibility: hidden;
        }

        .slick-slide {
            display: none;
            float: left;
            height: 100%;
            min-height: 1px;
        }

        [dir='rtl'] .slick-slide {
            float: right;
        }

        .slick-slide img {
            display: block;
        }

        .slick-slide.slick-loading img {
            display: none;
        }

        .slick-slide.dragging img {
            pointer-events: none;
        }

        .slick-initialized .slick-slide {
            display: block;
        }

        .slick-loading .slick-slide {
            visibility: hidden;
        }

        .slick-vertical .slick-slide {
            display: block;
            height: auto;
            border: 1px solid transparent;
        }

        .slick-arrow.slick-hidden {
            display: none;
        }
    </style>
    <hr style="margin-top: 0px; margin-bottom: 0px">
    <section>
        <div style="background-color: #222222; font-size: 15px; text-decoration: none;">
            <div class="container">
                <div class="row">

                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="row" style="margin-top: 13px; margin-left: -9px">
                            <asp:Label runat="server" AssociatedControlID="Email" Style="color: white; font-size: 13px" CssClass="col-md-1 col-sm-1 col-xs-12 control-label">Email or Mobile:</asp:Label>
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:TextBox runat="server" ID="Email" CssClass="form-control input-sm" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="text-danger" ErrorMessage="Please enter the email or mobile number." />
                            </div>
                            <asp:Label runat="server" AssociatedControlID="Password" Style="color: white; font-size: 13px" CssClass="col-md-1 col-sm-1 col-xs-12 control-label">Password:</asp:Label>
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control input-sm" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" Style="color: white; font-size: 13px" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                <asp:Button runat="server" OnClick="LogIn" Text="Log in" Style="padding: 3px 10px 3px 10px" class="btn btn-default btn-xs" />
                                <a href="Account/Forgot.aspx" style="font-size: 13px; color: white; text-align: left; text-decoration: none;">Forgot Password?</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <br />
    <div class="container">
        <section>
            <div class="row" style="text-align: center;">
                <div class="col-md-12">
                    <hr>
                    <div class="row">
                        <div class="col-md-6">
                            <img src="images/students-classroom.png" style="width: 80%" />
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
                        </div>
                        <div class="col-md-6">
                            <img src="images/Daily-Attendance.png" style="width: 80%" />
                            <div class="row">
                                <div class="col-md-1">&nbsp</div>
                                <div class="col-md-10">
                                    <h2>TAKE ATTENDANCE</h2>
                                    <p style="text-align: justify">
                                        Any admin member can take attendance during the day. Each class/section/group will have the same facility. Once the attendance is submitted, it cannot be altered. No Internet connection is needed for marking attendance.
                                    </p>

                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <img src="images/hand-raised.png" style="width: 80%" />
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
                        <div class="col-md-6">
                            <img src="images/Monthly-report.png" style="width: 80%" />
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
                    </div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="container">
                    <section class="customer-logos slider">
                        <%--<div class="slide">
                            <img src="images/IMG-20181227-WA0008.jpg">
                            <h5 style="text-align: center; font-weight: bold">Trial By DOE</h5>
                        </div>--%>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0009.jpg">
                            <h5 style="text-align: center; font-weight: bold">Approved by MSME</h5>
                        </div>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0010.jpg">
                            <h5 style="text-align: center; font-weight: bold">Client - BSL</h5>
                        </div>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0011.jpg">
                            <h5 style="text-align: center; font-weight: bold">Funded by Bank of Maharashtra</h5>
                        </div>
                        <%-- <div class="slide">
                            <img src="images/IMG-20181227-WA0008.jpg">
                            <h5 style="text-align: center; font-weight: bold">Trial By DOE</h5>
                        </div>--%>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0009.jpg">
                            <h5 style="text-align: center; font-weight: bold">Approved by MSME</h5>
                        </div>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0010.jpg">
                            <h5 style="text-align: center; font-weight: bold">Client - BSL</h5>
                        </div>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0011.jpg">
                            <h5 style="text-align: center; font-weight: bold">Funded by Bank of Maharashtra</h5>
                        </div>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0009.jpg">
                            <h5 style="text-align: center; font-weight: bold">Approved by MSME</h5>
                        </div>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0010.jpg">
                            <h5 style="text-align: center; font-weight: bold">Client - BSL</h5>
                        </div>
                        <div class="slide">
                            <img src="images/IMG-20181227-WA0011.jpg">
                            <h5 style="text-align: center; font-weight: bold">Funded by Bank of Maharashtra</h5>
                        </div>
                    </section>
                </div>

            </div>
        </section>
    </div>
    <%------------Comment code from here------------%>

    <script>
        $(document).ready(function () {
            $('.customer-logos').slick({
                slidesToShow: 6,
                slidesToScroll: 1,
                autoplay: true,
                autoplaySpeed: 1500,
                arrows: false,
                dots: false,
                pauseOnHover: false,
                responsive: [{
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 4
                    }
                }, {
                    breakpoint: 520,
                    settings: {
                        slidesToShow: 3
                    }
                }]
            });
        });
    </script>
    <%------------Comment code to here------------%>
</asp:Content>
