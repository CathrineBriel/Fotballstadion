﻿using System;
using System.Windows.Forms;

namespace Tribune           
{
    class Tribunetest2
    {
        static void Main(String[] args)
        {
            Tribune[] tribuner = new Tribune[3];
            tribuner[0] = new Ståtribune("Felt A", 50, 1000);
            tribuner[1] = new Sittetribune("Felt A", 250, 200, 20);
            tribuner[2] = new VIPtribune("Kafe Fotball", 1000, 10, 2);
            double solgtFor = 0;
            string res = "";

            for (int i = 0; i < tribuner.Length; i++)
            {
                res += "Kapasitet på " + tribuner[i].Navn
                    + ": " + tribuner[i].Kapasitet + "\n";
                if (tribuner[i].SelgPlasser(20))
                    res += "20 plasser solgt \n";
                else res += "Ikke nok plass \n";
                if (tribuner[i].SelgPlasser(10))
                    res += "10 plasser solgt \n";
                else res += "Ikke nok plass \n";
                if (tribuner[i].SelgPlasser(5))
                    res += "5 plasser solgt \n";
                else res += "Ikke nok plass \n";
                solgtFor += tribuner[i].SolgtFor();
            }
            res += "Solgt for: " + solgtFor + " kroner\n";

            MessageBox.Show(res, "Tribuner", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
