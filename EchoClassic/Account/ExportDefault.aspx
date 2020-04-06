<%@ Page Title="Export Data" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ExportDefault.aspx.cs" Inherits="EchoClassic.Account.ExportDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default" style="padding-top: 50px">
        <div class="panel-heading">
            <h3 class="panel-title">Export Data in Excel
            </h3>
        </div>
        <hr />
        <div class="panel-body">
            <div class="form-group row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <asp:DropDownList ID="ddlOption" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Schools not reported" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Schools Reported" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Schools Changed Password" Value="3"></asp:ListItem>

                    </asp:DropDownList>
                      <br />
                    <asp:Button ID="btnExport" runat="server" CssClass="btn btn-default btn-sm" Text="Export to Excel" OnClick="btnExport_Click" />
                </div>
                <div class="col-md-1"></div>
            </div>

        </div>
        <hr />
        <div class="panel-heading" style="background-color: #dedae699; height: 30px;">
            <h5 class="panel-title" style="text-align: center"></h5>
        </div>

    </div>
</asp:Content>
