using Alexa.NET.Request;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace tesMexTacosbot.Controllers
{
    public class AlexaController : ApiController
    {
        public SkillResponse post(SkillRequest skillRequest)
        {
            var response = new SkillResponse()
            {
                Version = "2.0",
                Response = new ResponseBody()
            };

            response.Response.OutputSpeech = new PlainTextOutputSpeech()
            {
                Text = "Hello Sumit"
            };
            return response;
        }
        public string Get()
        {
            return "Hello Alexa!";
        }

    }
}

