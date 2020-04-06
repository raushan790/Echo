<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="EchoClassic.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <asp:Literal ID="litChk" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="litUserID" runat="server" Visible="false"></asp:Literal>
        <div class="form-horizontal">

            <hr />
            <asp:Panel ID="pnlOTP" runat="server">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email/Mobile</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ValidationGroup="grpOTP" ID="Email" CssClass="form-control" />
                        <asp:RequiredFieldValidator ValidationGroup="grpOTP" runat="server" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="Please enter registered email or mobile number." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtRecoveryMobile" CssClass="col-md-2 control-label">Recovery Mobile No.</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ValidationGroup="grpOTP" ID="txtRecoveryMobile" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="grpOTP" ControlToValidate="txtRecoveryMobile"
                            CssClass="text-danger" ErrorMessage="Please enter the recovery mobile number registered with account." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" ValidationGroup="grpOTP" OnClick="SendOTP" Text="Get OTP" CssClass="btn btn-default" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlPWD" runat="server" Visible="false">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtOTP" CssClass="col-md-2 control-label">OTP</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ValidationGroup="grpPWD" ID="txtOTP" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="grpPWD" ControlToValidate="txtOTP"
                            CssClass="text-danger" ErrorMessage="Please enter OTP." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Password" ValidationGroup="grpPWD" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="grpPWD" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                        <asp:RegularExpressionValidator ID="regPWD" CssClass="text-danger" ControlToValidate="Password" ValidationGroup="grpPWD" runat="server" ValidationExpression="^([a-zA-Z0-9@*#]{6,15})$" ErrorMessage="Password must contain at least 6 characters"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="ConfirmPassword" ValidationGroup="grpPWD" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="grpPWD" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator runat="server" ValidationGroup="grpPWD" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <p>If you want to use different registered username or associated mobile please refresh the page</p>
                        <asp:Button runat="server" OnClick="SendOTP" ValidationGroup="grpOTP" Text="Resend OTP" CssClass="btn btn-default" />
                        <asp:Button runat="server" OnClick="Reset_Click" ValidationGroup="grpPWD" Text="Submit" CssClass="btn btn-secondary" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
