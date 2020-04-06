<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMember.aspx.cs" Inherits="EchoClassic.Admin.AddMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Members</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header style="height: 10px">
            </header>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <asp:Literal ID="litGroupName" runat="server"></asp:Literal>
                    </h3>
                </div>

                <div class="panel-body">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                        <asp:Literal runat="server" ID="litFlowType" Visible="false" />
                        <asp:Literal runat="server" ID="litClientID" Visible="false" />

                    </p>

                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12" style="border: 1px solid #e3e3e3;">
                            <div class="row">
                                <div class="form-group well well-sm">
                                    <h5 style="text-align: center">
                                        <asp:RadioButton ID="rdManual" Checked="true"
                                            Text="Manual Entry" GroupName="g1" runat="server"
                                            AutoPostBack="true" OnCheckedChanged="rdManual_CheckedChanged" />
                                        <asp:RadioButton ID="rdBulkUpload" Text="Bulk Upload" GroupName="g1" runat="server" AutoPostBack="true" OnCheckedChanged="BulkUpload_CheckedChanged" />
                                    </h5>
                                </div>
                            </div>
                            <asp:Panel ID="pnlManualEntry" runat="server">
                                <div class="form-group row">
                                    <div class="form-group">
                                        <asp:Literal ID="litGroupID" runat="server" Visible="false"></asp:Literal>
                                        <label for="txtGroupName" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                            Serial/Roll No:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control input-sm"
                                                runat="server" ID="txtRollNo" MaxLength="10"
                                                placeholder="Roll No./Serial No."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group">
                                        <label for="txtNewUserName" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                            Name:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtNewUserName"
                                                MaxLength="50" placeholder="Member Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group">
                                        <label for="txtDesignation" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                            Designation:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtDesignation"
                                                placeholder="Enter designation here"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group">
                                        <label for="txtDOJ" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                            Date of joining:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtDOJ"
                                                placeholder="Date of joining" TextMode="Date"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group">
                                        <label for="txtMobileNo" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                            Mobile:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control input-sm" runat="server" ID="txtMobileNo"
                                                MaxLength="11" placeholder="Enter 10 digit mobile number here"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group">
                                        <label for="txtEmailID" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                            Email:</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control input-sm" runat="server" TextMode="Email" ID="txtEmailID"
                                                MaxLength="50" placeholder="username@domain.com"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group">
                                        <label for="rdGender" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                            Gender:</label>
                                        <div class="col-sm-8">
                                            <asp:RadioButtonList ID="rdGender" Font-Bold="false" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group">
                                        <label for="chkIsAdmin" class="col-sm-4 control-label" style="text-align: left; font-size: 16px; font-family: Cambria; font-size: 16px; text-align: -moz-right;">
                                            Admin?:</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="ddlIsAdmin" runat="server">
                                                <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="true"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group" align="center">
                                        <asp:Button ID="btnAddNewUser" CssClass="btn btn-default" runat="server" OnClick="Insert" Text="Add" Style="margin-top: 20px" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlBulkUpload" runat="server" Visible="false">

                                <div class="form-group row">
                                    <div class="form-group">
                                        <h5 style="font-weight: bold">Instructions:</h5>
                                        <ul>
                                            <li>Click <a href="../ContactsUpload/Sample.xlsx">Here </a>to download excel file.</li>
                                            <li>Fill contact details in the excel file.</li>
                                            <li>Date format should be mm/dd/yyyy.</li>
                                            <li>Upload the file.</li>
                                        </ul>
                                    </div>

                                </div>
                                <div class="form-group row">
                                    <asp:Label runat="server" AssociatedControlID="fuContacts">Select Contact List</asp:Label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="fuContacts" runat="server" CssClass="form-control" />

                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="form-group" align="center">
                                        <asp:Button ID="btnUploadContacts" CssClass="btn btn-default" runat="server" OnClick="UploadContacts" Text="Upload" Style="margin-top: 20px" />
                                        <asp:Button ID="btnViewAllMembers" CssClass="btn btn-default" runat="server" OnClick="ViewAllMembers" Text="View All" Style="margin-top: 20px" />

                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group well well-sm">
                                <h3>Select Admin</h3>
                                <div class="form-group well well-sm"
                                    style="overflow-y: scroll; max-height: 400px;">

                                    <asp:GridView ID="gvAdmins" runat="server"
                                        CssClass="table table-striped"
                                        AutoGenerateColumns="False" OnSelectedIndexChanged="gvAdmins_SelectedIndexChanged">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="UserID" runat="server" Text='<%# Eval("UserID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAdmin" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RollNo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRollNo" Text='<%# Eval("Custom1")%>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <asp:Button ID="btnMakeAdmin" CssClass="btn btn-default" runat="server" OnClick="MakeAdmin" Text="Make Admin" Style="margin-top: 10px; margin-bottom: 10px" />


                        </div>

                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12" style="overflow-y: scroll; max-height: 1100px;">
                            <asp:Literal ID="litBulkUploadResult" runat="server"></asp:Literal>
                            <asp:GridView ID="gvContactsFromXls" runat="server" CssClass="table table-striped">
                            </asp:GridView>
                            <asp:GridView ID="gvContacts" runat="server" CssClass="table table-striped"
                                OnRowEditing="GvContacts_RowEditing" AutoGenerateColumns="False"
                                OnRowCancelingEdit="GvContacts_RowCancelingEdit"
                                OnRowDeleting="GvContacts_RowDeleting"
                                OnRowUpdating="GvContacts_RowUpdating"
                                OnRowDataBound="gvContacts_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" ToolTip="Click here to select all" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkdel" runat="server" />
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
                                    <asp:TemplateField HeaderText="Name" ItemStyle-Wrap="false">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                                CssClass="text-danger" ErrorMessage="The Name field is required." />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <EditItemTemplate>
                                            <asp:TextBox Text='<%# Bind("Custom4") %>' CssClass="form-control input-sm" runat="server" ID="txtDesignation"
                                                placeholder="Designation" Style="max-width: 150px"></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Custom4") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Joining Date" HeaderStyle-Wrap="false" ItemStyle-Wrap="false">
                                        <EditItemTemplate>
                                            <asp:TextBox Text='<%# Bind("Custom3") %>' CssClass="form-control input-sm" runat="server" ID="txtDOJ"
                                                placeholder="Date of joining" TextMode="Date" Style="max-width: 135px"></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDOJ" runat="server"></asp:Label>
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
                                    <asp:TemplateField HeaderText="Email">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtUserEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
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
                        <asp:Button ID="btnDeleteSelected" runat="server"
                            OnClientClick="javascript : return confirm('Are you sure \nyou want to delete User(s) ?');"
                            CssClass="btn btn-default" Text="Delete Selected" Style="margin-top: 10px; margin-bottom: 10px"
                            OnClick="btnDeleteSelected_Click" />
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function SelectAll(id) {
                //get reference of GridView control
                var grid = document.getElementById("<%= gvContacts.ClientID %>");
                //variable to contain the cell of the grid

                var cell;

                if (grid.rows.length > 0) {
                    //loop starts from 1. rows[0] points to the header.
                    for (i = 1; i < grid.rows.length; i++) {
                        //get the reference of first column
                        cell = grid.rows[i].cells[0];

                        //loop according to the number of childNodes in the cell
                        for (j = 0; j < cell.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }
                }
            }
        </script>
    </form>
</body>
</html>
