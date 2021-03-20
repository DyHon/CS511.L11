using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Media;

namespace KBC_Game
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SoundPlayer j = new SoundPlayer(@Application.StartupPath + @"\Data\Music\begin.wav");




        private void button1_Click(object sender, EventArgs e)
        {
            j.Stop();
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            
            if (form2.isRestart())
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }
            this.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            j.Play();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            this.Hide();
            form8.ShowDialog();
            this.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            this.Hide();
            form9.ShowDialog();
            this.Show();
        }
    }
}
