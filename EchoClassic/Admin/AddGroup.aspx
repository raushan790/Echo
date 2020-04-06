<%@ Page Title="Add or Edit Groups" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddGroup.aspx.cs" Inherits="EchoClassic.Admin.AddGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/Popup/animate.min.css" rel="stylesheet" />
    <link href="css/Popup/jAlert-v3.css" rel="stylesheet" />
    <script src="js/Popup/jAlert-v3.js"></script>
    <script src="js/Popup/jAlert-functions.js"></script>
    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtGroupName.ClientID%>").value == "") {
                alert("Please Enter Group Name");
                document.getElementById("<%=txtGroupName.ClientID%>").focus();
                return false;
            }
            else if (document.getElementById("<%=txtDescription.ClientID%>").value == "") {
                alert("Please Enter Group Description");
                document.getElementById("<%=txtDescription.ClientID%>").focus();
                return false;
            }

    }
    </script>
    <%--<asp:UpdateProgress ID="updateProgress" runat="server" AssociatedUpdatePanelID="up1"
        DisplayAfter="0">
        <ProgressTemplate>
            <div class="invisible_layer" id="processMessage">
                <div class="transparent_bg">
                </div>
                <div class="loadingbar">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="container">
        <h4>Add/Edit Group</h4>
        <hr />

        <%-- <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>
        <div class="form-group row">
            <asp:Literal ID="litClientID" runat="server" Visible="false"></asp:Literal>
            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                <div class="form-group row">
                    <div class="form-group">
                        <asp:Literal ID="litGroupID" runat="server" Visible="false"></asp:Literal>
                        <label for="txtGroupName" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Group Name:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm"
                                runat="server" ID="txtGroupName" MaxLength="20"
                                placeholder="Put the Company Name here"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <asp:Literal ID="litDepartment" runat="server" Visible="false"></asp:Literal>
                        <label for="txtDepartment" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Department:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm"
                                runat="server" ID="txtDepartment" MaxLength="20"
                                Text="DefDepartment"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <asp:Literal ID="litSubDepartment" runat="server" Visible="false"></asp:Literal>
                        <label for="txtSubDepartment" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Sub-Department</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm"
                                runat="server" ID="txtSubDepartment" MaxLength="20"
                                Text="DefSubDepartment"></asp:TextBox>
                        </div>
                    </div>
                </div>               
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtDescription" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Description:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtDescription"
                                MaxLength="20" placeholder="Put the Group Display name here"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtStartTime" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Start Time:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="TxtStartTime"
                                MaxLength="20" placeholder="Start Time"></asp:TextBox>
                        </div>
                    </div>
                </div>
                  <div class="form-group row">
                    <div class="form-group">
                        <label for="txtEndTime" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            End Time:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtEndTime"
                                MaxLength="20" placeholder="End Time"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtGraceTime" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Grace Time:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtGraceTime"
                                MaxLength="20" placeholder="Grace Time"></asp:TextBox>
                        </div>
                    </div>
                </div>
                 <div class="form-group row">
                    <div class="form-group">
                        <label for="txtNoOfClasses" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                           No Of Classes:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtNoOfClasses"
                                MaxLength="20" placeholder="No Of Classes"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="form-group">
                        <label for="txtType" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Type:</label>
                        <div class="col-sm-8">
                            <asp:DropDownList Style="max-width: 280px" CssClass="form-control input-sm" ID="ddlFlowType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFlowType_change">
                                <asp:ListItem Text="Classroom Attendance" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Attendance with code" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Offline Attendance with code" Value="5"></asp:ListItem>

                                <asp:ListItem Text="Self Attendance" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Checkin and Checkout" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <asp:Panel class="form-group row" ID="pnlSelfAttendanceOption" runat="server" Visible="false">
                    <div class="form-group">
                        <label for="txtType" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Select Option:</label>
                        <div class="col-sm-8">
                            <asp:DropDownList Style="max-width: 280px" CssClass="form-control" ID="ddlSelfAttendanceOption" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSelfAttendanceOption_change">
                                 <asp:ListItem Text="Geo location" Value="1"></asp:ListItem>
                                <asp:ListItem Text="With geo fencing" Value="2"></asp:ListItem>
                                <asp:ListItem Text="With wifi tagging" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlGeoLocation" class="form-group row" runat="server" Visible="false">
                    <div class="form-group">
                        <label for="txtGeoLocation" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            Geo Location:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtGeoLocation"
                                MaxLength="50" placeholder="Put the geo location here"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlWifiID" class="form-group row" runat="server" Visible="false">
                    <div class="form-group">
                        <label for="txtWifiID" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                            WIFI MAC ID:</label>
                        <div class="col-sm-8">
                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtWifiID"
                                MaxLength="50" placeholder="Put the WIFI MAC ID here"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>

                <div class="form-group row">
                    <div class="form-group" align="center">
                        <asp:Button ID="btnSaveGroup" runat="server" OnClientClick=" return validate()" CssClass="btn btn-default" Text="Save"
                            OnClick="btnSaveGroup_Click" TabIndex="10" />
                        <asp:Button ID="btnClear" Visible="false" runat="server" CssClass="btn btn-default" Text="Clear" TabIndex="11" OnClick="btnClearClient_Click" />
                    </div>
                </div>

            </div>

            <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12"
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
                        <asp:TemplateField HeaderText="GroupID" Visible="false">
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

                        <asp:TemplateField HeaderText="Action">

                            <ItemTemplate>
                                <a href="#" id="a<%# Eval("GroupID") %>" title="Add or View Group Members" style="text-decoration: none"><i class="fa fa-users" aria-hidden="true"></i></a>
                                <script>

                                    $('#a<%# Eval("GroupID") %>').alertOnClick({
                                        'iframe': '/admin/AddMember?GroupID=<%# Eval("GroupID") %>',
                                        'size': 'xlg'
                                    });

                                </script>
                                <asp:LinkButton ID="lbkEdit" ToolTip="Edit" runat="server" CausesValidation="False"
                                    CommandName="EditGroup" CommandArgument='<%# Eval("GroupID") %>'><i class="fa fa-pencil fa-fw"></i></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                    OnClientClick="javascript : return confirm('Are you sure \nyou want to delete this group ?');"
                                    CommandName="Delete" ToolTip="Delete"><i class="fa fa-trash-o fa-fw"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>



</asp:Content>
