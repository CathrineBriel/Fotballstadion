using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribune
{
    

        public class Ståbillett : Billett
        {
            //test test test 
            public Ståbillett(string tribunenavn, double pris)
                : base(tribunenavn, pris)
            {

            }
            public override string ToString()
            {
                return base.ToString() + '\n';
            }
        }
    }
    
