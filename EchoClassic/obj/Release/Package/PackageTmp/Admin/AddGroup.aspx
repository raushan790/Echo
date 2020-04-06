<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddGroup.aspx.cs" Inherits="EchoClassic.Admin.AddGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtGroupName.ClientID%>").value == "") {
                alert("Please Enter Group Name");
                document.getElementById("<%=txtGroupName.ClientID%>").focus();
                return false;
            }


        }
    </script>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="container">
        <h4>Add/Edit Group</h4>
        <hr />
        <div class="form-group row">
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group row">
                    <div class="form-group">
                        <asp:Literal ID="litGroupID" runat="server" Visible="false"></asp:Literal>
                        <label for="txtGroupName" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Group Name:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm"
                                runat="server" ID="txtGroupName"
                                TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtDescription" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Description:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtDescription"
                                TabIndex="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtType" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Type:</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlFlowType" runat="server">
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>




                <div class="form-group row">
                    <div class="form-group" align="center">
                        <asp:Button ID="btnSaveGroup" runat="server" OnClientClick=" return validate()" CssClass="btn btn-default" Text="Save"
                            OnClick="btnSaveGroup_Click" TabIndex="10" />
                        <asp:Button ID="btnClear" runat="server" CssClass="btn btn-default" Text="Clear" TabIndex="11" OnClick="btnClearClient_Click" />
                    </div>
                </div>

            </div>
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12"
                style="overflow-y: scroll; max-height: 300px;">
                <asp:GridView ID="gvGroups" runat="server"
                    CssClass="table table-striped table-fit" AutoGenerateColumns="false"
                    OnRowDeleting="gvGroups_RowDeleting" OnRowCommand="gvGroups_RowCommand">
                    <Columns>

                        <asp:TemplateField HeaderText="SLNo.">
                            <ItemTemplate>
                                <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GroupID">
                            <ItemTemplate>
                                <asp:Label ID="lblGroupID" runat="server"
                                    Text='<%#  Eval("GroupID") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Group Name">
                            <ItemTemplate>
                                <asp:Label ID="lblGroupNameName" runat="server"
                                    Text='<%#  Eval("GroupName") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server"
                                    Text='<%# Eval("Description") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbkEdit" runat="server" CausesValidation="False"
                                    CommandName="EditGroup" Text="Edit" CommandArgument='<%# Eval("GroupID") %>'></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                    OnClientClick="javascript : return confirm('Are you sure \nyou want to delete this User ?');"
                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>

       
    </div>
</asp:Content>
