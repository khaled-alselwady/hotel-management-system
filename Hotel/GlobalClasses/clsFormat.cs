using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.GlobalClasses
{
    public class clsFormat
    {
        public static string DateToShort(DateTime? Dt1)
        {

            return Dt1?.ToString("dd/MMM/yyyy");
        }

    }
}
