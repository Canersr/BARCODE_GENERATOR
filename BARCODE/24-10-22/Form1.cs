using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
namespace _24_10_22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("BARKODLANACAK VERIYI ALANA YAZINIZ!!!");
                textBox1.Focus();
            }
            else
            {
                Barcode barkod_olustur = new Barcode();
                barkod_olustur.IncludeLabel = true;
                Color yazi = Color.Black;
                Color arka = Color.White;

                pictureBox1.Image = barkod_olustur.Encode(TYPE.CODE128,textBox1.Text,
                    yazi,arka,(int)(pictureBox1.Width*0.9),(int)(pictureBox1.Height*0.9));
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var resim = pictureBox1.Image;
                resim.Save(Application.StartupPath + "\\" + DateTime.Now.ToShortDateString() + DateTime.Now.ToFileTime() + ".png");
                MessageBox.Show("QR Code başarıyla kaydedilmiştir.");
                pictureBox1.Image = null;
            }
            catch
            {
                MessageBox.Show("lutfen karekod oluştur");
            }

           
        }
    }
}
