<%@ Page Title="Mark Attendance" Language="C#" MasterPageFile="~/Account/Account.Master" AutoEventWireup="true" CodeBehind="SelfAttendance.aspx.cs" Inherits="EchoClassic.Account.SelfAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                <asp:Panel ID="pnlAttendance" runat="server" Visible="false">
                    <div id="Attendance" class="tab-pane fade in active">
                        <div class="row">
                            <div class="col-md-7">
                                <asp:Label ID="lblError" runat="server"></asp:Label>
                                <asp:Literal ID="litAtt" runat="server" Visible="false"></asp:Literal>
                                <div id="flip" style="font-weight: bold; background-color: #f5f3f3; overflow: hidden">
                                    <i class="fa fa-check-square-o" style="font-size: 14px"></i>
                                    Mark Attendance
                                </div>

                                <div class="row">
                                    <br />
                                    <div class="col-md-5">
                                        Attendance Code:
                                        <asp:TextBox ID="txtAttendanceCode" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                        <br />
                                        <asp:Button ID="btnSendAttendanceMail" runat="server" Text="Mark Attendance" OnClick="btnSendAttendanceMail_Click" Style="padding: 2px 5px 2px 7px; margin-left: 23px" />
                                    </div>
                                </div>


                            </div>
                            <div class="col-md-5">
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

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
