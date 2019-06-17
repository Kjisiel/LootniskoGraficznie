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

                foreach (Lotnisko lotnisko in BazaDanych.lotniska)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = lotnisko.nazwa;
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
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {


                int ID = 1;
                if (BazaDanych.lotniska.Count() > 0)
                {
                    ID = BazaDanych.lotniska.Max(x => x.ID) + 1;
                }
                if(textBox1.Text=="")
                {
                    throw new ArgumentException("pole nazwa nie może być puste");
                }
                if (textBox2.Text == "")
                {
                    throw new ArgumentException("polee państwo nie może być puste");
                }
                if (textBox3.Text == "")
                {
                    throw new ArgumentException("polee miasto nie może być puste");
                }
                if (textBox4.Text == "")
                {
                    throw new ArgumentException("pole szerokość geograficzna nie może być puste");
                }
                if (textBox5.Text == "")
                {
                    throw new ArgumentException("pole wysokość geograficzna nie może być puste");
                }
                if(textBox4.Text.Contains(".")|| textBox5.Text.Contains("."))
                {
                    throw new ArgumentException("format double powinien zawieraz , nie .");
                }
                if (!double.TryParse(textBox4.Text,out double szerokosc))
                {
                    throw new ArgumentException("szerokosc geograficzna jest zlego formatu");
                }
                if (!double.TryParse(textBox5.Text, out double wysokosc))
                {
                    throw new ArgumentException("wysokość geograficzna jest zlego formatu");
                }
                Lotnisko lotnisko = new Lotnisko(ID, textBox1.Text, textBox2.Text,
                    textBox3.Text, double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                Random random = new Random();

                BazaDanych.lotniska.Add(lotnisko);

                initLotniskaCombobox();
            }
            catch(ArgumentException exd)
            {
                MessageBox.Show(exd.Message);
            }
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

        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                int ID = (comboBox1.SelectedItem as ComboboxItem).Value;
                Lotnisko lotnisko = BazaDanych.lotniska.Find(x => x.ID == ID);
                BazaDanych.lotniska.Remove(lotnisko);
                Console.WriteLine("a=" + BazaDanych.lotniska.Count);
                comboBox1.Items.Remove(ID);
            }
            initLotniskaCombobox();
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
