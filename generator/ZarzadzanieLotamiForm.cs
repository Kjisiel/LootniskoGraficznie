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
    /// <summary>
    /// Klasa pozwala na zarządzanie lotami: ich przeglądanie, dodawanie i usuwanie.
    /// </summary>
    public partial class ZarzadzanieLotamiForm : Form
    {
        public ZarzadzanieLotamiForm()
        {
            InitializeComponent();
            initTrasyComboBox();
        }

        private void initTrasyComboBox()
        {
            comboBox1.Items.Clear();

            foreach (Trasa trasa in BazaDanych.trasy)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = trasa.odlot.nazwa + " " + trasa.odlot.miasto
                    + "-" + trasa.przylot.nazwa + " " + trasa.przylot.miasto;

                item.Value = trasa.ID;
                comboBox1.Items.Add(item);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = -1;
                comboBox1.SelectedText = "brak wartości";

            }
        }

        private void ZarzadzanieLotamiForm_Load(object sender, EventArgs e)
        {

        }
        private List<Samolot> FindFreeSamolotList()
        {
           List<Samolot> samoloty = new List<Samolot>();
            foreach(Samolot samolot in BazaDanych.samoloty)
            {
                Boolean free = true;
                foreach(Lot lot in BazaDanych.loty)
                {
                    if (lot.samolot.ID==samolot.ID)
                    {
                        free = false;
                        break;
                    }
                }

                if (free)
                {
                    samoloty.Add(samolot);
                }
            }

            return samoloty;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            initSamolotyComboBox();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void initSamolotyComboBox()
        {
            List<Samolot> samoloty = FindFreeSamolotList();

            comboBox2.Items.Clear();

            int ID = (comboBox1.SelectedItem as ComboboxItem).Value;
            Lotnisko wybraneLotnisko = BazaDanych.lotniska.Find(x => x.ID == ID);

            Nullable <Double> minDistance =null;
            foreach (Samolot samolot in samoloty)
            {
                ComboboxItem item = new ComboboxItem();

                Double distnace = DistanceUtil.calculate(wybraneLotnisko, samolot.obecneLotnisko);

             


                if (minDistance ==null || distnace < minDistance)
                {
                minDistance = distnace;
                }


                item.Text = samolot.nazwa + " " + (int)distnace + " km";

                item.Value = samolot.ID;
                comboBox2.Items.Add(item);

                if (minDistance == distnace)
                {
                    comboBox2.SelectedIndex = comboBox2.Items.Count-1;
                }
            }


           

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
