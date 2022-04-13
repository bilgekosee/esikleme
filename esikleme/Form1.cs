using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esikleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "resimler|*.bmp|All files|*.*";
            if(sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            pictureBox1.ImageLocation = sfd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);

            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int EsiklemeDegeri = Convert.ToInt32(textBox1.Text);

            for(int x=0;x<ResimGenisligi;x++)
            {
                for(int y=0; y<ResimYuksekligi;y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);

                    if (OkunanRenk.R >= EsiklemeDegeri)
                        R = 255;
                    else R = 0;
                    if (OkunanRenk.G >= EsiklemeDegeri)
                        G = 255;
                    else G = 0;
                    if (OkunanRenk.B >= EsiklemeDegeri)
                        B = 255;
                    else B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);

                }
            }
            pictureBox2.Image = CikisResmi;
        }
    }
}
