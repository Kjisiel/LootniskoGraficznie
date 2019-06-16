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
    public partial class ZarzadzanieLotniskamiForm : Form
    {
        public ZarzadzanieLotniskamiForm()
        {
            InitializeComponent();
            initLotniskaCombobox();
        }
        public void initLotniskaCombobox()
        {
            comboBox1.Items.Clear();
            foreach (Lotnisko lotnisko in BazaDanych.lotniska)
            {
                // ComboboxItem item = new ComboboxItem();
                //  item.Text = samolot.nazwa;
                //  item.Value = samolot.ID;
                comboBox1.DisplayMember = "Text";
                comboBox1.ValueMember = "Value";

                comboBox1.Items.Add((new { Text = lotnisko.nazwa, Value = lotnisko.ID }));

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
    }
}
