<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EchoClassic._Default" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>

        //var AttendanceList = new Array();
        //var ContactInfo = new Object();

        //ContactInfo["UserID"] = "347307B9-62B3-4E26-AB47-6810F4914CF3";
        //ContactInfo["GroupID"] = "23";
        //ContactInfo["AttendanceStatus"] = "P";
        //ContactInfo["UDF1"] = "1";
        //ContactInfo["UDF2"] = "11/11/2018";
        //AttendanceList[0] = ContactInfo;
        
        //ContactInfo = new Object();
        //ContactInfo["UserID"] = "347307B9-62B3-4E26-AB47-6810F4914CF3";
        //ContactInfo["GroupID"] = "23";
        //ContactInfo["AttendanceStatus"] = "P";
        //ContactInfo["UDF1"] = "2";
        //ContactInfo["UDF2"] = "11/11/2018";
        //AttendanceList[1] = ContactInfo;
        //var Attendance = JSON.stringify(AttendanceList);
        //alert(Attendance);
        var ss = JSON.stringify({ Attendance: "chk" });
        alert(ss);
        $.ajax({
            type: "POST",
            url: "http://www.echocommunicator.com/service1.svc/CreateAttendance",
            data: ss,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            processData: true,
            success: function (data) {
                alert("success..." + data);
                alert(1);
            },
            error: function (xhr) {
                alert(2);
                alert(xhr.responseText);
            }
        });


    </script>
    <div class="navbar navbar-inverse navbar" style="height: 100% auto; z-index: 100; margin-top: 97px;">
        <div class="row">
            
            <div class="col-md-10">
                <div class="row" style="margin-top: 12px; margin-left: 5%">
                    <asp:Label runat="server" AssociatedControlID="Email" Style="color: white; font-size: 13px" CssClass="col-md-1 control-label">Email:</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control input-sm" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="The email field is required." />
                    </div>
                    <asp:Label runat="server" AssociatedControlID="Email" Style="color: white; font-size: 13px" CssClass="col-md-1 control-label">Password:</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control input-sm" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                    <div class="col-md-4">
                        <div class="checkbox" style="margin-top: 5px">
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" Style="color: white; font-size: 13px" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            <%--<asp:Label runat="server" Style="color: white; font-size: 13px" AssociatedControlID="RememberMe">Remember me?</asp:Label>--%>
                            &nbsp
                            <%--<asp:Button ID="Button1" runat="server" Style="padding: 3px 10px 3px 10px" class="btn btn-default btn-xs" Text="Log in" />--%>
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" Style="padding: 3px 10px 3px 10px" class="btn btn-default btn-xs" />
                        </div>
                        <%--<div class="col-md-2">
                            <asp:Button ID="btnSubmit" runat="server" Text="Log in" />
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row" style="text-align: center; margin-top: 117px; margin-bottom: 150px">
        <div class="col-md-5">
            <img src="images/echo-default1.PNG" style="width: 90%" />
            <div class="row">
                <div class="col-md-1">&nbsp;</div>
                <div class="col-md-10">
                    <h2>CREATE CLASSES</h2>
                    <p style="text-align: justify">
                        Create as many classes/groups for attendance as you need from your contacts or by 
                uploading an Excel file. No group should have more than 60 members. 
                Up to 5 members can be given admin rights to record attendance
                    </p>
                </div>
            </div>
            <img src="images/echo-default1.PNG" style="width: 90%" />
            <div class="row">
                <div class="col-md-1">&nbsp;</div>
                <div class="col-md-10">
                    <h2>DAILY REPORT</h2>
                    <p style="text-align: justify">
                        Once the app is connected to the internet, the app emails report automatically to all the users registered as admin.
                             If attendance is taken more than once for the same group, both reports are shared.
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-5">
            <img src="images/echo-default2.PNG" style="width: 90%" />
            <div class="row">
                <div class="col-md-1">&nbsp</div>
                <div class="col-md-10">
                    <h2>TAKE ATTENDANCE</h2>
                    <p style="text-align: justify">
                        Any admin member can take attendance during the day. Each class/section/group will have the same facility. Once the attendance is submitted, it cannot be altered. No Internet connection is needed for marking attendance.
                    </p>

                </div>
            </div>
            <img src="images/echo-default2.PNG" style="width: 90%" />
            <div class="row">
                <div class="col-md-1">&nbsp;</div>
                <div class="col-md-10">
                    <h2>MONTHLY REPORT</h2>
                    <p style="text-align: justify">
                        On the last day of the calendar month, a report is shared for the whole month. 
                            A lot of intuitive analytical reports are also provided along so that it helps the management to take necessary decisions with right inputs.
                    </p>

                </div>
            </div>
        </div>
        <div class="col-md-2" style="background-color: gainsboro; height: 830px">

            <%--<h2>Add Section</h2>
                <p style="text-align: justify">
                    Create as many classes/groups for attendance as you need from your contacts or by 
                uploading an Excel file. No group should have more than 60 members. 
                Up to 5 members can be given admin rights to record attendance
                </p>--%>
        </div>
    </div>
</asp:Content>
