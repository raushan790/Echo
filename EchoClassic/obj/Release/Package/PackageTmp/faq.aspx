<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="faq.aspx.cs" Inherits="EchoClassic.faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2><%: Title %>.</h2>
        </div>

       

        <div class="panel-body">
            <div class="row">
                <%--<div class="col-md-1"></div>--%>
                <div class="col-md-10">
                    <p>
                        <b>Question: Where can I download the app from?</b>
                        <br />
                        <b>Answer:</b> The app is available on Google Playstore and on web through <a href="https://www.echocommunicator.com">https://www.echocommunicator.com</a>.
                    </p>


                    <p>
                        <b>Question: Can I use the app on the web?</b>
                        <br />
                        <b>Answer:</b> Yes you can you any browser to use the solution. Please access <a href="https://www.echocommunicator.com">https://www.echocommunicator.com</a> for registration and log-in. Once you log in, you will access all the groups that you have created or are a part of, same as the app. The web version does not work on offline version.   
   
                    </p>
                    <p>
                        <b>Question: What is Coupon Code?</b>
                        <br />
                        <b>Answer:</b> Coupon code is the code you receive through SMS and Email before registration. It is mandatory for a new registration. 
   
                    </p>
                    <p>
                        <b>Question: How do I get the coupon code message?</b>
                        <br />
                        <b>Answer:</b> You have to register as a client on the website. You can also drop a mail on <a href="mailto://info@echocommunicator.com">info@echocommunicator.com</a>for the same. Please mention ‘Registration’ on the subject line. You have to give the following for the new registration. 
                    </p>
                    <ol>
                        <li>Organization Name / Proprietor name</li>
                        <li>Contact person name </li>
                        <li>Date of Birth</li>
                        <li>Mobile number </li>
                        <li>Email ID</li>
                        <li>Address</li>
                        <li>City and state</li>
                        <li>Number of Members / Students</li>
                    </ol>

                    <p>
                        <b>Question: How do I register myself for the app?</b>
                        <br />
                        <b>Answer:</b> For registering yourself, you have to enter the coupon code it will then populate the name and the email ID and the mobile number registered on the system. If you want to make any changes then you can do it at this time itself. Press OK and you are done. Now you can start using the system by creating as many groups as you want and marking their attendance.

                    </p>
                    <p>
                        <b>Question: What is the registration fee for EchoAttendance?</b>
                        <br />
                        <b>Answer:</b> Eco attendance at this moment does not have any registration fee however the company reserves the right to introduce of fee for new registrations at a later point of time.
                    </p>

                    <p>
                        <b>Question: How can I create a group?</b>
                        <br />
                        <b>Answer:</b> Creating a group is easy and just like any other chat group app. At the time of group creation you have to mention who are admin of the group. A group can have a maximum of 5 admin members. The rights of admin members are mentioned separately. 
                    </p>

                    <p>
                        <b>Question: What is the maximum size of the group?</b>
                        <br />
                        <b>Answer:</b> 60 members
                    </p>

                    <p>
                        <b>Question: Can I take attendance while offline?</b>
                        <br />
                        <b>Answer:</b> Yes, you can take attendance via mobile app while you are offline. For receiving reports, you must connect the app to the internet. 
                    </p>

                    <p>
                        <b>Question: What are the rights of admin members of a group?</b>
                        <br />
                        <b>Answer:</b> The admin members of the group will be able to add or delete members from the group, assign / alter member roles, mark attendance and receive reports for daily and monthly for their attendance on their registered email ID. The admin must provide email ID at the time of registration for receiving the reports. 
                    </p>

                    <p>
                        <b>Question: What can a normal member do on the app?</b>
                        <br />
                        <b>Answer:</b> And an admin or a normal member is added currently only for the purpose of marking attendance. He/She is only a member whose attendance is to be taken and he's not allowed to take attendance or create groups on the app. He/She can, however, create new groups to take attendance.
                    </p>

                    <p>
                        <b>Question: What are the reports that an admin will receive?</b>
                        <br />
                        <b>Answer:</b> Admin will receive daily and monthly attendance reports on registered email ID. 
                    </p>

                    <p>
                        <b>Question: Can the attendance once recorded be altered?</b>
                        <br />
                        <b>Answer:</b> No. The attendance once recorded CANNOT be altered. 
                    </p>
                    <p>
                        <b>Questions: One group can take attendance how many times during a day?</b>
                        <br />
                        <b>Answer:</b> One group can take attendance 2 times a day. This will allow an in time and out time attendance for a group. 
   
                    </p>

                    <p>
                        <b>Question: Will I get percentage attendance at the end of the month?</b>
                        <br />
                        <b>Answer:</b> Yes. At the beginning of the month, please enter the number of workdays for the coming in the pop-up box. That will allow calculation of the monthly attendance percentage.  
                    </p>

                    <p>
                        <b>Question: What is a Daily attendance report?</b>
                        <br />
                        <b>Answer:</b> Daily attendance report is sent automatically on the registered email ids of the group admin(s). It contains the member name, present/absent status, date of the report and time of the attendance taken. The time and date are as per the server. 
                    </p>

                    <p>
                        <b>Question: What is monthly attendance report?</b>
                        <br />
                        <b>Answer:</b> The monthly attendance report is sent on the registered email ID of admin(s) on the last calendar date of the month. It contains member name, number of days present and percentage attendance for the month (Number of the days present*100 / number of workdays during the month).
                    </p>
                </div>
                <div class="col-md-1"></div>
            </div>


        </div>
    </div>
</asp:Content>
