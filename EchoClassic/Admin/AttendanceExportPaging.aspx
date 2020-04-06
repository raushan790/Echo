<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AttendanceExportPaging.aspx.cs" Inherits="EchoClassic.AttendanceExportPaging" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Export Attendance
            </h3>
        </div>
        <div class="panel-body" style="background-color: #dedae699; width: 100%">
            <div class="row">
                <div class="col-md-1">&nbsp</div>
                <div class="col-md-3">
                    From Date:<br />
                    <div class="form-group">


                        <asp:TextBox ID="txtdtFrom" TextMode="Date" runat="server" CssClass="form-control input-sm"></asp:TextBox>


                    </div>


                </div>

                <div class="col-md-3">
                    To Date:<br />
                    <asp:TextBox ID="txtdtTo" runat="server" TextMode="Date" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <br />
                <div class="col-md-5">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default btn-sm" OnClick="btnSearch_Click" />
                    &nbsp
                    <asp:Button ID="Button1" runat="server" Text="Export to Excel" CssClass="btn btn-default btn-sm" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
        <hr />
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2">&nbsp</div>
                <div class="col-md-8">
                    <div id="pagenavigation" runat="server">
                        <div class="row" style="background-color: #e2dfdf; margin-left: 20px; border: 1px solid gray; padding: 2px">
                            <div class="col-md-2" style="text-align: left; font-weight: bold">
                                <asp:LinkButton ID="btnFirst" ToolTip="First" runat="server" CommandArgument="First" CommandName="Page"
                                    OnClick="btnFirst_OnClick" CssClass="buttonStyle" Width="40px"><span><span><<</span></span></asp:LinkButton>
                                <asp:LinkButton ID="btnPrev" ToolTip="Prev" runat="server" CommandArgument="Prev" CommandName="Page"
                                    Text="<" OnClick="btnPrev_OnClick" CssClass="buttonStyle" Width="40px"><span><span><</span></span></asp:LinkButton>
                            </div>

                            <div class="col-md-8" style="text-align: center">
                                <asp:DropDownList ID="DDLPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPage_SelectedIndexChanged"
                                    Width="50px">
                                </asp:DropDownList>
                                <asp:Label ID="lblCurrent" runat="server"></asp:Label>
                                of
                                                        <asp:Label ID="lblPages" runat="server"></asp:Label>
                                Pages
                            </div>

                            <div class="col-md-2" style="text-align: right; font-weight: bold">
                                <asp:LinkButton ID="btnNext" ToolTip="Next" OnClick="btnNext_OnClick" CommandArgument="Next" runat="server"
                                    CssClass="buttonStyle" Width="40px"><span><span>></span></span></asp:LinkButton>
                                <asp:LinkButton ID="btnLast" ToolTip="Last" OnClick="btnLast_OnClick" CommandArgument="Last" runat="server"
                                    CssClass="buttonStyle" Width="40px"><span><span>>></span></span></asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2">&nbsp</div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <div id="form" runat="server">
                        <asp:GridView ID="gvAttendance" AutoGenerateColumns="false" runat="server" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="UserID" />
                                <asp:BoundField DataField="RollNo" HeaderText="RollNo" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                <asp:BoundField DataField="Cast" HeaderText="Cast" />
                                <asp:BoundField DataField="GroupName" HeaderText="GroupName" />
                                <asp:BoundField DataField="AttendanceDate" HeaderText="AttendanceDate" />
                                <asp:BoundField DataField="AttendanceStatus" HeaderText="AttendanceStatus" />
                                <asp:BoundField DataField="Count" HeaderText="Count" />
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="col-md-1"></div>
            </div>



        </div>
        <hr />

    </div>
</asp:Content>
