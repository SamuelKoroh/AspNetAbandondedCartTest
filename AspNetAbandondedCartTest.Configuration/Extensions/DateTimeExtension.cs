using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetAbandondedCartTest.Configuration.Extensions
{
    public static class DateTimeExtension
    {
        public static int DayFromDate(this DateTime dateTime)
        {
            return DateTime.Now.Day - dateTime.Day;
        }
    }
} 
