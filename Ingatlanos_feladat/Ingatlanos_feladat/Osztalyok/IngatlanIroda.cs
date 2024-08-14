using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanos_feladat.Osztalyok
{
    class IngatlanIroda
    {
        string irodaNeve;
        List<Ingatlan> ingatlanokLista;
        public List<Ingatlan> csaladiHazakLista;

        private string IrodaNeve
        {
            get
            {
                return irodaNeve;
            }

            set
            {
                if (value != null)
                {
                    irodaNeve = value;
                }
                else
                {
                    throw new Exception("Az iroda neve nem lehet null!");
                }

                if (value.Length >= 3)
                {
                    irodaNeve = value;
                }
                else
                {
                    throw new Exception("Az iroda neve legalább három karakter kell legyen, és egy szóközt tartalmaznia kell!");
                }
            }
        }

        public List<Ingatlan> IngatlanokLista
        {
            get
            {
                List<Ingatlan> temp = new List<Ingatlan>();

                if (ingatlanokLista.Count == 0)
                {
                    throw new Exception("Az ingatlanok lista üres.");
                }
                else
                {
                    foreach (Ingatlan item in ingatlanokLista)
                    {
                        temp.Add(item);
                    }
                }
                return temp;
            }
        }


        public CsaladiHaz Legolcsobb
        {
            get
            {
                int legolcsobbHaz = int.MaxValue;
                bool vanCsaladi = false;

                foreach (Ingatlan item in ingatlanokLista)
                {
                    if (item is CsaladiHaz)
                    {
                        vanCsaladi = true;
                    }
                }

                if (vanCsaladi)
                {
                    foreach (Ingatlan item in ingatlanokLista)
                    {
                        if (item is CsaladiHaz)
                        {
                            if (item.Vetelar() < legolcsobbHaz)
                            {
                                legolcsobbHaz = item.Vetelar();
                            }
                        }
                    }
                }

                CsaladiHaz c = null;
                foreach (Ingatlan item in ingatlanokLista)
                {
                    if (item is CsaladiHaz)
                    {
                        if (item.Vetelar() == legolcsobbHaz)
                        {
                            c = (CsaladiHaz)item;
                        }
                    }
                }

                return c;
            }
        }

        public void AddIngatlan(Ingatlan obj)
        {
            try
            {
                if (!ingatlanokLista.Contains(obj))
                {
                    ingatlanokLista.Add(obj);
                }
            }
            catch (Exception)
            {
                throw new Exception("A hozzáadni kívánt ingatlan már szerepel a listában!");
            }
        }

        public List<Ingatlan> CsaladiHazakAdottArig(Allapot allapot, int maxAr)
        {
            csaladiHazakLista = new List<Ingatlan>();

            foreach (Ingatlan item in ingatlanokLista)
            {
                if (item is CsaladiHaz)
                {
                    if (item.Allapot == allapot && item.Vetelar() <= maxAr)
                    {
                        csaladiHazakLista.Add(item);
                    }
                    
                }
            }

            return csaladiHazakLista;
        }


        public IngatlanIroda(string irodaNeve) : this()
        {
            IrodaNeve = irodaNeve;
        }

        private IngatlanIroda()
        {
            ingatlanokLista = new List<Ingatlan>();
        }


        public Ingatlan this[string helyrajziSzam]
        {
            get
            {
                if (IngatlanokLista.Count == 0)
                {
                    throw new Exception("Üres az ingatlanok lista.");
                }

                foreach (Ingatlan item in ingatlanokLista)
                {
                    if (item.HelyrajziSzam == helyrajziSzam)
                    {
                        return item;
                    }
                }
                throw new Exception("Nincs ilyen helyrajzi számú ingatlan a listában.");
            }
        }
    }
}
