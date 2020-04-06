<%@ Page Title="Features" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Features.aspx.cs" Inherits="EchoClassic.Features" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        th, td {
            padding: 5px;
            text-align: left;
        }
    </style>
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
                    <h1 style="color: white; font-size: 55px">Features</h1>
                </div>
            </div>
        </div>

        <div class="panel-heading">
            <%--<img src="images/featuresheading.png" alt="Features" />--%>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-1">&nbsp</div>
                <div class="col-md-10">
                    <h4 style="font-weight: bold; font-family: Arial">Echo is the most intuitive app for attendance recording. It not only saves you time and effort but brings in a major improvement in management functioning and it costs less than your current system.</h4>
                    <p>It has 3 modules for attendance that cover the full spectrum of your attendance management requirements:</p>
                    <div>
                        <h4>Employee attendance through</h4>
                        <br />
                        <ol type="I">
                            <li>
                                <b>The Echo App</b>– The app presents 5 ways of capturing attendance
                                <ol type="a">
                                    <li><b>Supervisor/Teacher marking attendance</b> – In this, the class groups are created, and members can be added, edited or removed from the group. It is simple, intuitive and does not require Internet for marking attendance.</li>
                                    <li><b>Student/Member Marking attendance with code </b>code – This variant is suitable for large classes/groups. In this the supervisor or teacher generates a random code and the members must enter the code within a short time duration. Their location is captured and analyzed vis-à-vis where the code was generated to prevent any proxy marking. </li>
                                    <li><b>Self-Attendance with Geo-location- </b>The employees can mark their own attendance and their geo-location with device id are captured. </li>
                                    <li><b>Self-Attendance with Geo-fencing </b>– In this, the application allows marking attendance within 200 meters of office location for attendance. Beyond this range, the app does not allow attendance submission.</li>
                                    <li><b>Self-Attendance with Wi-Fi padding – </b>In this, the app is tied to theoffice wi-fi device and when the phone is connected to that specific wi-fi device, only then it allows marking attendance.</li>
                                    <li><b>Self-Attendance on a computer – </b>The employee can mark his attendance on a specific computer.</li>
                                </ol>
                            </li>
                            <li><b>Biometric Machines– </b>– The attendance can be recorded on biometric machines, both finger as well as palm.</li>
                            <li><b>AI-enabled face recognition Cameras–</b>A special camera is installed to read the faces of employees checking in or checking out and the attendance is recorded. The camera uses “in the wild’ mechanism where the employees do not have to pose in front of the camera.</li>
                        </ol>
                        <br />
                        <table style="width: 100%; border: 1px solid">
                            <thead style="font-weight: bold">
                                <tr>
                                    <th>Mode</th>
                                    <th>Type</th>
                                    <th>Suitable for</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><b>Echo App</b></td>
                                    <td>Supervisor/Teacher marking attendance</td>
                                    <td>Classrooms or groups up to 50 members</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Student/Member Marking attendance with code</td>
                                    <td>Large classrooms or groups where members have smartphones</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Self-Attendance with Geo-location</td>
                                    <td>Field Staff or Employees who do not have a specific location </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Self-Attendance with Geo-fencing</td>
                                    <td>Employees who are based in an office location but cannot be granted access to office wi-fi</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Self-Attendance with Wi-Fi padding</td>
                                    <td>Employees who have access to office wi-fi</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Self-Attendance on a Computer</td>
                                    <td>Employees who use desktops</td>
                                </tr>
                                <tr>
                                    <td><b>Biometric Machines</b></td>
                                    <td></td>
                                    <td>Office staff</td>
                                </tr>
                                <tr>
                                    <td><b>AI Based Face Recognition Cameras</b></td>
                                    <td></td>
                                    <td>High end offices with large number of members.</td>
                                </tr>
                            </tbody>
                        </table>
                        <br />
                        <p><b>Special Feature:</b>All these modes can be used simultaneously for catering to different requirements within the same institution.</p>
                        <p><b>Leave Reporting –</b>– The app provides a simple interface for leave reporting of the employees. It captures all types of leave that are allowed in the organization. This allows the management better manpower planning.</p>
                    </div>
                </div>
                <div class="col-md-1">&nbsp</div>
            </div>


        </div>
    </div>
</asp:Content>
