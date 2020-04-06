<%@ Page Title="Upload Attendance" Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="addAttendance.aspx.cs" Inherits="EchoClassic.Admin.addAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


 <div class="container">
        <h4>Upload Biometric Attendance</h4>
        <hr />
        <div class="form-group row">
            <asp:Literal ID="litClientID" runat="server" Visible="false"></asp:Literal>
            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                <div class="form-group row">
                    <div class="form-group">
                        <asp:Literal ID="litGroupID" runat="server" Visible="false"></asp:Literal>
                        <label class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Upload File (.csv):</label>
                        <div class="col-sm-8">
                            <asp:FileUpload CssClass="form-control input-sm" accept=".csv"
                                runat="server" ID="fuAddAttendance"
                                placeholder="Put the Company Name here"></asp:FileUpload>
                        </div>
                    </div>
                </div>

                <div class="form-group row">
                    <div class="form-group" align="center">
                        <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-default" Text="Upload"
                            OnClick="btnUpload_Click" TabIndex="10" />
                    </div>
                </div>

            </div>

        </div>
    </div>
    
</asp:Content>