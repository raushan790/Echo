<%@ Page Title="Clients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="EchoClassic.Admin.Clients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtOrganizationName.ClientID%>").value == "") {
                alert("Please Enter Organization Name");
                document.getElementById("<%=txtOrganizationName.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtContactPersonName.ClientID%>").value == "") {
                alert("Please Enter Contact Person Name");
                document.getElementById("<%=txtContactPersonName.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtEmail.ClientID%>").value == "") {
                alert("Enter your Email Id");
                document.getElementById("<%=txtEmail.ClientID%>").focus();
                return false;
            }

        }
    </script>
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">New Client
            </h3>
            <p>Please Fill the below form to Complete your registration. We will get back to you soon.</p>
        </div>
        <div class="panel-body" style="background-color: #dedae699; width: 100%">
        </div>
        <hr />
        <div class="panel-body">
            <div class="form-group row">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtOrganizationName" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                Organization Name:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtOrganizationName"
                                    TabIndex="1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtEmail" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                Email:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtEmail"
                                    TabIndex="3"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtAddress" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                Address:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtAddress" TabIndex="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtState" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                State:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtState"
                                    TabIndex="7"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtUsersAllowedCount" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                No of Users Allowed:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtUsersAllowedCount"
                                    Rows="3" TabIndex="9"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtContactPersonName" class="col-sm-4 control-label" style="margin-top: 5px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                Contact Person Name:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtContactPersonName"
                                    TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtMobile" class="col-sm-4 control-label" style="margin-top: 5px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                Mobile Number:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtMobile" TabIndex="4"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtCity" class="col-sm-4 control-label" style="text-align: -moz-right; margin-top: 5px; font-family: Cambria; font-size: 16px">
                                City:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtCity"
                                    TabIndex="6"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group">
                            <label for="txtMembersCount" class="col-sm-4 control-label" style="text-align: -moz-right; margin-top: 5px; font-family: Cambria; font-size: 16px">
                                No of Members:</label>
                            <div class="col-sm-8">
                                <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtMembersCount" TabIndex="8"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="form-group">
                            <asp:Button ID="btnSaveClient" runat="server" OnClientClick=" return validate()" CssClass="btn btn-default" Text="Save" OnClick="btnSaveClient_Click" TabIndex="10" />
                            <asp:Button ID="btnClear" runat="server" CssClass="btn btn-default" Text="Clear" TabIndex="11" OnClick="btnClearClient_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <%--<div class="form-group row">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    &nbsp
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12" style="text-align: center">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" Text="Save" />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" Text="Clear" />
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    &nbsp
                </div>
            </div>--%>
        </div>
        <hr />
        <div class="panel-heading" style="background-color: #dedae699; height: 30px;">
            <h5 class="panel-title" style="text-align: center"></h5>
        </div>
    </div>
    
</asp:Content>
