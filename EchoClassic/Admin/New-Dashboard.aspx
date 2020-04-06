<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New-Dashboard.aspx.cs" Inherits="EchoClassic.Admin.New_Dashboard" %>

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
                        <img src="../images/DashboardHeader1.JPG" style="width: 50%" class="img-responsive" />
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

                        <div class="row tile_count" style="display: none">
                            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-user"></i>Total Students</span>
                                <div class="count">2500</div>
                                <span class="count_bottom"></span>
                            </div>

                            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-male"></i>Total Males</span>
                                <div class="count green">2,500</div>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-female"></i>Total Females</span>
                                <div class="count">4,567</div>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-list-alt"></i>Total Districts</span>
                                <div class="count">2,315</div>
                            </div>
                            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                <span class="count_top"><i class="fa fa-list-alt"></i>Total Schools</span>
                                <div class="count">7,325</div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <div class="dashboard_graph">
                                    <div class="row x_title">
                                        <div class="row" style="padding-top: 5px">
                                            <div class="col-md-2">&nbsp</div>
                                            <div class="col-md-2" style="text-align: right">
                                                <h3>Select Date
                                                </h3>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtDate" ClientIDMode="Static" AutoPostBack="true" runat="server" CssClass="form-control" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">&nbsp</div>
                                        </div>
                                        <div class="row" style="height: 100px">
                                            <div id="divCountForDate" runat="server" class="row tile_count">
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-user"></i>Total Students</span>
                                                    <div class="count" style="font-size: 30px"><%=TotalStudentsonDate %></div>
                                                    <span class="count_bottom">Present: <%=TotalStudentsPresentonDate %></span>
                                                </div>

                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-user"></i>Total Males</span>
                                                    <div class="count green" style="font-size: 30px"><%=TotalMaleonDate %></div>
                                                    <span class="count_bottom">Present: <%=TotalMalePresentonDate %></span>
                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-female"></i>Total Females</span>
                                                    <div class="count" style="font-size: 30px"><%=TotalFemaleonDate %></div>
                                                    <span class="count_bottom">Present: <%=TotalFemalePresentonDate %></span>
                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-list-alt"></i>Total Districts</span>
                                                    <div class="count" style="font-size: 30px"><%=TotalDistrictonDate %></div>
                                                </div>
                                                <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                                                    <span class="count_top"><i class="fa fa-list-alt"></i>Total Schools</span>
                                                    <div class="count" style="font-size: 30px"><%=TotalSchoolonDate %></div>
                                                </div>
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
                        <br />
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320">
                                    <div class="x_title">
                                        <h2>Student's Attendance</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="jqChart"></div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320">
                                    <div class="x_title">
                                        <h2>Teacher's Attendance</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="jqChartTeacher"></div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320 overflow_hidden">
                                    <div class="x_title">
                                        <h2>Caste</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="CasteChart"></div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320">
                                    <div class="x_title">
                                        <h2>Gender</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="GenderChart"></div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320 overflow_hidden">
                                    <div class="x_title">
                                        <h2>Top 5</h2>

                                        <div class="clearfix"></div>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12">
                                <div class="x_panel tile fixed_height_320">
                                    <div class="x_title">
                                        <h2>Bottom 5</h2>

                                        <div class="clearfix"></div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="x_panel tile fixed_height_320">
                                    <div class="x_title">
                                        <h2>Earlier 10 days trend for Students</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="jqLineChart"></div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="x_panel tile fixed_height_320">
                                    <div class="x_title">
                                        <h2>Earlier 10 days trend for Teachers</h2>
                                        <div class="clearfix"></div>
                                    </div>
                                    <div id="jqLineChartTeacher"></div>
                                </div>
                            </div>

                        </div>

                        <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style="background: #fff;">
                                    <div class="row" style="overflow-y: scroll; max-height: 300px; padding-left: 10px;">
                                        <%--btn <asp:Button ID="btnPrintDistrict" runat="server" Text="Print" OnClientClick="PrintPage();" />
                                        --%>
                                        <h3>District</h3>
                                        <asp:GridView ID="gvDistrictLevel" runat="server" CssClass="table table-striped"
                                            AutoGenerateColumns="false" OnRowDataBound="gvDistrictLevel_Databound"
                                            OnRowCommand="gvDistrictLevel_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SLNo.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="District">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District")%>'></asp:Label>--%>
                                                        <asp:LinkButton ID="LinkDistrict" runat="server" CausesValidation="False"
                                                            CommandName="ViewDetails" Text='<%# Eval("District")%>'
                                                            CommandArgument='<%# Eval("District")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance Student">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalStudentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Attendance Teacher">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalTeacherDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalTeacherPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalTeacherAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageTeacherDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <div class="row" style="overflow-y: scroll; max-height: 300px; padding-left: 10px;">
                                        <h3 style="align-content: center">
                                            <asp:Literal ID="litDistrict" runat="server"></asp:Literal></h3>

                                        <asp:GridView ID="gvBlockLevel" runat="server" CssClass="table table-striped"
                                            AutoGenerateColumns="false" OnRowDataBound="gvBlockLevel_Databound"
                                            OnRowCommand="gvBlockLevel_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SLNo.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Block">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District")%>'></asp:Label>--%>
                                                        <asp:LinkButton ID="LinkBlock" runat="server" CausesValidation="False"
                                                            CommandName="ViewDetails" Text='<%# Eval("Block")%>'
                                                            CommandArgument='<%# Eval("Block")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance Student">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalStudentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Attendance Teacher">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalTeacherDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalTeacherPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalTeacherAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageTeacherDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <div class="row" style="overflow-y: scroll; max-height: 300px; padding-left: 10px;">
                                        <h3 style="align-content: center">
                                            <asp:Literal ID="litBlock" runat="server"></asp:Literal></h3>

                                        <asp:GridView ID="gvClusterLevel" runat="server" CssClass="table table-striped"
                                            AutoGenerateColumns="false" OnRowDataBound="gvClusterLevel_Databound"
                                            OnRowCommand="gvClusterLevel_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SLNo.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cluster">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District")%>'></asp:Label>--%>
                                                        <asp:LinkButton ID="LinkCluster" runat="server" CausesValidation="False"
                                                            CommandName="ViewDetails" Text='<%# Eval("Cluster")%>'
                                                            CommandArgument='<%# Eval("Cluster")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance Student">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalStudentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Attendance Teacher">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalTeacherDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalTeacherPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalTeacherAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageTeacherDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>



                                    <div class="row" style="overflow-y: scroll; max-height: 300px; padding-left: 10px;">
                                        <h3 style="align-content: center">
                                            <asp:Literal ID="litCluster" runat="server"></asp:Literal></h3>
                                        <asp:GridView ID="gvSchoolLevel" runat="server" CssClass="table table-striped"
                                            AutoGenerateColumns="false" OnRowDataBound="gvSchoolLevel_Databound"
                                            OnRowCommand="gvSchoolLevel_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SLNo.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="School">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("District")%>'></asp:Label>--%>
                                                        <asp:LinkButton ID="LinkSchool" runat="server" CausesValidation="False"
                                                            CommandName="ViewDetails" Text='<%# Eval("School")%>'
                                                            CommandArgument='<%# Eval("School")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance Student">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalStudentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Attendance Teacher">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalTeacherDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalTeacherPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalTeacherAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageTeacherDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <div class="row" style="overflow-y: scroll; max-height: 300px; padding-left: 10px;">
                                        <h3 style="align-content: center">
                                            <asp:Literal ID="litScholl" runat="server"></asp:Literal></h3>
                                        <asp:GridView ID="gvClassLevel" runat="server" CssClass="table table-striped"
                                            AutoGenerateColumns="false" OnRowDataBound="gvClassLevel_Databound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SLNo.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Class">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClass" runat="server"
                                                            Text='<%# Eval("Class")%>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance Student">
                                                    <ItemTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3">
                                                                <b>Total:</b>
                                                                <asp:Label ID="lblTotalStudentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Present:</b>
                                                                <asp:Label ID="lblTotalPresentDistrict" runat="server">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Absent:</b>
                                                                <asp:Label ID="lblTotalAbsentDistrict" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <b>Percentage:</b>
                                                                <asp:Label ID="lblPercentageDistrict" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
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
            <script>
                $(function () {
                    $("#txtDate").datepicker();
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

                        legend: { title: 'On <%=(DateSelected)%>' },
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
                                fillStyles: ['#FCB441', '#418CF0'],
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

            <script lang="javascript" type="text/javascript">
                $(document).ready(function () {


                    $('#jqChartTeacher').jqChart({

                        legend: { title: 'On <%=(DateSelected)%>' },
                        border: {
                            cornerRadius: 0,
                            lineWidth: 1,
                            strokeStyle: '#ffffff'
                        },
                        animation: { duration: 1 },
                        color: 'white',
                        shadows: {
                            enabled: true
                        },
                        series: [
                            {
                                type: 'pie',
                                fillStyles: ['#FCB441', '#418CF0'],
                                labels: {
                                    stringFormat: '%.1f%%',
                                    valueType: 'percentage',
                                    font: '15px sans-serif',
                                    fillStyle: 'white'
                                },
                                explodedRadius: 10,
                                explodedSlices: [5],
                                data: [['Absent', '<%=(PerAbsentTeacher)%>'], ['Present', '<%=(PerPresentTeacher)%>']]
                            }
                        ]
                    });

                    $('#jqChartTeacher').bind('tooltipFormat', function (e, data) {
                        var percentage = data.series.getPercentage(data.value);
                        percentage = data.chart.stringFormat(percentage, '%.2f%%');

                        return '<b>' + data.dataItem[0] + '</b><br />' + percentage;
                    });
                });
            </script>

            <%-- Cast Doughnut Chart--%>
            <script lang="javascript" type="text/javascript">
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
                                data: <%=(CasteSeries)%>,
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
            </script>

            <script lang="javascript" type="text/javascript">
                $(document).ready(function () {
                    //var series1=
                    $('#GenderChart').jqChart({
                        title: { text: 'Boys vs Girls' },
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
                                fillStyle: '#5B8C5B',
                                data: <%=(MaleSeries)%>,
                                labels: {
                                    stringFormat: '%d %'
                            
                                },
                        
                            },
                    {
                        type: 'column',
                        title: 'Female',
                        fillStyle: '#993399',
                        data: <%=(FemaleSeries)%>,
                        labels: {
                            stringFormat: '%d %'
                            
                        },
                        
                    }
                        ]
                    });

           
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

            <script lang="javascript" type="text/javascript">
                $(document).ready(function () {
                    $('#jqLineChartTeacher').jqChart({
               
                        legend: { visible: false },
                        border: {
                            cornerRadius: 0,
                            lineWidth: 1,
                            strokeStyle: '#ffffff'
                        },
                        animation: { duration: 1 },
                        axes: [
                            {
                                type: 'category',
                                location: 'bottom',
                                categories: <%=(DateSeriesTeacher)%>,
                                labels: {
                            
                           
                                    visible:false
                                }
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
                                data: <%=(PresentSeriesforLineChartTeacher)%>,
                                labels: {
                                    stringFormat: '%d %',
                                    font: '12px sans-serif'
                                }
                            }
                        ]
                    });
                   
                });
            </script>
        </div>
    </form>
</body>
</html>
