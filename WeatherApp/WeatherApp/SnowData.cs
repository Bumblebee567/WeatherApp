using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class SnowData : Form
    {
        public SnowData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem == null || this.comboBox2.SelectedItem == null || this.comboBox3.SelectedItem == null || this.comboBox4.SelectedItem == null || this.comboBox5.SelectedItem == null)
            {
                MessageBox.Show("Uzupełnij wszystkie dane", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InsertData.newDay.Opady_sniegu.Add(new Opady_sniegu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox1.Text), Pora_dnia = "Rano", Rodzaj_sniegu = comboBox6.Text });
                InsertData.newDay.Opady_sniegu.Add(new Opady_sniegu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox5.Text), Pora_dnia = "Przedpołudnie", Rodzaj_sniegu = comboBox7.Text });
                InsertData.newDay.Opady_sniegu.Add(new Opady_sniegu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox4.Text), Pora_dnia = "Popołudnie", Rodzaj_sniegu = comboBox8.Text });
                InsertData.newDay.Opady_sniegu.Add(new Opady_sniegu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox3.Text), Pora_dnia = "Wieczór", Rodzaj_sniegu = comboBox9.Text });
                InsertData.newDay.Opady_sniegu.Add(new Opady_sniegu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox2.Text), Pora_dnia = "Noc", Rodzaj_sniegu = comboBox10.Text });
                this.Close();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null)
            {
                comboBox6.Enabled = false;
            }
        }
    }
}
