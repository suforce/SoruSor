using System;
using System.IO;
using System.Windows.Forms;

namespace SoruSor
{
    public partial class ayarlar : Form
    {
        public ayarlar()
        {
            InitializeComponent();
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            TopMost = true;
            textBox3.PasswordChar = '*';
            textBox4.PasswordChar = '*';
            textBox5.PasswordChar = '*';
            textBox6.PasswordChar = '*';
            textBox8.PasswordChar = '*';
        }

        string durum, yaz;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Boş Alan Bırakmayın !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox3.Text != Form1.sifre)
                {
                    MessageBox.Show("Eski Şifrenizi Yanlış Yazdınız !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    veriguncelle(textBox2.Text, Form1.sifre, Form1.sure, Form1.devre);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Boş Alan Bırakmayın !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox5.Text != textBox4.Text)
                {
                    MessageBox.Show("Yeni Şifreler Aynı Olmak Zorundadır !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox6.Text != Form1.sifre)
                    {
                        MessageBox.Show("Şu Anki Şifreniz Doğru Değil !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        veriguncelle(Form1.kullaniciAdi, textBox5.Text, Form1.sure, Form1.devre);
                    }
                }
            }
        }
        private void veriguncelle(string kullaniciAdi, string sifre, string sure, string devre)
        {
            StreamWriter yaz = new StreamWriter(Form1.dosya);
            yaz.WriteLine(kullaniciAdi);
            yaz.WriteLine(sifre);
            yaz.WriteLine(sure);
            yaz.WriteLine(Form1.devre);
            yaz.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Boş Alan Bırakmayın !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox8.Text != Form1.sifre)
                {
                    MessageBox.Show("Şifreniz Yanlış !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    veriguncelle(Form1.kullaniciAdi, Form1.sifre, textBox7.Text, Form1.devre);
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Form1.devre == "0")
            {
                durum = "1";
                yaz = "Uygulamayı Devreye Sokarsanız Belirlediğiniz Sürede Bir Uygulama Açılacak ve 1 Tane Güvenlik Sorusu Soracaktır.\nSorulan Güvenlik Sorusunu Doğru Cevaplamadan Uygulama Kapanmayacak ve Bilgisayarınızı Aktif Olarak Kullanamayacaksınız.\n\nUygulamayı Aktifleştirmek İstediğinizden Emin Misiniz ?";
            }
            else
            {
                durum = "0";
                yaz = "Uygulamayı Devre Dışı Bırakırsanız Bir Daha ki Etkinleştirmeye Kadar Güvenlik Soruları Çıkmayacaktır.\n\nUygulamayı Devre Dışı Bırakmak İstediğinizden Emin Misiniz ?";
            }
            DialogResult onay = MessageBox.Show(yaz, "Devre Dışı Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                veriguncelle(Form1.kullaniciAdi, Form1.sifre, Form1.sure, durum);
            }
        }
    }
}