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
            intitSamolotView();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            int ID = 1;
            if (BazaDanych.samoloty.Count()>0){
                ID = BazaDanych.samoloty.Max(x => x.ID) + 1;
            }
            
            Samolot samolot = new Samolot(ID,textBox1.Text,int.Parse(textBox2.Text),
                int.Parse(textBox3.Text),double.Parse(textBox4.Text));
            Random random = new Random();
            Lotnisko obecneLotnisko = BazaDanych.lotniska[random.Next(BazaDanych.lotniska.Count)];
            BazaDanych.samoloty.Add(samolot);
            
            initSamolotyCombobox();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                int ID = (comboBox1.SelectedItem as ComboboxItem).Value; 
                Samolot samolot = BazaDanych.samoloty.Find(x => x.ID == ID);
                BazaDanych.samoloty.Remove(samolot);
                Console.WriteLine("a=" + BazaDanych.samoloty.Count);
                comboBox1.Items.Remove(ID);
            }
            initSamolotyCombobox();
        }

        private void ZarzadzanieSamolotyForm_Load(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            intitSamolotView();
        }

        private void intitSamolotView() { 


            int ID = (comboBox1.SelectedItem as ComboboxItem).Value;
            if (ID>=0)
            {
                Samolot samolot = BazaDanych.samoloty.Find(x => x.ID == ID);
                textBox5.Text = samolot.ID.ToString();
                textBox6.Text = samolot.nazwa;
                textBox7.Text = samolot.zasieg.ToString();
                textBox8.Text = samolot.liczbamiejsc.ToString();
                textBox9.Text = samolot.sredniaPredkosc.ToString();
                textBox10.Text = samolot.obecneLotnisko.miasto
                    + " - " + samolot.obecneLotnisko.nazwa;

            }
        }
    }
}
