using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisisaLibrary
{
    public class DaysToSols
    {
        public System.DateTime d1 = new System.DateTime(2021, 02, 18, 20, 55, 0);
        public System.DateTime d2 = System.DateTime.UtcNow;

        public static int solsSearched(System.DateTime d1, System.DateTime d2)
        {
            var timePassed = TimeOnMars.calculateTimeOnMars(d1, d2);

            int sols = (int)(timePassed.Days * .97);

            return sols;
        }
        
    }
}
