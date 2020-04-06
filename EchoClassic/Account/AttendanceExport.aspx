<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AttendanceExport.aspx.cs" Inherits="EchoClassic.Account.AttendanceExport" %>

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
                    Select Client Name:<br />
                    <asp:DropDownList ID="ddlClients" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                </div>
            </div>
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
            <div class="form-group row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <div id="form" runat="server">
                        <asp:GridView ID="gvAttendance" runat="server" CssClass="table table-striped"></asp:GridView>
                    </div>
                </div>
                <div class="col-md-1"></div>
            </div>

        </div>
        <hr />
        <div class="panel-heading" style="background-color: #dedae699; height: 30px;">
            <h5 class="panel-title" style="text-align: center">A</h5>
        </div>
    </div>

</asp:Content>
