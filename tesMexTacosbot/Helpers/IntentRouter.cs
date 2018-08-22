using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tesMexTacosbot.Models.Common;

namespace tesMexTacosbot.Helpers
{
    public class IntentRouter
    {
        public static CommonModel Process(CommonModel commonModel)
        {
            var intentsList = WebApiConfig.IntentHandlers;

            var intent = intentsList.FirstOrDefault(i => i.Key.ToLower() == commonModel.Request.Intent.ToLower());
            if (!string.IsNullOrWhiteSpace(intent.Key))
            {
                return intent.Value(commonModel);
            }

            if (string.IsNullOrWhiteSpace(commonModel.Response.Text))
            {
                commonModel.Response.Text = "Sorry, I didn't understand, please try again";                
            }
            return commonModel;
        }
    }
}