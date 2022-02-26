using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ນ_ໃຈປະສົງ_ວົງພັນສີ_3CS2__ອາທິດທີ_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            Bitmap pict_C;
            Bitmap pict_O;
           // Bitmap pict_O = (Bitmap)Image.FromFile("D:\\comvision\\Image_comvision\\dog.jpg");

            public Bitmap ConvertToGrayScale(Bitmap source)
            {
                Bitmap bmp = new Bitmap(source.Width, source.Height);
                for (int i = 0; i < source.Width; i++)
                {
                    for (int j = 0; j < source.Height; j++)
                    {
                        Color c = source.GetPixel(i, j);
                        int avg = (int)((c.R + c.G + c.B) / 3);
                        bmp.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                    }
                }
                return bmp;
            }

            public Bitmap ConvertToGrayScale2(Bitmap source)
            {
                Bitmap bmp = new Bitmap(source.Width, source.Height);
                for (int i = 0; i < source.Width; i++)
                {
                    for (int j = 0; j < source.Height; j++)
                    {
                        Color c = source.GetPixel(i, j);
                        //Luminance
                        int nP = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                        bmp.SetPixel(i, j, Color.FromArgb(nP, nP, nP));
                    }
                }
                return bmp;
            }
            //setting threshold
            public Bitmap Thresholding1(Bitmap source)
            {
                Bitmap bmp = new Bitmap(source.Width, source.Height);
                int t = int.Parse(textBox1.Text);

                for (int i = 0; i < source.Width; i++)
                {
                    for (int j = 0; j < source.Height; j++)
                    {
                        Color c = source.GetPixel(i, j);
                        int avg = (int)((c.R + c.G + c.B) / 3);
                        if (avg > t)
                            avg = 255;
                        else avg = 0;

                        bmp.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                    }
                }
                return bmp;
            }
            //setting invert
            public Bitmap Invert(Bitmap source)
            {
                Bitmap bmp = new Bitmap(source.Width, source.Height);
                int t = int.Parse(textBox1.Text);

                for (int i = 0; i < source.Width; i++)
                {
                    for (int j = 0; j < source.Height; j++)
                    {
                        Color c = source.GetPixel(i, j);
                        int avg = (int)((c.R + c.G + c.B) / 3);
                        if (avg == 255)
                            avg = 0;
                        else if (avg == 0)
                            avg = 255;

                        bmp.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                    }
                }
                return bmp;
            }
        //setting negative
        public Bitmap Negative(Bitmap source)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            int t = int.Parse(textBox1.Text);

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    int r1, g1, b1;
                    r1 = 255 - (int)(c.R);
                    g1 = 255 - (int)(c.G);
                    b1 = 255 - (int)(c.B);
                    bmp.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                }
            }
            return bmp;
        }
        //original
        private void btnOriginal_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pict_O;
        }
        //grayscale1
        private void btnGrayScale1_Click(object sender, EventArgs e)
        {
            pict_C = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = ConvertToGrayScale(pict_C);
        }
        //grayscale2
        private void btnGrayScale2_Click(object sender, EventArgs e)
        {
            pict_C = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = ConvertToGrayScale2(pict_C);
        }
        //black and white1
        private void btnBlack_White_1_Click(object sender, EventArgs e)
        {
            pict_C = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = Thresholding1(pict_C);
        }
        //negative
        private void btnNagative_Click(object sender, EventArgs e)
        {
            pict_C = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = Negative(pict_C);
        }
        //invert
        private void btnInvert_Click(object sender, EventArgs e)
        {
            pict_C = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = Invert(pict_C);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = pict_O;
            pictureBox1.Refresh();

        }

        private void btn_OpenPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Open image from path";
            opf.Filter = "Png Images (*.png)|*.png|Jpeg Images (*.jpg)|*.jpg|Bitmap Images (*bmp)|*.bmp";
            if (opf.ShowDialog()==DialogResult.OK)
            {
                pict_O = new Bitmap(opf.FileName);
                pict_C = pict_O;
                pictureBox1.Image = pict_C;
            }

        }
        public Bitmap logTransformation(Bitmap source)
        {
            Bitmap log = new Bitmap(source.Width, source.Height);
            int C = int.Parse(textBox2.Text);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color n = source.GetPixel(x, y);
                    int sR = (int)(C * Math.Log10(1 + n.R));
                    int sG = (int)(C * Math.Log10(1 + n.G));
                    int sB = (int)(C * Math.Log10(1 + n.B));
                    log.SetPixel(x, y, Color.FromArgb(n.A, sR, sG, sB));
                }
            }
            return log;
        }
            public Bitmap powerLaw (Bitmap source, double R)
            {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            int c = int.Parse(textBox3.Text.ToString().Trim());

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color renk = source.GetPixel(x, y);
                    double gd = ((double)R / 20);
                    int sR = (int)(c * Math.Pow((renk.R / 255.0), gd));
                    int sG = (int)(c * Math.Pow((renk.G / 255.0), gd));
                    int sB = (int)(c * Math.Pow((renk.B / 255.0), gd));
                    bmp.SetPixel(x, y, Color.FromArgb(renk.A, sR, sG, sB));
                }
            }
            return bmp;
        }

        private void btn_Log_Transformation_Click(object sender, EventArgs e)
        {
            pict_C = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = logTransformation(pict_C);
        }

        private void lblC_PowerLaw_Click(object sender, EventArgs e)
        {
            pict_C = new Bitmap(pictureBox1.Image);
            //textBox4.Text = (int.Parse(textBox3.Text.ToString()) / 20.0).ToString("F2");
            pictureBox1.Image = powerLaw(pict_C, double.Parse(textBox4.Text.ToString()));
        }
    }



 
}
