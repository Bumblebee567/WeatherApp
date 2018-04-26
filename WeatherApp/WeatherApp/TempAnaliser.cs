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
    public partial class TempAnaliser : Form
    {

        public TempAnaliser()
        {
            InitializeComponent();
            Height = 229;
            Width = 410;
            checkBox1.Hide();
            checkBox2.Hide();
            BackColor = SystemColors.ActiveCaption;
            using (var context = new WeatherBaseEntities())
            {
                List<string> startDate = new List<string>();
                List<string> endDate = new List<string>();
                foreach (var item in context.Dzien)
                {
                    startDate.Add(item.Data.ToShortDateString());
                }
                comboBox1.Items.AddRange(startDate.ToArray());

                foreach (var item in context.Dzien)
                {
                    endDate.Add(item.Data.ToShortDateString());
                }
                comboBox2.Items.AddRange(endDate.ToArray());
            }
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Uzupełnij wszystkie dane", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    List<Temperatura> temperatureCollection = new List<Temperatura>();
                    var startDate = DateTime.Parse(comboBox1.Text);
                    var endDate = DateTime.Parse(comboBox2.Text);
                    var currentDate = new DateTime();
                    int counter = 0;
                    Temperatura deafultTemperature = new Temperatura { Temp_max = 0, Temp_min = 0 };
                    do
                    {
                        currentDate = startDate.AddDays(counter);
                        //dzien = context.Dzien.Where(x => x.Data == currentDate).First();
                        if(context.Temperatura.Where(x => x.Dzien.Data == currentDate).Any())
                            temperatureCollection.Add(context.Temperatura.Where(x => x.Dzien.Data == currentDate).First());
                        else
                        {
                            deafultTemperature.Dzien = new Dzien();
                            deafultTemperature.Dzien.Data = currentDate;
                            temperatureCollection.Add(deafultTemperature);
                        }
                        counter += 1;
                    } while (DateTime.Compare(currentDate, endDate) != 0);
                    foreach (var item in temperatureCollection)
                    {
                        chart1.Series["Najwyższe temperatury"].Points.AddXY(item.Dzien.Data.ToShortDateString(), item.Temp_max);
                        chart1.Series["Najniższe temperatury"].Points.AddXY(item.Dzien.Data.ToShortDateString(), item.Temp_min);
                    }
                    button1.Hide();
                    button2.Hide();
                    label6.Hide();
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    Width = 1287;
                    Height = 684;
                    BackColor = Color.White;
                    checkBox1.Show();
                    checkBox2.Show();
                    this.CenterToScreen();
                    var t = new Temperatura();
                    t = temperatureCollection.Where(x => x.Temp_max == temperatureCollection.Max(y => y.Temp_max)).First();
                    label4.Text = t.Temp_max.ToString() + "*C (" + t.Dzien.Data.Day + "." + t.Dzien.Data.Month+")";
                    t = temperatureCollection.Where(x => x.Temp_min == temperatureCollection.Min(y => y.Temp_min)).First();
                    label7.Text = t.Temp_min.ToString() + "*C (" + t.Dzien.Data.Day + "." + t.Dzien.Data.Month + ")";
                    var minAvg = temperatureCollection.Average(x => x.Temp_min);
                    var maxAvg = temperatureCollection.Average(x => x.Temp_max);
                    label9.Text = (Math.Round(minAvg + maxAvg) / 2).ToString() + "*C";
                    int ampOv = temperatureCollection.Max(x => x.Temp_max) - temperatureCollection.Min(y => y.Temp_min);
                    label11.Text = $"{ampOv} *C";
                    t = temperatureCollection.Where(x => x.Temp_max - x.Temp_min == temperatureCollection.Max(y => y.Temp_max - y.Temp_min)).First();
                    label13.Text = (t.Temp_max - t.Temp_min).ToString() + "*C (" + t.Dzien.Data.Day + "." + t.Dzien.Data.Month + ")";
                    t = temperatureCollection.Where(x => x.Temp_max - x.Temp_min == temperatureCollection.Min(y => y.Temp_max - y.Temp_min)).First();
                    label15.Text = (t.Temp_max - t.Temp_min).ToString() + "*C (" + t.Dzien.Data.Day + "." + t.Dzien.Data.Month + ")";

                }
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            var am = new AnalizerMain();
            am.Show();
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                chart1.Series["Najwyższe temperatury"].BorderWidth = 3;
            }
            else
            {
                chart1.Series["Najwyższe temperatury"].BorderWidth = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                chart1.Series["Najniższe temperatury"].BorderWidth = 3;
            }
            else
            {
                chart1.Series["Najniższe temperatury"].BorderWidth = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ta = new TempAnaliser();
            ta.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chart1.BackColor = Color.Transparent;
            
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

