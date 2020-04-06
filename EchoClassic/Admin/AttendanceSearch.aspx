<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceSearch.aspx.cs" Inherits="EchoClassic.Admin.AttendanceSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Echo Communicator | Dashboard </title>
    <link href="css/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/nprogress/nprogress.css" rel="stylesheet" />
    <link href="css/iCheck/skins/flat/green.css" rel="stylesheet" />
    <link href="css/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" />
    <link href="Charts/CSS/JQCSS.css" rel="stylesheet" />

    <link href="css/custom.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link href="../css/Common.css" rel="stylesheet" />
    <style>
        .counter-count {
            font-size: 24px;
            background: linear-gradient(to bottom,#DECBA4 0%, #3E5151 100%);
            border-radius: 50%;
            position: relative;
            color: #ffffff;
            text-align: center;
            line-height: 92px;
            width: 95px;
            height: 95px;
            -webkit-border-radius: 50%;
            -moz-border-radius: 50%;
            -ms-border-radius: 50%;
            -o-border-radius: 50%;
            display: inline-block;
        }

        .counter-count1 {
            font-size: 24px;
            background: linear-gradient(to bottom, #958989 0%, #434343 100%);
            border-radius: 50%;
            position: relative;
            color: #ffffff;
            text-align: center;
            line-height: 92px;
            width: 95px;
            height: 95px;
            -webkit-border-radius: 50%;
            -moz-border-radius: 50%;
            -ms-border-radius: 50%;
            -o-border-radius: 50%;
            display: inline-block;
        }

        .counter-count2 {
            font-size: 24px;
            background: linear-gradient(to bottom, #918f99 0%, #605C3C 100%);
            border-radius: 50%;
            position: relative;
            color: #ffffff;
            text-align: center;
            line-height: 92px;
            width: 95px;
            height: 95px;
            -webkit-border-radius: 50%;
            -moz-border-radius: 50%;
            -ms-border-radius: 50%;
            -o-border-radius: 50%;
            display: inline-block;
        }
    </style>
</head>
<body class="nav-md" style="background-color: white;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
        <asp:UpdateProgress ID="updateProgress" runat="server" AssociatedUpdatePanelID="up1"
            DisplayAfter="0">
            <ProgressTemplate>
                <div class="invisible_layer" id="processMessage">
                    <div class="transparent_bg">
                    </div>
                    <div class="loadingbar">
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <header style="background-color: white">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="navbar navbar-default" style="height: 48px">
                        <nav class="navbar navbar-inverse navbar-fixed-top">
                            <div class="container">
                                <div class="navbar-header" style="background-color: #D2DBE3!important">
                                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar6">
                                        <span class="sr-only">Toggle navigation</span>
                                        <span class="icon-bar"></span>
                                        <span class="icon-bar"></span>
                                        <span class="icon-bar"></span>
                                    </button>
                                </div>
                                <div id="navbar6" class="navbar-collapse collapse" style="background-color: #dedcdc;">
                                    <ul class="nav navbar-nav navbar-right" style="margin-left: 0px; position: relative; background-color: #e0e5e6; z-index: 1">
                                        <li><a href="su-dashboard">Dashboard Home</a></li>
                                        <li class="active"><a href="#" style="font-weight: bold; background-color: #c7c2c2 !important">Attendance Search</a></li>
                                       <li><a href="ExportAttendance">Export Attendance</a></li>
                                        <li><a href="summary">Summary</a></li>
                                      
                                        <li class="">
                                            <a href="javascript:;" class="user-profile dropdown-toggle" style="background-color: #e0e5e6" data-toggle="dropdown" aria-expanded="false">
                                                <img src="images/user.png" alt="" />Administrator
                                        <span class=" fa fa-angle-down"></span>
                                            </a>
                                            <ul class="dropdown-menu dropdown-usermenu pull-right" style="background-color: #e0e5e6; z-index: 1">
                                                <li><a href="javascript:;">Profile</a></li>

                                                <li><a href="../contact">Help</a></li>
                                                <li><a href="../logout"><i class="fa fa-sign-out pull-right"></i>Log Out</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                                <!--/.nav-collapse -->
                            </div>
                            <!--/.container-fluid -->
                        </nav>
                    </div>
                </div>
            </div>
            <hr />
            <div class="row" style="margin-right: 1px; margin-bottom: 10px">
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <h1 style="color: #0d0c0c">
                        <asp:Image ID="imgGroup" Style="width: 180px; margin-left: 72px; margin-top: -5px;" runat="server" CssClass="img-responsive" />
                        <asp:Literal ID="litSchoolName" runat="server"></asp:Literal></h1>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <asp:UpdatePanel ID="upLiveAttendance" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>

                            <div class="x_panel tile fixed_height_100" align="center" style="border-radius: 25px; box-shadow: 3px 4px 10px 2px; font-weight: bold; background-color: #228b22;">
                                <div class="x_title">
                                    <h2 style="color: white;">Live Attendance Counter</h2>
                                    <div class="clearfix"></div>
                                </div>
                                <h3 style="font-weight: bold" class="counter-count">
                                    <div id="count-test" class="demo"></div>
                                </h3>
                            </div>

                            <div class="col-md-4 col-sm-4 col-xs-12" style="display: none">
                                <input type="button" id="btnClick" value="click" />
                                <input type="text" id="txtinput" />
                                <input type="text" id="txtinput1" />
                                <input type="text" id="txtinput2" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <div class="x_panel tile fixed_height_100" align="center" style="box-shadow: 3px 4px 10px 2px; font-weight: bold; border-radius: 25px; background-color: darkgray;">
                        <div class="x_title">
                            <h2 style="color: white;">Number of Groups</h2>
                            <div class="clearfix"></div>
                        </div>
                        <h3 style="font-weight: bold" class="counter-count1">
                            <asp:Literal ID="litClassesCount" runat="server"></asp:Literal>
                        </h3>
                    </div>
                </div>

                <div class="col-md-3 col-sm-3 col-xs-12">
                    <div class="x_panel tile fixed_height_100" align="center" style="border-radius: 25px; box-shadow: 3px 4px 10px 2px; font-weight: bold; background-color: #9a0543;">
                        <div class="x_title">
                            <h2 style="color: white;">Installation Report</h2>
                            <div class="clearfix"></div>
                        </div>
                        <h3 style="font-weight: bold" class="counter-count2">
                            <asp:Literal ID="litInstallationReport" runat="server"></asp:Literal>
                        </h3>
                    </div>
                </div>
            </div>
        </header>
        <div>
            <asp:TextBox ID="litClientID" ClientIDMode="Static" runat="server" Text="52" Style="display: none"></asp:TextBox>

            <section>
                <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="dashboard_graph" style="box-shadow: 0px 1px 6px 1px">
                                    <div class="row x_title">
                                        <div class="row">
                                            <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                            <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                                                <h3>Select Date:</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                                <div class="form-group row">
                                                    <div class="form-group">
                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                            <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="FromDateChanged"> 
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="calEFromDate" runat="server" TargetControlID="txtDateFrom" />

                                                        </div>
                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                            <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="ToDateChanged">   
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalETodate" runat="server" TargetControlID="txtDateTo" />

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                                <div class="form-group row">
                                                    <div class="form-group">
                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                            <asp:DropDownList ID="ddlClass" AutoPostBack="true" OnSelectedIndexChanged="ddlClassSelectedIndexChanged" runat="server" CssClass="form-control">
                                                                <asp:ListItem Text="MBBS 1st Year" Value="MBBS 1st Year"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                            <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectSelectedIndexChanged">
                                                                <asp:ListItem Text="Anatomy" Value="121892"></asp:ListItem>
                                                                <asp:ListItem Text="Biochemistry" Value="121893"></asp:ListItem>
                                                                <asp:ListItem Text="Physiology" Value="121894"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <asp:Panel ID="pnlNormalAttendance" runat="server" Visible="false">
                            <div class="row">
                                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                                    <h3>Attendance Status:</h3>
                                </div>
                            </div>
                            <div class="row" style="overflow-y: scroll; max-height: 300px;">
                                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:GridView ID="gvAttendanceStatus" runat="server" Style="box-shadow: 0px 1px 6px 1px; width: 100%"
                                        CssClass="table table-striped table-fit" AutoGenerateColumns="false"
                                        OnRowDataBound="gvAttendanceStatus_Databound"
                                        OnRowCommand="gvAttendanceStatus_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SLNo.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkStudentName" CommandName="ViewDetails" CommandArgument='<%#Eval("UserID") %>' runat="server" Text='<%#Eval("UDF2") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No. of days Present">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkTotalPresent" CommandName="ViewDetails" CommandArgument='<%#Eval("UserID") %>' runat="server" Text='<%#Eval("PresentCount") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Overall Classes">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalClasses" runat="server"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Overall Percentage">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPercent" runat="server"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Overall fulfilled">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMin" Text="Yes" runat="server"></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                <div class="col-lg-11 col-md-11 col-sm-11 col-xs-12">
                                    <h3>Attendance Details for:
                                            <asp:Literal ID="litStudentName" runat="server"></asp:Literal></h3>
                                </div>
                            </div>
                            <div class="row" style="overflow-y: scroll; max-height: 300px;">
                                <%--btn <asp:Button ID="btnPrintDistrict" runat="server" Text="Print" OnClientClick="PrintPage();" />
                                --%>
                                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <asp:GridView ID="gvAttendanceDetails" runat="server" Style="box-shadow: 0px 1px 6px 1px; width: 100%"
                                        CssClass="table table-striped" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SLNo.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attendance Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAttendanceDate" runat="server"
                                                        Text='<%#Convert.ToDateTime( Eval("AttendanceDate")).Date.ToShortDateString() %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attendance Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAttendanceTime" runat="server" Text='<%#Eval("AttendanceTime") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Device">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDevice" runat="server" Text='<%#Eval("Device") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlCheckinCheckout" runat="server" Visible="false">
                            <div class="row" style="overflow-y: scroll; max-height: 300px;">
                                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                    <h3>Checkin, Checkout</h3>
                                    <asp:GridView ID="gvCheckinCheckoutData" runat="server" Style="box-shadow: 0px 1px 6px 1px; width: 100%"
                                        CssClass="table table-striped table-fit" AutoGenerateColumns="false"
                                        OnRowDataBound="gvCheckinCheckoutData_Databound" OnRowCommand="gvAttendanceStatus_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SLNo.">
                                                <ItemTemplate>
                                                    <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("udf2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpres" runat="server" Text="Present"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Checked-in At">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCheckin" runat="server" Text='<%#Eval("CheckinDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Checked-out At">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCheckout" runat="server" Text='<%#Eval("CheckoutDate") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Working hours">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWorkingHours" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                    <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">&nbsp</div>
                                </div>
                            </div>
                        </asp:Panel>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
            <script src="js/jquery.min.js"></script>
            <script src="css/bootstrap/dist/js/bootstrap.min.js"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
            <script src="js/fastclick.js"></script>
            <script src="css/nprogress/nprogress.js"></script>

            <script src="js/gauge.min.js"></script>
            <script src="css/bootstrap-progressbar/bootstrap-progressbar.min.js"></script>

            <script src="js/skycons.js"></script>

            <script src="js/Flot/jquery.flot.js"></script>
            <script src="js/Flot/jquery.flot.pie.js"></script>
            <script src="js/Flot/jquery.flot.time.js"></script>
            <script src="js/Flot/jquery.flot.stack.js"></script>
            <script src="js/Flot/jquery.flot.resize.js"></script>
            <script src="js/jquery.flot.orderBars.js"></script>
            <script src="js/jquery.flot.spline.min.js"></script>
            <script src="js/curvedLines.js"></script>
            <script src="js/custom.min.js"></script>
            <script src="js/date.js"></script>
            <script src="Charts/JS/JQChart.js"></script>
            <script src="css/bootstrap-daterangepicker/daterangepicker.js"></script>
            <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
            <script src="js/jQuerySimpleCounter.js"></script>
            <script src="js/Dashboard.js"></script>
            <script type="text/javascript">
                jQuery(document).ready(function () {
                    $('#txtinput1').val(0);
                    $('#txtinput2').val(0);
                    runCounter(0, 0);
                });
                function runCounter(start, end) {
                    $('#count-test').jQuerySimpleCounter({
                        start: start,
                        end: end,
                        duration: 10000
                    });
                    setTimeout(function () {
                        //alert(1);
                        $('#txtinput2').val(end);
                        LiveAttendanceCounter();
                        $('#txtinput').blur();
                        //alert(1);
                    }, 10000);
                };

                jQuery('#txtinput').on('blur', function () {
                    //alert(3);
                    var end1 = $('#txtinput2').val();
                    var start1 = 0;
                    start1 = end1;
                    end1 = $('#txtinput').val();
                    //alert(start1);
                    runCounter(start1, end1);
                });
            </script>
        </div>
    </form>
</body>
</html>
