using System;

namespace Tribune
{
    /// <summary>
    /// Basisklasse Tribunene samt de avledete kalssene Ståtribune, Sittetribune og VIPtribune
    /// </summary>
    public class Tribune
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


        public virtual int AntallSolgtePlasser
        {
            get
            {
                return 0;
            }

            
        }

        public int Kapasitet
        {
            get;
            private set;
        }
        public virtual bool SelgPlasser(int antall)
        {
            return false;
        }
      
       
        
      

        public double SolgtFor()
        {
            int antallSolgtePlasser = AntallSolgtePlasser;
            int antBarn = AntBarn;
            double totalpris = (antallSolgtePlasser) * Pris + (antBarn * Barnepris);
            if (totalpris < 0)
            {
                totalpris = 0;
            }
            return totalpris;
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




        public Ståbillett[] KjøpBillett(int antVoksne, int antBarn)
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
            if (AntallSolgtePlasser + antall < Kapasitet)
            {
                 int rad;
                 int plassnr;
                 SelgPlasser( antall, out rad, out plassnr);
            
        

            return true;
        }
        else return false;
    }

       

       
           
        
        
        public Sittebillett[] KjøpBillett(int antVoksne, int antBarn)
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
             
        
    }

}



