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
    public partial class CloudData : Form
    {
        public CloudData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedItem == null || this.comboBox2.SelectedItem == null || this.comboBox3.SelectedItem == null || this.comboBox4.SelectedItem == null || this.comboBox5.SelectedItem == null)
            {
                MessageBox.Show("Uzupełnij wszystkie pola", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InsertData.newDay.Stan_zachmurzenia.Add(new Stan_zachmurzenia { Pora_dnia = "Rano", Wielkosc_zachmurzenia =             IntensivityParser.ParseIntensivity(comboBox1.Text), Typ_chmur = comboBox6.Text });
                InsertData.newDay.Stan_zachmurzenia.Add(new Stan_zachmurzenia { Pora_dnia = "Przedpołudnie", Wielkosc_zachmurzenia =    IntensivityParser.ParseIntensivity(comboBox2.Text), Typ_chmur = comboBox7.Text });
                InsertData.newDay.Stan_zachmurzenia.Add(new Stan_zachmurzenia { Pora_dnia = "Popołudnie", Wielkosc_zachmurzenia =       IntensivityParser.ParseIntensivity(comboBox3.Text), Typ_chmur = comboBox8.Text });
                InsertData.newDay.Stan_zachmurzenia.Add(new Stan_zachmurzenia { Pora_dnia = "Wieczór", Wielkosc_zachmurzenia =          IntensivityParser.ParseIntensivity(comboBox4.Text), Typ_chmur = comboBox9.Text });
                InsertData.newDay.Stan_zachmurzenia.Add(new Stan_zachmurzenia { Pora_dnia = "Noc", Wielkosc_zachmurzenia =              IntensivityParser.ParseIntensivity(comboBox5.Text), Typ_chmur = comboBox10.Text });
                this.Close();
            }
        }

    }
}
