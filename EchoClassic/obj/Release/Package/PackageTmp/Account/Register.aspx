<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EchoClassic.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div id="divFormSection" runat="server" class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group" style="display: none;">
            <asp:Label runat="server" AssociatedControlID="txtCouponCode" CssClass="col-md-2 control-label">Coupon Code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCouponCode" CssClass="form-control" TextMode="Number" MaxLength="12" Enabled="false" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCouponCode"
                    CssClass="text-danger" ErrorMessage="The Coupon Code field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                    CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Literal ID="litUserID" runat="server" Visible="false"></asp:Literal>
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
               
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtMobile" CssClass="col-md-2 control-label">Mobile</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMobile"
                    CssClass="text-danger" ErrorMessage="The Mobile number field is required." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Confirm" CssClass="btn btn-default" />
            </div>
        </div>
    </div>

    <div id="divOtpSection" runat="server" visible="false" class="form-horizontal">
        <asp:Label ID="lblOTPMessage" runat="server" Text="We have send OTP to mobile and email provided please enter the OTP below"></asp:Label>
        <h4>Validate OTP</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCouponCode" CssClass="col-md-2 control-label">OTP</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOtp" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtOtp"
                    CssClass="text-danger" ErrorMessage="The OTP field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Literal ID="litChk" runat="server" Visible="false"></asp:Literal>
                <asp:Button runat="server" OnClick="OTPValidate_Click" Text="Submit" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
