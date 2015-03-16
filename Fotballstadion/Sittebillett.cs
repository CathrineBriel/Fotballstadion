using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribune
{
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
        public Sittebillett(String tribunenavn, double pris, int rad, int plassnummer, string tilskuernavn)
            : base(tribunenavn, pris)
        {
            Tilskuernavn = tilskuernavn;
        }
        public string Tilskuernavn
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
