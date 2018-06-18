using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_GraTekstowa
{
    class Bohaterowie
    {
        public class Bohater
        {
            public double siła, wytrzymałość, zdrowie, mana, złoto, dmg;
            public string profesja = "brak";
            public string zbroja_nazwa = "brak";
            public string bron_nazwa = "brak";
            public string blyskot_nazwa = "brak";
            public double bazowa_siła, bazowa_wytrzymałość, bazowa_zdrowie, bazowa_mana;
            public int poziom = 0;
            public double broń_siła = 0;
            public double zbroja_wytrzymałość = 0;
            public double błyskotka_mana = 0;
            public double błyskotka_zdrowie = 0;
            public double max_zdrowie = 0;
            public double max_mana = 0;
            public Bohater(double siła, double wytrzymałość, double zdrowie, double mana, double złoto, string profesja)
            {
                bazowa_siła = siła;
                bazowa_wytrzymałość = wytrzymałość;
                bazowa_zdrowie = zdrowie;
                bazowa_mana = mana;
                this.złoto = złoto;
                this.profesja = profesja;
            }
            public double Złoto{ set { złoto = value; } get { return złoto; } }
            public string Zbroja { set { zbroja_nazwa = value; } get { return zbroja_nazwa; } }
            public string Broń { set { bron_nazwa = value; } get { return bron_nazwa; } }
            public string Błyskotka { set { blyskot_nazwa = value; } get { return blyskot_nazwa; } }
            public double ZbrojaWytrzymałość { set { zbroja_wytrzymałość = value; } }
            public double BrońSiła{ set { broń_siła = value; } }
            public double BłyskotkaManaZdrowie { set { błyskotka_mana = value; błyskotka_zdrowie = value; } }

            public void StatystykiEkwipunek() 
            {
                Console.WriteLine($"\nTwoja profesja: {profesja}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Twój obecny poziom: {poziom}");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nEkwipunek bohatera");
                Console.ResetColor();
                Console.WriteLine($"Zbroja: {zbroja_nazwa}\nBroń: {bron_nazwa}\nBłyskotka: {blyskot_nazwa}");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nStatystyki bohatera");
                Console.ResetColor();
                Console.WriteLine($"Siła: {siła}\nWytrzymałość: {wytrzymałość}\nZdrowie: {zdrowie}/{max_zdrowie}\nMana: {mana}/{max_mana}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\nPosiadasz {złoto} złota");
                Console.ResetColor();
            }

            public void Awans() 
            {
                poziom += 1;
                bazowa_siła *= (1 + (poziom / 10));
                bazowa_wytrzymałość *= (1 + (poziom / 10));
                bazowa_zdrowie *= (1 + (poziom / 10));
                bazowa_mana *= (1 + (poziom / 10));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Awansowałeś na {poziom} poziom. Twoje statystyki wzrosły.");
                Console.ResetColor();
                UstawStatystki();
            }

            public void UstawStatystki()
            {
                siła = bazowa_siła + broń_siła;
                wytrzymałość = bazowa_wytrzymałość + zbroja_wytrzymałość;
                mana = bazowa_mana + błyskotka_mana;
                max_mana = bazowa_mana + błyskotka_mana;
                zdrowie = bazowa_zdrowie + błyskotka_zdrowie;
                max_zdrowie = bazowa_zdrowie + błyskotka_zdrowie;
            }

            public double ZwykłyAtak()
            {
                dmg = 2.23 * siła;
                return dmg;
            }

            public void Leczenie()
            {
                if (mana >= 20)
                {
                    mana -= 20;
                    if (zdrowie < max_zdrowie - 20)
                    {
                        zdrowie += 20;
                    }
                    else zdrowie = max_zdrowie;
                    Console.WriteLine($"Twoje zdrowie wynosi: {zdrowie}/{max_zdrowie}");
                }
                else Console.WriteLine("Starasz się uleczyć, niestety masz za mało many na tą chwilę.");
            }

            public void Uzdrowienie()
            {
                zdrowie = max_zdrowie;
                mana = max_mana;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Twoje zdrowie wzrosło do {zdrowie}.\nTwoja mana wzrosła do {mana}");
                Console.ResetColor();
            }

            public void ZdrowieMana()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Twoje zdrowie wynosi: {zdrowie}/{max_zdrowie}");
                Console.WriteLine($"Twoja mana wynosi: {mana}/{max_mana}");
                Console.ResetColor();
            }
        }

    }
}
