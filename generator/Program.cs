using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using L1;

namespace generator
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           /* int ID = 0;
            string mieodlotu, mieprzylotu;
            foreach (Bilet bilet in BazaDanych.bilety)
            {
                if (bilet.ID > ID)
                {
                    ID = bilet.ID + 1;
                }
            }

            List<Lot> loty_tmp = new List<Lot>();

            foreach (Lot lot in BazaDanych.loty)
            {
                if (lot.trasa.odlot.Equals(mieodlotu) && lot.trasa.przylot.Equals(mieprzylotu))
                {
                    loty_tmp.Add(lot);
                }
            }//przeglądanie listy i wybór lotu w interfejsie graficznym

            Bilet bilet = new Bilet();

            bool posrednikczynie;
            if (posrednikczynie == true)
            {
                string nazwa;
                Posrednik posrednik = new Posrednik(ID, nazwa);
                int liczbabiletow;

                for (int i = 0; i < liczbabiletow; i++)
                {

                }
            }
            else
            {
                string imie, nazwisko;
                Indywidualny indywidualny = new Indywidualny(ID, imie, nazwisko);

            }
            */
        }

    }
}