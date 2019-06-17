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
    public partial class ZarzadzanieBiletamiForm : Form
    {
        public ZarzadzanieBiletamiForm()
        {
            InitializeComponent();
            InitKlientCombobox();
            initLotCombobox();
            initBiletyCombobox();
        }

        private void ZarzadzanieBiletamiForm_Load(object sender, EventArgs e)
        {

        }
        private void InitKlientCombobox()
        {
            comboBox1.Items.Clear();

            foreach (Klient klient in BazaDanych.klienci)
            {
                string nazwa = "";
                if (klient.GetType() == typeof(Posrednik))
                {

                    Posrednik posrednik = (Posrednik)klient;
                    nazwa = posrednik.nazwa;
                   
                }
                else if (klient.GetType() == typeof(Indywidualny))
                {
                    Indywidualny indywidualny = (Indywidualny)klient;
                    nazwa = indywidualny.imie + " " + indywidualny.nazwisko;
                   
                }
                ComboboxItem item = new ComboboxItem();
                item.Text = nazwa;
                item.Value = klient.ID;
                comboBox1.Items.Add(item);



            }
            comboBox1.SelectedIndex = 0;

           

        }
        public void initLotCombobox()
        {
            {
                comboBox2.Items.Clear();

                foreach (Lot lot in BazaDanych.loty)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = lot.ID.ToString() + " " + lot.trasa.odlot.nazwa + " " + lot.trasa.przylot.nazwa;
                    item.Value = lot.ID;
                    comboBox2.Items.Add(item);
                }
                if (comboBox2.Items.Count > 0)
                {
                    comboBox2.SelectedIndex = 0;
                }
                else
                {
                    comboBox2.SelectedIndex = -1;
                    

                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           Bilet bilet = new Bilet();
            if (BazaDanych.bilety.Count > 0)
            {
                bilet.ID = BazaDanych.bilety.Max(x => x.ID) + 1;
            }
            else
            {
                bilet.ID = 1;
            }

            if (comboBox1.SelectedIndex != -1)
            {
                int IDkLient = (comboBox1.SelectedItem as ComboboxItem).Value;
                Klient klient = BazaDanych.klienci.Find(x => x.ID == IDkLient);
                //Console.WriteLine("a=" + BazaDanych.samoloty.Count);
                bilet.klient = klient;

            }else
            {
                MessageBox.Show("Brak wybranego klienta");
            }
            if (comboBox2.SelectedIndex != -1)
            {
                int IDlot = (comboBox2.SelectedItem as ComboboxItem).Value;
                Lot lot = BazaDanych.loty.Find(x => x.ID == IDlot);
                //Console.WriteLine("a=" + BazaDanych.samoloty.Count);
                lot.wykupioneMiejsca++;
                bilet.lot = lot;

            }
            else
            {
                MessageBox.Show("Brak wybranego lotu");//todo rzucenie wyjatku
            }
            
            BazaDanych.bilety.Add(bilet);
            //initSamolotyComboBox();
            InitKlientCombobox();
            initLotCombobox();
            initBiletyCombobox();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button2.Enabled = false;

            } else if (int.Parse(textBox1.Text) <= 0)
            {
                button2.Enabled = false;
            }else
            {
                button2.Enabled = true;
            }

        }
        private void initLiczbaMiejscTextbox()
        {
            if (comboBox2.SelectedIndex != -1)
            {
                int ID = (comboBox2.SelectedItem as ComboboxItem).Value;
                Lot lot = BazaDanych.loty.Find(x => x.ID == ID);
                textBox1.Text = (lot.samolot.liczbamiejsc - lot.wykupioneMiejsca).ToString();
                
            }
            else
            {
                textBox1.Text = "0";
            }
            
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            initLiczbaMiejscTextbox();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

              if (comboBox3.SelectedIndex != -1)
            {

                int ID = (comboBox3.SelectedItem as ComboboxItem).Value;
                Bilet bilet = BazaDanych.bilety.Find(x => x.ID == ID);
                Lot lot = BazaDanych.loty.Find(x => x.ID == bilet.lot.ID);
                lot.wykupioneMiejsca--;
                BazaDanych.bilety.Remove(bilet);
                Console.WriteLine("a=" + BazaDanych.bilety.Count);
                comboBox3.Items.Remove(ID);
            }
            
            initBiletyCombobox();
        }
        public void initBiletyCombobox()
        {
            {
                comboBox3.Items.Clear();

                foreach (Bilet bilet in BazaDanych.bilety)
                {
                    ComboboxItem item = new ComboboxItem();
                    string nazwa = "";
                    if (bilet.klient.GetType() == typeof(Posrednik))
                    {
                        Posrednik posrednik = (Posrednik)bilet.klient;
                        nazwa = posrednik.nazwa;
                        item.Text = bilet.ID.ToString() + " "+nazwa;
                        item.Value = bilet.ID;
                        comboBox3.Items.Add(item);
                    }
                    else if (bilet.klient.GetType() == typeof(Indywidualny))
                    {
                        Indywidualny indywidualny = (Indywidualny)bilet.klient;
                        nazwa = indywidualny.imie + " " + indywidualny.nazwisko;
                        item.Text = bilet.ID.ToString() + " "+ nazwa;
                        item.Value = bilet.ID;
                        comboBox3.Items.Add(item);

                    }
                    
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

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
