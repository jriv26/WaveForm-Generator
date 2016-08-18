using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            double Amplitude = 1;
            double freq = 1; //Hz
            double Amplitude2 = 1;
            double freq2 = 1; //Hz
            double period = 1;
            double period2 = 2;
            double phase;

            if (Double.TryParse(textBox1.Text, out freq) && Double.TryParse(textBox2.Text, out Amplitude) && Double.TryParse(textBox4.Text, out freq2) && Double.TryParse(textBox3.Text, out Amplitude2) && Double.TryParse(textBox5.Text, out phase))
            {
                double x = 0;
                int samples = 1000;
                period = 1 / freq;
                double x2 = 0;
                int samples2 = 1000;
                period2 = 1 / freq2;

                double longerperiod;
                if (period > period2)
                {
                    longerperiod = period;
                }
                else
                    longerperiod = period2;

                while (x < longerperiod)
                {
                    chart1.Series[0].Points.AddXY(x, Amplitude * Math.Sin(x * 2 * Math.PI * freq));
                    x += longerperiod / (2 * (double)samples);
                }
                while (x2 < longerperiod)
                {
                    chart1.Series[1].Points.AddXY(x2, Amplitude2 * Math.Sin(x2 * 2 * Math.PI * freq2 + phase*(Math.PI/180)));
                    x2 += longerperiod / (2 * (double)samples2);
                }

            }

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            if (period2 > period)
            {
                chart1.ChartAreas[0].AxisX.Maximum = period2;
            }
            else
                chart1.ChartAreas[0].AxisX.Maximum = period;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            for (int i = -200; i < 201; i++)
            {
                chart1.Series[0].Points.AddXY(i, Math.Pow((double)i, 3));
                chart1.ChartAreas[0].AxisX.Maximum = Double.NaN;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            for (int i = -200; i < 201; i++)
            {
                chart1.Series[0].Points.AddXY(i, Math.Pow((double)i, 4));
                chart1.ChartAreas[0].AxisX.Maximum = Double.NaN;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double userinput;
            if (Double.TryParse(textBox1.Text,out userinput))
            {
                chart1.Series[0].Points.Clear();
                for (int i = -200; i < 201; i++)
                {
                    chart1.Series[0].Points.AddXY(i, Math.Pow((double)i, userinput));
                    chart1.ChartAreas[0].AxisX.Maximum = Double.NaN;
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void Square_Click(object sender, EventArgs e)
        {

        }
    }
}
