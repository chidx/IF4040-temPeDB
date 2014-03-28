using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            String coba = "when 100-200 @> 100-300";

            coba = coba.Substring((coba.IndexOf(" ") + 1));
            String periode1 = coba.Substring(0, (coba.IndexOf(" ")));
            coba = coba.Substring((coba.IndexOf(" ") + 1));
            String operate = coba.Substring(0, (coba.IndexOf(" ")));
            coba = coba.Substring((coba.IndexOf(" ") + 1)); 
            String periode2 = coba;

            String periode1Angka1 = periode1.Substring(0, periode1.IndexOf("-"));
            String periode1Angka2 = periode1.Substring(periode1.IndexOf("-") + 1);
            String periode2Angka1 = periode2.Substring(0, periode2.IndexOf("-"));
            String periode2Angka2 = periode2.Substring(periode2.IndexOf("-") + 1);
            Console.WriteLine("Periode 1 = " + periode1);
            Console.WriteLine("Operator  = " + operate);
            Console.WriteLine("Periode 2 = " + periode2);

            Console.WriteLine("TS1 = " + periode1Angka1);
            Console.WriteLine("TE1 = " + periode1Angka2);
            Console.WriteLine("TS2 = " + periode2Angka1);
            Console.WriteLine("TE2 = " + periode2Angka2);
            Console.Read();

        }
    }
}
