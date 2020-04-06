<%@ Page Title="Contact" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="EchoClassic.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="row" style="background-color: white">
            <div class="col-md-1">
                <img src="images/logoecho.png" alt="Features" />
            </div>
            <div class="col-md-11">
                &nbsp
            </div>
        </div>
        <div class="row">
            <div style="background-color: #666467; height: 85px">
                <div class="col-md-1">
                    &nbsp
                </div>
                <div class="col-md-11">
                    <h1 style="color: white; font-size: 55px">Contact</h1>
                </div>
            </div>
        </div>
        <div class="panel-heading">
            <%--<h2>Contact
            </h2>--%>
        </div>
        <div class="container">
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <h3>
                            <br />
                            <b>EMAIL:</b><a href="mailto:amit.sengupta@echocommunicator.com">amit.sengupta@echocommunicator.com</a>
                            <br />
                            <b>Mobile:</b>+917738919680
                        </h3>
                    </div>
                    <div class="col-md-1">&nbsp</div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
