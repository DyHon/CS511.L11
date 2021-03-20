using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBC_Game
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string[] ListStr = new string[100];

            int i = 0;
            int top1_score = 0;
            int top1_des = 0;
            int top2_score = 0;
            int top2_des = 0;
            int top3_score = 0;
            int top3_des = 0;
            string path = @"C:\Users\ADMIN\Desktop\KBC Game\KBC_Game\KBC_Game\bin\Debug\Data\RankingScore.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                i = 0;
                while (sr.Peek() >= 0)
                {
                    
                    ListStr[i] = sr.ReadLine();
                    if (Convert.ToInt32(ListStr[i]) > top1_score)
                    {
                        top1_score = Convert.ToInt32(ListStr[i]);
                        top1_des = i;
                    }
                    i++;

                }
            }
            using (StreamReader sr = new StreamReader(path))
            {
                i = 0;
                while (sr.Peek() >= 0)
                {
                    ListStr[i] = sr.ReadLine();
                    if (Convert.ToInt32(ListStr[i]) > top2_score && i!=top1_des)
                    {
                        top2_score = Convert.ToInt32(ListStr[i]);
                        top2_des = i;
                    }
                    i++;

                }
            }
            using (StreamReader sr = new StreamReader(path))
            {
                i = 0;
                while (sr.Peek() >= 0)
                {
                    ListStr[i] = sr.ReadLine();
                    if (Convert.ToInt32(ListStr[i]) > top3_score && i!=top1_des && i!=top2_des)
                    {
                        top3_score = Convert.ToInt32(ListStr[i]);
                        top3_des = i;
                    }
                    i++;

                }
            }
            label8.Text = Convert.ToString(top1_score);
            label9.Text = Convert.ToString(top2_score);
            label10.Text = Convert.ToString(top3_score);
            path = @"C:\Users\ADMIN\Desktop\KBC Game\KBC_Game\KBC_Game\bin\Debug\Data\RankingName.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                
                i = 0;
                while (sr.Peek() >= 0)
                {
                    
                    ListStr[i] = sr.ReadLine();
                    if (i == top1_des)
                    {
                        label5.Text = ListStr[i];
                    }
                    else if (i == top2_des)
                    {
                        label6.Text = ListStr[i];
                    }
                    else if (i == top3_des)
                    {
                        label7.Text = ListStr[i];
                    }

                    i++;

                }
            }
        }
    }
}
