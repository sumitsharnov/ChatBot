﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tesMexTacosbot.Models.Common;

namespace tesMexTacosbot.Handlers
{
    public class WelcomeIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Text = "Hi there, would you like to book a table?";

            return commonModel;
        }
    }
}