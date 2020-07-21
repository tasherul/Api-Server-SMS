using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace SmsApi.Controllers
{
    public class SMSController : ApiController
    {
        // GET: api/SMS
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/SMS/5
        apiCheck _check = new apiCheck();
        private bool ChkUP(string UserName, string Password)
        {
            if (_check.intCheck("select count(*) from Login where UserName='" + UserName + "' and Password='" + Password + "' ") == 1)
            {
                return true;
            }
            else
            { return false; }
        }

        [HttpGet]
        public List<SMS> Get(string UserName, string Password)
        {
            List<SMS> returnVal = new List<SMS>();
            if(ChkUP(UserName, Password))
            {
                SqlDataReader dr = _check.SqlDataReader("select * from MySmsServer where UserName='" + UserName + "' ");
                int i = 1;
                while(dr.Read())
                {
                    returnVal.Add(new SMS() {
                        ID = i,
                        Index=dr["SMSID"].ToString(),
                        Messege =dr["Messege"].ToString(),
                        MobileNumber= dr["MobileNumber"].ToString(),
                       // ReciveDateTime= Convert.ToDateTime(dr["ReciveDateTime"].ToString()),
                       // SendDateTime= Convert.ToDateTime(dr["SendDateTime"].ToString()),
                        Status= dr["Operation"].ToString()
                    });
                    i++;
                }
                return returnVal;
            }
            else
            {
                returnVal.Add(new SMS() { Messege="Error"});
                return returnVal;
            }

            
        }

        // POST: api/SMS
        public string Post([FromBody]SMS Value, string UserName, string Password)
        {
            if (Value.MobileNumber != "" && Value.Messege != "")
            {
                if(ChkUP(UserName,Password))
                {
                    if(_check.ExcutionNonQuery(string.Format(@"insert into MySmsServer (MobileNumber,Messege,Operation,ReciveDateTime,UserName) values('{0}','{1}','{2}','{3}','{4}')  ",
                        Value.MobileNumber,Value.Messege,"",DateTime.Now.ToString(),UserName)))
                    {
                        return "Sucessfully Data Storaged.";
                    }
                    else
                    {
                        return "Data Not Storage.";
                    }
                }
                else
                {
                    return "UserName/ Password Invaild.";
                }
            }
            else
            {
                return "Messege and Number is not to be empty.";
            }

        }

        // PUT: api/SMS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SMS/5
        public void Delete(int id)
        {
        }
    }

    public class SMS
    {
        public int ID { get; set; }
        public string Index { get; set; }
        public string MobileNumber { get; set; }
        public string Messege { get; set; }
        public string Status { get; set; }
        public DateTime ReciveDateTime { get; set; }
        public DateTime SendDateTime { get; set; }

    }


}
