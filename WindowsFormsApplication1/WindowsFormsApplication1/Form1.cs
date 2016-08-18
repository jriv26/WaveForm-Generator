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

        bool sig1case = false;
        bool sig2case = false;

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

        private void Square_Click_1(object sender, EventArgs e)
        {
            double vpp;
            double freq;
            double dcoff;
            double x;
            double samples;
            double period;
            double Amplitude;
            double offset = 0;
            double duty;

            if (Double.TryParse(Vpp.Text, out vpp) && Double.TryParse(Freq.Text, out freq) && Double.TryParse(DcOffset.Text, out dcoff) && Double.TryParse(Duty.Text, out duty))
            {
                x = 0;
                samples = 1000;
                period = 1 / freq;
                Amplitude = vpp / 2;
                duty = duty / 100;


                if (sig1case)
                {
                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();
                    while (x < 2 * period)
                    {
                        if (x < period)
                            if (x < (period) * duty)
                                chart1.Series[0].Points.AddXY(x, Amplitude + dcoff);
                            else
                                chart1.Series[0].Points.AddXY(x, -Amplitude + dcoff);
                        else
                            if (x < (2 * period) - (period - period * duty))
                            chart1.Series[0].Points.AddXY(x, Amplitude + dcoff);
                        else
                            chart1.Series[0].Points.AddXY(x, -Amplitude + dcoff);

                        x += period / (2 * (double)samples);
                    }
                }
                chart1.ChartAreas[0].AxisX.Maximum = Double.NaN;
                chart1.ChartAreas[0].AxisX.Minimum = Double.NaN;

            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Vpp_TextChanged(object sender, EventArgs e)
        {

        }

        private void Freq_TextChanged(object sender, EventArgs e)
        {

        }

        private void DcOffset_TextChanged(object sender, EventArgs e)
        {

        }

        private void Signal1_Click(object sender, EventArgs e)
        {
            sig1case = !sig1case;
            if (sig1case)
                Signal1.BackColor = Color.Green;
            else
                Signal1.BackColor = Color.Red;
        }

        private void Signal2_Click(object sender, EventArgs e)
        {

        }

        private void Duty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
