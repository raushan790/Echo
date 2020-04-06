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
    <div class="panel panel-default">
        <div class="row" style="background-color: white">
            <div class="col-md-1">
                <img src="images/logoecho.png" alt="Features" />
            </div>
            <div class="col-md-11">
                &nbsp
            </div>
        </div>
        <div class="row">
            <div style="background-color: #666467; height: 85px">
                <div class="col-md-1">
                    &nbsp
                </div>
                <div class="col-md-11">
                    <h1 style="color: white; font-size: 55px">New Client</h1>
                </div>
            </div>
        </div>
        <div class="panel-heading">
            <%-- <h3 class="panel-title">New Client
            </h3>--%>
            <%--<p>Please Fill the below form to Complete your registration. We will get back to you soon.</p>--%>
        </div>
    </div>
    <div class="panel-body">
        <div class="form-group row">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                <%-- <img src="/images/clients.jpg" />--%>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="border: 1px solid #e3e3e3; padding-top: 20px;">
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtOrganizationName" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Organization Name:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtOrganizationName"
                                TabIndex="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="gc" runat="server"
                                ControlToValidate="txtOrganizationName"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Please enter organization name" />
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtContactPersonName" class="col-sm-4 control-label" style="margin-top: 5px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Contact Person Name:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtContactPersonName"
                                TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="gc" runat="server"
                                ControlToValidate="txtContactPersonName"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Please enter contact person name" />
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtMobile" class="col-sm-4 control-label" style="margin-top: 5px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Mobile Number:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtMobile"
                                TabIndex="3" MaxLength="11" placeholder="This is will be your login Id"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="gc" runat="server"
                                ControlToValidate="txtMobile"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Mobile number is required." />
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtEmail" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Email:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtEmail"
                                TabIndex="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="gc" runat="server" ControlToValidate="txtEmail"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The email field is required." />

                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtPwd" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Password:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtPwd"
                                TabIndex="5" ValidationGroup="gc" TextMode="Password" placeholder="This is will be your password"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="gc" runat="server" ControlToValidate="txtPwd"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtConfirmPwd" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Confirm password:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtConfirmPwd"
                                TabIndex="6" ValidationGroup="gc" TextMode="Password"></asp:TextBox>

                            <asp:RequiredFieldValidator runat="server" ValidationGroup="gc" ControlToValidate="txtConfirmPwd"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                            <asp:CompareValidator runat="server" ValidationGroup="gc" ControlToCompare="txtPwd" ControlToValidate="txtConfirmPwd"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />

                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="fuLogo" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Logo/Image:</label>
                        <div class="col-sm-8">
                            <asp:FileUpload ID="fuLogo" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="form-group row" style="display: none">
                    <div class="form-group">
                        <label for="txtAddress" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Address:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtAddress" TabIndex="5"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row" style="display: none">
                    <div class="form-group">
                        <label for="txtState" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            State:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtState"
                                TabIndex="7"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div class="form-group row" style="display: none">
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
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12"></div>
                    <div class="form-group">
                        <asp:Button ID="btnSaveClient" ValidationGroup="gc" runat="server"
                            CssClass="btn btn-default" Text="Register" OnClick="btnSaveClient_Click" TabIndex="10" />
                        <asp:Button ID="btnClear" Visible="false" runat="server" CssClass="btn btn-default" Text="Clear" TabIndex="11" OnClick="btnClearClient_Click" />
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12"></div>
                </div>


            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12"></div>
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

    <div class="panel-heading" style="background-color: #dedae699; height: 30px;">
        <h5 class="panel-title" style="text-align: center"></h5>
    </div>
</asp:Content>
