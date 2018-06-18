using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_GraTekstowa
{
    class Program
    {
        static void Walka(Bohaterowie.Bohater bohater, Potwory.Potwór przeciwnik)
        {
            Console.WriteLine(@" __    __      _ _         
/ / /\ \ \__ _| | | ____ _ 
\ \/  \/ / _` | | |/ / _` |
 \  /\  / (_| | |   < (_| |
  \/  \/ \__,_|_|_|\_\__,_|
                           ");
            Console.WriteLine($"Napotkałeś na swojej drodzę {przeciwnik.nazwa}a.");
            Console.WriteLine($"{przeciwnik.nazwa.ToUpper()} od razu Cię zaatakował. Walcz albo giń.");
            while(true)
            {
                bohater.ZdrowieMana();
                przeciwnik.Zdrowie();
                Console.WriteLine("Co chcesz zrobić?\n1.Atakuj\n2.Leczenie(koszt: 20 many, bonus: +20 życia)");
                while(true)
                {
                    Console.Write("Wprowadź cyfrę: ");
                    int odpowiedz = int.Parse(Console.ReadLine());
                    if (odpowiedz == 1)
                    {
                        przeciwnik.zdrowie -= bohater.ZwykłyAtak();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Zaatakowałeś {przeciwnik.nazwa}a za {bohater.ZwykłyAtak()} zdrowia.");
                        Console.ResetColor();
                        if (przeciwnik.zdrowie <= 0)
                        {
                            Console.WriteLine($"Udało Ci się pokonać {przeciwnik.nazwa}a.");
                            Console.WriteLine("Wygrałeś walkę.");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            goto exitMethod;
                        }
                        else break;
                    }
                    else if (odpowiedz == 2)
                    {
                        bohater.Leczenie();
                        break;
                    }
                    else Console.WriteLine("Zła opcja!");
                }
                bohater.zdrowie -= przeciwnik.Atak();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{przeciwnik.nazwa.ToUpper()} zaatakował Cię za {przeciwnik.Atak()} zdrowia.");
                Console.ResetColor();
                if (bohater.zdrowie <= 0)
                {
                    Console.WriteLine($"{przeciwnik.nazwa.ToUpper()} zadał Ci śmiertelny cios.");
                    Console.WriteLine("Niestety zginąłeś.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"                  _           
  /\ /\___  _ __ (_) ___  ___ 
 / //_/ _ \| '_ \| |/ _ \/ __|
/ __ \ (_) | | | | |  __/ (__ 
\/  \/\___/|_| |_|_|\___|\___|
                              ");
                    System.Threading.Thread.Sleep(5000);
                    Environment.Exit(0);

                }
                else {}
            }
            exitMethod: ;
        }
        static void Świątynia(Bohaterowie.Bohater bohater)
        {
            Console.WriteLine(@" __          _       _               _       
/ _\_      _(_) __ _| |_ _   _ _ __ (_) __ _ 
\ \\ \ /\ / / |/ _` | __| | | | '_ \| |/ _` |
_\ \\ V  V /| | (_| | |_| |_| | | | | | (_| |
\__/ \_/\_/ |_|\__,_|\__|\__, |_| |_|_|\__,_|
                         |___/               ");
            int cena = 40 * (1 + bohater.poziom);
            Console.WriteLine($"Znajdujesz się w świątyni. Kapłan oferuję Ci pełne uzdrowienie za {cena} złota");
            Console.WriteLine("Przyjmujesz ofertę?\n1.Tak\n2.Nie");
            while(true)
            {
                Console.Write("Podaj cyfrę: ");
                int odpowiedz = int.Parse(Console.ReadLine());
                if (odpowiedz == 1)
                {
                    if (bohater.Złoto < cena)
                    {
                        Console.WriteLine($"Brak funduszy. Potrzebujesz jeszcze {cena - bohater.Złoto} złota.");
                    }
                    else
                    {
                        bohater.Uzdrowienie();
                        bohater.Złoto -= cena;
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        Karczma(bohater);
                    }
                }
                else if (odpowiedz == 2)
                {
                    Console.Clear();
                    Karczma(bohater);
                }
                else Console.WriteLine("Zła opcja");
            }
        }
        static void PonureLasy(Bohaterowie.Bohater bohater)
        {
            Console.Clear();
            Console.WriteLine(@"   ___                               __                 
  / _ \___  _ __  _   _ _ __ ___    / /  __ _ ___ _   _ 
 / /_)/ _ \| '_ \| | | | '__/ _ \  / /  / _` / __| | | |
/ ___/ (_) | | | | |_| | | |  __/ / /__| (_| \__ \ |_| |
\/    \___/|_| |_|\__,_|_|  \___| \____/\__,_|___/\__, |
                                                  |___/ ");

            Console.WriteLine("Zbliżasz się do ponurych lasów.\nCzy na pewno chcesz wejść w ich mroczne zakamarki?\n1.Tak\n2.Nie");
            while(true)
            {
                Console.Write("Wprowadź cyfrę: ");
                int odpowiedz = int.Parse(Console.ReadLine());
                if (odpowiedz == 1)
                {
                    Random r1 = new Random();
                    for (int x = 1; x <= 10; x++)
                    {
                        int losowa_liczba = r1.Next(1, 10);

                        if (losowa_liczba == 1 || losowa_liczba == 2 || losowa_liczba == 3)
                        {
                            Console.Clear();
                            Potwory.Potwór wilk = new Potwory.Potwór(2, 50, "wilk");
                            Walka(bohater, wilk);
                        }
                        else if (losowa_liczba == 4 || losowa_liczba == 5 || losowa_liczba == 6 || losowa_liczba==7)
                        {
                            Console.Clear();
                            Console.WriteLine("Znalazłeś skromną ilość złota, szybko schowałeś całą sumkę do swojego plecaka");
                            bohater.Złoto += 10;
                            Console.WriteLine("Twoje saldo wzrosło o 10 złota");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wygląda na to, że niczego tutaj nie znalazłeś");
                        }

                        if (x == 10)
                        {
                            Console.WriteLine("Brawo, ukończyłeś przygodę!");
                            bohater.Awans();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            Karczma(bohater);
                        }
                        else
                        {
                            Console.WriteLine($"Przeszedłeś właśnie {x} km. Idziesz dalej czy wracasz do karczmy?\n1.Idę dalej\n2.Wracam");
                            while(true)
                            {
                                Console.Write("Wybierz cyfrę: ");
                                int odpowiedz1 = int.Parse(Console.ReadLine());
                                if (odpowiedz1 == 1)
                                {
                                    break;
                                }
                                else if(odpowiedz1 == 2)
                                {
                                    Console.Clear();
                                    Karczma(bohater);
                                }
                                else
                                {
                                    Console.WriteLine("Zła opcja!");
                                }
                            }
                        }
                    
                    }
                }
                else if (odpowiedz == 2)
                {
                    Console.Clear();
                    Karczma(bohater);
                }
                else Console.WriteLine("Zła opcja!");
            }
        }
        static void LochyUmarlych(Bohaterowie.Bohater bohater)
        {
            Console.Clear();
            Console.WriteLine(@"   __            _                                        _            _     
  / /  ___   ___| |__  _   _   _   _ _ __ ___   __ _ _ __| |_   _  ___| |__  
 / /  / _ \ / __| '_ \| | | | | | | | '_ ` _ \ / _` | '__| | | | |/ __| '_ \ 
/ /__| (_) | (__| | | | |_| | | |_| | | | | | | (_| | |  | | |_| | (__| | | |
\____/\___/ \___|_| |_|\__, |  \__,_|_| |_| |_|\__,_|_|  |_|\__, |\___|_| |_|
                       |___/                                |___/            ");
            Console.WriteLine("Zbliżasz się do Lochów Umarłych.\nCzy na pewno chcesz wejść w tak przeraźliwy obszar?\n1.Tak\n2.Nie");
            while(true)
            {
                Console.Write("Wprowadź cyfrę: ");
                int odpowiedz = int.Parse(Console.ReadLine());
                if (odpowiedz == 1)
                {
                    for (int x = 1; x <= 10; x++)
                    {
                        Random r1 = new Random();
                        int losowa_liczba = r1.Next(1, 10);

                        if (losowa_liczba == 1 || losowa_liczba == 2 || losowa_liczba == 3 || losowa_liczba == 4)
                        {
                            Console.Clear();
                            Potwory.Potwór szkielet = new Potwory.Potwór(3, 100, "szkielet");
                            Walka(bohater, szkielet);
                        }
                        else if (losowa_liczba == 5 || losowa_liczba == 6 || losowa_liczba == 7 || losowa_liczba==8)
                        {
                            Console.WriteLine("Znalazłeś skromną ilość złota, szybko schowałeś całą sumkę do swojego plecaka");
                            bohater.Złoto += 20;
                            Console.WriteLine("Twoje saldo wzrosło o 20 złota");
                        }
                        else
                        {
                            Console.WriteLine("Wygląda na to, że niczego tutaj nie znalazłeś");
                        }

                        if (x == 10)
                        {
                            Console.WriteLine("Brawo, ukończyłeś przygodę!");
                            bohater.Awans();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            Karczma(bohater);
                        }
                        else
                        {
                            Console.WriteLine($"Przeszedłeś właśnie {x} poziom lochu. Zauwazyłeś drabinę. Schodzisz dalej czy wracasz do karczmy?\n1.Schodzę\n2.Wracam");
                            while(true)
                            {
                                Console.Write("Wybierz cyfrę: ");
                                int odpowiedz1 = int.Parse(Console.ReadLine());
                                if (odpowiedz1 == 1)
                                {
                                    break;
                                }
                                else if(odpowiedz1 == 2)
                                {
                                    Console.Clear();
                                    Karczma(bohater);
                                }
                                else
                                {
                                    Console.WriteLine("Zła opcja!");
                                }
                            }
                        }
                    
                    }
                }
                else if (odpowiedz == 2)
                {
                    Console.Clear();
                    Karczma(bohater);
                }
                else Console.WriteLine("Zła opcja!");
            }
        }
        static void SwiatyniaZla(Bohaterowie.Bohater bohater)
        {
            Console.Clear();
            Console.WriteLine(@" __          _       _               _         ______       
/ _\_      _(_) __ _| |_ _   _ _ __ (_) __ _  / _  / | __ _ 
\ \\ \ /\ / / |/ _` | __| | | | '_ \| |/ _` | \// /| |/ _` |
_\ \\ V  V /| | (_| | |_| |_| | | | | | (_| |  / //\ | (_| |
\__/ \_/\_/ |_|\__,_|\__|\__, |_| |_|_|\__,_| /____/_|\__,_|
                         |___/                              ");

            while(true)
            {
                Console.Write("Wprowadź cyfrę: ");
                int odpowiedz = int.Parse(Console.ReadLine());
                if (odpowiedz == 1)
                {
                    for (int x = 1; x <= 10; x++)
                    {
                        Random r1 = new Random();
                        int losowa_liczba = r1.Next(1, 10);

                        if (losowa_liczba == 1 || losowa_liczba == 2 || losowa_liczba == 3)
                        {
                            Console.Clear();
                            Potwory.Potwór kapłan = new Potwory.Potwór(4, 150, "kapłan");
                            Walka(bohater, kapłan);
                        }
                        else if (losowa_liczba == 4 || losowa_liczba == 5 || losowa_liczba == 6 || losowa_liczba==7)
                        {
                            Console.WriteLine("Znalazłeś skromną ilość złota, szybko schowałeś całą sumkę do swojego plecaka");
                            bohater.Złoto += 30;
                            Console.WriteLine("Twoje saldo wzrosło o 30 złota");
                        }
                        else
                        {
                            Console.WriteLine("Wygląda na to, że niczego tutaj nie znalazłeś");
                        }
                        if (x == 10)
                        {
                            Console.WriteLine("Brawo, ukończyłeś przygodę!");
                            bohater.Awans();
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                            Karczma(bohater);
                        }
                        else
                        {
                            Console.WriteLine($"Przeszedłeś właśnie {x} piętro. Zauwazyłeś schody. Wchodzi wyżej czy wracasz do karczmy?\n1.Wchodzę\n2.Wracam");
                            while(true)
                            {
                                Console.Write("Wybierz cyfrę: ");
                                int odpowiedz1 = int.Parse(Console.ReadLine());
                                if (odpowiedz1 == 1)
                                {
                                    break;
                                }
                                else if(odpowiedz1 == 2)
                                {
                                    Console.Clear();
                                    Karczma(bohater);
                                }
                                else
                                {
                                    Console.WriteLine("Zła opcja!");
                                }
                            }
                        }
                    }
                }
                else if (odpowiedz == 2)
                {
                    Console.Clear();
                    Karczma(bohater);
                }
                else Console.WriteLine("Zła opcja!");
            }
        }
        static void Przygoda(Bohaterowie.Bohater bohater)
        {
            Console.WriteLine(@"   ___                                _       
  / _ \_ __ _____   _  __ _  ___   __| | __ _ 
 / /_)/ '__|_  / | | |/ _` |/ _ \ / _` |/ _` |
/ ___/| |   / /| |_| | (_| | (_) | (_| | (_| |
\/    |_|  /___|\__, |\__, |\___/ \__,_|\__,_|
                |___/ |___/                   ");
            Console.WriteLine("Oto lista przygód. Wybierz lokację, której chcesz stawić czoło.");
            
            Console.WriteLine("1. Ponure lasy [0-4 LVL].");
            Console.WriteLine("2. Lochy umarłych [5-9 LVL].");
            Console.WriteLine("3. Świątynia zła [10-14 LVL].");
            while(true)
            {
                Console.Write("Wprowadz cyfre: ");
                int odpowiedz = int.Parse(Console.ReadLine());
                if(odpowiedz == 1)
                {
                    if (bohater.poziom < 5)
                    {
                        PonureLasy(bohater);
                    }
                    else Console.WriteLine("Masz za wysoki poziom na tę przygodę.");
                }
                else if(odpowiedz == 2)
                {
                    if (bohater.poziom < 5)
                    {
                        Console.WriteLine("Masz za niski poziom na tę przygodę.");
                    }
                    else if (bohater.poziom < 10)
                    {
                        LochyUmarlych(bohater);
                    }
                    else Console.WriteLine("Masz za wysoki poziom na tę przygodę.");
                }
                else if (odpowiedz == 3)
                {
                    if (bohater.poziom < 10)
                    {
                        Console.WriteLine("Masz za niski poziom na tę przygodę.");
                    }
                    else
                    {
                        SwiatyniaZla(bohater);
                    }
                    
                }
                else Console.WriteLine("Zła opcja!");
            }
        }
        static void StatEkwi(Bohaterowie.Bohater bohater)
        {
            Console.WriteLine(@" __ _        _             _         _    _   _     __ _              _                        _    
/ _\ |_ __ _| |_ _   _ ___| |_ _   _| | _(_) (_)   /__\ | ____      _(_)_ __  _   _ _ __   ___| | __
\ \| __/ _` | __| | | / __| __| | | | |/ / | | |  /_\ | |/ /\ \ /\ / / | '_ \| | | | '_ \ / _ \ |/ /
_\ \ || (_| | |_| |_| \__ \ |_| |_| |   <| | | | //__ |   <  \ V  V /| | |_) | |_| | | | |  __/   < 
\__/\__\__,_|\__|\__, |___/\__|\__, |_|\_\_| |_| \__/ |_|\_\  \_/\_/ |_| .__/ \__,_|_| |_|\___|_|\_\
                 |___/         |___/                                   |_|                          ");
            bohater.StatystykiEkwipunek();
            Console.WriteLine("\nCo chcesz zrobić?\n1. Powrót\n2. Wyjdź z gry");
            while (true)
            {
                Console.Write("Wprowadź cyfre: ");
                int odpowiedz = int.Parse(Console.ReadLine());
                if (odpowiedz == 1)
                {
                    Console.Clear();
                    Karczma(bohater);
                    break;
                }
                else if (odpowiedz == 2)
                {
                    Environment.Exit(0);
                }
                else Console.WriteLine("Zła opcja!");
            }
        }
        static void Sklep(Bohaterowie.Bohater bohater)
        {
            double cena = 0;
            int odpowiedz1;
            double bonus_przedmiotu = 0;
            string nazwa_przedmiotu = "";
            Console.WriteLine(@" __ _    _            
/ _\ | _| | ___ _ __  
\ \| |/ / |/ _ \ '_ \ 
_\ \   <| |  __/ |_) |
\__/_|\_\_|\___| .__/ 
               |_|    ");
            Console.WriteLine("Witaj w sklepie konusie");
            Console.WriteLine("\nWybierz rodzaj wyposażenia który chciałbyś zakupić:\n1. Broń\n2. Zbroja\n3. Błyskotka\n4. Powrót do Karczmy");
            while (true)
            {
                Console.Write($"Twoje saldo: {bohater.Złoto}. Wprowadź cyfre: ");
                odpowiedz1 = int.Parse(Console.ReadLine());
                if (odpowiedz1 == 1)
                {
                    Console.WriteLine($"Oto lista broni. Pamiętaj że możesz nosić tylko jedną jednocześnie.\nAktualnie posiadasz: {bohater.Broń}");
                    Console.WriteLine("Wprowadz cyfre:");
                    Console.WriteLine("1. Ostrze Zatracenia: +5 do siły. Cena 40");
                    Console.WriteLine("2. Rapier Szermierza: +5.5 do siły. Cena 50");
                    Console.WriteLine("3. Młot Bojowy: +6 do siły. Cena 65");
                    Console.WriteLine("4. Sztylet Okrutnika: +6.5 do siły. Cena 70");
                    Console.WriteLine("5. Kostur Mąciciela: +6.9 do siły. Cena 80");
                    Console.WriteLine("6. Laska Mędrca: +7.5 do siły. Cena 100");
                    Console.WriteLine("7. Srebrna Naginata Wiedzmina z Rybnika: +8 do siły. Cena 110");
                    Console.WriteLine("8. Powrót");
                    int odpowiedz2 = int.Parse(Console.ReadLine());
                    if (odpowiedz2 == 1)
                    {
                        cena = 40;
                        bonus_przedmiotu = 5;
                        nazwa_przedmiotu = "Ostrze Zatracenia";
                        break;
                        
                    }
                    else if (odpowiedz2 == 2)
                    {

                        cena = 50;
                        bonus_przedmiotu = 5.5;
                        nazwa_przedmiotu = "Rapier Szermierza";
                        break;
                    }
                    else if (odpowiedz2 == 3)
                    {

                        cena = 65;
                        bonus_przedmiotu = 6;
                        nazwa_przedmiotu = "Młot Bojowy";
                        break;
                    }
                    else if (odpowiedz2 == 4)
                    {

                        cena = 70;
                        bonus_przedmiotu = 6.5;
                        nazwa_przedmiotu = "Sztylet Okrutnika";
                        break;
                    }
                    else if (odpowiedz2 == 5)
                    {

                        cena = 80;
                        bonus_przedmiotu = 6.9;
                        nazwa_przedmiotu = "Kostur Mąciciela";
                        break;
                    }
                    else if (odpowiedz2 == 6)
                    {

                        cena = 100;
                        bonus_przedmiotu = 7.5;
                        nazwa_przedmiotu = "Laska Mędrca";
                        break;
                    }
                    else if (odpowiedz2 == 7)
                    {

                        cena = 110;
                        bonus_przedmiotu = 8;
                        nazwa_przedmiotu = "Naginata";
                        break;

                    }
                    else if (odpowiedz2 == 8)
                    {
                        Console.Clear();
                        Sklep(bohater);
                        break;
                    }
                    else Console.WriteLine("Zła opcja!");
                }
                else if (odpowiedz1 == 2)
                {

                    Console.WriteLine($"Oto lista zbroi. Pamiętaj że możesz nosić tylko jedną jednocześnie.\nAktualnie posiadasz: {bohater.Zbroja}");
                    Console.WriteLine("Wprowadz cyfre:");
                    Console.WriteLine("1. Kapota mnicha: +8 wytrzymałość. Cena 35");
                    Console.WriteLine("2. Strój Ninja: +12 wytrzymałość. Cena 70");
                    Console.WriteLine("3. Pełna Płytówka: +14 wytrzymałość. Cena 80");
                    Console.WriteLine("4. Runiczny Pancerz Gurala z Bieszczad: +20 wytrzymałość. Cena 120 ");
                    Console.WriteLine("5. Powrót");
                    int odpowiedz2 = int.Parse(Console.ReadLine());
                    if (odpowiedz2 == 1)
                    {

                        cena = 35;
                        bonus_przedmiotu = 8;
                        nazwa_przedmiotu = "Kapota mnicha";
                        break;
                    }
                    else if (odpowiedz2 == 2)
                    {

                        cena = 70;
                        bonus_przedmiotu = 12;
                        nazwa_przedmiotu = "Strój Ninja";
                        break;
                    }
                    else if (odpowiedz2 == 3)
                    {

                        cena = 80;
                        bonus_przedmiotu = 14;
                        nazwa_przedmiotu = "Pełna Płytówka";
                        break;
                    }
                    else if (odpowiedz2 == 4)
                    {

                        cena = 120;
                        bonus_przedmiotu = 20;
                        nazwa_przedmiotu = "Runiczny Pancerz";
                        break;
                    }
                    else if (odpowiedz2 == 5)
                    {
                        Console.Clear();
                        Sklep(bohater);
                        break;
                    }
                    else Console.WriteLine("Zła opcja!");
                }
                else if (odpowiedz1 == 3)
                {

                    Console.WriteLine($"Oto lista błyskotek. Pamiętaj że możesz nosić tylko jedną jednocześnie.\nAktualnie posiadasz: {bohater.Błyskotka}");
                    Console.WriteLine("Wprowadz cyfre:");
                    Console.WriteLine("1. Pierścień mnicha: +10 zdrowie i mana. Cena 50");
                    Console.WriteLine("2. Naszyjnik złotego kapłana : +20 zdrowie i mana. Cena 100 ");
                    Console.WriteLine("3. Broszka Czarnego Jastrzębia: +30 zdrowie i mana. Cena 250");
                    Console.WriteLine("4. Powrót");
                    int odpowiedz2 = int.Parse(Console.ReadLine());
                    if (odpowiedz2 == 1)
                    {
                        cena = 50;
                        bonus_przedmiotu = 10;
                        nazwa_przedmiotu = "Pierścień mnicha";
                        break;
                    }
                    else if (odpowiedz2 == 2)
                    {
                        cena = 100;
                        bonus_przedmiotu = 20;
                        nazwa_przedmiotu = "Naszyjnik złotego kapłana";
                        break;
                    }
                    else if (odpowiedz2 == 3)
                    {
                        cena = 250;
                        bonus_przedmiotu = 30;
                        nazwa_przedmiotu = "Broszka Czarnego Jastrzębia";
                        break;
                    }
                    else if (odpowiedz2 == 4)
                    {
                        Console.Clear();
                        Sklep(bohater);
                        break;
                    }
                    else Console.WriteLine("Zła opcja!");

                }
                else if (odpowiedz1 == 4)
                {
                    Console.Clear();
                    Karczma(bohater);
                    break;
                }
                else Console.WriteLine("Zła opcja!");
            }

            if(cena <= bohater.Złoto)
            {
                if (odpowiedz1 == 1)
                {
                    bohater.BrońSiła = bonus_przedmiotu;
                    bohater.Broń = nazwa_przedmiotu;
                }
                else if (odpowiedz1 == 2)
                {
                    bohater.ZbrojaWytrzymałość = bonus_przedmiotu;
                    bohater.Zbroja = nazwa_przedmiotu;
                }
                else if (odpowiedz1 == 3)
                {
                    bohater.BłyskotkaManaZdrowie = bonus_przedmiotu;
                    bohater.Błyskotka = nazwa_przedmiotu;
                }
                bohater.Złoto -= cena;
                bohater.UstawStatystki();
                Console.WriteLine($"Kupiłeś {nazwa_przedmiotu}. Twoje aktualne saldo: {bohater.Złoto}");
                cena = 0;
            }
            else
            {
                Console.WriteLine($"Brak funduszy. Potrzebujesz jeszcze {cena - bohater.Złoto}");
                cena = 0;
            }

            Console.WriteLine("\nCo teraz?\n1. Kontynuuj zakupy\n2. Wróć do karczmy");

            while(true)
            {
                int odpowiedz3 = int.Parse(Console.ReadLine());
                    
                if(odpowiedz3 == 1)
                {
                    Console.Clear();
                    Sklep(bohater);
                    break;
                }
                else if (odpowiedz3 == 2)
                {
                    Console.Clear();
                    Karczma(bohater);
                    break;
                }
                    else Console.WriteLine("Zła opcja!");
            }
        }
        static void Karczma(Bohaterowie.Bohater bohater)
        {
            Console.WriteLine(@"                                         
  /\ /\__ _ _ __ ___ _____ __ ___   __ _ 
 / //_/ _` | '__/ __|_  / '_ ` _ \ / _` |
/ __ \ (_| | | | (__ / /| | | | | | (_| |
\/  \/\__,_|_|  \___/___|_| |_| |_|\__,_|
                                         ");
            Console.WriteLine("Witaj w karczmie podróżniku");
            Console.WriteLine("\nCo chcesz zrobić?\n1. Przygoda\n2. Sklep\n3. Statystyki i ekwipunek\n4. Świątynia\n5. Wyjdź z gry");
            while (true)
            {
                Console.Write("Wprowadź cyfre: ");
                int odpowiedz = int.Parse(Console.ReadLine());
                if (odpowiedz == 1)
                {
                    Console.Clear();
                    Przygoda(bohater);
                    break;
                }
                else if (odpowiedz == 2)
                {
                    Console.Clear();
                    Sklep(bohater);
                    break;
                }
                else if (odpowiedz == 3)
                {
                    Console.Clear();
                    StatEkwi(bohater);
                    break;
                }
                else if (odpowiedz == 4)
                {
                    Console.Clear();
                    Świątynia(bohater);
                    break;
                }
                else if (odpowiedz == 5)
                {
                    Environment.Exit(0);
                }
                else Console.WriteLine("Zła opcja!");
            }
        }
        static void NowaGra()
        {
            Console.WriteLine(@"     __                       ___           
  /\ \ \_____      ____ _    / _ \_ __ __ _ 
 /  \/ / _ \ \ /\ / / _` |  / /_\/ '__/ _` |
/ /\  / (_) \ V  V / (_| | / /_\\| | | (_| |
\_\ \/ \___/ \_/\_/ \__,_| \____/|_|  \__,_|
                                            ");
            Console.WriteLine("Witaj w przygodzie tekstowej super gra");
            Console.WriteLine("\nWybierz profesję gośćiu\n1. Rycerz\n2. Wojownik\n3. Łowca");
            while (true)
            {
                Console.Write("Wprowadź cyfre: ");
                int profesja = int.Parse(Console.ReadLine());
                if (profesja == 1)
                {
                    Bohaterowie.Bohater Rycerz = new Bohaterowie.Bohater(3, 20, 100, 50, 10, "Rycerz");
                    Rycerz.UstawStatystki();
                    Console.WriteLine("Wybrałeś profesje: Rycerz");
                    Console.Clear();
                    Karczma(Rycerz);
                    break;
                }
                else if (profesja == 2)
                {
                    Bohaterowie.Bohater Wojownik = new Bohaterowie.Bohater(1, 10, 50, 200, 20, "Wojownik");
                    Wojownik.UstawStatystki();
                    Console.WriteLine("Wybrałeś profesje: Wojownik");
                    Console.Clear();
                    Karczma(Wojownik);
                    break;
                }
                else if (profesja == 3)
                {
                    Bohaterowie.Bohater Łowca = new Bohaterowie.Bohater(6, 20, 70, 30, 50, "Łowca");
                    Łowca.UstawStatystki();
                    Console.WriteLine("Wybrałeś profesje: Łowca");
                    Console.Clear();
                    Karczma(Łowca);
                    break;
                }
                else Console.WriteLine("Zła opcja!");
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine(@" _____ _              _       _                 _                  
/__   \ |__   ___    /_\   __| |_   _____ _ __ | |_ _   _ _ __ ___ 
  / /\/ '_ \ / _ \  //_\\ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \
 / /  | | | |  __/ /  _  \ (_| |\ V /  __/ | | | |_| |_| | | |  __/
 \/   |_| |_|\___| \_/ \_/\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|
                                                                   ");
            int opcja;
            Console.WriteLine("\nWybierz opcję:\n1. Nowa Gra\n2. Wyjdź");
            while (true)
            {
                Console.Write("Wprowadź cyfre: ");
                opcja = int.Parse(Console.ReadLine());
                if (opcja == 1)
                {
                    Console.Clear();
                    NowaGra();
                    break;
                }
                else if (opcja == 2)
                {
                    Environment.Exit(0);
                }
                else Console.WriteLine("Zła opcja!");
            }
            Console.ReadKey();
        }
        
    }
}
