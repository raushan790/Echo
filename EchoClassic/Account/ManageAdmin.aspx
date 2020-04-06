<%@ Page Title="Manage Admin" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageAdmin.aspx.cs" Inherits="EchoClassic.Account.ManageAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Manage Admin
            </h3>
        </div>
        <div class="panel-body" style="background-color: #dedae699; width: 100%">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-9">
                    <label>Search User: </label>
                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserID"
                                    CssClass="text-danger" ErrorMessage="This Field is required" />
                          
                    <br />
                    <asp:Button ID="btnSearch" CssClass="btn" runat="server" Text="Search" OnClick="btnSearch_click" />

                </div>
                <div class="col-md-2">
                </div>
            </div>

        </div>
        <hr />
        <div class="panel-body">
            <div class="form-group row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <div id="form" runat="server">
                        <div style="overflow-x: scroll; overflow-y: scroll; max-height: 400px">
                            <asp:GridView ID="gvAdmin" runat="server" DataKeyNames="UserID" CssClass="table table-striped"
                                AutoGenerateColumns="false" OnRowCommand="gvAdmin_RowCommand" OnRowDataBound="gvAdmin_RowDataBound">
                                <%--OnRowCommand="gvAdmin_RowCommand"--%>
                                <Columns>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpwd" runat="server" Text='<%#Eval("PWD")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Changed Password">
                                        <ItemTemplate>
                                            <asp:Label ID="lblchangedpwd" runat="server" Text='<%# Eval("ChangedPassword")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Reset Password">
                                        <ItemTemplate>
                                            <asp:Button ID="btnResetPwd" Text="Reset Password" CssClass="btn" runat="server"
                                                CommandArgument='<%#Eval("UserID")%>' CommandName="ResetPwd"
                                                OnClientClick="javascript : return confirm('Are you sure! \nyou want to reset password for this user ?');" />
                                         <asp:Button ID="btnDeleteUser" Text="Delete" CssClass="btn" runat="server"
                                                CommandArgument='<%#Eval("UserID")%>' CommandName="DeleteUser"
                                                OnClientClick="javascript : return confirm('Are you sure! \nyou want to delete this user ?');" />
                                      </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>
            </div>

        </div>
        <hr />
        <div class="panel-heading" style="background-color: #dedae699; height: 5px;">
            <h5 class="panel-title" style="text-align: center"></h5>
        </div>
    </div>
</asp:Content>
