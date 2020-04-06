<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="EchoClassic.UserControls.Footer" %>
<style>
    ul {
        list-style-type: none;
    }


    li a {
        color: white;
        text-align: left;
        text-decoration: none;
    }

        li a:hover {
            color: gray;
        }

    footer {
        background-color: #000;
        padding: 13px;
        color: white;
    }
</style>
<footer>
    <div class="row">
        <div class="col-md-3">
            <h5 style="margin-left: 36px; color: #999999">ECHO</h5>
            <ul>
                <li><a href="../features.aspx">Features</a></li>
                <li><a href="../Security.aspx">Security</a></li>
                <li><a href="../Download.aspx">Download</a></li>
                <li><a href="../Business.aspx">Business</a></li>
                <li><a href="../EchoWeb.aspx">Echo Web</a></li>
                <li><a href="../ComingSoon.aspx">Echo Assessment</a></li>


            </ul>
        </div>

        <div class="col-md-3">
            <h5 style="margin-left: 36px; color: #999999">COMPANY</h5>
            <ul>
                <li><a href="../about.aspx">About</a></li>
                <li><a href="../ComingSoon">Career</a></li>

                <li><a href="../contact.aspx">Get in touch</a></li>
                <li><a href="../ComingSoon.aspx">blog</a></li>
                <li><a href="../terms-conditions.pdf">Terms & Conditions</a></li>
            </ul>
        </div>
        <div class="col-md-3">
            <h5 style="margin-left: 36px; color: #999999">DOWNLOAD</h5>
            <ul>
                <li><a href="echokgmc.apk" target="_blank">Android</a></li>
                <%--<li><a href="../ComingSoon.aspx">Iphone</a></li>--%>
            </ul>
        </div>
        <div class="col-md-3">
            <h5 style="margin-left: 36px; color: #999999">HELP</h5>
            <ul>
                <li><a href="../faq.aspx">FAQ</a></li>
                <li><a href="../ComingSoon.aspx">Twitter</a></li>
                <li><a href="../ComingSoon.aspx">Facebook</a></li>
                <li><a href="../clients.aspx">Clients</a></li>
            </ul>
        </div>

    </div>

    <div class="row" style="text-align: right;">
        <div class="col-md-8">
            &nbsp
        </div>
        <div class="col-md-3">
            <p style="color: white; font-size: 10px; margin-left: 100px">&copy; <%: DateTime.Now.Year %> - Echo Application</p>
        </div>
        <div class="col-md-1">
            &nbsp
        </div>
    </div>
</footer>
