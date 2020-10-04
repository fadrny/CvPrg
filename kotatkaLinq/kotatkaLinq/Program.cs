using System;
using System.Linq;

namespace kotatkaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var kotata = new Generator().Generuj;

            //Vsichni chlapci se jmenem delsim nez 7 znaku
            var d1 = from kote in kotata
                     where (kote.Jmeno.Length > 7)
                     where (kote.Pohlavi == "chlapec")
                     select kote;
            foreach (Kotatko kote in d1)
            {
                kote.Vypis("Vsichni chlapci se jmenem delsim nez 7 znaku", ConsoleColor.Red);
            }

            //Vsechny holky s modrobílým nebo zářivě žlutým zbarvením
            var d2 = from kote in kotata
                     where (kote.Pohlavi == "holka")
                     where kote.Zbarveni == "Modrobílé" || kote.Zbarveni == "Zářivě žluté"
                     select kote;
            foreach (Kotatko kote in d2)
            {
                kote.Vypis("Vsechny divky s modrobílým nebo zářivě žlutým zbarvením", ConsoleColor.Blue);
            }

            //Vsichni mladsi nez 150dni a s prepravkou o objemu vice nez 15 000cm3
            var d3 = from kote in kotata
                     where (kote.DnyOdNarozeni < 150)
                     let objem = kote.MinimalniRozmeryPrepravky.x * kote.MinimalniRozmeryPrepravky.y * kote.MinimalniRozmeryPrepravky.z
                     where (objem > 15000)
                     select kote;
            foreach (Kotatko kote in d3)
            {
                kote.Vypis("Vsichni mladsi nez 150dni a s prepravkou o objemu vice nez 15 000cm3", ConsoleColor.DarkYellow);
            }

            //Vsechny divky s x hodnotou minimalni velikosti prepravky vetsi nez 40
            var d4 = from kote in kotata
                     where (kote.Pohlavi == "holka")
                     where (kote.MinimalniRozmeryPrepravky.x > 40)
                     select kote;
            foreach (Kotatko kote in d4)
            {
                kote.Vypis("Vsechny divky s x hodnotou minimalni velikosti prepravky vetsi nez 40", ConsoleColor.DarkRed);
            }

            //Nejstarsi kote s alespon jednou nohou
            var d5 = (from kote in kotata
                     where (kote.PocetKoncetin > 0)
                     orderby kote.DnyOdNarozeni descending
                     select kote).First();
            
            d5.Vypis("Nejstarsi kote s alespon jednou nohou", ConsoleColor.Yellow);

            //Prvni 3 chlapci s nejmensim pocetem nohou
            var d6 = (from kote in kotata
                     where (kote.Pohlavi == "chlapec")
                     orderby kote.PocetKoncetin ascending
                     select kote).Take(3);
            foreach (Kotatko kote in d6)
            {
                kote.Vypis("Prvni 3 chlapci s nejmensim pocetem nohou", ConsoleColor.Magenta);
            }

            //Vsechny kotata, ktera se jmenuji Alfons, Filip, Mourek, Kryštof, Kvido nebo Bob a zaroven jsou holkou
            var d7 = from kote in kotata
                     where (kote.Pohlavi == "holka")
                     where (kote.Jmeno == "Alfons" || kote.Jmeno == "Filip" || kote.Jmeno == "Mourek" || kote.Jmeno == "Kryštof" || kote.Jmeno == "Kvido" || kote.Jmeno == "Bob")
                     select kote;
            foreach (Kotatko kote in d7)
            {
                kote.Vypis("Vsechny kotata, ktera se jmenuji Alfons, Filip, Mourek, Kryštof, Kvido nebo Bob a zaroven jsou holkou", ConsoleColor.Green);
            }

            //Vsichni chlapci, kteri maji alespon dve nohy a jsou stari alespon 100dni
            var d8 = from kote in kotata
                     where (kote.Pohlavi == "chlapec")
                     where (kote.DnyOdNarozeni > 99)
                     where (kote.PocetKoncetin > 1)
                     select kote;
            foreach (Kotatko kote in d8)
            {
                kote.Vypis("Vsichni chlapci, kteri maji alespon dve nohy a jsou stari alespon 100dni", ConsoleColor.DarkGreen);
            }

            //3 nejstarsi divky s prepravkou ktera zabere mene nez 900cm2
            var d9 = (from kote in kotata
                     let plocha = kote.MinimalniRozmeryPrepravky.x * kote.MinimalniRozmeryPrepravky.y
                     where (kote.Pohlavi == "holka")
                     where (plocha < 900)
                     orderby kote.DnyOdNarozeni descending
                     select kote).Take(3);
            foreach (Kotatko kote in d9)
            {
                kote.Vypis("3 nejstarsi divky s prepravkou ktera zabere mene nez 900cm2", ConsoleColor.Cyan);
            }

            //Vsechny kotata v barve Bílé jako sníh nebo Uhlovitě černe, ktere maji mene nez 3 koncetiny
            var d0 = kotata.Where(pkon => pkon.PocetKoncetin < 3).Where(barva => barva.Zbarveni == "Bílé jako sníh" || barva.Zbarveni == "Uhlovitě černé");
            foreach (Kotatko kote in d0)
            {
                kote.Vypis("Vsechny kotata v barve Bílé jako sníh nebo Uhlovitě černe, ktere maji mene nez 3 koncetiny", ConsoleColor.DarkBlue);
            }
        }
    }

    public class Generator {
        private string[] poleZbarveni = new string[] { "Mourovaté s bílými flíčky", "Uhlovitě černé", "Modrobílé", "Zářivě žluté", "Bílé jako sníh", "Světle šedivé", "Fialové" };
        private string[] poleJmen = new string[] { "Alfons", "Filip", "Adéla", "Janča", "Mourek", "Kryštof", "Gabriela", "Anička", "Kvido", "Bob", "Anežka", "Josefína", "B3456879256" };
        public System.Collections.Generic.IEnumerable<Kotatko> Generuj
        {
            get
            {
                for (int iter = 0; iter < 15; iter++)
                {
                    Random rand = new Random();
                    Kotatko k = new Kotatko();
                    k.Jmeno = poleJmen[rand.Next(0, poleJmen.Length)];
                    k.PocetKoncetin = rand.Next(0, 5);
                    k.DnyOdNarozeni = rand.Next(0, 366);
                    k.Zbarveni = poleZbarveni[rand.Next(0, poleZbarveni.Length)];
                    //Jmeno a pohlavi pochopitelne nebude korespondovat, to je pochopitelne, nebot u malych kotatek se to tezko poznava a jmeno mu musite dat pochopitelne co nejdrive
                    if (rand.NextDouble() >= 0.5)
                        k.Pohlavi = "holka";
                    else
                        k.Pohlavi = "chlapec";
                    k.MinimalniRozmeryPrepravky = new Rozmery(rand.Next(10, 51), rand.Next(10, 51), rand.Next(10, 51));
                    yield return k;
                }
            }
        }
    }

    public struct Rozmery
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int z { get; private set; }
        public Rozmery(int _x, int _y, int _z){
            x = _x;
            y = _y;
            z = _z;
        }
    }
    public class Kotatko
    {
        public string Jmeno { get; set; }
        public int PocetKoncetin { get; set; }
        public int DnyOdNarozeni { get; set; }
        public string Zbarveni { get; set; }
        public string Pohlavi { get; set; }
        public Rozmery MinimalniRozmeryPrepravky { get; set; }

        public void Vypis(string popis, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(popis);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Koťátko " + Jmeno + " je " + Pohlavi + ", už je " + DnyOdNarozeni + " dní staré a má " + PocetKoncetin + "ks nožiček.");
            Console.WriteLine("Je krásné - " + Zbarveni);
            Console.WriteLine($"Minimální rozměry přepravky jsou: {MinimalniRozmeryPrepravky.x}x{MinimalniRozmeryPrepravky.y}x{MinimalniRozmeryPrepravky.z}cm");
            Console.ForegroundColor = color;
            Console.WriteLine("-----------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
