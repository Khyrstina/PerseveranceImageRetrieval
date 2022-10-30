using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisisaLibrary
{
    public class TimeOnMars
    {
        DateTime landingDate = new DateTime(2021, 02, 18);
        public int CalculateLengthOfTime(DateTime landingDate, DateTime now)
        {
            int time = now.Year - landingDate.Year;

            if (now.Month < landingDate.Month || (now.Month == landingDate.Month && now.Day < landingDate.Day))
                time--;

            return time;
        }
    }
}
