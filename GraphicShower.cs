using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Метод_Наименьших_Квадратов
{
    public partial class GraphicShower : Form
    {
        laba element;

        public GraphicShower(laba Results)
        {
            InitializeComponent();
            element = Results;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            points_load(2);
            chart1.Visible = true;
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            double step_x = element.get_a(), h = (element.get_b() - element.get_a()) /element.get_setka() ;
            for (int pointIndex = 0; pointIndex < 6 ; pointIndex++)
            {
                chart1.Series["Series1"].Points.AddXY(step_x, element.get_F(step_x));
                chart1.Series["Series2"].Points.AddXY(step_x, element.get_P(1,pointIndex));
                step_x = step_x + h;
            }
            chart1.Series["Series1"].LegendText = "функция y_yzlu";
            chart1.Series["Series2"].LegendText = "функция N1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            points_load(4);
            double step_x = element.get_a(), h = (element.get_b() - element.get_a()) / element.get_setka();
            for (int pointIndex = 0; pointIndex < 16; pointIndex++)
            {
                chart1.Series["Series1"].Points.AddXY(step_x, element.get_F(step_x));
                chart1.Series["Series2"].Points.AddXY(step_x, element.get_P(3, pointIndex));
                step_x = step_x + h;
            }
            chart1.Series["Series1"].LegendText = "функция y_yzlu";
            chart1.Series["Series2"].LegendText = "функция N3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            points_load(7);
            double step_x = element.get_a(), h = (element.get_b() - element.get_a()) / element.get_setka();
            for (int pointIndex = 0; pointIndex < 31; pointIndex++)
            {
                chart1.Series["Series1"].Points.AddXY(step_x, element.get_F(step_x));
                chart1.Series["Series2"].Points.AddXY(step_x, element.get_P(6, pointIndex));
                step_x = step_x + h;
            }
            chart1.Series["Series1"].LegendText = "функция y_yzlu";
            chart1.Series["Series2"].LegendText = "функция N6";
        }


        private void points_load(int yzel)
        {
            chart1.Series["Series3"].Points.Clear();
            for (int i = 0; i < yzel; i++)
            {
                double xq = element.get_x(i);
                chart1.Series["Series3"].Points.AddXY(xq, element.get_F(xq));
            }
        }

        private void GraphicShower_Load(object sender, EventArgs e)
        {

        }


    }
}
