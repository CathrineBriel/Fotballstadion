﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribune
{
    public class Sortering
    {
        public delegate bool Sammenligner(Object o1, Object o2);

        public static void sorter(Object[] tab, Sammenligner Sml)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab.Length - 1; j++)
                {
                    if (Sml(tab[j], tab[j + 1])) bytt(tab, j, j + 1);
                }
            }
        }

        private static void bytt(Object[] tab, int i, int j)
        {
            Object temp = tab[i];
            tab[i] = tab[j];
            tab[j] = temp;
        }
    }
}
