using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EchoClassic
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            Service1 s = new Service1();
            s.AddLeave("F8D74E73-D173-42A6-BDC6-78E9767FEF93", "PL", "2020-02-02", "2020-02-07", 5, "Ttest Reason");
            return "Hello World";
        }

        [WebMethod]
        public string sendNotification()
        {
            try
            {
                string DeviceToken = "e0X_WMWLXWo:APA91bFcM7yHoHhY7CjoraQ7zTebsHZr4gnFaeThcUt_jxQlWxcg--eoyOXydDOrBSaPosWkoAxMBaGVqqkLobpBC00WG4l0EXMq4dbqQV2sQ5_MvDNTj4GrNLxUmW3RdvXsb-6CA8eZ";
                string Title = "Attendance Added";
                string Message = "Your attendance is added on date";
                General.SendPushNotificationAndroid(DeviceToken,Title, Message);
                return "success";
            }
            catch (Exception)
            {

                throw;
            }
            return "success";
        }
    }
}
