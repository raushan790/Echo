<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="EchoClassic.Admin.Summary" %>

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
<body class="nav-md">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
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
                                        <li><a href="AddGroup" target="_blank">Manage Groups</a></li>
                                        <li><a href="su-dashboard">Dashboard Home</a></li>
                                        <li><a href="AttendanceSearch">Attendance Search</a></li>
                                       <li><a href="ExportAttendance">Export Attendance</a></li>
                                        <li class="active"><a href="#" style="font-weight: bold; background-color: #c7c2c2 !important">Summary</a></li>
                                                                              <li><a href="viewGroups.aspx">View Notice </a></li>

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
            <div class="row" style="margin-right: 1px">
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <h1 style="color: #0d0c0c">
                        <asp:Image ID="imgGroup" runat="server" CssClass="img-responsive" Style="width: 180px; margin-left: 72px; margin-top: -5px;" />
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
            <div class="container body">
                <div class="main_container">
                    <div class="right_col" role="main">
                        <div class="row tile_count" style="box-shadow: 1px 2px 8px 1px; width: 100%;">
                            <div class="col-md-3 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-user"></i>Total Students</span>
                                <div class="count">
                                    <asp:Literal ID="litTotalStudent" runat="server"></asp:Literal>
                                </div>
                                <span class="count_bottom"></span>
                            </div>

                            <div class="col-md-3 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-male"></i>Total Males</span>
                                <div class="count green">
                                    <asp:Literal ID="litTotalMale" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-female"></i>Total Females</span>
                                <div class="count">
                                    <asp:Literal ID="litTotalFemale" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-4 col-xs-6 tile_stats_count" style="display: none;">
                                <span class="count_top"><i class="fa fa-list-alt"></i>Total Teachers</span>
                                <div class="count">
                                    <asp:Literal ID="litTotalTeacher" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-list-alt"></i>Total Classes</span>
                                <div class="count">
                                    <asp:Literal ID="LitTotalClasses" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                        <div class="row tile_count" style="overflow-y: scroll;">
                            <h3>Summary for Groups</h3>
                            <%--<a href="AddGroup.aspx">Click here to Manage Groups</a>--%>
                            <asp:GridView ID="gvGroupAndMembers" runat="server" Style="box-shadow: 0px 1px 6px 1px; width: 100%"
                                CssClass="table table-striped"
                                AutoGenerateColumns="false" OnRowDataBound="gvGroupAndMembers_databound">
                                <Columns>
                                    <asp:TemplateField HeaderText="SLNo.">
                                        <ItemTemplate>
                                            <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GroupID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroupID" runat="server" Text='<%# Eval("GroupID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroupName" Text='<%# Eval("GroupName")%>' runat="server">
                                            </asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroupDesctiption" Text='<%# Eval("GroupDescription")%>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="No Of Students">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalMember" Text='<%# Eval("CountMember")%>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Admins">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdmins" Text='<%# Eval("CountAdmin")%>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>


                    <footer>
                        <div class="pull-right">
                            Designed and developed by <a href="https://echocommunicator.com/">Echo Communicator</a>
                        </div>
                        <div class="clearfix"></div>
                    </footer>

                </div>
            </div>
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
