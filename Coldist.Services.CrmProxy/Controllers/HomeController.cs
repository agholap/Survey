using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Coldist.Services.CrmProxy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ////Url - Configure it to read from config/common place - 
            //string method = "Survey/GetAll/NotStarted";
            //// Create an HTTP web request using the URL:
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(Constants.CrmProxyBaseURI + method));
            //request.ContentType = "application/json";
            //request.Method = "GET";

            //// Send the request to the server and wait for the response:
            //using (WebResponse response = request.GetResponse())
            //{
            //    // Get a stream representation of the HTTP web response:
            //    using (Stream stream = response.GetResponseStream())
            //    {
            //        // Use this stream to build a JSON document object:
            //        JsonResult jsonDoc = JsonObject.Load(stream);
            //        Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

            //        // Return the JSON document:
            //        return jsonDoc;
            //    }
            //}

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
