using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tesMexTacosbot.Models.Common;

namespace tesMexTacosbot.Handlers
{
    public class ReservationIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            var time = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "time");
            var date = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "date");
            var number = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "number");

            commonModel.Response.Text = $"Perfect your table for {number} has been booked for {time} on {date}";
            return commonModel;
        }

    }
}