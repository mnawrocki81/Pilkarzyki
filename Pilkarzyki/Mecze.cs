using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarzyki
{
    class Mecze
    {


        public Drużyny d1;
        public Drużyny d2;
        public int Wd1 { get; set; }
        public int Wd2 { get; set; }


        public Mecze(Drużyny d1, Drużyny d2, int x = 0, int y = 0)
        {

            this.d1 = d1;
            this.d2 = d2;
            this.Wd1 = x;
            this.Wd2 = y;
        }

        //Funkcja rekurencyjna obliczająca iloć meczy, w zależności od ilości zawodników
        public static int IloscMeczy(int n)
        {
            if (n < 2) return 0;
            else if (n == 2) return 1;
            else return (n - 1) + IloscMeczy(n - 1);

        }


        public static int SetInt(string a)
        {
            int x;
            Console.WriteLine();
            while (!int.TryParse(a, out x))
            {
                Console.Write("Musisz podać liczbę, spróbuj ponownie: ");
                a = Console.ReadLine();
            }

            return x;

        }


        public static void Rozgrywki(Mecze[] losowaneMecze, int i)
        {

            Console.Write($"\nMecz {i + 1}: \nPodaj wynik drużyny {losowaneMecze[i].d1.Nazwa}: ");
            string a = Console.ReadLine();
            losowaneMecze[i].Wd1 = SetInt(a);

            Console.Write($"Podaj wynik drużyny {losowaneMecze[i].d2.Nazwa}: ");
            a = Console.ReadLine();
            losowaneMecze[i].Wd2 = SetInt(a);


            if (losowaneMecze[i].Wd1 == losowaneMecze[i].Wd2)
            {

                do
                {
                    Console.WriteLine("Mecz musi być rozstrzygnięty! Nie może być remisów!!!");
                    Console.Write($"Podaj wynik drużyny {losowaneMecze[i].d1.Nazwa}: ");

                    a = Console.ReadLine();
                    losowaneMecze[i].Wd1 = SetInt(a);

                    Console.Write($"Podaj wynik drużyny {losowaneMecze[i].d2.Nazwa}: ");

                    a = Console.ReadLine();
                    losowaneMecze[i].Wd2 = SetInt(a);

                } while (losowaneMecze[i].Wd1 == losowaneMecze[i].Wd2);
            }


            if (losowaneMecze[i].Wd1 > losowaneMecze[i].Wd2)
                losowaneMecze[i].d1.Punkty += 3;
            else losowaneMecze[i].d2.Punkty += 3;

            losowaneMecze[i].d1.Małepunkty += losowaneMecze[i].Wd1 - losowaneMecze[i].Wd2;
            losowaneMecze[i].d2.Małepunkty += losowaneMecze[i].Wd2 - losowaneMecze[i].Wd1;

        }

        public static void Losowanie(Mecze[] tabMecze, Mecze[] losowaneMecze)
        {
            Random rand = new Random();
            int m = tabMecze.Length;

            Console.WriteLine();
            for (int i = 0; i < tabMecze.Length; i++)
            {
                int r = rand.Next(m);

                //losowaneMecze[i] = new Mecze (tabMecze[r].d1, tabMecze[r].d2)  ;
                losowaneMecze[i] = tabMecze[r];
                tabMecze[r] = tabMecze[m - 1];

                Console.WriteLine($"Mecz {i + 1} po losowaniu: drużyna {losowaneMecze[i].d1.Nazwa} ({losowaneMecze[i].d1.z1.Ksywa},{losowaneMecze[i].d1.z2.Ksywa}) " +
                    $"kontra {losowaneMecze[i].d2.Nazwa} ({losowaneMecze[i].d2.z1.Ksywa},{losowaneMecze[i].d2.z2.Ksywa})");
                m--;

            }

        }


        public static void PokażWyniki(Drużyny[] tabdrużyny)
        {
            Drużyny bufor;

            for (int i = 0; i < tabdrużyny.Length - 1; i++)
            {
                for (int j = 0; j < tabdrużyny.Length - 1; j++)
                {
                    if (((tabdrużyny[j].Punkty == tabdrużyny[j + 1].Punkty) && (tabdrużyny[j].Małepunkty < tabdrużyny[j + 1].Małepunkty))
                       || (tabdrużyny[j].Punkty < tabdrużyny[j + 1].Punkty))
                    {
                        bufor = tabdrużyny[j];
                        tabdrużyny[j] = tabdrużyny[j + 1];
                        tabdrużyny[j + 1] = bufor;
                    }

                }
            }

            Console.WriteLine();
            for (int i = 0; i < tabdrużyny.Length; i++)
                Console.WriteLine("Drużyna: {0} Punkty: {1}, małe Punkty: {2}", tabdrużyny[i].Nazwa, tabdrużyny[i].Punkty, tabdrużyny[i].Małepunkty);

        }

        public static void KorektyMeczów(Mecze[] losowaneMecze, Drużyny[] tabdrużyny)
        {
            Console.Write("\nCzy przed decydującymi meczami chcesz wyświetlić i zmienić wyniki meczów? <t/n> ");
            string odp = Console.ReadLine().ToLower();
            if (odp == "t")
            {
                for (int i = 0; i < losowaneMecze.Length; i++)
                    Console.WriteLine($"Mecz {i + 1}: Drużyna {losowaneMecze[i].d1.Nazwa} kontra {losowaneMecze[i].d2.Nazwa}. Wynik: {losowaneMecze[i].Wd1} : {losowaneMecze[i].Wd2} ");

            }

            do
            {
                Console.Write("\nCzy chcesz skorygować wynik któregoś meczu? <t/n> ");
                odp = Console.ReadLine().ToLower();

                if (odp == "t")
                {
                    Console.Write($"\nPodaj numer meczu: ");
                    string a = Console.ReadLine();
                    int j = SetInt(a);

                    if (j > losowaneMecze.Length || j < losowaneMecze.Length)
                    {
                        do
                        {
                            Console.Write("Nie było takiego meczu, spróbuj ponownie: ");
                            a = Console.ReadLine();
                            j = SetInt(a);
                        } while (j > losowaneMecze.Length || j < losowaneMecze.Length);

                    }

                    //Resetowanie punktów przed korektą

                    if (losowaneMecze[j - 1].Wd1 > losowaneMecze[j - 1].Wd2)
                        losowaneMecze[j - 1].d1.Punkty -= 3;
                    else losowaneMecze[j - 1].d2.Punkty -= 3;

                    losowaneMecze[j - 1].d1.Małepunkty -= losowaneMecze[j - 1].Wd1 - losowaneMecze[j - 1].Wd2;
                    losowaneMecze[j - 1].d2.Małepunkty -= losowaneMecze[j - 1].Wd2 - losowaneMecze[j - 1].Wd1;

                    Rozgrywki(losowaneMecze, j - 1);

                    Mecze.PokażWyniki(tabdrużyny);
                }
            } while (odp == "t");
        }

        public static void GramyMecz(Drużyny[] tabdrużyny, int x, int y)
        {
            Console.WriteLine($"\nGramy mecz {tabdrużyny[x].Nazwa} kontra {tabdrużyny[y].Nazwa}");

            Console.Write($"\nPodaj wynik drużyny {tabdrużyny[x].Nazwa}: ");

            string a = Console.ReadLine();
            tabdrużyny[x].Wynik = SetInt(a);

            Console.Write($"Podaj wynik drużyny {tabdrużyny[y].Nazwa}: ");

            string b = Console.ReadLine();
            tabdrużyny[y].Wynik = SetInt(b);

            if (tabdrużyny[x].Wynik == tabdrużyny[y].Wynik)
            {
                do
                {
                    Console.WriteLine("Mecz musi być rozstrzygnięty! Nie może być remisów!!!");
                    Console.Write($"Podaj wynik drużyny {tabdrużyny[x].Nazwa}: ");

                    a = Console.ReadLine();
                    tabdrużyny[x].Wynik = SetInt(a);

                    Console.Write($"Podaj wynik drużyny {tabdrużyny[y].Nazwa}: ");

                    b = Console.ReadLine();
                    tabdrużyny[y].Wynik = SetInt(b);

                } while (tabdrużyny[x].Wynik == tabdrużyny[y].Wynik);
            }

            if (tabdrużyny[x].Wynik < tabdrużyny[y].Wynik)
            {
                Drużyny temp = tabdrużyny[x];
                tabdrużyny[x] = tabdrużyny[y];
                tabdrużyny[y] = temp;
            }

        }

        public static void GramyMecz(Drużyny[] tabdrużyny, Drużyny[] Grupa1tabdrużyny, Drużyny[] Grupa2tabdrużyny, int x, int y)
        {
            Console.WriteLine($"\nGramy mecz {Grupa1tabdrużyny[x].Nazwa} kontra {Grupa2tabdrużyny[y].Nazwa}");


            Console.Write($"\nPodaj wynik drużyny {Grupa1tabdrużyny[x].Nazwa}: ");

            string a = Console.ReadLine();
            Grupa1tabdrużyny[x].Wynik = SetInt(a);

            Console.Write($"Podaj wynik drużyny {Grupa2tabdrużyny[y].Nazwa}: ");

            string b = Console.ReadLine();
            Grupa2tabdrużyny[y].Wynik = SetInt(b);

            if (Grupa1tabdrużyny[x].Wynik == Grupa2tabdrużyny[y].Wynik)
            {
                do
                {
                    Console.WriteLine("Mecz musi być rozstrzygnięty! Nie może być remisów!!!");
                    Console.Write($"\nPodaj wynik drużyny {Grupa1tabdrużyny[x].Nazwa}: ");

                    a = Console.ReadLine();
                    Grupa1tabdrużyny[x].Wynik = SetInt(a);

                    Console.Write($"Podaj wynik drużyny {Grupa2tabdrużyny[y].Nazwa}: ");

                    b = Console.ReadLine();
                    Grupa2tabdrużyny[y].Wynik = SetInt(b);

                } while (Grupa1tabdrużyny[x].Wynik == Grupa2tabdrużyny[y].Wynik);
            }

            if (Grupa1tabdrużyny[x].Wynik > Grupa2tabdrużyny[y].Wynik)
            {
                tabdrużyny[x] = Grupa1tabdrużyny[x];
                tabdrużyny[x + 2] = Grupa2tabdrużyny[y];
            }
            else
            {
                tabdrużyny[x] = Grupa2tabdrużyny[y];
                tabdrużyny[x + 2] = Grupa1tabdrużyny[x];
            }


        }

        public static void WielkiFinał(Drużyny[] tabdrużyny, int x, int y)
        {
            Console.WriteLine("\nCzas na WIELKI FINAŁ!");
            Mecze.GramyMecz(tabdrużyny, 0, 1);
            Console.WriteLine($"\nTurniej wygrała drużyna {tabdrużyny[0].Nazwa}. Zawodnicy {tabdrużyny[0].z1.Ksywa} i {tabdrużyny[0].z2.Ksywa} otrzymują po 3 punkty. ");
            Console.WriteLine($"Drugie miejsce zajęła drużyna {tabdrużyny[1].Nazwa}. Zawodnicy {tabdrużyny[1].z1.Ksywa} i {tabdrużyny[1].z2.Ksywa} otrzymują po 2 punkty. ");
            if (tabdrużyny.Length > 2)
                Console.WriteLine($"Trzecie miejce zajęła drużyna {tabdrużyny[2].Nazwa}. Zawodnicy {tabdrużyny[2].z1.Ksywa} i {tabdrużyny[2].z2.Ksywa} otrzymują po 1 punkcie. ");
        }



        public static void Półfinały(Drużyny[] tabdrużyny, int n)
        {
            if (n >= 8)
            {
                Console.Write("\nCzy rozgrywamy półfinały? < t / n >: ");

                string odp = Console.ReadLine().ToLower();
                if (odp == "t")
                {
                    Mecze.GramyMecz(tabdrużyny, 0, 3);
                    Mecze.GramyMecz(tabdrużyny, 1, 2);
                }
            }
        }

        public static void Półfinały(Drużyny[] tabdrużyny, Drużyny[] Grupa1tabdrużyny, Drużyny[] Grupa2tabdrużyny)
        {

            Mecze.GramyMecz(tabdrużyny, Grupa1tabdrużyny, Grupa2tabdrużyny, 0, 1);
            Mecze.GramyMecz(tabdrużyny, Grupa1tabdrużyny, Grupa2tabdrużyny, 1, 0);

        }

        public static void MeczOTrzecieMiejsce(Drużyny[] tabdrużyny, int n)
        {
            if (n >= 8)

            {
                Console.Write("\nCzy rozgrywamy mecz o trzecie miejsce? < t / n >: ");

                string odp = Console.ReadLine().ToLower();
                if (odp == "t")
                {
                    Mecze.GramyMecz(tabdrużyny, 2, 3);
                }
                else if (odp == "n")
                {
                    if (((tabdrużyny[2].Punkty == tabdrużyny[3].Punkty) && (tabdrużyny[2].Małepunkty < tabdrużyny[3].Małepunkty))
                       || (tabdrużyny[2].Punkty < tabdrużyny[3].Punkty))
                    {
                        Drużyny temp = tabdrużyny[2];
                        tabdrużyny[2] = tabdrużyny[3];
                        tabdrużyny[3] = temp;
                    }
                }
            }

        }


    }
}
