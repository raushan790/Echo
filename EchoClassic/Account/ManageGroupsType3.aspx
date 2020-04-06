<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="ManageGroupsType3.aspx.cs" Inherits="EchoClassic.Account.ManageGroupsType3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="updateProgress" runat="server" AssociatedUpdatePanelID="up1"
        DisplayAfter="0">
        <ProgressTemplate>
            <div class="invisible_layer" id="processMessage">
                <div class="transparent_bg">
                </div>
                <div class="loadingbar">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
     <asp:UpdateProgress ID="updateProgress1" runat="server" AssociatedUpdatePanelID="upAttendance"
        DisplayAfter="0">
        <ProgressTemplate>
            <div class="invisible_layer" id="processMessage">
                <div class="transparent_bg">
                </div>
                <div class="loadingbar">
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="tab-content">
        <asp:UpdatePanel ID="upAttendance" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:TextBox ID="txtLatLong" runat="server" Style="display: none"></asp:TextBox>

                <div id="Attendance" class="tab-pane fade in active">
                    <div class="row">
                        <div class="col-md-7">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                            <asp:Literal ID="litAtt" runat="server" Visible="false"></asp:Literal>
                            <div id="flip" style="font-weight: bold; background-color: #f5f3f3; overflow: hidden">
                                <i class="fa fa-check-square-o" style="font-size: 14px"></i>
                                Mark Attendance
                            </div>
                            <asp:Panel ID="pnlAttendance" runat="server" Width="99%">
                                <asp:GridView ID="gvAttendance" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SLNo.">
                                            <ItemTemplate>
                                                <asp:Label ID="SLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="UserID" runat="server" Text='<%# Eval("UserID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Attendance" ItemStyle-Width="50%">
                                            <ItemTemplate>
                                                <asp:RadioButton ID="rbPresent" runat="server" Text="Present" GroupName="grpAttendance" Checked="true"></asp:RadioButton>
                                                <asp:RadioButton ID="rbAbsent" runat="server" Text="Absent" GroupName="grpAttendance"></asp:RadioButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </asp:Panel>
                            <div class="row">
                                <div class="col-md-7">&nbsp;</div>
                                <div class="col-md-5">
                                    <asp:Button ID="btnSendAttendanceMail" Visible="false" runat="server" Text="Mark Attendance" OnClick="btnSendAttendanceMail_Click" Style="padding: 2px 5px 2px 7px; margin-left: 23px" />
                                </div>
                            </div>


                        </div>
                        <div class="col-md-5">
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="view" class="tab-pane fade">

            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
            <div id="divFormSection" runat="server" class="form-horizontal" style="padding-left: 0px">
                <asp:Panel ID="pnlForm" runat="server">
                    <h4>Create/Edit Group</h4>
                    <hr />
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                    <div style="width: 70%; padding-left: 50px">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Name</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" Enabled="false" ID="txtName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                                    CssClass="text-danger" ErrorMessage="The Name field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtDesc" CssClass="col-md-2 control-label">Description</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" Enabled="false" ID="txtDesc" CssClass="form-control" />

                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="fuImage" CssClass="col-md-2 control-label">Image</asp:Label>
                            <div class="col-md-10">
                                <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" />

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2"></div>
                            <div class="col-md-10">
                                <h5 style="font-weight: bold">Instructions:</h5>
                                <ul>
                                    <li>Click <a href="../ContactsUpload/SampleContacts.xlsx">Here </a>to download excel file.</li>
                                    <li>Fill contact details in the excel file.</li>
                                    <li>Upload the file.</li>
                                </ul>
                            </div>

                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="fuContacts" CssClass="col-md-4 control-label">Select Contact List</asp:Label>
                            <div class="col-md-8">
                                <asp:FileUpload ID="fuContacts" runat="server" CssClass="form-control" />

                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Enabled="false" CssClass="btn" ID="btnCreateGroup"
                                    OnClick="CreateGroup_Click" Text="Save" />
                                <asp:Button runat="server" Enabled="false" CssClass="btn" ID="btnDelete" OnClick="DeleteGroup"
                                    Text="Delete this Group" Visible="false"
                                    OnClientClick="javascript : return confirm('Are you sure \nyou want to delete this Group ?');" />
                            </div>
                        </div>
                        <br />
                        <asp:GridView ID="gvContactsFromXls" runat="server" CssClass="table table-striped">
                        </asp:GridView>
                    </div>
                    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="overflow-x: scroll; overflow-y: scroll; max-height: 300px">
                                <asp:TextBox ID="txtClientID" runat="server" Visible="true"></asp:TextBox>

                                <asp:GridView ID="gvContacts" runat="server" CssClass="table table-striped"
                                    OnRowEditing="GvContacts_RowEditing" AutoGenerateColumns="False"
                                    OnRowCancelingEdit="GvContacts_RowCancelingEdit"
                                    OnRowDeleting="GvContacts_RowDeleting" OnRowUpdating="GvContacts_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDel" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="UserID" runat="server" Text='<%# Eval("UserID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="RollNo">
                                            <EditItemTemplate>

                                                <asp:TextBox ID="txtRollNumber"
                                                    runat="server" Text='<%# Bind("Custom1") %>'></asp:TextBox>

                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRollNo" Text='<%# Eval("Custom1")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                                    CssClass="text-danger" ErrorMessage="The Name field is required." />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtUserEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtUserMobile" runat="server" Text='<%# Bind("MobileNo") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gender">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddType" runat="server" SelectedValue='<%#Bind("Custom2")%>'>
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>

                                                    <%--<asp:ListItem Text="Teacher" Value="Teacher"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%# Bind("Custom2") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cast">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlCast" runat="server" SelectedValue='<%#Bind("Custom3")%>'>
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Gen" Value="Gen"></asp:ListItem>
                                                    <asp:ListItem Text="Obc" Value="Obc"></asp:ListItem>

                                                    <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                                                    <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                                                    <asp:ListItem Text="Minority" Value="Minority"></asp:ListItem>
                                                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCast" runat="server" Text='<%# Bind("Custom3") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="P.H.?">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlHandicap" runat="server" SelectedValue='<%#Bind("Custom4")%>'>
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblHandicapped" runat="server" Text='<%# Bind("Custom4") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ShowEditButton="true" />
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                                    OnClientClick="javascript : return confirm('Are you sure \nyou want to delete this User ?');"
                                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>


                            </div>
                            <br />
                            <asp:Button ID="btnDeleteRecord" CssClass="btn" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click" Style="padding: 2px 10px 2px 9px" Visible="false" />
                            <br />
                            <br />
                            <asp:Panel ID="pnlAddRow" runat="server" Style="border: 1px solid gray; padding: 5px;">
                                <div class="row" style="margin-left: 1px">
                                    <div class="col-md-3">
                                        RollNo:<br />
                                        <asp:TextBox ID="txtRollNo" runat="server" />
                                    </div>
                                    <div class="col-md-3">
                                        Name:<br />
                                        <asp:TextBox ID="txtNewUserName" runat="server" />
                                    </div>
                                    <div class="col-md-3">
                                        Email:<br />
                                        <asp:TextBox ID="txtEmailID" runat="server" TextMode="Email" />
                                    </div>
                                    <div class="col-md-3">
                                        Mobile:<br />
                                        <asp:TextBox ID="txtMobileNo" runat="server" />
                                    </div>

                                </div>
                                <div class="row" style="margin-left: 1px">
                                    <div class="col-md-3">
                                        Gender:<br />
                                        <asp:DropDownList ID="ddlType" runat="server">
                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>


                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        Cast:<br />
                                        <asp:DropDownList ID="ddlCast" runat="server">
                                            <asp:ListItem Text="Gen" Value="Gen"></asp:ListItem>
                                            <asp:ListItem Text="Obc" Value="Obc"></asp:ListItem>

                                            <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                                            <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                                            <asp:ListItem Text="Minority" Value="Minority"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        Phy. Handicap?:<br />
                                        <asp:DropDownList ID="ddlHandicap" runat="server">
                                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:CheckBox ID="chkIsAdmin" runat="server" />&nbsp IsAdmin
                                    </div>
                                </div>

                                <div class="row" style="margin-left: 1px">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button ID="btnAddNewUser" runat="server" Text="Add" OnClick="Insert" Style="margin-top: 20px" />
                                    </div>
                                    <div class="col-md-4">
                                    </div>

                                </div>

                            </asp:Panel>
                            <br />
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </asp:Panel>
            </div>
        </div>
        <div id="Chat" class="tab-pane fade">
            this is chat section
        </div>


    </div>
    <script type="text/javascript">
        var x = document.getElementById('<%=txtLatLong.ClientID %>');
        $(document).ready(function () {
            getLocation();
        })
        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
            }
            else { x.innerHTML = "Geolocation is not supported by this browser."; }
        }

        function showPosition(position) {
            var latlondata = position.coords.latitude + "," + position.coords.longitude;
            x.value = position.coords.latitude + "," + position.coords.longitude;
            //alert(latlondata)
        }

        function showError(error) {
            if (error.code == 1) {
                x.innerHTML = "User denied the request for Geolocation."
            }
            else if (err.code == 2) {
                x.innerHTML = "Location information is unavailable."
            }
            else if (err.code == 3) {
                x.innerHTML = "The request to get user location timed out."
            }
            else {
                x.innerHTML = "An unknown error occurred."
            }
        }
    </script>
</asp:Content>
