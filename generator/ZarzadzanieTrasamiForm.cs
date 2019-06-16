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
    public partial class ZarzadzanieTrasamiForm : Form
    {
        public ZarzadzanieTrasamiForm()
        {
            InitializeComponent();
            initTrasyCombobox();
        }
        public void initOdlotCombobox()
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
        public void initPrzylotCombobox()
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
        public void initTrasyCombobox()
        {
            comboBox3.Items.Clear();
            comboBox3.DisplayMember = "Text";
            comboBox3.ValueMember = "Value";
            foreach (Trasa trasa in BazaDanych.trasy)
            {
                comboBox3.Items.Add((new { Text = trasa.odlot.nazwa+"-"+trasa.przylot.nazwa, Value = trasa.ID  }));
                

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ZarzadzanieTrasamiForm_Load(object sender, EventArgs e)
        {

        }
    }
}
