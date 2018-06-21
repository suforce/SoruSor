using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;
using System.IO;

namespace SoruSor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string isaret, sonuc, klasor;
        int sayi, kontrol = 0, birincisayi, ikincisayi, sayac;
        Random rnd = new Random();
        internal static string kullaniciAdi, sifre, sure, dosya, devre;
        private void button2_Click(object sender, EventArgs e)
        {
            soru();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Space)
            {
                button1.PerformClick();
                textBox1.Focus();
            }
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giris gir = new giris();
            gir.ShowDialog();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Space)
            {
                soru();
                textBox1.Focus();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AutoSize = false;
            Height = MaximumSize.Height;
        }

        private void Form1_Move(object sender, EventArgs e) => Location = new Point(Screen.GetBounds(new Point(0, 0)).Width / 2 - Width / 2, Screen.GetBounds(new Point(0, 0)).Height / 2 - Height / 2);

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == Convert.ToInt32(devre))
            {
                if (Form1.devre == "1")
                {
                    Show();
                    soru();
                    timer1.Stop();
                    textBox1.Clear();
                    sayac = 0;
                    degiskenler();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void degiskenler()
        {
            FileStream fileStream = new FileStream(dosya, FileMode.Open, FileAccess.Read);
            fileStream.Dispose();
            fileStream.Close();
            StreamReader oku = new StreamReader(dosya);
            kullaniciAdi = oku.ReadLine();
            sifre = oku.ReadLine();
            sure = oku.ReadLine();
            devre = oku.ReadLine();
            oku.Close();
        }

        private void Form1_Click(object sender, EventArgs e) => textBox1.Focus();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            panel1.Location = new Point(Width / 2 - panel1.Width/2, Height / 2 - panel1.Height/2);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("SoruSor", "\"" + Application.ExecutablePath + "\"");
            TopMost = true;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximumSize = Size;
            MinimumSize = Size;
            Height = MaximumSize.Height;
            soru();
            AutoSize = false;
            AutoSizeMode = AutoSizeMode.GrowOnly;
            klasor = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\ayarlar";
            dosya = klasor + "\ayar.txt";
            if (!Directory.Exists(klasor))  Directory.CreateDirectory(klasor);
            if (!File.Exists(dosya))
            {
                FileStream fs = new FileStream(dosya, FileMode.Create, FileAccess.Write);
                fs.Dispose();
                fs.Close();
            }
            degiskenler();
            kullaniciAdi = "asdasd";
            sifre = "asdasd";
            sure = "0";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kontrol == 0)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sonuc == textBox1.Text)
            {
                kontrol = 1;
                timer1.Start();
                Hide();
            }
            else
            {
                textBox1.Clear();
                textBox1.Focus();
            }
        }
        void soru()
        {
            sayi = rnd.Next(2);
            if (sayi == 0)
            {
                birincisayi = rnd.Next(10);
                ikincisayi = rnd.Next(10);
                isaret = "+";
            }
            else
            {
                isaret = "-";
                ikincisayi = rnd.Next(10);
                birincisayi = rnd.Next(ikincisayi, 10);
            }
            label2.Text = birincisayi.ToString();
            label3.Text = ikincisayi.ToString();
            label4.Text = isaret;
            if (sayi == 0)
            {
                sonuc = (Convert.ToInt32(label2.Text) + Convert.ToInt32(label3.Text)).ToString();
            }
            else
            {
                sonuc = (Convert.ToInt32(label2.Text) - Convert.ToInt32(label3.Text)).ToString();
            }
        }
    }
}