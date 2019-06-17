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
    /// Klasa pozwala na zarządzanie lotniskami: ich przeglądanie, dodawanie i usuwanie.
    /// </summary>
    public partial class ZarzadzanieLotniskamiForm : Form
    {
        public ZarzadzanieLotniskamiForm()
        {
            InitializeComponent();
            initLotniskaCombobox();
        }
        public void initLotniskaCombobox()
        {
            {
                comboBox1.Items.Clear();

                foreach (Samolot samolot in BazaDanych.samoloty)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = samolot.nazwa;
                    item.Value = samolot.ID;
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
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int ID = BazaDanych.lotniska.Max(x => x.ID) + 1;
            Lotnisko lotnisko = new Lotnisko(ID, textBox1.Text,textBox2.Text,
                textBox3.Text, double.Parse(textBox4.Text),double.Parse(textBox5.Text));
            BazaDanych.lotniska.Add(lotnisko);
            initLotniskaCombobox();
        }

        private void ZarzadzanieLotniskamiForm_Load(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            intitLotniskoView();
        }
        private void intitLotniskoView()
        {


            int ID = (comboBox1.SelectedItem as ComboboxItem).Value;
            if (ID >= 0)
            {
                Lotnisko lotnisko = BazaDanych.lotniska.Find(x => x.ID == ID);
                textBox11.Text = lotnisko.ID.ToString();
                textBox6.Text = lotnisko.nazwa;
                textBox7.Text = lotnisko.panstwo.ToString();
                textBox8.Text = lotnisko.miasto.ToString();
                textBox9.Text = lotnisko.szerokoscGeo.ToString();
                textBox10.Text = lotnisko.wysokoscGeo.ToString();
                 

            }
        }

      
    }
}
