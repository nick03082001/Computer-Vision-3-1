using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ບົດຝຶກຫັດອາທິດທີ1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSetPixel_Click(object sender, EventArgs e)
        {
            //ສ້າງ object Bitmap ຈາກ pictureBox
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int x = 10; x < 200; x++)
            {
                for(int y = 100; y < 150; y++)
                {
                    bmp.SetPixel(x, y, Color.Red);
                }
                
            }

            pictureBox1.Image = bmp;

        }

        private void PictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Color clr = bmp.GetPixel(e.X, e.Y);
            lblr.Text = "R: " + clr.R.ToString();
            lblg.Text = "G: " + clr.G.ToString();
            lblb.Text = "B: " + clr.B.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ສ້າງ object Bitmap ຈາກ PictureBox1
            Bitmap srcBitmap = new Bitmap(pictureBox3.Image);

            //ສ້າງ object Bitmap ເປົ່າທີ່ມີຂະໜາດ 100x50
            Bitmap dstBitmap = new Bitmap(153, 74);

            for (int x = 120; x < 273; x++)
            {
                for (int y = 250; y < 324; y++)
                {
                    dstBitmap.SetPixel(x - 120, y - 250, srcBitmap.GetPixel(x, y));
                }
            }
            //ສະແດງຄ່າ Bitmap ອອກມາທີ່ PictureBox2
            pictureBox4.Image = dstBitmap;


        }
        public Bitmap ConvertToGray(Bitmap source)
        {

            //ສ້າງ object ແລະກຳນົດຂະໜາດຂອງ Bitmap
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = source.GetPixel(x, y);
                    int avr = (int)((c.R + c.G + c.B) / 3);
                    bmp.SetPixel(x, y, Color.FromArgb(avr, avr, avr));
                }
            }
            //ສົ່ງຄ່າ Bitmap ກັບຄືນອອກໄປ
            return bmp;
        }

        private void ConvertGray_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = ConvertToGray(new Bitmap(pictureBox5.Image));
        }
    }

   


}


