using Ingatlanos_feladat.Osztalyok;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanos_feladat
{
    class Program
    {
        static void FajlbolBe(string fajlnev, IngatlanIroda iroda)
        {
            foreach (var item in File.ReadAllLines(fajlnev, Encoding.Default).Skip(1))
            {
                string[] sorAdat = item.Split(';');
                if (sorAdat[0] == "I")
                {
                    iroda.AddIngatlan(new Ingatlan(
                        sorAdat[1],
                        int.Parse(sorAdat[2]),
                        int.Parse(sorAdat[3]),
                        (Allapot)Enum.Parse(typeof(Allapot), sorAdat[4])
                        ));
                }
                else
                {
                    iroda.AddIngatlan(new CsaladiHaz(
                        sorAdat[1],
                        int.Parse(sorAdat[2]),
                        int.Parse(sorAdat[3]),
                        (Allapot)Enum.Parse(typeof(Allapot), sorAdat[4]),
                        int.Parse(sorAdat[5]),
                        int.Parse(sorAdat[6]),
                        byte.Parse(sorAdat[7])
                        ));
                }
            }
            Console.WriteLine("Beolvasva.");
        }


        static void Main(string[] args)
        {
            IngatlanIroda ujIroda = new IngatlanIroda("Ingatlan iroda Kft.");
            FajlbolBe("ingatlanok.csv", ujIroda);
            ujIroda.CsaladiHazakAdottArig(Allapot.Felujitando, 5000000);
            Console.WriteLine("\nLegolcsóbb:");
            Console.WriteLine(ujIroda.Legolcsobb);
            Console.WriteLine("\nAdott helyrajzi szám:");
            Console.WriteLine(ujIroda["6739"]);

            foreach (var item in ujIroda.csaladiHazakLista)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
