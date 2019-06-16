using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarzyki
{
    class Zawodnicy
    {
        public string Ksywa { get; set; }
        public int Miejsce { get; set; }

        public Zawodnicy(string ks, int mi)
        {
            Ksywa = ks;
            Miejsce = mi;
        }


        public static void TworzenieZawodników(Zawodnicy[] tab, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("\nPodaj ksywke {0} gracza: ", i + 1);
                string ksywa = Console.ReadLine();

                Console.Write("Podaj miejsce w rankingu {0} gracza: ", i + 1);
                string a = Console.ReadLine();
                int miejsce = Mecze.SetInt(a);

                tab[i] = new Zawodnicy(ksywa, miejsce);

            }
        }
        public static void Sortuj(Zawodnicy[] t)
        {
            Zawodnicy bufor;

            for (int i = 0; i < t.Length - 1; i++)
            {
                for (int j = 0; j < t.Length - 1; j++)
                {
                    if (t[j].Miejsce > t[j + 1].Miejsce)
                    {
                        bufor = t[j];
                        t[j] = t[j + 1];
                        t[j + 1] = bufor;
                    }

                }

            }
        }

    }
}
