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
    public partial class StormDatacs : Form
    {
        public StormDatacs()
        {
            InitializeComponent();
        }

        private void StormDatacs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) == true || string.IsNullOrEmpty(textBox2.Text) == true || string.IsNullOrEmpty(textBox3.Text) == true || string.IsNullOrEmpty(textBox4.Text) == true)
            {
                MessageBox.Show("Uzupełnij wszystkie pola", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(int.Parse(textBox1.Text) > 4 || int.Parse(textBox1.Text) < 0)
            {
                MessageBox.Show("Niepoprawna wartość w polu Intensywność wyładowań", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = null;
            }
            else if (int.Parse(textBox2.Text) > 3 || int.Parse(textBox2.Text) < 0)
            {
                MessageBox.Show("Niepoprawna wartość w polu Intensywność deszczu", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = null;
            }
            else if (int.Parse(textBox3.Text) > 3 || int.Parse(textBox3.Text) < 0)
            {
                MessageBox.Show("Niepoprawna wartość w polu Wielkość gradu", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Text = null;
            }
            else if (int.Parse(textBox4.Text) > 10 || int.Parse(textBox4.Text) < 0)
            {
                MessageBox.Show("Niepoprawna wartość w polu Prędkość wiatru", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Text = null;
            }
            else if(richTextBox1.Text.Length > 100)
            {
                MessageBox.Show("Za długi opis (> 100 znaków)", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                InsertData.newDay.Burza.Add(new Burza
                {
                    Punkty_deszcz = Convert.ToInt32(textBox2.Text),
                    Punkty_wyladowania = Convert.ToInt32(textBox1.Text),
                    Punkty_grad = Convert.ToInt32(textBox3.Text),
                    Kierunek_frontu = textBox7.Text,
                    Opis = richTextBox1.Text
                });
                this.Close();
            }
        }
    }
}
