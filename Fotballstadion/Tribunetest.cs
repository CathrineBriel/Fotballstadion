using System;
using System.Windows.Forms;

namespace Tribune
{
    class Tribunetest
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Kjøre1();
            Tribunetest2.kjør();
        }

        private static void Kjøre1()
        {
            Ståtribune feltA = new Ståtribune("Felt A", 50, 1000);
            Sittetribune feltB = new Sittetribune("Felt B", 250, 200, 20);
            VIPtribune kafeen = new VIPtribune("Kafe Fotball", 1000, 10, 2);
            String res = "";
            res += "Kapasitet på felt A: " + feltA.Kapasitet + "\n";
            res += "Kapasitet på felt B: " + feltB.Kapasitet + "\n";
            res += "Kapasitet i kafeen: " + kafeen.Kapasitet + "\n";
            Ståbillett[] ståbilletter = feltA.KjøpBillett(1, 2);
            if (ståbilletter != null)
            {
                foreach (Ståbillett b in ståbilletter) res += b;
                res += '\n';
            }
            else res += "Ikke nok plass\n";
            Sittebillett[] sittebilletter = feltB.KjøpBillett(1, 2);
            if (sittebilletter != null)
            {
                foreach (Sittebillett b in sittebilletter) res += b;
                res += '\n';
            }
            else res += "Ikke nok plass\n";
            Sittebillett[] vipbilletter = kafeen.KjøpBillett(1, 2);
            if (vipbilletter != null)
            {
                foreach (Sittebillett b in vipbilletter) res += b;
                res += '\n';
            }
            else res += "Ikke nok plass\n";
            double solgtFor = feltA.SolgtFor() + feltB.SolgtFor() + kafeen.SolgtFor();
            res += "Solgt for: " + solgtFor + " kroner\n";
            MessageBox.Show(res, "Tribuner", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
          
        }
    }
}
    