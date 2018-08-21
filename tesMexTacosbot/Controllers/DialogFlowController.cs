using ApiAiSDK.Model;
using Google.Apis.Dialogflow.v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tesMexTacosbot.Controllers
{
    public class DialogFlowController : ApiController
    {
        public dynamic Post(AIResponse aiResponse)
        {
            var response = new
            {
                fulfillmentText = "Hello Sumit",
                ////Text = "Hello!!"
            };

            return response;

        }

        public string Get()
        {
            return "Hello Google!";
        }
    }
}
