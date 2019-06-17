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
             comboBox1.DisplayMember = "Text";
             comboBox1.ValueMember = "Value";
            foreach (Lotnisko lotnisko in BazaDanych.lotniska)
            {
            
              comboBox1.Items.Add((new { Text = lotnisko.nazwa, Value = lotnisko.ID }));

            }
        }
        public void initPrzylotCombobox()
        {
            comboBox2.Items.Clear();
            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";

            foreach (Lotnisko lotnisko in BazaDanych.lotniska)
            {
              

                comboBox2.Items.Add((new { Text = lotnisko.nazwa, Value = lotnisko.ID }));

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

        private void Button1_Click(object sender, EventArgs e)
        {
            int ID = BazaDanych.trasy.Max(x => x.ID) + 1;
            //Trasa trasa = new Trasa (ID, textBox1.Text, int.Parse(textBox2.Text),
              //  int.Parse(textBox3.Text), double.Parse(textBox4.Text));
           // BazaDanych.trasy.Add(trasa);
            initTrasyCombobox();
        }
    }
}
