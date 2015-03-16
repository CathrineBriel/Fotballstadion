using System;



namespace Tribune
{
    /// <summary>
    /// Basisklasse Tribunene samt de avledete kalssene Ståtribune, Sittetribune og VIPtribune
    /// </summary>
    abstract public class Tribune
    {

        public Tribune(string navn, double pris, int kap)
        {
            Navn = navn;
            Pris = pris;
            Kapasitet = kap;
        }

        public string Navn
        {
            get;
            private set;
        }

        public double Pris
        {
            get;
            private set;
        }

        public virtual double Barnepris
        {
            get
            {
                return Pris * 0.5;
            }
        }

        public int AntBarn
        {
            get;
            protected set;
        }
        public int AntVoksne
        {
            get;
            protected set;
        }

        public abstract int AntallSolgtePlasser
        {
            get;
        }

        public int Kapasitet
        {
            get;
            private set;
        }
        public abstract bool SelgPlasser(int antall);



        public abstract Billett[] KjøpBillett(int antVoksne, int antBarn);

        public abstract Billett[] KjøpBillett(string[] navnVoksne, string[] navnBarn);


        public double SolgtFor()
        {
            int antallSolgtePlasser = AntallSolgtePlasser;
            int antBarn = AntBarn;


            double totalpris = (antallSolgtePlasser * Pris - antBarn * Pris + antBarn * Barnepris);

            return totalpris;
        }


        private static bool sorterNavn(Tribune o1, Tribune o2)
        {
            if (string.Compare(o2.Navn, o1.Navn) < 0)
            {
                return true;
            }
            else return false;
        }
        private static bool sorterSolgt(Tribune o1, Tribune o2)
        {
            if (o2.SolgtFor() > o1.SolgtFor())
            {
                return true;
            }
            else return false;
        }








        public override string ToString()
        {
            return Navn + " har kapasitet " + Kapasitet + " og pris " + Pris + " kroner.";
        }
    }

    public class Ståtribune : Tribune
    {
        private int antallSolgtePlasser;



        public Ståtribune(string navn, double pris, int kap)
            : base(navn, pris, kap)
        {
            antallSolgtePlasser = 0;

        }


        public override bool SelgPlasser(int antall)
        {
            if (AntallSolgtePlasser + antall <= Kapasitet)
            {
                antallSolgtePlasser += antall;
                return true;
            }
            else return false;
        }
        public override int AntallSolgtePlasser
        {
            get
            {
                return antallSolgtePlasser;

            }

        }

        public override Billett[] KjøpBillett(int antVoksne, int antBarn)
        {


            int antallBilletter = antVoksne + antBarn;
            if (SelgPlasser(antallBilletter))
            {
                Ståbillett[] billetter = new Ståbillett[antallBilletter];
                for (int i = 0; i < antVoksne; i++)
                {
                    billetter[i] = new Ståbillett(Navn, Pris);
                }

                for (int i = antVoksne; i < antallBilletter; i++)
                {
                    billetter[i] = new Ståbillett(Navn, Barnepris);
                    AntBarn += antBarn;

                }
                return billetter;
            }
            else return null;
        }


        public override Billett[] KjøpBillett(string[] navnVoksne, string[] navnBarn)
        {

            int antBarn = AntBarn;
            int antVoksne = AntVoksne;

            Billett[] billetter = new Billett[antVoksne + antBarn];

            KjøpBillett(antBarn, antVoksne);

            return billetter;
        }
    }

    public class Sittetribune : Tribune
    {
        private int[] antallSolgtPrRad;


        public Sittetribune(string navn, double pris, int kap, int antRader)
            : base(navn, pris, kap)
        {


            AntallRader = antRader;
            antallSolgtPrRad = new int[AntallRader];
            for (int i = 0; i < AntallRader; i++) antallSolgtPrRad[i] = 0;
        }





        public int AntallRader
        {
            get;
            private set;
        }

        public override int AntallSolgtePlasser
        {
            get
            {
                int total = 0;
                for (int i = 0; i < AntallRader; i++) total += antallSolgtPrRad[i];
                return total;
            }
        }




        public bool SelgPlasser(int antall, out int rad, out int plassnr)
        {

            rad = -1;
            plassnr = -1;

            int kapPrRad = Kapasitet / AntallRader;
            int i = 0;

            while (i < AntallRader && antallSolgtPrRad[i] + antall > kapPrRad) i++;
            if (i < AntallRader)
            {
                rad = i;
                plassnr = antallSolgtPrRad[i];
                antallSolgtPrRad[i] += antall;
                return true;

            }
            else return false;
        }
        public override bool SelgPlasser(int antall)
        {
            int kapPrRad = Kapasitet / AntallRader;
            int i = 0;
            while (i < AntallRader && antallSolgtPrRad[i] + antall > kapPrRad) i++;
            if (i < AntallRader)
            {
                int rad;
                int plassnr;
                SelgPlasser(antall, out rad, out plassnr);



                return true;
            }
            else
            {
                return false;
            }
        }





        /// <summary>
        /// Ovveride this method 
        /// </summary>
        /// 
        /// <returns></returns>

        public override Billett[] KjøpBillett(int antVoksne, int antBarn)
        {

            int antBilletter = antVoksne + antBarn;
            int rad;
            int plass;

            if (SelgPlasser(antBilletter, out rad, out plass))
            {
                Sittebillett[] sittebilletter = new Sittebillett[antBilletter];
                for (int i = 0; i < antVoksne; i++)
                {
                    sittebilletter[i] = new Sittebillett(Navn, Pris, rad, plass + i);
                }
                for (int i = antVoksne; i < antBilletter; i++)
                {
                    sittebilletter[i] = new Sittebillett(Navn, Barnepris, rad, plass + i);
                    AntBarn += antBarn;

                }
                return sittebilletter;
            }
            else return null;
        }

        public override Billett[] KjøpBillett(string[] navnVoksne, string[] navnBarn)
        {

            int antBarn = AntBarn;
            int antVoksne = AntVoksne;

            Billett[] billetter = new Billett[antVoksne + antBarn];

            KjøpBillett(antBarn, antVoksne);

            return billetter;
        }


        public override string ToString()
        {
            return base.ToString() + " Antall rader er " + AntallRader + ".";
        }
    }

    public class VIPtribune : Sittetribune
    {
        private string[,] tilskuer;

        public VIPtribune(string navn, double pris, int kap, int antRader)
            : base(navn, pris, kap, antRader)
        {


            int antPrRad = Kapasitet / AntallRader;
            tilskuer = new string[AntallRader, antPrRad];
        }

        public override double Barnepris
        {
            get
            {
                return base.Pris;
            }

        }
        public override Billett[] KjøpBillett(int antVoksne, int antBarn)
        {

            int antBilletter = antVoksne + antBarn;
            int rad;
            int plass;


            if (SelgPlasser(antBilletter, out rad, out plass))
            {
                Sittebillett[] sittebilletter = new Sittebillett[antBilletter];
                for (int i = 0; i < antVoksne; i++)
                {
                    sittebilletter[i] = new Sittebillett(Navn, Pris, rad, plass + i);
                }
                for (int i = antVoksne; i < antBilletter; i++)
                {
                    sittebilletter[i] = new Sittebillett(Navn, Barnepris, rad, plass + i);
                    AntBarn += antBarn;

                }
                return null;
            }
            else return null;
        }
        public override Billett[] KjøpBillett(string[] navnVoksne, string[] navnBarn)
        {
            int antVoksne = navnVoksne.Length;
            int antBarn = navnBarn.Length;
            int antBilletter = antVoksne + antBarn;
            int rad;
            int plass;





            if (SelgPlasser(antBilletter, out rad, out plass))
            {
                Sittebillett[] sittebilletter = new Sittebillett[antBilletter];
                for (int i = 0; i < antVoksne; i++)
                {
                    sittebilletter[i] = new Sittebillett(Navn, Pris, rad, plass + i);

                    for (int x = 0; x < navnVoksne.Length; x++)
                        tilskuer[0, i] = navnVoksne[i];


                }
                for (int i = antVoksne; i < antBilletter; i++)
                {
                    sittebilletter[i] = new Sittebillett(Navn, Barnepris, rad, plass + i);
                    AntBarn += antBarn;

                    for (int y = 0; y < navnBarn.Length; y++)
                        tilskuer[1, y] = navnBarn[y];


                }

                for (int x = 0; x < tilskuer.GetLength(0); x += 1)
                {
                    for (int y = 0; y < tilskuer.GetLength(1); y += 1)
                    {
                        Console.Write(tilskuer[x, y] + "\n");
                    }
                }

                return sittebilletter;
            }
            else return null;
        }
    }

}



