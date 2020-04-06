<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="IssueCoupon.aspx.cs" Inherits="EchoClassic.Admin.IssueCoupon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div id="divFormSection" runat="server" class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCouponCode" CssClass="col-md-2 control-label">Coupon Code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCouponCode" CssClass="form-control" Enabled="false" />
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
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
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
            <asp:Label runat="server" AssociatedControlID="ddlGroup" CssClass="col-md-2 control-label">Group</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" Width="280px" ></asp:DropDownList>
                
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="IssueCoupon_Click" Text="Issue Coupon" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
