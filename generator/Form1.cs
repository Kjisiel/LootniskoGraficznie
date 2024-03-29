﻿using L1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generator
{
    /// <summary>
    /// Klasa okna startowego programu.
    /// </summary>
    public partial class Form1 : Form
    {
        BazaDanych BazaDanych = new BazaDanych();
        public Form1()
        {
            InitializeComponent();
            initLotniska();
            initSamoloty();
            initTrasy();
            initKlienci();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private static void initSamoloty()
        {
            int ID = 0;
            BazaDanych.dodajSamolot(new Samolot(ID++, "bołing1", 30300, 330,200));
            BazaDanych.dodajSamolot(new Samolot(ID++, "bołing2", 30000, 300,200));
            BazaDanych.dodajSamolot(new Samolot(ID++, "bołing3", 32000, 200,300));
            BazaDanych.dodajSamolot(new Samolot(ID++, "bołing4", 33000, 350,340));

            Random random = new Random();

            foreach(Samolot samolot in BazaDanych.samoloty)
            {
                samolot.obecneLotnisko = BazaDanych.lotniska[random.Next(BazaDanych.lotniska.Count)];
            }


        }
        private static void initLoty()
        {
            int ID = 0;
           
        }
        private static void initLotniska()
        {
            int ID = 0;
            BazaDanych.dodajLotnisko(new Lotnisko(ID++, "Chopina", "Polska", "Warszawa", 52.232855, 20.9211113));
            BazaDanych.dodajLotnisko(new Lotnisko(ID++, "Babooo", "Polska", "Krakow", 50.0466814, 19.8647899));
            BazaDanych.dodajLotnisko(new Lotnisko(ID++, "Bububa", "Polska", "Bialystok", 53.1276047, 23.0860263));
            BazaDanych.dodajLotnisko(new Lotnisko(ID++, "OAKSDSAD", "Wileka_Brytania", "Londyn", 51.5285582, -0.2416815));
            BazaDanych.dodajLotnisko(new Lotnisko(ID++, "FDSKJNF", "Niemcy", "Berlin", 52.5065133, 13.1445527));

        }
        private static void initTrasy()
        {
            int ID = 0;
            BazaDanych.dodajTrase(createTrasa(ID++, BazaDanych.lotniska[0], BazaDanych.lotniska[2]));
            BazaDanych.dodajTrase(createTrasa(ID++, BazaDanych.lotniska[0], BazaDanych.lotniska[1]));
            BazaDanych.dodajTrase(createTrasa(ID++, BazaDanych.lotniska[2], BazaDanych.lotniska[1]));
            BazaDanych.dodajTrase(createTrasa(ID++, BazaDanych.lotniska[4], BazaDanych.lotniska[2]));
            BazaDanych.dodajTrase(createTrasa(ID++, BazaDanych.lotniska[4], BazaDanych.lotniska[3]));
        }
        private static void initKlienci()
        {
            int ID = 0;
            BazaDanych.dodajKlienta(new Posrednik(ID++, "Budimex"));
            BazaDanych.dodajKlienta(new Posrednik(ID++, "Luliczicy"));
            BazaDanych.dodajKlienta(new Posrednik(ID++, "Stefany"));
            BazaDanych.dodajKlienta(new Posrednik(ID++, "Janusze"));
            BazaDanych.dodajKlienta(new Indywidualny(ID++,"Stefan","Kowalski"));
            BazaDanych.dodajKlienta(new Indywidualny(ID++, "Janusz", "Bierczyk"));
            BazaDanych.dodajKlienta(new Indywidualny(ID++, "Jolanta", "KoKiepska"));
            BazaDanych.dodajKlienta(new Indywidualny(ID++, "Lysy", "Blokacz"));    
            BazaDanych.dodajKlienta(new Indywidualny(ID++, "Brajanek", "Franczesko"));

        }
       
        private static Trasa createTrasa(int id, Lotnisko odlot, Lotnisko przylot)
        {
            Trasa trasa = new Trasa();
            trasa.ID = id;
            trasa.odlot = odlot;
            trasa.przylot = przylot;
          
            double odleglosc = DistanceUtil.calculate(odlot, przylot);
            trasa.odleglosc = odleglosc;
            return trasa;
        }
 

        private void Button1_Click(object sender, EventArgs e)
        {
          ZarzadzanieSamolotyForm zarzadzanieSamolotuForm = new ZarzadzanieSamolotyForm();
            zarzadzanieSamolotuForm.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ZarzadzanieLotniskamiForm zarzadzanieLotniskaForm = new ZarzadzanieLotniskamiForm();
            zarzadzanieLotniskaForm.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ZarzadzanieTrasamiForm zarzadzanieTrasamiForm = new ZarzadzanieTrasamiForm();
            zarzadzanieTrasamiForm.ShowDialog();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ZarzadzanieLotamiForm zarzadzanieLotamiForm = new ZarzadzanieLotamiForm();
            zarzadzanieLotamiForm.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ZarzadzanieBiletamiForm zarzadzanieBiletamiForm = new ZarzadzanieBiletamiForm();
            zarzadzanieBiletamiForm.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ZarzadzanieKlientamiForm zarzadzanieKlientamiForm = new ZarzadzanieKlientamiForm();
            zarzadzanieKlientamiForm.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            BazaDanych.zapis();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            BazaDanych.odczyt();
        }
    }
}
