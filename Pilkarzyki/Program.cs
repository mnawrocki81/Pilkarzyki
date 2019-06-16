using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarzyki
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("*****************************************");
            Console.WriteLine("Rozpoczynamy kolejny turniej Renata's Cup!");
            Console.WriteLine("*****************************************\n");


            Console.Write("Podaj ilość graczy: ");

            string a = Console.ReadLine();
            int n = Mecze.SetInt(a);


            if (n % 2 > 0 || n < 4)
            {

                do
                {
                    Console.WriteLine("W turniej musi brać udział parzysta liczba graczy! Minimum 4 graczy");
                    Console.Write("Podaj ilość graczy: ");
                    a = Console.ReadLine();
                    n = Mecze.SetInt(a);

                } while (n % 2 != 0 || n < 4);
            }

            //tworzymy nowych zawodników

            Zawodnicy[] tab = new Zawodnicy[n];

            Zawodnicy.TworzenieZawodników(tab, n);

            //sortujemy graczy według ich pozycji w rankingu
            Zawodnicy.Sortuj(tab);

            Console.WriteLine("\nGracze posortowani ");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine("{0,-12} {1,2}", tab[i].Ksywa, tab[i].Miejsce);
            }

            //tworzymy podział na zawodników rozstawionych i nierozstawionych

            Zawodnicy[] tabRozstawieni = new Zawodnicy[n / 2];
            Zawodnicy[] tabNierozstawieni = new Zawodnicy[n / 2];

            for (int i = 0; i < n / 2; i++)
            {
                tabRozstawieni[i] = tab[i];
            }

            for (int i = 0; i < n / 2; i++)
            {

                tabNierozstawieni[i] = tab[i + n / 2];
            }

            //wyświetlenie podziału na rozstawionych i nierozstawionych
            Console.WriteLine("\nGracze rozstawieni ");
            for (int i = 0; i < tabRozstawieni.Length; i++)
            {
                Console.WriteLine("{0,-12} {1,2}", tabRozstawieni[i].Ksywa, tabRozstawieni[i].Miejsce);
            }

            Console.WriteLine("\nGracze nierozstawieni ");
            for (int i = 0; i < tabNierozstawieni.Length; i++)
            {
                Console.WriteLine("{0,-12} {1,2}", tabNierozstawieni[i].Ksywa, tabNierozstawieni[i].Miejsce);
            }

            //dzielimy graczy na drużyny 
            Random rand = new Random();
            Zawodnicy zaw1, zaw2;

            int m = n / 2;
            int d = n / 4;


            Drużyny[] Grupa1tabdrużyny = new Drużyny[n / 4];
            Drużyny[] Grupa2tabdrużyny = new Drużyny[(n / 2) - (n / 4)];
            Drużyny[] tabdrużyny = new Drużyny[n / 2];


            string tabSign = "ABCDEFGHIJKLMNOPRSTUVWXYZ";

            if (n < 16)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    int r1 = rand.Next(m);
                    zaw1 = tabRozstawieni[r1];
                    tabRozstawieni[r1] = tabRozstawieni[m - 1];

                    int r2 = rand.Next(m);
                    zaw2 = tabNierozstawieni[r2];
                    tabNierozstawieni[r2] = tabNierozstawieni[m - 1];

                    m--;

                    tabdrużyny[i] = new Drużyny(tabSign[i], zaw1, zaw2);

                }

                Console.WriteLine("\nWylosowane drużyny ");
                foreach (Drużyny p in tabdrużyny)
                {
                    p.PokażDrużyne();
                }
            }

            else if (n >= 16)
            {

                for (int i = 0; i < n / 4; i++)
                {
                    int r1 = rand.Next(m);
                    zaw1 = tabRozstawieni[r1];
                    tabRozstawieni[r1] = tabRozstawieni[m - 1];

                    int r2 = rand.Next(m);
                    zaw2 = tabNierozstawieni[r2];
                    tabNierozstawieni[r2] = tabNierozstawieni[m - 1];

                    m--;

                    Grupa1tabdrużyny[i] = new Drużyny(tabSign[i], zaw1, zaw2);


                }

                Console.WriteLine("\nWylosowane drużyny Grupa 1 ");
                foreach (Drużyny p in Grupa1tabdrużyny)
                {
                    p.PokażDrużyne();
                }

                for (int i = 0; i < (n / 2 - n / 4); i++)
                {
                    int r1 = rand.Next(m);
                    zaw1 = tabRozstawieni[r1];
                    tabRozstawieni[r1] = tabRozstawieni[m - 1];

                    int r2 = rand.Next(m);
                    zaw2 = tabNierozstawieni[r2];
                    tabNierozstawieni[r2] = tabNierozstawieni[m - 1];

                    m--;

                    Grupa2tabdrużyny[i] = new Drużyny(tabSign[d], zaw1, zaw2);

                    d++;

                }

                Console.WriteLine("\nWylosowane drużyny Grupa 2 ");
                foreach (Drużyny p in Grupa2tabdrużyny)
                {
                    p.PokażDrużyne();
                }

            }



            Console.WriteLine("\nNo to zaczynamy grę! GAAAAŁA!!!");

            if (n >= 16)
                Console.WriteLine($"\nW tym turnieju rozegranych będzie {(Mecze.IloscMeczy(n / 4) + Mecze.IloscMeczy(n / 2 - n / 4))} meczy");
            else
                Console.WriteLine($"\nW tym turnieju rozegranych będzie {Mecze.IloscMeczy(n / 2)} meczy");

            Mecze[] tabMecze = new Mecze[Mecze.IloscMeczy(n / 2)];
            Mecze[] tabMeczeGr1 = new Mecze[Mecze.IloscMeczy(n / 4)];
            Mecze[] tabMeczeGr2 = new Mecze[Mecze.IloscMeczy(n / 2 - n / 4)];
            int k = 0, l = 0;

            if (n < 16)
            {
                for (int i = 0; i < tabdrużyny.Length - 1; i++)
                {
                    for (int j = i + 1; j < tabdrużyny.Length; j++)
                    {
                        tabMecze[k] = new Mecze(tabdrużyny[i], tabdrużyny[j], 0, 0);
                        k++;
                    }
                }
            }

            else if (n >= 16)
            {
                for (int i = 0; i < Grupa1tabdrużyny.Length - 1; i++)
                {
                    for (int j = i + 1; j < Grupa1tabdrużyny.Length; j++)
                    {
                        tabMeczeGr1[k] = new Mecze(Grupa1tabdrużyny[i], Grupa1tabdrużyny[j], 0, 0);
                        k++;
                    }
                }

                for (int i = 0; i < Grupa2tabdrużyny.Length - 1; i++)
                {
                    for (int j = i + 1; j < Grupa2tabdrużyny.Length; j++)
                    {
                        tabMeczeGr2[l] = new Mecze(Grupa2tabdrużyny[i], Grupa2tabdrużyny[j], 0, 0);
                        l++;
                    }
                }

            }


            Mecze[] losowaneMecze = new Mecze[tabMecze.Length];
            Mecze[] Grupa1LosowaneMecze = new Mecze[tabMeczeGr1.Length];
            Mecze[] Grupa2LosowaneMecze = new Mecze[tabMeczeGr2.Length];


            if (n != 4) //gdy 2 drużyny, od razu przechodzimy do finału
            {
                if (n < 16)
                {
                    Mecze.Losowanie(tabMecze, losowaneMecze);

                    for (int i = 0; i < losowaneMecze.Length; i++)
                    {
                        Mecze.Rozgrywki(losowaneMecze, i);

                    }

                    Mecze.PokażWyniki(tabdrużyny);
                    Mecze.KorektyMeczów(losowaneMecze, tabdrużyny);

                }
                else

                {
                    Mecze.Losowanie(tabMeczeGr1, Grupa1LosowaneMecze);
                    Mecze.Losowanie(tabMeczeGr2, Grupa2LosowaneMecze);

                    for (int i = 0; i < Grupa1LosowaneMecze.Length; i++)
                    {
                        Console.Write($"\nGramy mecz grupy 1! Drużyna {Grupa1LosowaneMecze[i].d1.Nazwa} kontra {Grupa1LosowaneMecze[i].d2.Nazwa} ");
                        Mecze.Rozgrywki(Grupa1LosowaneMecze, i);
                        Console.Write($"\nGramy mecz grupy 2! Drużyna {Grupa2LosowaneMecze[i].d1.Nazwa} kontra {Grupa2LosowaneMecze[i].d2.Nazwa} ");
                        Mecze.Rozgrywki(Grupa2LosowaneMecze, i);
                    }

                    if (Grupa2LosowaneMecze.Length > Grupa1LosowaneMecze.Length)
                    {
                        int diff = Grupa1LosowaneMecze.Length;
                        for (int i = diff; i < Grupa2LosowaneMecze.Length; i++)
                        {
                            Console.Write($"\nGramy mecz grupy 2! Drużyna {Grupa2LosowaneMecze[i].d1.Nazwa} kontra {Grupa2LosowaneMecze[i].d2.Nazwa} ");
                            Mecze.Rozgrywki(Grupa2LosowaneMecze, i);
                        }

                    }

                    Console.Write("\nTabela grupy 1!");
                    Mecze.PokażWyniki(Grupa1tabdrużyny);
                    Mecze.KorektyMeczów(Grupa1LosowaneMecze, Grupa1tabdrużyny);
                    Console.Write("\nTabela grupy 2!");
                    Mecze.PokażWyniki(Grupa2tabdrużyny);
                    Mecze.KorektyMeczów(Grupa2LosowaneMecze, Grupa2tabdrużyny);

                }

                Console.Write("\nZakończyła się faza grupowa!");
            }

            if (n < 16)
                Mecze.Półfinały(tabdrużyny, n);
            else
            {
                Mecze.Półfinały(tabdrużyny, Grupa1tabdrużyny, Grupa2tabdrużyny);


                for (int i = 0; i < 4; i++)
                    Console.WriteLine("Drużyna: {0} Punkty: {1}, małe Punkty: {2}", tabdrużyny[i].Nazwa, tabdrużyny[i].Punkty, tabdrużyny[i].Małepunkty);
            }

            Mecze.MeczOTrzecieMiejsce(tabdrużyny, n);

            Mecze.WielkiFinał(tabdrużyny, 0, 1);


            Console.ReadKey();
        }
    }
}
