<%@ Page Title="Manage Governing Body" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageGoverning.aspx.cs" Inherits="EchoClassic.Admin.ManageGoverning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtGovName.ClientID%>").value == "") {
                alert("Please Enter Governing Body Name");
                document.getElementById("<%=txtGovName.ClientID%>").focus();
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
            if (document.getElementById("<%=txtMobile.ClientID%>").value == "") {
                alert("Enter your Mobile number");
                document.getElementById("<%=txtMobile.ClientID%>").focus();
                return false;
            }

        }
        <%--function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
            checkDelBtn()
        }
        function checkDelBtn() {
            var GridView = document.getElementById("<%=gvClients.ClientID%>").parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            var isChecked = false;
            for (var i = 0; i < inputList.length; i++) {
                if (inputList[i].type == "checkbox") {
                    if (inputList[i].checked)
                        isChecked = true;
                }
            }
            if (isChecked)
                document.getElementById("<%=Button1.ClientID%>").removeAttribute("disabled");
            else
                document.getElementById("<%=Button1.ClientID%>").setAttribute("disabled","");
        }--%>
    </script>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="container">
        <div class="row">
            <h4>Add/Edit Governing Body</h4>
            <hr />
            <div class="col-sm-12 col-md-12 col-lg-12 col-xs-12">
                <div class="form-group row">
                    <div class="form-group">
                        <asp:Literal ID="litGovID" runat="server" Visible="false"></asp:Literal>
                        <asp:Literal ID="litAdminID" runat="server" Visible="false"></asp:Literal>
                        <label for="txtOrganizationName" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Governing Body Name:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtGovName"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtEmail" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Email:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtEmail"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtContactPersonName" class="col-sm-4 control-label" style="margin-top: 5px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Contact Person Name:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtContactPersonName"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtMobile" class="col-sm-4 control-label" style="margin-top: 5px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Mobile Number:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtMobile"></asp:TextBox>
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
                        <asp:Button ID="btnSaveGov" runat="server" OnClientClick=" return validate()"
                            CssClass="btn btn-default" Text="Save" OnClick="btnSaveGov_Click" TabIndex="10" />
                        <asp:Button ID="btnClear" Visible="false" runat="server" CssClass="btn btn-default" Text="Clear" TabIndex="11" OnClick="btnClearGov_Click" />
                    </div>
                </div>
                
                <hr />
            </div>
        </div>
        <div class="form-group row">
            <h4>Governing Body List</h4>
            <%--<asp:Button ID="Button1" runat="server" OnClientClick="javascript : return confirm('Are you sure \nyou want to delete this Client ?');" Text="Bulk Delete" OnClick="Button1_Click" style="float:right" disabled/>--%>
            <hr />
            
            <asp:GridView ID="gvGov" runat="server"
                CssClass="table table-striped table-fit" AutoGenerateColumns="false"
                OnRowDeleting="gvGov_RowDeleting" OnRowCommand="gvGov_RowCommand">
                <Columns>
                    <%--<asp:TemplateField>
                        <HeaderTemplate>  
                            <asp:CheckBox ID="ChkHead" runat="server" onclick="checkAll(this)"/> 
                        </HeaderTemplate>  
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkItems" runat="server" onclick="checkDelBtn()" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="SLNo.">
                        <ItemTemplate>
                            <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Total Groups">
                        <ItemTemplate>
                            <asp:Label ID="GroupCount" runat="server" Text='<%# Eval("GroupCount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Member">
                        <ItemTemplate>
                            <asp:Label ID="TotalMemberCount" runat="server" Text='<%# Eval("TotalMemberCount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Active Member">
                        <ItemTemplate>
                            <asp:Label ID="ActiveCount" runat="server" Text='<%# Eval("ActiveCount") %>'></asp:Label>
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
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="GovID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="GovID" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Governing Body Name">
                        <ItemTemplate>
                            <asp:Label ID="lblGoverningBodyName" runat="server"
                                Text='<%#  Eval("FullName") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server"
                                    Text='<%# Eval("Address") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Contact Person">
                        <ItemTemplate>
                            <asp:Label ID="lblContactPersonName"
                                runat="server" Text='<%#Eval("ContactPerson") %>'></asp:Label>

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
                    <asp:TemplateField HeaderText="Join Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("CreateDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbkEdit" runat="server" CausesValidation="False"
                                CommandName="EditGov" Text="Edit" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                OnClientClick="javascript : return confirm('Are you sure \nyou want to delete this Governing Body ?');"
                                CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <hr />
        </div>
        
    </div>
</asp:Content>
