using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PushSharp.Apple;
using PushSharp.Google;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for General
/// </summary>
public class General : System.Web.UI.Page
{
    public General()
    {

    }

    public static int Language = 1;
    public static int PageSize = 24;
    public static string DefaultImage = "a63c563c-e4c1-4f49-b1d8-d4c29200b126";
    public static string DefaultImageExt = ".gif";
    public static string ProductImageExt = ".jpg";
    public static string ApplicationName = "Echo";
    public static string AnonymousUser = "ABBC8AFB-8E95-49C8-84F5-0C571F2136BB";
    public static string StaticSEO = "Echo";
    public static int BranchID = 1;
    public static string Sitelink = "http://echocommunicator.com";
    public static int Branch_LP = 1;
    public static int Branch_WholeSale = 2;
    public static string Project4 = "All";
    public static string AdminEmailAddress = "info@echocommunicator.com";
    public static string CurrencySympal = "Rs.";
    public static string ImageNotFound = "a63c563c-e4c1-4f49-b1d8-d4c29200b126.gif";
    public static int DefaultCategoryID = 1;
    public static int GeneralCustomerRoleID = 3;
    public static int WholeSaleCustomerRoleID = 2;
    public static string ConnString = @"Data Source=.\SQLEXPRESS;Initial Catalog=echo;Integrated Security=True";
    public static string OrderEmailAddress = "info@echocommunicator.com";
    public static string AndroidAppID = "echo-1db84";
    public static string AndroidAppKey = "AIzaSyAPXuxQPsmW6-zPL9KwtU598z0gc7Pgs10";
    public static string IOSKey = "info@echocommunicator.com";

    //public enum AutoShipTypes
    //{                     
    //    JustShipOnce = 0, Every1week = 1, Every2weeks = 2, Every3weeks = 3, Every1month =4
    //}

    public static int GetCodeForAttendance()
    {
        Random random = new Random();
        return random.Next(100001, 999999);
    }

    public static string SendPushNotificationAndroid(string DeviceToken, string Title, string Message)
    {
        string result = string.Empty;
        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        tRequest.Method = "post";
        //serverKey - Key from Firebase cloud messaging server  
        tRequest.Headers.Add(string.Format("Authorization: key={0}", AndroidAppKey));
        //Sender Id - From firebase project setting  
        //tRequest.Headers.Add(string.Format("Sender: id={0}", AndroidAppID));
        tRequest.ContentType = "application/json";
        var payload = new
        {
            to = DeviceToken,
            
            //content_available = true,
            notification = new
            {
                body = Message,
                title = Title
                //badge = 1
                //sound= "default"
            },
            data=new
            {
                
                title = Title,
                message = Message
            },
            priority = "high"
        };

        string postbody = JsonConvert.SerializeObject(payload).ToString();
        Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
        tRequest.ContentLength = byteArray.Length;
        using (Stream dataStream = tRequest.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
            using (WebResponse tResponse = tRequest.GetResponse())
            {
                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                {
                    if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            result = sResponseFromServer;
                        }
                }
            }
        }
        return result;
    }
    public static string SendPushNotificationIOS(string DeviceToken,string Title,string Message)
    {
        string result = string.Empty;

        try
        {
            //Get Certificate
            var appleCert = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Files/Certificate/IOS/EchoDevAPNS.p12"));

            // Configuration (NOTE: .pfx can also be used here)
            var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox, appleCert, "1234");

            // Create a new broker
            var apnsBroker = new ApnsServiceBroker(config);

            // Wire up events
            apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
            {

                aggregateEx.Handle(ex =>
                {

                    // See what kind of exception it was to further diagnose
                    if (ex is ApnsNotificationException)
                    {
                        var notificationException = (ApnsNotificationException)ex;

                        // Deal with the failed notification
                        var apnsNotification = notificationException.Notification;
                        var statusCode = notificationException.ErrorStatusCode;
                        string desc = $"Apple Notification Failed: ID={apnsNotification.Identifier}, Code={statusCode}";
                       // Console.WriteLine(desc);
                        result = desc;
                    }
                    else
                    {
                        string desc = $"Apple Notification Failed for some unknown reason : {ex.InnerException}";
                        // Inner exception might hold more useful information like an ApnsConnectionException			
                       // Console.WriteLine(desc);
                        result = desc;
                    }

                    // Mark it as handled
                    return true;
                });
            };

            apnsBroker.OnNotificationSucceeded += (notification) =>
            {
                result = "Success!";
            };

            var fbs = new FeedbackService(config);
            fbs.FeedbackReceived += (string devicToken, DateTime timestamp) =>
            {
                // Remove the deviceToken from your database
                // timestamp is the time the token was reported as expired
            };

            // Start Proccess 
            apnsBroker.Start();

            if (DeviceToken != "")
            {
                apnsBroker.QueueNotification(new ApnsNotification
                {
                    DeviceToken = DeviceToken,
                    Payload = JObject.Parse(("{\"aps\":{\"badge\":0,\"sound\":\"default\",\"alert\":{ \"title\" : \""+Title+"\",\"body\":\"" + (Message + "\"}}}")))
                });
            }

            apnsBroker.Stop();

        }
        catch (Exception)
        {

            throw;
        }

        return result;
    }
    public static string SendPushNotificationAndroidOld(string DeviceToken,string Title, string Message)
    {
        string result = string.Empty;
        try
        {
            var config = new GcmConfiguration(null, AndroidAppKey, null);
            var gcmbroker = new GcmServiceBroker(config);
            gcmbroker.OnNotificationFailed += (notification, aggregateEx) =>
            {
                aggregateEx.Handle(ex =>
                {
                    if (ex is GcmNotificationException)
                    {
                        var notificationException = (GcmNotificationException)ex;
                        var gcmNotification = notificationException.Notification;
                        var description = notificationException.Description;
                        result = $"Android Notification Failed: ID={ gcmNotification.MessageId}, Desc={ description}";
                    }
                    else if (ex is GcmMulticastResultException)
                    {
                        var multicastException = (GcmMulticastResultException)ex;
                        //foreach(var SucceededNotification in multicastException.Succeeded)
                        //{ }

                        foreach (var failedKvp in multicastException.Failed)
                        {
                            var n = failedKvp.Key;
                            var e = failedKvp.Value;
                            result = $"Android Notification Failed: ID={ n.MessageId}";

                        }
                    }
                    else
                    {
                        result = $"Notification failed with unknown reason";
                    }
                    return true;
                });
            };
            gcmbroker.OnNotificationSucceeded += (notification) =>
            {
                result = "Success";
            };
            gcmbroker.Start();
            gcmbroker.QueueNotification(new GcmNotification
            {
                RegistrationIds = new List<string>{
                             DeviceToken
                        },
                Data=JObject.Parse(("{\"aps\": {\"badge\": 1, \"sound\": \"oven.caf\", \"alert\":\"" + (Message + "\"}}")))
            });
            gcmbroker.Stop();
        }
        catch (Exception ex)
        {

            result = ex.Message;
        }
        return result;
    }
    public static string GetCurrentSession
    {
        get
        {
            string session = string.Empty;
            int currentYear = DateTime.UtcNow.AddHours(5.5).Year;

            int currentMonth = DateTime.UtcNow.AddHours(5.5).Month;
            if (currentMonth < 4)
            {
                session = (currentYear - 1) + "-" + currentYear;

            }
            else
            {
                session = currentYear + "-" + (currentYear + 1);

            }
            return session;
        }
    }
    static public string removeSpecialCharacters(string orig)
    {
        string rv;
        // replacing with space allows the camelcase to work a little better in most cases.
        rv = orig.Replace("\\", "");
        rv = rv.Replace("(", "");
        rv = rv.Replace(")", "");
        rv = rv.Replace("/", "");
        rv = rv.Replace(",", "");
        rv = rv.Replace(">", "");
        rv = rv.Replace("<", "");
        rv = rv.Replace("&", "");
        rv = rv.Replace("'", "");
        rv = rv.Replace("\u2019", "");
        rv = rv.Replace("   ", "");
        rv = rv.Replace("  ", "");
        rv = rv.Replace("£", "");
        rv = rv.Replace("¬", "");
        rv = rv.Replace("$", "");
        rv = rv.Replace("%", "");
        rv = rv.Replace("^", "");
        rv = rv.Replace("*", "");
        rv = rv.Replace(":", "");
        rv = rv.Replace(";", "");
        rv = rv.Replace("@", "");
        rv = rv.Replace("#", "");
        rv = rv.Replace("~", "");
        rv = rv.Replace("[", "");
        rv = rv.Replace("]", "");
        rv = rv.Replace("{", "");
        rv = rv.Replace("}", "");
        rv = rv.Replace("?", "");
        rv = rv.Replace("+", "");
        rv = rv.Replace("+", "");
        rv = rv.Replace("`", "");
        rv = rv.Replace("!", "");
        //rv = rv.Replace(".", "");
        rv = rv.Replace('"', '-');
        rv = rv.Replace(" ", "-");
        rv = rv.Replace("=", "");
        rv = rv.Replace("|", "");
        rv = rv.Trim(' ');
        return (rv);
    }

  
  
    
    public static string ConvertEnum(string s)
    {
        string result = string.Empty;
        char[] letters = s.ToCharArray();
        foreach (char c in letters)
            if (c.ToString() != c.ToString().ToLower())
                result += " " + c.ToString();
            else
                result += c.ToString();
        return result;
    }

   
    public static bool IsDateTime(object value)
    {
        try
        {
            if (value == null)
                return false;

            DateTime dateTime = DateTime.Parse(value.ToString());
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool IsZiro(object value)
    {
        try
        {
            if (value == null)
                return false;

            double Zero = double.Parse(value.ToString());

            if (Zero > 0)
                return true;
            else
                return false;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool IsNumber(object value)
    {
        try
        {
            if (value == null)
                return false;

            double Zero = double.Parse(value.ToString());
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static System.Collections.Hashtable CMSTEMPLATE_LIST()
    {
        System.Collections.Hashtable list = new System.Collections.Hashtable();
        list.Add(1, "home1.ascx");
        list.Add(2, "home2.ascx");
        list.Add(3, "home3.ascx");
        list.Add(4, "template1.ascx");
        list.Add(5, "template1.ascx");
        list.Add(6, "template1.ascx");
        return list;
    }

    public static void SendSMS(string mobile, string message)
    {
        try
        {

            if (mobile.Length >= 10 && mobile.Length < 12)
            {
                WebClient webClient = new WebClient();
                string SMSURL = "http://login.aquasms.com/sendSMS?username=echocommunicator&sendername=GOECHO&smstype=TRANS&numbers=" + mobile + "&apikey=3dfb9669-43ce-484c-864e-a09c0e21be3c&message=" + message + "";
                webClient.OpenRead(SMSURL);

            }
        }
        catch
        {
            
        }
    }

    public static string SendEmail(string _ToEmail, string _Subject, string _Body)
    {
        if (ValidEmail(_ToEmail))
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(AdminEmailAddress);
                mail.IsBodyHtml = true;
                mail.To.Add(_ToEmail);

                mail.Subject = _Subject;
                mail.Body = _Body;
                SmtpClient client = new SmtpClient();
                client.Host = "cmx5.my-hosting-panel.com";

                client.Port = 25;

                client.Credentials = new System.Net.NetworkCredential("info@echocommunicator.com", "abC@123#");
                client.Send(mail);

                return "";
            }
            catch (Exception)
            {
                throw;
            }

        }
        return "";

    }

    public static string SendEmail(string _ToEmail, string _FromEmail, string _Subject, string _Body)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_FromEmail);
            mail.IsBodyHtml = true;
            mail.To.Add(_ToEmail);
            //mail.CC.Add(new MailAddress(AdminEmailAddress));

            mail.Subject = _Subject;
            mail.Body = _Body;
            SmtpClient client = new SmtpClient();
            client.Host = "mail.echocommunicator.com";
            client.Port = 2525;
            //client.EnableSsl = true;
            client.Send(mail);
            client.Timeout = 100;
            client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static string SendEmail(string _ToEmail, string _Subject, ListDictionary _ListDictionary, string _Body)
    {
        try
        {
            MailDefinition md = new MailDefinition();
            md.From = AdminEmailAddress;
            md.IsBodyHtml = true;
            md.Subject = General.ApplicationName + " : " + _Subject;

            if (!ValidEmail(_ToEmail))
                _ToEmail = General.AdminEmailAddress;

            MailMessage MMsg = md.CreateMailMessage(_ToEmail, _ListDictionary,
                _Body, new System.Web.UI.Control());



            SmtpClient client = new SmtpClient();
            //client.EnableSsl = true;
            client.Host = "localhost";
            client.Send(MMsg);
            client.Timeout = 100;
            client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static string SendEmail(string _ToEmail, string _From, string _Subject, ListDictionary _ListDictionary, string _Body)
    {
        try
        {
            MailDefinition md = new MailDefinition();
            md.From = _From;
            md.CC = AdminEmailAddress;

            md.IsBodyHtml = true;
            md.Subject = General.ApplicationName + " : " + _Subject;

            if (!ValidEmail(_ToEmail))
                _ToEmail = General.AdminEmailAddress;

            MailMessage MMsg = md.CreateMailMessage(_ToEmail, _ListDictionary,
                _Body, new System.Web.UI.Control());



            SmtpClient client = new SmtpClient();
            client.Host = "cmx5.my-hosting-panel.com";

            client.Port = 25;

            client.Credentials = new System.Net.NetworkCredential("info@echocommunicator.com", "abC@123#");


            client.Send(MMsg);

            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static bool ValidEmail(string validatingstring)
    {
        if (!Regex.Match(validatingstring, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").Success)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

   
    

}