using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanos_feladat.Osztalyok
{
    class CsaladiHaz : Ingatlan
    {
        int telekSzelesseg;
        int telekHossz;
        byte szintekSzama;

        public int TelekSzelessege
        {
            get
            {
                return telekSzelesseg;
            }

            private set
            {
                try
                {
                    if (value >= 10 && value <= 100 && value >= Szelesseg)
                    {
                        telekSzelesseg = value;
                    }
                }
                catch (FormatException)
                {
                    throw new Exception("A telek szélessége 10 és 100 közötti szám kell legyen, és nem lehet kisebb mint az ingatlan szélessége!");
                }
            }
        }

        public int TelekHossz
        {
            get
            {
                return telekHossz;
            }

            private set
            {
                try
                {
                    if (value >= 10 && value <= 100 && value >= GetHossz())
                    {
                        telekHossz = value;
                    }
                }
                catch (FormatException)
                {
                    throw new Exception("A telek hossza 10 és 100 közötti szám kell legyen, és nem lehet kisebb mint az ingatlan hossza!");
                }
            }
        }

        public byte SzintekSzama
        {
            get
            {
                return szintekSzama;
            }

            set
            {
                try
                {
                    if (value >= 1 && value <= 3)
                    {
                        szintekSzama = value;
                    }
                }
                catch (FormatException)
                {
                    throw new Exception("A szintek száma 1 és 3 közötti érték kell legyen!");
                }
            }
        }

        public int KertTerulete
        {
            get
            {
                return (telekHossz * telekSzelesseg) - Alapterulet;
            }
        }



        public CsaladiHaz(string helyrajziSzam, int szelesseg, int hossz, Allapot allapot, int telekSzelesseg, int telekHossz, byte szintekSzama) : base(helyrajziSzam, szelesseg, hossz, allapot)
        {
            TelekSzelessege = telekSzelesseg;
            TelekHossz = TelekHossz;
            SzintekSzama = szintekSzama;
        }

        public CsaladiHaz(string helyrajziSzam, int szelesseg, int hossz, int telekSzelesseg, int telekHossz) : this(helyrajziSzam, szelesseg, hossz, Allapot.Ujepitesu, telekSzelesseg, telekHossz, 1)
        {
            TelekSzelessege = telekSzelesseg;
            TelekHossz = TelekHossz;
        }


        public override int Vetelar()
        {
            int ar = 0;

            switch (Allapot)
            {
                case Allapot.Ujepitesu:
                    ar = Alapterulet * 650000 + KertTerulete * 200000;
                    break;
                case Allapot.Korszerusitett:
                    ar = Alapterulet * 600000 + KertTerulete * 200000;
                    break;
                case Allapot.Felujitott:
                    ar = Alapterulet * 550000 + KertTerulete * 200000;
                    break;
                case Allapot.Felujitando:
                    ar = Alapterulet * 400000 + KertTerulete * 200000;
                    break;
            }
            return ar;
        }

        public override string ToString()
        {
            return "Helyrajzi szám: " + HelyrajziSzam + "\nSzélesség: " + Szelesseg + "\nHossz: " + GetHossz() + "\nÁllapot: " + Allapot + "\nAlapterület: " + Alapterulet + " m2" + "\nTelek szélesség: " + telekSzelesseg + "\nTelek hossz: " + telekHossz + "\nSzintek száma: " + szintekSzama + "\nKert területe: " + KertTerulete + " m2";
        }
    }
}
