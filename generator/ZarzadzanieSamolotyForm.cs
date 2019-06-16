using L1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace generator
{
    public partial class ZarzadzanieSamolotyForm : Form
    {
        public ZarzadzanieSamolotyForm()
        {
            InitializeComponent();
            initSamolotyCombobox();

        }
        public void initSamolotyCombobox()
        {
            comboBox1.Items.Clear();
            foreach (Samolot samolot in BazaDanych.samoloty)
            {
                // ComboboxItem item = new ComboboxItem();
                //  item.Text = samolot.nazwa;
                //  item.Value = samolot.ID;
                comboBox1.DisplayMember = "Text";
                comboBox1.ValueMember = "Value";

                comboBox1.Items.Add((new { Text =samolot.nazwa, Value =samolot.ID }));
                
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int ID = BazaDanych.samoloty.Max(x => x.ID) + 1;
            Samolot samolot = new Samolot(ID,textBox1.Text,int.Parse(textBox2.Text),
                int.Parse(textBox3.Text),double.Parse(textBox4.Text));
            BazaDanych.samoloty.Add(samolot);
            initSamolotyCombobox();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
           // comboBox1.SelectedItem
            initSamolotyCombobox();
        }
    }
}
