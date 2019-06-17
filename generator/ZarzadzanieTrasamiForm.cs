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
    /// Klasa pozwala na zarządzanie trasami: ich przeglądanie, dodawanie i usuwanie.
    /// </summary>
    public partial class ZarzadzanieTrasamiForm : Form
    {
        public ZarzadzanieTrasamiForm()
        {
            InitializeComponent();
            initTrasyCombobox();
            initOdlotCombobox();
            initPrzylotCombobox();
        }
        private void initLotniskaCombobox()
        {
                
        }
        public void initOdlotCombobox()
        {
            comboBox1.Items.Clear();

            foreach (Lotnisko lotnisko in BazaDanych.lotniska)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = lotnisko.nazwa + " " + lotnisko.panstwo;
                   

                item.Value = lotnisko.ID;
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
        public void initPrzylotCombobox()
        {
            comboBox2.Items.Clear();

            foreach (Lotnisko lotnisko in BazaDanych.lotniska)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = lotnisko.nazwa + " " + lotnisko.panstwo;


                item.Value = lotnisko.ID;
                comboBox2.Items.Add(item);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox2.SelectedIndex = -1;
                comboBox2.SelectedText = "brak wartości";
            }
        }
        public void initTrasyCombobox()
        {
            {
                comboBox3.Items.Clear();

                foreach (Trasa trasa in BazaDanych.trasy)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = trasa.ID.ToString() + " " + trasa.odlot.nazwa + " " + trasa.przylot.nazwa;
                    item.Value = trasa.ID;
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ZarzadzanieTrasamiForm_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //int ID = BazaDanych.trasy.Max(x => x.ID) + 1;
            //Trasa trasa = new Trasa (ID, textBox1.Text, int.Parse(textBox2.Text),
            //  int.Parse(textBox3.Text), double.Parse(textBox4.Text));
            // BazaDanych.trasy.Add(trasa);
            //initTrasyCombobox();
            Trasa trasa = new Trasa();
            if (BazaDanych.trasy.Count > 0)
            {
                trasa.ID = BazaDanych.trasy.Max(x => x.ID) + 1;
            }
            else
            {
                trasa.ID = 1;
            }

            if (comboBox1.SelectedIndex != -1)
            {
                int IDodlot = (comboBox1.SelectedItem as ComboboxItem).Value;
                Lotnisko lotnisko = BazaDanych.lotniska.Find(x => x.ID == IDodlot);
                //Console.WriteLine("a=" + BazaDanych.samoloty.Count);
                trasa.odlot =lotnisko;

            }
            if (comboBox2.SelectedIndex != -1)
            {
                int IDprzylot = (comboBox2.SelectedItem as ComboboxItem).Value;
                Lotnisko lotnisko = BazaDanych.lotniska.Find(x => x.ID == IDprzylot);
                //Console.WriteLine("a=" + BazaDanych.samoloty.Count);
                trasa.przylot =lotnisko;

            }
            else
            {
                //todo rzucenie wyjatku
            }
            BazaDanych.trasy.Add(trasa);

            initTrasyCombobox();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                int ID = (comboBox3.SelectedItem as ComboboxItem).Value;
                Trasa trasa = BazaDanych.trasy.Find(x => x.ID == ID);
                BazaDanych.trasy.Remove(trasa);
                Console.WriteLine("a=" + BazaDanych.trasy.Count);
                comboBox3.Items.Remove(ID);
            }
            initTrasyCombobox();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
