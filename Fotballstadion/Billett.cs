using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribune
{


    public class Billett
    /*Kan være abstrakt fordi det ikke skal lages objekter av den. Billettene er enten sittebilletter eller ståbilletter */
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
        /*Kan ikke være abstrakt fordi den kalles for å returnere Tribune  */
        {
            return Tribunenavn + " og pris " + Pris + " kroner.";
        }
    }
}

   

        

    
        
        

        
       

    

