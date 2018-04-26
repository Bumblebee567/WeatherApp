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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var insertdata = new InsertData();
            this.Hide();
            insertdata.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var analiser = new AnalizerMain();
            this.Hide();
            analiser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Czy na pewno chcesz wyjść?", "Wyjdź", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                Close();
            }
            
        }

        //na 5 kwietnia, podstawowe funkcjonalności mają być
    }
}
