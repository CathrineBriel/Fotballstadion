using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribune
{


    public class Billett
    {

        public Billett(string tribunenavn, double pris)
        {
            Tribunenavn = tribunenavn;
            Pris = pris;
        }
        public string Tribunenavn
        {
            get;
            private set;
        }
        public double Pris
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return Tribunenavn + " og pris " + Pris + " kroner.";
        }
    }

    public class Ståbillett : Billett
    {

        public Ståbillett(string tribunenavn, double pris)
            : base(tribunenavn, pris)

        {
            
        }
        public override string ToString()
        {
             return base.ToString() + '\n';
        }
    }

        public class Sittebillett : Billett
        {
            public Sittebillett(String tribunenavn, double pris, int rad, int plassnummer)
                : base(tribunenavn, pris)
            {
                Rad = rad;
                Plassnummer = plassnummer;
               
            }
            public int Rad
            {
                get;
                private set;
            }
            public int Plassnummer
            {
                get;
                private set;
            }
            public override string ToString()
            {
                return base.ToString() + " Rad er:  " + Rad + " Plassnummer er: " + Plassnummer + '\n';
            }
        }
    }


    
        
        

        
       

    

