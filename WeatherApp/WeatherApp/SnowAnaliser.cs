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
    public partial class SnowAnaliser : Form
    {
        public SnowAnaliser()
        {
            InitializeComponent();
            Width = 402;
            Height = 227;
            using (var context = new WeatherBaseEntities())
            {
                List<string> startDate = new List<string>();
                List<string> endDate = new List<string>();
                var dayCollection = context.Dzien.Where(x => x.Opady_sniegu.Any());

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

        private void chart1_Click(object sender, EventArgs e)
        {

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
                    List<Opady_sniegu> snowCollection = new List<Opady_sniegu>();
                    var startDate = DateTime.Parse(comboBox1.Text);
                    var endDate = DateTime.Parse(comboBox2.Text);
                    var currentDate = new DateTime();
                    int counter = 0;
                    Opady_sniegu[] deafultSnow = new Opady_sniegu[5]
                    {
                        new Opady_sniegu {Pora_dnia = "Rano",          Intensywnosc = "0", Rodzaj_sniegu = "brak" },
                        new Opady_sniegu {Pora_dnia = "Przedpołudnie", Intensywnosc = "0", Rodzaj_sniegu = "brak" },
                        new Opady_sniegu {Pora_dnia = "Popołudnie",    Intensywnosc = "0", Rodzaj_sniegu = "brak" },
                        new Opady_sniegu {Pora_dnia = "Wieczór",       Intensywnosc = "0", Rodzaj_sniegu = "brak" },
                        new Opady_sniegu {Pora_dnia = "Noc",           Intensywnosc = "0", Rodzaj_sniegu = "brak" }
                    };
                    do
                    {
                        currentDate = startDate.AddDays(counter);
                        if (context.Opady_sniegu.Where(x => x.Dzien.Data == currentDate).Any())
                            snowCollection.AddRange(context.Opady_sniegu.Where(x => x.Dzien.Data == currentDate));
                        else
                        {
                            for (int i = 0; i < deafultSnow.Length; i++)
                            {
                                deafultSnow[i].Dzien = new Dzien();
                                deafultSnow[i].Dzien.Data = currentDate;
                                snowCollection.AddRange(deafultSnow);
                            }

                        }
                        counter += 1;
                    } while (DateTime.Compare(currentDate, endDate) != 0);
                    foreach (var item in snowCollection)
                    {
                        chart1.Series["intensywność opadów śniegu"].Points.AddXY(item.Dzien.Data.ToShortDateString(), (item.Intensywnosc));
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

        private void button2_Click(object sender, EventArgs e)
        {
            var am = new AnalizerMain();
            am.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ran = new SnowAnaliser();
            ran.Show();
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
