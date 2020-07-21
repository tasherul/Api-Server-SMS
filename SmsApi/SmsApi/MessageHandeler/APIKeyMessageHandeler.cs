using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
namespace SmsApi.MessageHandeler
{
    public class APIKeyMessageHandeler : DelegatingHandler
    {
        Check chk = new Check();
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage,CancellationToken cancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> requestHeaders;
            var chekcApiKeyExists = httpRequestMessage.Headers.TryGetValues("ApiKey", out requestHeaders);

            if(chekcApiKeyExists)
            {                
                string Key = requestHeaders.FirstOrDefault();
                bool Enable = chk.stringCheck("select Api_Enable from Login where Api_Key='" + Key + "' ").ToLower()=="true"?true:false;
                if (Enable)
                {
                    validKey = true;
                }

            }
            if(!validKey)
            {
                return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
            }
            var response = await base.SendAsync(httpRequestMessage, cancellationToken);
            return response;
        }
    }
}