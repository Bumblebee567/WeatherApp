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
    public partial class SnowCoverData : Form
    {
        public SnowCoverData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == null || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Uzupełnij wszystkie dane", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InsertData.newDay.Pokrywa_sniezna.Add(new Pokrywa_sniezna { Grubosc = Convert.ToInt32(textBox1.Text), Typ_sniegu = comboBox1.Text});
                this.Close();
            }
        }
    }
}
