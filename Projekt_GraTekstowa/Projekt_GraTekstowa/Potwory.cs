using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_GraTekstowa
{
    class Potwory
    {
        public class Potwór
        {
            public double siła, zdrowie, dmg, max_zdrowie;
            public string nazwa;
            public Potwór(double siła, double zdrowie, string nazwa)
            {
                this.siła = siła;
                this.zdrowie = zdrowie;
                this.nazwa = nazwa;
                max_zdrowie = zdrowie;
            }
            public double Atak()
            {
                dmg = 2.23 * siła;
                return dmg;
            }
            public void Zdrowie()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Zdrowie {nazwa}a wynosi: {zdrowie}/{max_zdrowie}");
                Console.ResetColor();
            }
        }
    }
}
