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
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Microsoft.Edge.SeleniumTools;
namespace KBC_Game
{
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        int btn1Enable = 1;
        int btn2Enable = 1;
        int btn3Enable = 1;
        
        private void Form2_Load(object sender, EventArgs e)
        {
            displaycauhoi(1);
            
        }
        public SoundPlayer SP;
        public int rangbuoc = 60;
        Timer timer1;
        public int demsocau = 1;
        int tinhdiem(int x)
        {
            if (x == 0)
                return 0;
            if (x == 1)
                return 100;
            if (x == 2)
                return 200;
            if (x == 3)
                return 300;
            if (x == 4)
                return 500;
            if (x == 5)
                return 1000;
            if (x == 6)
                return 2000;
            if (x == 7)
                return 4000;
            if (x == 8)
                return 8000;
            if (x == 9)
                return 16000;
            if (x == 10)
                return 32000;
            if (x == 11)
                return 64000;
            if (x == 12)
                return 125000;
            if (x == 13)
                return 250000;
            if (x == 14)
                return 500000;
            if (x == 15)
                return 1000000;
            else return 0;
        }
        public void Dem_nguoc()
        {
            if (rangbuoc == 60)
            {
                //code countdown timer
                timer1 = new Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                label1.Text = rangbuoc.ToString();
                
            }
            
        }
        int dem = 4;
        public void count_3()
        {
            
            if (dem == 4)
            {
                //code countdown timer
                timer3 = new Timer();
                timer3.Tick += new EventHandler(timer3_Tick);
                timer3.Interval = 1000; // 1 second
                timer3.Start();
                
                
            }
        }
        int d = 0;
        Random rd = new Random();
        private void timer3_Tick(object sender, EventArgs e)
        {

            dem--;
            if (dem == 0)
            {
                timer3.Stop();
                while (d < 2)
                {
                    int r = rd.Next(1, 5);
                    if (r == 1)
                    {
                        if (btn_dapan.Text != btn_A.Text)
                        {
                            if (btn_A.Enabled == true)
                                d++;
                            btn_A.Enabled = false;

                        }
                    }
                    else if (r == 2)
                    {
                        if (btn_dapan.Text != btn_B.Text)
                        {
                            if (btn_B.Enabled == true)
                                d++;
                            btn_B.Enabled = false;

                        }
                    }
                    else if (r == 3)
                    {
                        if (btn_dapan.Text != btn_C.Text)
                        {
                            if (btn_C.Enabled == true)
                                d++;
                            btn_C.Enabled = false;

                        }
                    }
                    else if (r == 4)
                    {
                        if (btn_dapan.Text != btn_D.Text)
                        {
                            if (btn_D.Enabled == true)
                                d++;
                            btn_D.Enabled = false;

                        }
                    }

                    if (btn_B.Enabled == false && btn_D.Enabled == false)
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\b va d la hai phuong an sai.wav");
                        SP.Play();
                    }
                    else if (btn_C.Enabled == false && btn_D.Enabled == false)
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\c va d la hai phuong an sai.wav");
                        SP.Play();
                    }
                    else if (btn_A.Enabled == false && btn_D.Enabled == false)
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\a va d la hai phuong an sai.wav");
                        SP.Play();
                    }
                    else if (btn_A.Enabled == false && btn_C.Enabled == false)
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\a va d la hai phuong an sai.wav");
                        SP.Play();
                    }

                }
            }


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            rangbuoc--;
            if (rangbuoc == 0)
            {
                
                MessageBox.Show("BẠN ĐÃ HẾT THỜI GIAN!");
                Form4 form4 = new Form4(btn_diem.Text);
                this.Close();
                form4.ShowDialog();
                timer1.Stop();
            }    
                
            label1.Text = rangbuoc.ToString();

        }
        //Hàm đếm số dòng trong file text.
        public int countLine(string pathFile)
        {
            int keywordCount = 0;
            string s = File.ReadAllText(pathFile);
            Regex r = new Regex("\n", RegexOptions.Multiline);
            MatchCollection mc = r.Matches(s);
            keywordCount = mc.Count + 1;
            return keywordCount;

        }

        //Hàm lấy câu hỏi ngẫu nhiên  trả về là 1 câu hỏi.
        public cauhoi lcauhoi(int x)
        {
            Random rd = new Random();
            int fileCount = 0;
            string path = " ";
            if (x <= 5)
            {
                path = Application.StartupPath + @"\QS\0-5";
                fileCount = Directory.GetFiles(path,"*.mpv",SearchOption.AllDirectories).Length;
                
            }
            if (5 < x && x <= 10)
            {
                path = Application.StartupPath + @"\QS\5-10";
                fileCount = Directory.GetFiles(path, "*.mpv", SearchOption.AllDirectories).Length;
            }
            if (x > 10)
            {
                path = Application.StartupPath + @"\QS\10-15";
                fileCount = Directory.GetFiles(path, "*.mpv", SearchOption.AllDirectories).Length;
            }
            int rand = rd.Next(1, fileCount);
            
            cauhoi n = new cauhoi();
            StreamReader caumot = new StreamReader(path + @"\q" + rand.ToString() + ".mpv");
            string a;
            
            n.cauHoi = caumot.ReadLine();
            n.A = caumot.ReadLine();
            n.B = caumot.ReadLine();
            n.C = caumot.ReadLine();
            n.D = caumot.ReadLine();
            n.dapan1 = caumot.ReadLine();

            return n;
        }
        //Hàm hiển thị câu hỏi ra form.Các đáp án ngẫu nhiên/
        public void displaycauhoi(int x)
        {
            btn_A.Enabled = true; btn_C.Enabled = true;
            btn_B.Enabled = true; btn_D.Enabled = true;
            if (btn1Enable == 1)
                button1.Enabled = true;
            if (btn2Enable == 1)
                button2.Enabled = true;
            if (btn3Enable == 1)
                button3.Enabled = true;
            button4.Enabled = true;
            btn_A.BackColor = Color.Black; btn_B.BackColor = Color.Black;
            btn_C.BackColor = Color.Black; btn_D.BackColor = Color.Black;
            timer2.Stop();
            
            Dem_nguoc();
            //Đến câu nào thì btn câu đó đổi màu
            if (x == 1)
                pictureBox2.Image = Properties.Resources.Picture1;
            if (x == 2)
                pictureBox2.Image = Properties.Resources.Picture2;
            if (x == 3)
                pictureBox2.Image = Properties.Resources.Picture3;
            if (x == 4)
                pictureBox2.Image = Properties.Resources.Picture4;
            if (x == 5)
                pictureBox2.Image = Properties.Resources.Picture5;
            if (x == 6)
                pictureBox2.Image = Properties.Resources.Picture6;
            if (x == 7)
                pictureBox2.Image = Properties.Resources.Picture7;
            if (x == 8)
                pictureBox2.Image = Properties.Resources.Picture8;
            if (x == 9)
                pictureBox2.Image = Properties.Resources.Picture9;
            if (x == 10)
                pictureBox2.Image = Properties.Resources.Picture10;
            if (x == 11)
                pictureBox2.Image = Properties.Resources.Picture11;
            if (x == 12)
                pictureBox2.Image = Properties.Resources.Picture12;
            if (x == 13)
                pictureBox2.Image = Properties.Resources.Picture13;
            if (x == 14)
                pictureBox2.Image = Properties.Resources.Picture14;
            if (x == 15)
                pictureBox2.Image = Properties.Resources.Picture15;
            // khi hiện câu hỏi thì reset đồng hồ
            
            if (x == 16)
            {

            }
            else
            {//khai báo cauhoi outCH để nhận giá trị đưa ra từ hàm lcauhoi(int x).
                cauhoi outCH = new cauhoi();

                //thiết lập lại
                textBox_cauhoi.Text = "";
                btn_A.Text = "";
                btn_B.Text = "";
                btn_C.Text = "";
                btn_D.Text = "";
                btn_dapan.Text = "";
                //Gán 
                outCH = lcauhoi(x);
                textBox_cauhoi.Text = "Câu " + x.ToString() + ":   " + outCH.cauHoi;

                btn_dapan.Text = outCH.dapan1;
                //Random đáp án
                Random laydapan = new Random();
                int rdda = laydapan.Next(1, 4);
                if (rdda == 1)
                {

                    btn_A.Text = outCH.A;
                    btn_B.Text = outCH.B;
                    btn_C.Text = outCH.C;
                    btn_D.Text = outCH.D;

                }
                if (rdda == 2)
                {

                    btn_A.Text = outCH.D;
                    btn_B.Text = outCH.C;
                    btn_C.Text = outCH.A;
                    btn_D.Text = outCH.B;

                }
                if (rdda == 3)
                {

                    btn_A.Text = outCH.C;
                    btn_B.Text = outCH.A;
                    btn_C.Text = outCH.D;
                    btn_D.Text = outCH.B;

                }
                if (rdda == 4)
                {

                    btn_A.Text = outCH.B;
                    btn_B.Text = outCH.D;
                    btn_C.Text = outCH.C;
                    btn_D.Text = outCH.A;

                }
            }
        }

        bool rs = false;
        public bool isRestart()
        {
            return rs;
        }
        //Hàm thông báo nếu trả lời sai.
        void thongbaosai()
        {
            string diem = btn_diem.Text;
            if (Convert.ToInt32(diem) < 1000)
            {
                diem = "0";
            }    
            else if (Convert.ToInt32(diem) < 32000)
            {
                diem = "1000";
            }
            else if (Convert.ToInt32(diem) < 1000000)
            {
                diem = "32000";
            }
            Form4 form4 = new Form4(diem);
            form4.ShowDialog();
            rs = form4.isRestart();
            this.Close();
            
        }
        
        //Hàm hiển thị khi trả lời đúng


        void thongbaodung()
        {
            btn_diem.Text = tinhdiem(demsocau).ToString();
            demsocau++;
            
            rangbuoc = 60;
            
            displaycauhoi(demsocau);
        }
        public string test;

        private void btn_A_Click_1(object sender, EventArgs e)
        {
            btn_A.BackColor = Color.Yellow;
            btn_A.Enabled = false; btn_B.Enabled = false;
            btn_C.Enabled = false; btn_D.Enabled = false;
            button1.Enabled = false; button2.Enabled = false;
            button3.Enabled = false; button4.Enabled = false;
            timer1.Stop();
            timer2.Stop();

            if (Convert.ToInt32(btn_diem.Text) >= 1000)
            {
                SoundPlayer AAA = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Phuong an tra loi cuoi cung cua chung toi la.wav");
                AAA.Play();
            }
            test = "Adung";

            AA = 0;
            timer2.Start();
            
        }
        private void btn_B_Click(object sender, EventArgs e)
        {
            btn_B.BackColor = Color.Yellow;
            btn_A.Enabled = false; btn_B.Enabled = false;
            btn_C.Enabled = false; btn_D.Enabled = false;
            button1.Enabled = false; button2.Enabled = false;
            button3.Enabled = false; button4.Enabled = false;
            timer1.Stop();
            timer2.Stop();

            if (Convert.ToInt32(btn_diem.Text) >= 1000)
            {
                SoundPlayer AAA = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Phuong an tra loi cuoi cung cua chung toi la.wav");
                AAA.Play();
            }
            test = "Bdung";

            AA = 0;
            timer2.Start();
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            btn_C.BackColor = Color.Yellow;
            btn_A.Enabled = false; btn_B.Enabled = false;
            btn_C.Enabled = false; btn_D.Enabled = false;
            button1.Enabled = false; button2.Enabled = false;
            button3.Enabled = false; button4.Enabled = false;
            timer1.Stop();
            timer2.Stop();

            if (Convert.ToInt32(btn_diem.Text) >= 1000)
            {
                SoundPlayer AAA = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Phuong an tra loi cuoi cung cua chung toi la.wav");
                AAA.Play();
            }
            test = "Cdung";

            AA = 0;
            timer2.Start();
        }

        private void btn_D_Click(object sender, EventArgs e)
        {
            btn_D.BackColor = Color.Yellow;
            btn_A.Enabled = false; btn_B.Enabled = false;
            btn_C.Enabled = false; btn_D.Enabled = false;
            button1.Enabled = false; button2.Enabled = false;
            button3.Enabled = false; button4.Enabled = false;
            timer1.Stop();
            timer2.Stop();

            if (Convert.ToInt32(btn_diem.Text) >= 1000)
            {
                SoundPlayer AAA = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Phuong an tra loi cuoi cung cua chung toi la.wav");
                AAA.Play();
            }
            test = "Ddung";

            AA = 0;
            timer2.Start();
        }


        //Tạo hiệu ứng nháy nháy
        int AA = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            AA++;
            if (AA == 1)
            {
                if (test == "Adung")
                {
                    SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Cau tra loi cuoi cung cua ban la A.wav");
                    SP.Play();
                }
                if (test == "Bdung")
                {
                    SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Cau tra loi cuoi cung cua ban la B.wav");
                    SP.Play();
                }
                if (test == "Cdung")
                {
                    SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Cau tra loi cuoi cung cua ban la C.wav");
                    SP.Play();
                }
                if (test == "Ddung")
                {
                    SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Cau tra loi cuoi cung cua ban la D.wav");
                    SP.Play();
                }
            }
            if (AA == 129)
            {
                if (btn_dapan.Text == btn_A.Text)
                {
                    if (test == "Adung")
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\A xin chuc mung.wav");
                        SP.Play();
                    }
                    else
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Cau tra loi dung cua chung toi la A.wav");
                        SP.Play();
                    }
                    
                }
                if (btn_dapan.Text == btn_B.Text)
                {
                    if (test == "Bdung")
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\B xin chuc mung.wav");
                        SP.Play();
                    }
                    else
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Cau tra loi dung cua chung toi la B.wav");
                        SP.Play();
                    }

                }
                if (btn_dapan.Text == btn_C.Text)
                {
                    if (test == "Cdung")
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\C la cau tra loi dung.wav");
                        SP.Play();
                    }
                    else
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Cau tra loi dung cua chung toi la C.wav");
                        SP.Play();
                    }

                }
                if (btn_dapan.Text == btn_D.Text)
                {
                    if (test == "Ddung")
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\D do la cau tra loi dung.wav");
                        SP.Play();
                    }
                    else
                    {
                        SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Cau tra loi dung cua chung toi la D.wav");
                        SP.Play();
                    }
                }

            }
            if (AA > 130)
            {
                if (btn_dapan.Text == btn_A.Text)
                {
                    if (AA % 2 == 0)
                    {
                        btn_A.BackColor = Color.Red;

                    }
                    else
                    {
                        btn_A.BackColor = Color.Blue;
                    }
                    

                }
                if (btn_dapan.Text == btn_B.Text)
                {
                    if (AA % 2 == 0)
                    {
                        btn_B.BackColor = Color.Red;
                    }
                    else
                    {
                        btn_B.BackColor = Color.Blue;
                    }


                }
                if (btn_dapan.Text == btn_C.Text)
                {
                    if (AA % 2 == 0)
                    {
                        btn_C.BackColor = Color.Red;
                    }
                    else
                    {
                        btn_C.BackColor = Color.Blue;
                    }
                }
                
                if (btn_dapan.Text == btn_D.Text)
                {
                    if (AA % 2 == 0)
                    {
                        btn_D.BackColor = Color.Red;
                    }
                    else
                    {
                        btn_D.BackColor = Color.Blue;
                    }
                }
            }
            if (AA == 180)
            {
                btn_A.BackColor = Color.Blue;
                btn_B.BackColor = Color.Blue;
                btn_C.BackColor = Color.Blue;
                btn_D.BackColor = Color.Blue;
                if (test == "Adung")
                {
                    if (btn_A.Text == btn_dapan.Text)
                    {
                        thongbaodung();
                    }
                    else
                        thongbaosai();
                }
                if (test == "Bdung")
                {
                    if (btn_B.Text == btn_dapan.Text)
                    {
                        thongbaodung();
                    }
                    else
                        thongbaosai();
                }
                if (test == "Cdung")
                {
                    if (btn_C.Text == btn_dapan.Text)
                    {
                        thongbaodung();
                    }
                    else
                        thongbaosai();
                }
                if (test == "Ddung")
                {
                    if (btn_D.Text == btn_dapan.Text)
                    {
                        thongbaodung();
                    }
                    else
                        thongbaosai();
                }
                /*
                tmdapan.Stop();
                */
                //testing
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(btn_diem.Text);
            SoundPlayer SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Dung choi.wav");
            SP.Play();
            rs = form4.isRestart();
            this.Close();
            form4.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\May tinh bo 2 phuong an sai.wav");
            SP.Play();
            //int d = 0;
            btn1Enable = 0;
            button1.Enabled = false;
            button1.Image = Properties.Resources.jpge50X;
            //Random rd = new Random();
            count_3();
            
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            btn3Enable = 0;
            button3.Enabled = false;
            button3.Image = Properties.Resources.jpgePeopleX;
            string da = "";
            if(btn_dapan.Text == btn_A.Text)
            {
                da = "A";
            }
            else if (btn_dapan.Text == btn_B.Text)
            {
                da = "B";
            }
            else if (btn_dapan.Text == btn_C.Text)
            {
                da = "C";
            }
            else if (btn_dapan.Text == btn_D.Text)
            {
                da = "D";
            }
            Form5 form5 = new Form5(da);
            form5.ShowDialog();
            
        }

        public void CallFacebook(string email, string password, string user_receive)
        {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                ChromeOptions options = new ChromeOptions();
                options.AddArgument(Application.StartupPath + "chromedriver.exe");
                options.AddArguments("--incognito");
                options.AddArgument(@"--start-maximized");
                options.AddArgument(@"--disable-infobars");
                //options.AddArgument("user-data-dir=/some/path/allow-camera");
                options.AddArgument("--disable-user-media-security=true");
                options.AddArgument("--use-fake-ui-for-media-stream=1");

                //var caps = new DesiredCapabilities();
                options.AddArgument("headless");
                options.AddArgument("window-size=1200x600"); // optional

                var driver = new ChromeDriver(driverService, options);
                driver.Navigate().GoToUrl("https://www.messenger.com/login");   
                /*System.Threading.Thread.Sleep(1000);
                //driver.Manage().Window.Minimize();
                IWebElement query = driver.FindElement(By.CssSelector("#email"));
                query.SendKeys(email);

                query = driver.FindElement(By.CssSelector("#pass"));
                query.SendKeys(password);

                query = driver.FindElement(By.CssSelector("#loginbutton"));
                query.Click();
                driver.Navigate().GoToUrl(user_receive);
                query = driver.FindElement(By.XPath(".//*[@data-testid='startVoiceCall']"));
                query.Click();
                System.Threading.Thread.Sleep(5000);
                driver.Quit();*/


        }
        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer SP = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Nguoi than.wav");
            SP.Play();
            


            var driverservice = Microsoft.Edge.SeleniumTools.EdgeDriverService.CreateChromiumService();
            driverservice.HideCommandPromptWindow = true;

            var options = new Microsoft.Edge.SeleniumTools.EdgeOptions();
            options.UseChromium = true;
            options.BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

            var driver = new Microsoft.Edge.SeleniumTools.EdgeDriver(driverservice, options);
            driver.Url = "https://www.messenger.com/login/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement query = driver.FindElement(By.CssSelector("#email"));
            query.SendKeys("ldh2210");
            query = driver.FindElement(By.CssSelector("#pass"));
            query.SendKeys("lehoang2210kt");
            query = driver.FindElement(By.CssSelector("#loginbutton"));
            query.Click();
            driver.Navigate().GoToUrl("https://www.messenger.com/t/100012544930422");

            query = driver.FindElement(By.XPath(".//*[@role = 'presentation']"));
            query.Click();

            //driver.Quit();


        }


    }
}
