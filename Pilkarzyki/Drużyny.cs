using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarzyki
{
    class Drużyny
    {

        public char Nazwa { get; set; }
        public Zawodnicy z1;
        public Zawodnicy z2;


        public int Wynik { get; set; }
        public int Punkty { get; set; }
        public int Małepunkty { get; set; }

        public Drużyny(char n, Zawodnicy zaw1, Zawodnicy zaw2, int Wynik = 0)
        {
            Nazwa = n;
            z1 = zaw1;
            z2 = zaw2;
            this.Wynik = Wynik;
        }

        public override string ToString() { return String.Format("{0,-15} {1,10}", z1.Ksywa, z2.Ksywa); }

        public void PokażDrużyne()
        {

            Console.WriteLine("{0} {1,10} {2,10}", Nazwa, z1.Ksywa, z2.Ksywa);
        }



        public static void Losuj(Zawodnicy[] tab)
        {
            Random rand = new Random();

            int r = rand.Next(tab.Length);

        }

    }
}

