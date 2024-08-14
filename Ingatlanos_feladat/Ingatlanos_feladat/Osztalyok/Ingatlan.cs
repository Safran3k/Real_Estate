using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ingatlanos_feladat.Osztalyok
{
    enum Allapot
    {
        Ujepitesu, 
        Korszerusitett, 
        Felujitott, 
        Felujitando
    }

    class Ingatlan
    {
        string helyrajziSzam;
        int szelesseg;
        bool szelessegModositva_e = false;
        int hossz;
        bool hosszModositva_e = false;
        Allapot allapot;


        public string HelyrajziSzam
        {
            get
            {
                return helyrajziSzam;
            }

            private set
            {
                try
                {
                    if (value != null &&
                        value != string.Empty &&
                        Regex.IsMatch(value, "^[1-9][0-9/]+[0-9]$"))
                    {
                        helyrajziSzam = value;
                    }
                }
                catch (FormatException)
                {
                    throw new Exception("A helyrajzi szám nem lehet üres, vagy null és csak számokat tartalmazhat, első és utolsó karaktere nem lehet / jel, és első karakter nem lehet 0!");
                }
            }
        }

        public int Szelesseg
        {
            get
            {
                return szelesseg;
            }

            private set
            {
                try
                {
                    if (value >= 4 && value <= 20 && !szelessegModositva_e)
                    {
                        szelesseg = value;
                        szelessegModositva_e = true;
                    }
                }
                catch (FormatException)
                {
                    throw new Exception("A szélesség 4 és 20 közötti érték lehet!");
                }
            }
        }

        public Allapot Allapot
        {
            get
            {
                return allapot;
            }
            set
            {
                allapot = value;
            }
        }

        public int GetHossz()
        {
            return hossz;
        }

        private void SetHossz(int value)
        {
            try
            {
                if (value >= 4 && value <= 20 && !hosszModositva_e)
                {
                    hossz = value;
                    hosszModositva_e = true;
                }
            }
            catch (FormatException)
            {
                throw new Exception("A hossz 4 és 20 közötti érték lehet!");
            }
        }

        public virtual int Alapterulet //Virtual késői kötés miatt
        {
            get
            {
                return hossz * szelesseg;
            }
        }

        public Ingatlan(string helyrajziSzam, int szelesseg, int hossz, Allapot allapot)
        {
            HelyrajziSzam = helyrajziSzam;
            Szelesseg = szelesseg;
            SetHossz(hossz);
            Allapot = allapot;
        }

        public Ingatlan(string helyrajziSzam, int szelesseg, int hossz) : this(helyrajziSzam, szelesseg, hossz, Allapot.Ujepitesu)
        {
            HelyrajziSzam = helyrajziSzam;
            Szelesseg = szelesseg;
            SetHossz(hossz);
        }



        public virtual int Vetelar()
        {
            int ar = 0;

            switch (allapot)
            {
                case Allapot.Ujepitesu:
                    ar = Alapterulet * 600000;
                    break;
                case Allapot.Korszerusitett:
                    ar = Alapterulet * 500000;
                    break;
                case Allapot.Felujitott:
                    ar = Alapterulet * 450000;
                    break;
                case Allapot.Felujitando:
                    ar = Alapterulet * 300000;
                    break;
            }
            return ar;
        }

        public override string ToString()
        {
            return "Helyrajzi szám: " + helyrajziSzam + "\nSzélesség: " + szelesseg + "\nHossz: " + hossz + "\nÁllapot: " + allapot + "\nAlapterület: " + Alapterulet + " m2";
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Ingatlan ing = (Ingatlan)obj;
                return helyrajziSzam == ing.helyrajziSzam;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return helyrajziSzam.Length + Alapterulet; // random valamit adjon már vissza
        }
    }
}
