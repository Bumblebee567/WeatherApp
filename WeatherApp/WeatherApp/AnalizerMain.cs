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
    public partial class AnalizerMain : Form
    {
        public AnalizerMain()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var start = new Form1();
            start.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ta = new TempAnaliser();
            ta.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ran = new RainAnaliser();
            ran.Show();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var san = new SnowAnaliser();
            san.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var can = new CloudAnaliser();
            can.Show();
            Close();
        }
    }
}
