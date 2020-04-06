using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;


namespace EchoClassic
{
    public class SecurePage
    {
        string _path = "";
        string _pathType = "";

        public string Path
        {
            get { return this._path; }
            set { this._path = value; }
        }

        public string PathType
        {
            get { return this._pathType; }
            set { this._pathType = value; }
        }
    }
    public class Global : HttpApplication
    {
        public static bool IsSecure(string path)
        {

            List<SecurePage> lstPages = new List<SecurePage>();
            bool isSecure = false;

            try
            {
                //Fill the list of pages defined in web.config
                NameValueCollection sectionPages = (NameValueCollection)ConfigurationManager.GetSection("SecurePages");

                foreach (string key in sectionPages)
                {
                    if ((!string.IsNullOrEmpty(key)) && (!string.IsNullOrEmpty(sectionPages.Get(key))))
                    {
                        lstPages.Add(new SecurePage { PathType = sectionPages.Get(key), Path = key });
                    }
                }

                //loop through the list to match the path with the value in the list item
                foreach (SecurePage page in lstPages)
                {
                    switch (page.PathType.ToLower().Trim())
                    {
                        case "directory":
                            if (path.Contains(page.Path))
                            {
                                isSecure = true;
                            }
                            break;
                        case "page":
                            if (path.ToLower().Trim() == page.Path.ToLower().Trim())
                            {
                                isSecure = true;
                            }
                            break;
                        default:
                            isSecure = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isSecure;
        }
        void Application_BeginRequest(Object sender, EventArgs e)
        {

            ////if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["isLocal"].ToString()))// == "prod")
            ////{
            //    if (!HttpContext.Current.Request.IsSecureConnection)
            //    {
            //        if (IsSecure(Request.Url.AbsolutePath))
            //        {
            //            if (!Request.Url.GetLeftPart(UriPartial.Authority).Contains("www"))
            //            {
            //                HttpContext.Current.Response.Redirect(
            //                    Request.Url.GetLeftPart(UriPartial.Authority).Replace("http://", "https://www."), true);
            //            }
            //            else
            //            {
            //                HttpContext.Current.Response.Redirect(
            //                    Request.Url.GetLeftPart(UriPartial.Authority).Replace("http://", "https://"), true);
            //            }
            //        }
            //    }
            ////}

        }
        void Application_Start(object sender, EventArgs e)
        {

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
            Notification();
        }

        private void Notification()
        {
            Thread thread = new Thread(new ThreadStart(NotFunc));
            thread.IsBackground = true;
            thread.Name = "NotFunc";
            thread.Start();
        }
        protected void NotFunc()
        {
            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(NotWorker);
            t.Interval = 600000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }

        protected void NotWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            Service1 s = new Service1();
            s.BackgroundJob();
            Console.WriteLine("test");
            //work args
        }
    }
}