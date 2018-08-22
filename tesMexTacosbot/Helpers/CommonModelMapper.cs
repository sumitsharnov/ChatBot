using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using ApiAiSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tesMexTacosbot.Models.Common;

namespace tesMexTacosbot.Helpers
{
    public class CommonModelMapper
    {
        internal static CommonModel AlexaToCommonModel(SkillRequest skillRequest)
        {
            var CommonModel = new CommonModel()
            {
                Id = skillRequest.Request.RequestId
            };

            var requestType = skillRequest.GetRequestType();
            if (requestType == typeof(IntentRequest))
            {
                var intentRequest = skillRequest.Request as IntentRequest;
                CommonModel.Request.Intent = intentRequest.Intent.Name;
                CommonModel.Request.Parameters = intentRequest.Intent.Slots.ToList().ConvertAll(s => new KeyValuePair<string, string>(s.Value.Name, s.Value.Value));
            }

            else if (requestType == typeof(LaunchRequest))
            {
                CommonModel.Request.Intent = "DefaultWelcomeIntent";
            }

            else if (requestType == typeof(LaunchRequest))
            {
                CommonModel.Request.Intent = "Default Welcome Intent";
            }

            else if (requestType == typeof(SessionEndedRequest))
            {

                return null;
            }

            return CommonModel;

        }
        internal static CommonModel DialogFlowToCommonModel(AIResponse aiResponse)
        {
            var CommonModel = new CommonModel()
            {
                Id = aiResponse.Id
            };

            CommonModel.Session.Id = aiResponse.SessionId;
            CommonModel.Request.Intent = aiResponse.Result.Metadata.IntentName;
            CommonModel.Request.Parameters = aiResponse.Result.Parameters.ToList().ConvertAll(p => new KeyValuePair<string, string>(p.Key, p.Value.ToString()));
            return CommonModel;
        }

        internal static SkillResponse CommonModelToAlexa(CommonModel commonModel)
        {
            var response = new SkillResponse()
            {
                Version = "1.0",
                Response = new ResponseBody()
            };

            response.Response.OutputSpeech = new PlainTextOutputSpeech { Text = commonModel.Response.Text };
            return response;
        }


        internal static dynamic CommonModelToDialogFlow(CommonModel commonModel)
        {
            return new
            {
                Speech = commonModel.Response.Text,
                fulfillmentText = commonModel.Response.Text,
                source = "tex Mex tacos"

            };
        }

    }
}