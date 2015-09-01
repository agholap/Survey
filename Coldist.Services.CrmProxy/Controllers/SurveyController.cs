using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Coldist.Services.CrmProxy.Controllers
{
    [RoutePrefix("api/survey")]
    public class SurveyController : ApiController
    {
        //// GET: api/Survey
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Survey/5
        //Adding route for attribute mapping - 
        // refer https://damienbod.wordpress.com/2014/08/22/web-api-2-exploring-parameter-binding/
        [Route("GetAll/{type}")]
        [HttpGet]
        public IEnumerable<string> GetAll(string type)
        {
            DateTime dayMin, dayMax;
            var days = new List<string>();

            switch (type)
            {
                case "NotStarted":
                    dayMin = DateTime.Now.AddDays(-2); //new DateTime ( 2012, 02, 27, 0, 0, 0 );
                    dayMax = DateTime.Now.AddDays(2);

                    for (var i = 0; dayMin.AddDays(i) < dayMax; i++)
                    {
                        days.Add(dayMin.AddDays(i).ToShortDateString());
                    }
                    break;
                case "Completed":
                    dayMin = DateTime.Now.AddDays(-4); //new DateTime ( 2012, 02, 27, 0, 0, 0 );
                    dayMax = DateTime.Now.AddDays(4);

                    for (var i = 0; dayMin.AddDays(i) < dayMax; i++)
                    {
                        days.Add(dayMin.AddDays(i).ToShortDateString());
                    }
                    break;
                case "InProgress":
                    dayMin = DateTime.Now.AddDays(-6); //new DateTime ( 2012, 02, 27, 0, 0, 0 );
                    dayMax = DateTime.Now.AddDays(6);

                    for (var i = 0; dayMin.AddDays(i) < dayMax; i++)
                    {
                        days.Add(dayMin.AddDays(i).ToShortDateString());
                    }
                    break;

                default:
                    break;
            }
            return days;
        }

        // POST: api/Survey
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Survey/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Survey/5
        public void Delete(int id)
        {
        }
    }
}
