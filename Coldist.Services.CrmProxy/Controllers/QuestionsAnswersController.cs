using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Coldist.Services.CrmProxy.Controllers
{
    public class QuestionsAnswersController : ApiController
    {
        // GET: api/QuestionsAnswers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/QuestionsAnswers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/QuestionsAnswers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QuestionsAnswers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuestionsAnswers/5
        public void Delete(int id)
        {
        }
    }
}
