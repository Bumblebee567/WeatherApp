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
    public partial class RainAnaliser : Form
    {
        public RainAnaliser()
        {
            InitializeComponent();
            Width = 402;
            Height = 227;
            using (var context = new WeatherBaseEntities())
            {
                List<string> startDate = new List<string>();
                List<string> endDate = new List<string>();
                var dayCollection = context.Dzien.Where(x => x.Opady_deszczu.Any());
                
                foreach (var item in dayCollection)
                {
                        startDate.Add(item.Data.ToShortDateString());
                }
                comboBox1.Items.AddRange(startDate.ToArray());
                foreach (var item in dayCollection)
                {
                        endDate.Add(item.Data.ToShortDateString());
                }
                comboBox2.Items.AddRange(endDate.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Uzupełnij wszystkie pola", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == comboBox2.Text || DateTime.Parse(comboBox1.Text) > DateTime.Parse(comboBox2.Text))
            {
                MessageBox.Show("Niewłaściwa wartość w polu Data początkowa", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Text = null;
            }
            else
            {
                using (var context = new WeatherBaseEntities())
                {
                    List<Opady_deszczu> rainCollection = new List<Opady_deszczu>();
                    var startDate = DateTime.Parse(comboBox1.Text);
                    var endDate = DateTime.Parse(comboBox2.Text);
                    var currentDate = new DateTime();
                    int counter = 0;
                    Opady_deszczu[] deafultRain = new Opady_deszczu[5]
                    {
                        new Opady_deszczu {Pora_dnia = "Rano",          Intensywnosc = "0" },
                        new Opady_deszczu {Pora_dnia = "Przedpołudnie", Intensywnosc = "0" },
                        new Opady_deszczu {Pora_dnia = "Popołudnie",    Intensywnosc = "0" },
                        new Opady_deszczu {Pora_dnia = "Wieczór",       Intensywnosc = "0" },
                        new Opady_deszczu {Pora_dnia = "Noc",           Intensywnosc = "0" }
                    };
                    do
                    {
                        currentDate = startDate.AddDays(counter);
                        if (context.Opady_deszczu.Where(x => x.Dzien.Data == currentDate).Any())
                            rainCollection.AddRange(context.Opady_deszczu.Where(x => x.Dzien.Data == currentDate));
                        else
                        {
                            for (int i = 0; i < deafultRain.Length; i++)
                            {
                                deafultRain[i].Dzien = new Dzien();
                                deafultRain[i].Dzien.Data = currentDate;
                                rainCollection.AddRange(deafultRain);
                            }

                        }
                        counter += 1;
                    } while (DateTime.Compare(currentDate, endDate) != 0);
                    foreach (var item in rainCollection)
                    {
                        chart1.Series["intensywność opadów deszczu"].Points.AddXY(item.Dzien.Data.ToShortDateString(), (item.Intensywnosc));
                    }
                    button1.Hide();
                    button2.Hide();
                    label6.Hide();
                    BackColor = Color.White;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    //label4.Text = rainCollection.Where(x => x.Intensywnosc.Any(y => nt.Parse(y)>) && x.Dzien.Data >= startDate && x.Dzien.Data <= endDate).Count().ToString();
                    //label4.Text = rainCollection.Where(x => x.Intensywnosc.Any(y=> y!=0) && x.Dzien.Data >= startDate && x.Dzien.Data <= endDate).Count().ToString();
                    Width = 1287;
                    Height = 684;
                    this.CenterToScreen();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ran = new RainAnaliser();
            ran.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var am = new AnalizerMain();
            am.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (Graphics gfx = CreateGraphics())
            {
                using (Bitmap bmp = new Bitmap(Width, Height, gfx))
                {
                    DrawToBitmap(bmp, new Rectangle(0, 0, Width, Height));
                    SaveFileDialog f = new SaveFileDialog();
                    f.Filter = "PNG(*.PNG)|*.png";
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        bmp.Save(f.FileName);
                    }
                }
            }
        }
    }
}
