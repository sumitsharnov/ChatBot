using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tesMexTacosbot.Helpers;
using tesMexTacosbot.Models.Common;

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

            var responseText = string.Empty;
            var intentRequest = skillRequest.Request as IntentRequest;

            var commonModel = CommonModelMapper.AlexaToCommonModel(skillRequest);
            if (commonModel == null)
            {
                return null;
            }

            commonModel = IntentRouter.Process(commonModel);
            return CommonModelMapper.CommonModelToAlexa(commonModel);
        }  
        public string Get()
        {
            return "Hello Alexa!";
        }

    }
}

