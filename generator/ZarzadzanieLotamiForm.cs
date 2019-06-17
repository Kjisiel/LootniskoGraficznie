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
            initSamolotyComboBox();
          //  initLotCombobox();
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
                Double czas = Math.Round((distnace /samolot.sredniaPredkosc),1); 
             


                if (minDistance ==null || distnace < minDistance)
                {
                minDistance = distnace;
                }


                item.Text = samolot.nazwa + " " + (int)distnace + " km, "+czas+" h";

                item.Value = samolot.ID;
                comboBox2.Items.Add(item);

                if (minDistance == distnace)
                {
                    comboBox2.SelectedIndex = comboBox2.Items.Count-1;
                }
            }

            



        }
        public void initLotCombobox()
        {
            {
                comboBox3.Items.Clear();

                foreach (Lot lot in BazaDanych.loty)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = lot.ID.ToString()+ " " + lot.trasa.odlot.nazwa + " " + lot.trasa.przylot.nazwa;
                    item.Value = lot.ID;
                    comboBox3.Items.Add(item);
                }
                if (comboBox3.Items.Count > 0)
                {
                    comboBox3.SelectedIndex = 0;
                }
                else
                {
                    comboBox3.SelectedIndex = -1;
                    comboBox3.SelectedText = "brak wartości";

                }
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Lot lot = new Lot();
                if (BazaDanych.loty.Count > 0)
                {
                    lot.ID = BazaDanych.loty.Max(x => x.ID) + 1;
                }
                else
                {
                    lot.ID = 1;
                }

                if (comboBox1.SelectedIndex != -1)
                {
                    int IDtrasa = (comboBox1.SelectedItem as ComboboxItem).Value;
                    Trasa trasa = BazaDanych.trasy.Find(x => x.ID == IDtrasa);
                    //Console.WriteLine("a=" + BazaDanych.samoloty.Count);
                    lot.trasa = trasa;

                }
                if (comboBox2.SelectedIndex != -1)
                {
                    int IDsamolot = (comboBox2.SelectedItem as ComboboxItem).Value;
                    Samolot samolot = BazaDanych.samoloty.Find(x => x.ID == IDsamolot);
                    //Console.WriteLine("a=" + BazaDanych.samoloty.Count);
                    lot.samolot = samolot;

                }
                else
                {
                    //todo rzucenie wyjatku
                }
                if (!float.TryParse(textBox1.Text, out float kwota))
                {
                    throw new ArgumentException("Kwota musi być typu float");
                }
                if (float.Parse(textBox1.Text) <= 0)
                {
                    throw new ArgumentException("Kwota musi być wieksza od 0");
                }

                lot.kwota = float.Parse(textBox1.Text);

                BazaDanych.loty.Add(lot);
                //initSamolotyComboBox();
                initTrasyComboBox();
                initLotCombobox();

            }
            catch(ArgumentException exd)
            {
                MessageBox.Show(exd.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                int ID = (comboBox3.SelectedItem as ComboboxItem).Value;
                Lot lot = BazaDanych.loty.Find(x => x.ID == ID);
                BazaDanych.loty.Remove(lot);
                Console.WriteLine("a=" + BazaDanych.loty.Count);
                comboBox3.Items.Remove(ID);
            }
            initLotCombobox();
        
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
