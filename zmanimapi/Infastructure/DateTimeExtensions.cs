using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zmanimapi.Infastructure
{
    public static class DateTimeExtensions
    {
        public static String formatDate(this DateTime? dt)
        {
            String formatter = "{0:h:mm:sstt}";
            return String.Format(formatter, dt.GetValueOrDefault());
        }
    }
}
