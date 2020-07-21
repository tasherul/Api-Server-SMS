using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmsApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {

       static List<SMSs> Data = new List<SMSs>() {
            new SMSs() {ID=1,Number="+8801920640620",Message="Test 1",Status="Not Send", DateTime=new DateTime().AddDays(5)   },
            new SMSs() {ID=3,Number="+8801841659090",Message="Test 2",Status="Send", DateTime=new DateTime().AddDays(2)   },
            new SMSs() {ID=2,Number="+8801920640620",Message="Test 3",Status="Not Send", DateTime=new DateTime().AddDays(1)   }
        };

        // GET api/values
        [HttpGet]        
        public IEnumerable<SMSs> Get()
        {
            return Data;
        }

        // GET api/values/5
        [Route("sms/student/{id}")]
        public SMSs Get(int id)
        {
            return Data.Where(x=>x.ID ==id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public SMSs Post([FromBody]SMSs value)
        {
            //AllData[4] = "App new";
            //return value;
            Data.Add(value);
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }


    public class SMSs
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}
