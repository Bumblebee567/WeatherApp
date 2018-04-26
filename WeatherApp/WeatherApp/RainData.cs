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
    public partial class RainData : Form
    {
        public RainData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedItem == null || this.comboBox2.SelectedItem == null || this.comboBox3.SelectedItem == null || this.comboBox4.SelectedItem == null || this.comboBox5.SelectedItem == null)
            {
                MessageBox.Show("Uzupełnij wszystkie dane", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InsertData.newDay.Opady_deszczu.Add(new Opady_deszczu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox1.Text), Pora_dnia = "Rano" });
                InsertData.newDay.Opady_deszczu.Add(new Opady_deszczu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox5.Text), Pora_dnia = "Przedpołudnie" });
                InsertData.newDay.Opady_deszczu.Add(new Opady_deszczu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox4.Text), Pora_dnia = "Popołudnie" });
                InsertData.newDay.Opady_deszczu.Add(new Opady_deszczu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox3.Text), Pora_dnia = "Wieczór" });
                InsertData.newDay.Opady_deszczu.Add(new Opady_deszczu { Intensywnosc = IntensivityParser.ParseIntensivity(comboBox2.Text), Pora_dnia = "Noc" });
                this.Close();
            }
        }
    }
}
