<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contactus.aspx.cs" Inherits="EchoClassic.Contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Features
            </h3>
        </div>
        <%--   <div class="panel-body" style="background-color: #dedae699; width: 100%">
        </div>--%>
        <hr />

        <div class="panel-body">
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <h2><%: Title %>.</h2>
                    <h3>Your contact page.</h3>
                    <address>
                        One Microsoft Way<br />
                        Redmond, WA 98052-6399<br />
                        <abbr title="Phone">P:</abbr>
                        425.555.0100
                    </address>

                    <address>
                        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
                        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
                    </address>
                </div>
                <div class="col-md-1"></div>
            </div>


        </div>
    </div>
</asp:Content>
