using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoruSor
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox1.Text != Form1.kullaniciAdi || textBox2.Text != Form1.sifre)
                {
                    MessageBox.Show("Kullanıcı Adı Yada Şifre Yanlış !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ayarlar ayar = new ayarlar();
                    ayar.ShowDialog();
                    Hide();
                }
            }
        }

        private void giris_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            TopMost = true;
            textBox2.PasswordChar = '*';
        }
    }
}
