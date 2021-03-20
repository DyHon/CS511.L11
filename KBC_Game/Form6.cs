using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KBC_Game
{
    public partial class Form6 : Form
    {
        int diem;
        public Form6(int n)
        {
            diem = n;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\ADMIN\Desktop\KBC Game\KBC_Game\KBC_Game\bin\Debug\Data\RankingName.txt";
            string str;
            str = textBox1.Text.ToString();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(str);
            }
            path = @"C:\Users\ADMIN\Desktop\KBC Game\KBC_Game\KBC_Game\bin\Debug\Data\RankingScore.txt";
            
            str = diem.ToString();
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(str);
            }

            this.Close();
            
            
           
        }
    }
}
