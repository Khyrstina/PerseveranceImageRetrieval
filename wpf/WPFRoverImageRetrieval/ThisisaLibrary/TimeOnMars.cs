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

        public static TimeSpan calculateTimeOnMars(System.DateTime d1, System.DateTime d2)
        {
            
           TimeSpan timePassed = d2.Subtract(d1);
            
            return timePassed;
        }
    }
}
