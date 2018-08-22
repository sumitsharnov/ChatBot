using ApiAiSDK.Model;
using Google.Apis.Dialogflow.v2;
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
    public class DialogFlowController : ApiController
    {
        public dynamic Post(AIResponse aiResponse)
        {
            var commonModel = CommonModelMapper.DialogFlowToCommonModel(aiResponse);
            if (commonModel == null)
                return null;
            commonModel = IntentRouter.Process(commonModel);
            return CommonModelMapper.CommonModelToDialogFlow(commonModel);
            ////var response = new
            ////{
               
            ////    fulfillmentText = Handlers.WelcomeIntent.Process(new CommonModel()).Response.Text,
            ////    ////Text = "Hello!!"
            ////};

            ////return response;

        }

        public string Get()
        {
            return "Hello Google!";
        }
    }
}
