using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBC_Game
{
    public partial class Form5 : Form
    {
        string x = "";
        public Form5(string i)
        {
            x = i;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SoundPlayer SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Khangia.wav");
            SP.Play();
            Random r1 = new Random();
            int x1 = r1.Next(1, 101);
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            while(x1 < 30)
            {
                x1 = r1.Next(1, 101);
            }
            int x2 = r1.Next(1, 101 - x1);
            int x3 = r1.Next(1, 101 - x1 - x2);
            int x4 = 100 - x1 - x2 - x3;
            if(x == "A")
            {
                chart1.Series["A"].Points.AddXY("A", x1.ToString()) ;
                chart1.Series["A"].Points.AddXY("B", x2.ToString());
                chart1.Series["A"].Points.AddXY("C", x3.ToString());
                chart1.Series["A"].Points.AddXY("D", x4.ToString());
            }
            else if (x == "B")
            {
                chart1.Series["A"].Points.AddXY("A", x2.ToString());
                chart1.Series["A"].Points.AddXY("B", x1.ToString());
                chart1.Series["A"].Points.AddXY("C", x3.ToString());
                chart1.Series["A"].Points.AddXY("D", x4.ToString());
            }
            else if (x == "C")
            {
                chart1.Series["A"].Points.AddXY("A", x2.ToString());
                chart1.Series["A"].Points.AddXY("B", x3.ToString());
                chart1.Series["A"].Points.AddXY("C", x1.ToString());
                chart1.Series["A"].Points.AddXY("D", x4.ToString());
            }
            else if (x == "D")
            {
                chart1.Series["A"].Points.AddXY("A", x2.ToString());
                chart1.Series["A"].Points.AddXY("B", x4.ToString());
                chart1.Series["A"].Points.AddXY("C", x3.ToString());
                chart1.Series["A"].Points.AddXY("D", x1.ToString());
            }
            chart1.Series["A"].IsVisibleInLegend = false;
        }
    }
}
