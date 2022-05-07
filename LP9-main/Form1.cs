using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LP9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxXmin.Text = "0,12";
            textBoxXmax.Text = "0,64";
            step.Text = "0,2";
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double xmin = double.Parse(textBoxXmin.Text);
            double xmax = double.Parse(textBoxXmax.Text);
            double dx = double.Parse(step.Text);

            int count = (int)Math.Ceiling((xmax - xmin) /dx) + 1;
            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];

            for (int i = 0; i < count; i++)
            {
                x[i] = xmin + dx * i;
                y1[i] = Math.Pow(Math.Log(Math.Sin(Math.Pow(x[i], 3) + 0.0025)), 1.5) + (0.8 * Math.Pow(10, -3));
                y2[i] = Math.Cos(x[i]);
            }
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = dx;
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}