<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageClients.aspx.cs" Inherits="EchoClassic.Admin.ManageClients" %>

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
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="container">
        <h4>Add/Edit Client</h4>
        <hr />
        <div class="form-group row">
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group row">
                    <div class="form-group">
                        <asp:Literal ID="litClientID" runat="server" Visible="false"></asp:Literal>
                        <asp:Literal ID="litAdminID" runat="server" Visible="false"></asp:Literal>
                        <label for="txtOrganizationName" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Organization Name:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtOrganizationName"
                                ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtEmail" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Email:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtEmail"
                                ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtAddress" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Address:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtAddress" 
                                ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtState" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            State:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtState"
                                ></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtContactPersonName" class="col-sm-4 control-label" style="margin-top: 5px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Contact Person Name:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtContactPersonName"
                                ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtMobile" class="col-sm-4 control-label" style="margin-top: 5px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Mobile Number:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtMobile" 
                                ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtCity" class="col-sm-4 control-label" style="text-align: -moz-right; margin-top: 5px; font-family: Cambria; font-size: 16px">
                            City:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtCity"
                               ></asp:TextBox>
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
                <div class="form-group row">
                    <div class="form-group" align="center">
                        <asp:Button ID="btnSaveClient" runat="server" OnClientClick=" return validate()" CssClass="btn btn-default" Text="Save" OnClick="btnSaveClient_Click" TabIndex="10" />
                        <asp:Button ID="btnClear" runat="server" CssClass="btn btn-default" Text="Clear" TabIndex="11" OnClick="btnClearClient_Click" />
                    </div>
                </div>

            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12"
                style="overflow-y: scroll; max-height: 300px;">
                <asp:GridView ID="gvClients" runat="server"
                    CssClass="table table-striped table-fit" AutoGenerateColumns="false"
                    
                    OnRowDeleting="gvClients_RowDeleting" OnRowCommand="gvClients_RowCommand">
                    <Columns>

                        <asp:TemplateField HeaderText="SLNo.">
                            <ItemTemplate>
                                <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ClientID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="ClientID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add Group">
                            <ItemTemplate>
                                <a href="/admin/AddGroup?ClientID=<%# Eval("ID") %>">Add Group</a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Organization Name">
                            <ItemTemplate>
                                <asp:Label ID="lblOrganizationName" runat="server"
                                    Text='<%#  Eval("OrganizationName") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server"
                                    Text='<%# Eval("Address") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact Person">
                            <ItemTemplate>
                                <asp:Label ID="lblContactPersonName"
                                    runat="server" Text='<%#Eval("ContactPersonName") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile">
                            <ItemTemplate>
                                <asp:Label ID="lblMobileNo" runat="server"
                                    Text='<%#Eval("MobileNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbkEdit" runat="server" CausesValidation="False"
                                    CommandName="EditClient" Text="Edit" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                    OnClientClick="javascript : return confirm('Are you sure \nyou want to delete this Client ?');"
                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
