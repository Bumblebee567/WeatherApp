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
    public partial class InsertData : Form
    {
        public static Dzien newDay = new Dzien();

        public InsertData()
        {
            InitializeComponent();
            this.Width = 469;
            //string[] items = new string[14];
            var d = new DateGenerator();
            var col = d.GenerateDateItemsToCombobox();
            comboBox3.Items.AddRange(col);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DateTime data = DateTime.Parse(comboBox3.Text);
            using (var context = new WeatherBaseEntities())
            {
                if (comboBox3.SelectedItem == null || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Uzupełnij wszystkie pola", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (context.Dzien.Any(x => x.Data == data))
                {
                    MessageBox.Show("Dzień o podanej dacie jest już w bazie", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox3.ResetText();
                }
                else
                {
                    newDay.Data = DateTime.Parse(comboBox3.Text);
                    newDay.Temperatura.Add(new Temperatura { Temp_max = Convert.ToInt32(textBox2.Text), Temp_min = Convert.ToInt32(textBox3.Text) });
                    context.Dzien.Add(newDay);
                    context.SaveChanges();
                    MessageBox.Show("Dane zostały dodane", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var f1 = new Form1();
                    f1.Show();
                    this.Close();
                }

            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var f = new RainData();
                f.Show();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                var s = new SnowData();
                s.Show();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                var w = new WindData();
                w.Show();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                var sc = new SnowCoverData();
                sc.Show();
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                var c = new CloudData();
                c.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                var s = new StormDatacs();
                s.Show();
            }
        }
    }
}
