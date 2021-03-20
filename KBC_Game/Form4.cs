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
    public partial class Form4 : Form
    {
        public  Form4(string diem1)
        {
            diem2 = diem1;
            InitializeComponent();
        }
        
        string diem2;
        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = diem2;
        }
        bool rs = false;
        public bool isRestart()
        {
            return rs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            rs = true;
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rs = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name;
            Form6 form6 = new Form6(Convert.ToInt32(label3.Text));
            form6.ShowDialog();
            
            
        }
    }
}
