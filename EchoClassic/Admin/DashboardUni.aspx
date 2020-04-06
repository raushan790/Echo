<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardUni.aspx.cs" Inherits="EchoClassic.Admin.DashboardUni" %>

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
</head>
<body class="nav-md">
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
        <div>
            <header style="background-color: white">
                <div class="row">
                    <div class="col-md-6">
                        <h1>
                            <asp:Image ID="imgGroup" runat="server" CssClass="img-responsive" />
                        </h1>
                    </div>
                    <div class="col-md-6 pull-right">
                        <img src="../images/DashboardHeader2.JPG" style="float: right; width: 40%" class="img-responsive" />
                    </div>
                </div>
                <div class="nav_menu" style="height: 48px">
                    <nav>
                        <ul class="nav navbar-nav navbar-right">
                            <li class="">
                                <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    <img src="images/user.png" alt="" />Administrator
                                        <span class=" fa fa-angle-down"></span>
                                </a>
                                <ul class="dropdown-menu dropdown-usermenu pull-right">
                                    <li><a href="javascript:;">Profile</a></li>

                                    <li><a href="../contact">Help</a></li>
                                    <li><a href="../logout"><i class="fa fa-sign-out pull-right"></i>Log Out</a></li>
                                </ul>
                            </li>
                        </ul>
                    </nav>
                </div>
            </header>
            <div class="container body">
                <div class="main_container">
                    <div class="right_col" role="main">

                        <h1>Dashboard</h1>
                        <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Literal ID="litClientID" runat="server" Visible="false"></asp:Literal>
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="dashboard_graph">
                                            <div class="row x_title">
                                                <div class="row" style="padding-top: 5px">


                                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                                        <asp:DropDownList ID="ddlClass" AutoPostBack="true" OnSelectedIndexChanged="ddlClassSelectedIndexChanged" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="MBBS 1st Year" Value="MBBS 1st Year"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-1 col-sm-1 col-xs-12" style="text-align: right">
                                                    </div>
                                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                                        <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectSelectedIndexChanged">
                                                            <asp:ListItem Text="Anatomy" Value="121892"></asp:ListItem>
                                                            <asp:ListItem Text="Biochemistry" Value="121893"></asp:ListItem>
                                                            <asp:ListItem Text="Physiology" Value="121894"></asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-1 col-sm-1 col-xs-12" style="text-align: right">
                                                    </div>
                                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                                        <asp:TextBox ID="txtDateFrom" TextMode="Date" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="FromDateChanged">
                                                           
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1 col-sm-1 col-xs-12" style="text-align: right">
                                                    </div>
                                                    <div class="col-md-2 col-sm-2 col-xs-12">
                                                        <asp:TextBox ID="txtDateTo" TextMode="Date" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="ToDateChanged">
                                                           
                                                        </asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>

                                <div style="background: #fff;">
                                    <div class="row" style="overflow-y: scroll; max-height: 300px; padding-left: 10px;">
                                        <%--btn <asp:Button ID="btnPrintDistrict" runat="server" Text="Print" OnClientClick="PrintPage();" />
                                        --%>
                                        <h3>Attendance Status</h3>
                                        <asp:GridView ID="gvAttendanceStatus" runat="server"
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
                                    </div>

                                </div>

                                <div class="clearfix"></div>

                                <div style="background: #fff;">
                                    <div class="row" style="overflow-y: scroll; max-height: 300px; padding-left: 10px;">
                                        <%--btn <asp:Button ID="btnPrintDistrict" runat="server" Text="Print" OnClientClick="PrintPage();" />
                                        --%>
                                        <h3>Attendance Details for 
                                            <asp:Literal ID="litStudentName" runat="server"></asp:Literal>

                                        </h3>
                                        <asp:GridView ID="gvAttendanceDetails" runat="server"
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

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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

        </div>
    </form>
</body>
</html>
