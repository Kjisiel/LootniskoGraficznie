using L1;
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
    public partial class Form1 : Form
    {
        BazaDanych BazaDanych = new BazaDanych();
        public Form1()
        {
            InitializeComponent();
            initLotniska();
            initSamoloty();
            initTrasy(); 
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
            Lotnisko lotnisko1 = BazaDanych.lotniska[0];
            Lotnisko lotnisko2 = BazaDanych.lotniska[2];
            BazaDanych.dodajTrase(createTrasa(ID++, lotnisko1, lotnisko2));
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
    }
}
