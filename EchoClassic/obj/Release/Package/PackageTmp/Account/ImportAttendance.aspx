<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ImportAttendance.aspx.cs" Inherits="EchoClassic.Account.ImportAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div class="panel-heading">
            <h3 class="panel-title">Import
            </h3>
        </div>
 <div class="row">
        <div class="col-md-6">
           Please select an excel file: <asp:FileUpload ID="fuUploadAttendance" runat="server" />
        </div>
        <div class="col-md-3">
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div>
    </div>
</asp:Content>
