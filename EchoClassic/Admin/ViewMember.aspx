<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMember.aspx.cs" Inherits="EchoClassic.Admin.ViewMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Members</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header style="height: 10px">
            </header>
            <div class="container">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">View Members
                        </h3>
                    </div>
                    <div class="panel-body" style="height: 280px"></div>
                </div>
                <div style="text-align: right">
                    <asp:Button ID="btnClose"  runat="server" Text="Close" OnClick="btnClose_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
