using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ThisisaLibrary
{
    public class TimeOnMars
    {

        public System.DateTime d1 = new System.DateTime(2021, 02, 18, 20, 55, 0);
        public System.DateTime d2 = System.DateTime.UtcNow;
        //public TimeSpan timePassed { get; set; }

        public static TimeSpan calculateTimeOnMars(System.DateTime d1, System.DateTime d2)
        {
            
           TimeSpan timePassed = d2.Subtract(d1);
            
            return timePassed;
        }




        //public System.DateTime d1;
        //public System.DateTime d2;
        //    DateTime landingDate = new DateTime(2021, 02, 18);
        //    public int CalculateLengthOfTime(DateTime landingDate, DateTime now)
        //    {
        //        int time = now.Year - landingDate.Year;

        //        if (now.Month < landingDate.Month || (now.Month == landingDate.Month && now.Day < landingDate.Day))
        //            time--;

        //        return time;
        //    }
        //}
    }

    internal class TimePassed
    {
        private TimeSpan timeSpan;

        public TimePassed(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }
    }
}
