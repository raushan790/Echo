using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using BusinessObjects;
using DataObjects;

namespace EchoWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult About()
        {
            //User u = DataAccess.UserDao.GetUser("admin@hellopunditji.com", "3jis5AvsKszdLSeEEIPN3Q==");
            //WebClient proxy = new WebClient();
            //byte[] data = proxy.DownloadData("http://localhost:38395/Service1.svc/GetJosnmessage");
            //Stream stream = new MemoryStream(data);
            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(string));
            //string result = obj.ReadObject(stream).ToString();
            //Console.WriteLine(result.ToString());
            //Console.ReadKey(true);
           
           
            WebClient Proxy1 = new WebClient();
            //Proxy1.Headers["Content-type"] = "application/json";
            //MemoryStream ms = new MemoryStream();

            byte[] data = Proxy1.DownloadData("http://localhost:6296/EchoApi.svc/GetUser/admin@hellopunditji.com/3jis5AvsKszdLSeEEIPN3Q==");
            Stream stream = new MemoryStream(data);
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(User));
            var resultStudent = obj.ReadObject(stream) as User;
            Response.Write(resultStudent.FirstName + " " + resultStudent.LastName);
            //Console.ReadKey(true);
            string fullPath = "http://localhost:6296/EchoApi.svc/GetUser/admin@hellopunditji.com/3jis5AvsKszdLSeEEIPN3Q==";
           //     / admin@hellopunditji.com/3jis5AvsKszdLSeEEIPN3Q==";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullPath);
           
            
           

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string myResponse = "";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                myResponse = sr.ReadToEnd();
            }
           // DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(User));
           // User uu = obj.ReadObject(response) as User;
            ViewBag.Message = myResponse;// "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}