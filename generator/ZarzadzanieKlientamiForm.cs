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
    /// Klasa pozwala na zarządzanie klientami: ich przeglądanie, dodawanie i usuwanie.
    /// </summary>
    public partial class ZarzadzanieKlientamiForm : Form
    {
        public ZarzadzanieKlientamiForm()
        {
            InitializeComponent();
            InitKlientCombobox();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitTypKlientaKontrolki();
        }
      

        private void ZarzadzanieKlientamiForm_Load(object sender, EventArgs e)
        {
            ComboboxItem item = new ComboboxItem();
            item.Text = "Posrednik";
            item.Value = 0;
            comboBox1.Items.Add(item);
            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "Indywidualny";
            item2.Value = 1;
            comboBox1.Items.Add(item2);
            comboBox1.SelectedIndex = 0;
            InitTypKlientaKontrolki();
        }

        private void InitTypKlientaKontrolki()
        {
            int typKlient = (comboBox1.SelectedItem as ComboboxItem).Value;
            if (typKlient==0)
            {
                label2.Text = "Nazwa";
                label3.Visible = false;
                textBox2.Visible = false;
            } else
            {
                label2.Text = "Imie";
                label3.Visible = true;
                textBox2.Visible = true;

            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int typKlient = (comboBox1.SelectedItem as ComboboxItem).Value;
            int ID = 1;
            if (BazaDanych.klienci.Count() > 0)
            {
                ID = BazaDanych.klienci.Max(x => x.ID + 1);
            }
            if (typKlient==1)
            {
                Indywidualny indywidualny = new Indywidualny(ID, textBox1.Text, textBox2.Text);
                indywidualny.ID = ID;
                BazaDanych.klienci.Add(indywidualny);

            }
            else if(typKlient==0)
            {
                Posrednik posrednik = new Posrednik(ID, textBox1.Text);
                posrednik.ID = ID;
                BazaDanych.klienci.Add(posrednik);
            }
            InitKlientCombobox();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                int ID = (comboBox2.SelectedItem as ComboboxItem).Value;
                Klient klient = BazaDanych.klienci.Find(x => x.ID == ID);
                BazaDanych.klienci.Remove(klient);
                Console.WriteLine("a=" + BazaDanych.klienci.Count);
                comboBox2.Items.Remove(ID);
            }
            InitKlientCombobox();
        }
        private void InitKlientCombobox()
        {
            comboBox2.Items.Clear();

            foreach (Klient klient in BazaDanych.klienci)
            {
                string nazwa="";
                if(klient.GetType()==typeof(Posrednik))
                {   
                    
                    Posrednik posrednik = (Posrednik)klient;
                    nazwa = posrednik.nazwa;
                    textBox3.Text = posrednik.nazwa;
                    textBox4.Text = "";
                }else if(klient.GetType() == typeof(Indywidualny))
                {
                    Indywidualny indywidualny = (Indywidualny)klient;
                    nazwa = indywidualny.imie + " " + indywidualny.nazwisko;
                    textBox3.Text = indywidualny.imie;
                    textBox4.Text = indywidualny.nazwisko;
                }
                ComboboxItem item = new ComboboxItem();
                item.Text = nazwa;
                item.Value = klient.ID;
                comboBox2.Items.Add(item);
                


            }
            
            InitSelectedKlient();

        }
        private void InitSelectedKlient()
        {

            if (comboBox2.SelectedItem != null)
            {
                int ID = (comboBox2.SelectedItem as ComboboxItem).Value;
                Klient klient = BazaDanych.klienci.Find(x => x.ID == ID);

                string nazwa = "";
                if (klient.GetType() == typeof(Posrednik))
                {

                    Posrednik posrednik = (Posrednik)klient;
                    nazwa = posrednik.nazwa;
                    textBox3.Text = posrednik.nazwa;
                    textBox4.Text = "";
                }
                else if (klient.GetType() == typeof(Indywidualny))
                {
                    Indywidualny indywidualny = (Indywidualny)klient;
                    nazwa = indywidualny.imie + " " + indywidualny.nazwisko;
                    textBox3.Text = indywidualny.imie;
                    textBox4.Text = indywidualny.nazwisko;
                }

            }
            

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitSelectedKlient();
        }
    }
    }

