<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gov-dashboard.aspx.cs" Inherits="EchoClassic.Admin.gov_dashboard" %>

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

        <div>
            <asp:TextBox ID="litClientID" ClientIDMode="Static" runat="server" Text="52" Style="display: none"></asp:TextBox>
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
                                            <li class="active"><a href="#" style="font-weight: bold; background-color: #c7c2c2 !important">Dashboard Home</a></li>
                                            <%--<li><a href="AttendanceSearch">Attendance Search</a></li>
                                            <li><a href="ExportAttendance">Export Attendance</a></li>--%>
                                       <%--<li><a href="summary">Summary</a></li>--%>
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
                    <div class="col-md-1 col-md-offset-1 col-sm-3 col-xs-12">
                        
                            <asp:Image ID="imgGroup" runat="server" CssClass="img-responsive" />
                            <asp:Literal ID="litSchoolName" runat="server">
                            </asp:Literal>

                    </div>
                    <div class="col-md-8 col-sm-8 col-xs-12" style="padding-left:30px">
                        <h3><br /> <%=GovName %></h3>
                    </div>
                    <%--<div class="col-md-3 col-sm-3 col-xs-12">
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
                                <h2 style="color: white;">Groups reported attendance</h2>
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
                    </div>--%>
                </div>
                <%-- <hr style="margin-top: 5px" />--%>
            </header>
            <div class="container body">
                <div class="main_container">
                    <div class="" role="main" style="padding: 10px 20px 0; background-color: white;">
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="dashboard_graph" style="box-shadow: 0px 1px 6px 1px">
                                    <div class="row x_title">
                                        <div class="row hide" style="padding-top: 5px; margin-right: 40px">
                                            <div class="col-sm-1 col-md-1 col-lg-1 col-xs-12">&nbsp</div>
                                            <div class="col-sm-2 col-md-2 col-lg-2 col-xs-12" style="text-align: right">
                                                <h3>Select Date
                                                </h3>
                                            </div>
                                            <div class="col-sm-4 col-md-4 col-lg-4 col-xs-12">
                                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="FromDateChanged">           
                                                </asp:TextBox>
                                                <asp:Calendar ID="calEFromDate" runat="server" TargetControlID="txtDateFrom" />
                                            </div>
                                            <div class="col-sm-4 col-md-4 col-lg-4 col-xs-12">
                                                <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="ToDateChanged">     
                                                </asp:TextBox>
                                                 <asp:Calendar ID="CalETodate" runat="server" TargetControlID="txtDateTo" />
                                           
                                            </div>
                                            <div class="col-sm-1 col-md-1 col-lg-1 col-xs-12">&nbsp</div>
                                        </div>
                                        <div class="row" align="center" style="height: 100px">
                                            <div id="divCountForDate" runat="server" class="row tile_count">
                                                <div class="col-md-1 col-sm-4 col-xs-6">
                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6">
                                                    <span class="count_top"><i class="fa fa-group"></i>Number of Institutions</span>
                                                    <div class="count green" style="font-size: 30px; font-weight: bold; color: #228b22"><%=TotalInstitution %></div>

                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-user"></i>Number of Students</span>
                                                    <div class="count" style="font-size: 30px; font-weight: bold;"><%=TotalStudent %></div>
                                                    <%--<span class="count_bottom">Present: <%=TotalStudentsPresentonDate %></span>--%>
                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-user"></i>Number of Active Students</span>
                                                    <div class="count" style="font-size: 30px; font-weight: bold;"><%=TotalActiveStudent %></div>
                                                    <%--<span class="count_bottom">Present: <%=TotalStudentsPresentonDate %></span>--%>
                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count hide">
                                                    <span class="count_top"><i class="fa fa-user"></i>Number of Students present</span>
                                                    <div class="count" style="font-size: 30px; font-weight: bold;"><%=TotalPresentStudent %></div>
                                                    <%--<span class="count_bottom">Present: <%=TotalStudentsPresentonDate %></span>--%>
                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-user"></i>Total Males</span>
                                                    <div class="count green" style="font-size: 30px; color: #002366"><%=TotalMales %></div>
                                                    <%--<span class="count_bottom">Present: <%=TotalMalePresentonDate %></span>--%>
                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-female"></i>Total Females</span>
                                                    <div class="count" style="font-size: 30px; color: #e73895"><%=TotalFemales %></div>
                                                    <%--<span class="count_bottom">Present: <%=TotalFemalePresentonDate %></span>--%>
                                                </div>

                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count hide">
                                                    <span class="count_top"><i class="fa fa-group"></i>Groups not reported</span>
                                                    <div class="count green" style="font-size: 30px; color: #9a0543">
                                                      <asp:Literal ID="litTotalGroups" runat="server" Visible="false"></asp:Literal>
                                                   
                                                          <asp:Literal ID="litGroupNotReported" runat="server"></asp:Literal>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            
                                            <div class="col-md-offset-1 col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtSearch" placeholder="Search College/Institutes" runat="server" CssClass="form-control" list="CollegeList">           
                                </asp:TextBox>
                                <datalist id="CollegeList">
                                    <%=Institutes %>
                                </datalist>
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-12">
                                <asp:Button Text="Search" ID="btnSearchCollege" runat="server" CssClass="form-control btn-primary" OnClick="btnSearchCollege_Click" />
                            </div>
                                        </div>
                                    </div>
                                    <%--<div class="col-md-6 col-sm-6 col-xs-12">
                                    </div>
                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        
                        <br />
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320" style="border-radius: 5px; box-shadow: 0px 0px 13px 1px;">
                                    <div class="x_title">
                                        <h2>Students present today</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="count text-center" style="font-size: 90px;margin-top:50px; font-weight: bold;"><%=TotalPresentStudent %></div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320" style="border-radius: 5px; box-shadow: 0px 0px 13px 1px;">
                                    <div class="x_title">
                                        <h2>Student's Attendance</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="jqChart"></div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320 overflow_hidden" style="border-radius: 5px; box-shadow: 0px 0px 13px 1px;">
                                    <div class="x_title">
                                        <h2>Male vs Female</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="GenderChart"></div>
                                </div>
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320" style="border-radius: 5px; box-shadow: 0px 0px 13px 1px;">
                                    <div class="x_title">
                                        <h2>Earlier 10 days trend for Students</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <%--<div id="TrendChart"></div>--%>
                                    <ul class="list-group" style="height: 100%;overflow-y: auto;">
                                        <%=Trends %>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320" style="border-radius: 5px; box-shadow: 0px 0px 13px 1px;">
                                    <div class="x_title">
                                        <h2>Top 5 Institutes</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <ul class="list-group">
                                        <%=TopInstitute %>
                                      <%--<li class="list-group-item">Cras justo odio</li>
                                      <li class="list-group-item">Dapibus ac facilisis in</li>
                                      <li class="list-group-item">Morbi leo risus</li>
                                      <li class="list-group-item">Porta ac consectetur ac</li>
                                      <li class="list-group-item">Vestibulum at eros</li>--%>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320" style="border-radius: 5px; box-shadow: 0px 0px 13px 1px;">
                                    <div class="x_title">
                                        <h2>Bottom 5 Institutes</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <ul class="list-group">
                                        <%=BottomInstitute %>
                                    </ul>
                                </div>
                            </div>
                            
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
            <script>
                $(function () {
                    $("#txtDate").datepicker();
                    <%--var dd='<%=CurrentDate%>';
                    alert(dd);--%>
                    //if(dd!="")
                    //{
                    //    $("#txtDate").datepicker( "setDate" , "03/09/2019" );
                    //}
                    //$("#txtDate").datepicker("option", "dateFormat", "DD, d MM, yy");
                    $("#txtDate").datepicker("option", "showAnim", "slideDown");
                   
                });
            </script>
            <script lang="javascript" type="text/javascript">
                $(document).ready(function () {

                    var background = {
                        type: 'linearGradient',
                        x0: 0,
                        y0: 0,
                        x1: 0,
                        y1: 1,

                    };

                    $('#jqChart').jqChart({

                        
                        border: {
                            cornerRadius: 0,
                            lineWidth: 1,
                            strokeStyle: '#ffffff'
                        },
                        background: background,
                        animation: { duration: 1 },
                        color: 'white',
                        shadows: {
                            enabled: true
                        },
                        series: [
                            {
                                type: 'pie',
                                fillStyles: ['#9a0543', '#228b22'],
                                labels: {
                                    stringFormat: '%.1f%%',
                                    valueType: 'percentage',
                                    font: '15px sans-serif',
                                    fillStyle: 'white'
                                },
                                explodedRadius: 10,
                                explodedSlices: [5],
                                data: [['Absent', '<%=(PerAbsent)%>'], ['Present', '<%=(PerPresent)%>']]
                            }
                        ]
                    });

                    $('#jqChart').bind('tooltipFormat', function (e, data) {
                        var percentage = data.series.getPercentage(data.value);
                        percentage = data.chart.stringFormat(percentage, '%.2f%%');

                        return '<b>' + data.dataItem[0] + '</b><br />' + percentage;
                    });
                });
            </script>



            <%-- Cast Doughnut Chart--%>
            <%--<script lang="javascript" type="text/javascript">
                $(document).ready(function () {
                    $('#CasteChart').jqChart({
               
                        legend: { title: 'Caste' },
                        border: {
                            cornerRadius: 0,
                            lineWidth: 1,
                            strokeStyle: '#ffffff'
                        },
                        animation: { duration: 1 },
                        shadows: {
                            enabled: true
                        },
                        series: [
                            {
                                type: 'doughnut',
                                innerExtent: 0.5,
                                outerExtent: 1.0,
                                fillStyles: ['#418CF0', '#FCB441', '#E0400A', '#056492', '#BFBFBF', '#1A3B69', '#FFE382'],
                                
                                labels: {
                                    stringFormat: '%.1f%%',
                                    valueType: 'percentage',
                                    font: '15px sans-serif',
                                    fillStyle: 'white'
                                },
                                
                            }
                        ]
                    });
                });
            </script>--%>

            <script lang="javascript" type="text/javascript">
                $(document).ready(function () {
                    //var series1=
                    $('#GenderChart').jqChart({
                        title: { text: '' },
                        animation: { duration: 1 },
                        shadows: {
                            enabled: true
                        },
                        border: {
                            cornerRadius: 0,
                            lineWidth: 1,
                            strokeStyle: '#ffffff'
                        },
                        axes: [
                            {
                                location: 'left',
                                labels: {stringFormat: '%d %%', },
                                type: 'linear',
                                majorGridLines: { strokeDashArray: [1, 3] },  
                            }
                        ],
                        series: [
                            {
                                type: 'column',
                                title: 'Male',
                                fillStyle: '#002366',
                                data: <%=(MaleSeries)%>,
                                labels: {
                                    stringFormat: '%d %'
                            
                                },
                        
                            },
                    {
                        type: 'column',
                        title: 'Female',
                        fillStyle: '#e73895',
                        data: <%=(FemaleSeries)%>,
                        labels: {
                            stringFormat: '%d %'
                            
                        },
                        
                    }
                        ]
                    });
                    <%--$('#TrendChart').jqChart({
                        title: { text: '' },
                        animation: { duration: 1 },
                        shadows: {
                            enabled: true
                        },
                        border: {
                            cornerRadius: 0,
                            lineWidth: 1,
                            strokeStyle: '#ffffff'
                        },
                        axes: [
                            {
                                location: 'left',
                                labels: { stringFormat: '%d %%', },
                                type: 'linear',
                                majorGridLines: { strokeDashArray: [1, 3] },
                            }
                        ],
                        series: [
                            <%=Trends%>
                        ]
                    });--%>
           
                });
            </script>

            <script lang="javascript" type="text/javascript">
                $(document).ready(function () {
                    $('#jqLineChart').jqChart({
               
                        legend: { visible: false },
                        animation: { duration: 1 },
                        border: {
                            cornerRadius: 0,
                            lineWidth: 1,
                            strokeStyle: '#ffffff'
                        },
                        axes: [
                            {
                               
                                location: 'bottom',
                                categories: <%=(DateSeries)%>,
                                labels: { visible:false },
                                
                            },
                        {
                            location: 'left',
                            majorGridLines: { strokeDashArray: [1, 3] },
                        }
                        ],
                        
                        series: [
                            {
                                type: 'line',
                                title: 'Present',
                                strokeStyle: '#418CF0',
                                lineWidth : 2,
                                data: <%=(PresentSeriesforLineChart)%>,
                                labels: {
                                    stringFormat: '%d %',
                                    font: '12px sans-serif'
                                }
                            }<%--,
                    {
                        type: 'line',
                        title: 'Absent',
                        strokeStyle: '#FCB441',
                        lineWidth: 2,
                        data: <%=(AbsentSeriesforLineChart)%>,
                        labels: {
                            stringFormat: '%d %',
                            font: '12px sans-serif'
                        }
                    }--%>
                        ]
                    });
                    //$('#jqLineChart').bind('tooltipFormat', function (e, data) {
                    //    return "<b>" + data.series.title + "</b><br />" +
                    //           "X = " + data.x + "<br />" +
                    //           "Y = " + data.y ;
                    //});
                });
            </script>


        </div>
    </form>
</body>
</html>
