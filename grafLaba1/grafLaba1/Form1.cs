using System;
using System.Drawing;
using System.Windows.Forms;

namespace grafLaba1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bm;
        int x1, y1, x2, y2;

        private void Form1_Load(object sender, EventArgs e)
        {
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void BresenhamFloat(int x1, int y1, int x2, int y2, Bitmap bm)
        {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = Math.Sign(x2 - x1);
            int sy = Math.Sign(y2 - y1);
            bool flag = false;

            if (dy > dx)
            {
                int temp = dx;
                dx = dy;
                dy = temp;
                flag = true;
            }

            double f = (double)dy / dx - 0.5;
            int x = x1, y = y1;

            for (int i = 0; i < dx; i++)
            {
                bm.SetPixel(x, y, Color.Red);
                if (f >= 0)
                {
                    if (flag)
                        x += sx;
                    else
                        y += sy;
                    f -= 1.0;
                }

                if (f < 0)
                {
                    if (flag)
                        y += sy;
                    else
                        x += sx;
                }

                f += (double)dy / dx;
            }
            pictureBox1.Image = bm;
        }

        private void BresenhamInt(int x1, int y1, int x2, int y2, Bitmap bm)
        {
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = Math.Sign(x2 - x1);
            int sy = Math.Sign(y2 - y1);
            bool flag = false;

            if (dy > dx)
            {
                int temp = dx;
                dx = dy;
                dy = temp;
                flag = true;
            }

            int f = 2 * dy - dx;
            int x = x1, y = y1;

            for (int i = 0; i < dx; i++)
            {
                bm.SetPixel(x, y, Color.Green);

                if (f >= 0)
                {
                    if (flag)
                        x += sx;
                    else
                        y += sy;
                    f -= 2 * dx;
                }

                if (f < 0)
                {
                    if (flag)
                        y += sy;
                    else
                        x += sx;
                }

                f += 2 * dy;
            }
            pictureBox1.Image = bm;
        }

        private void CDA(int x1, int y1, int x2, int y2, Bitmap bm)
        {
            int l;
            double dx, dy, x, y;
            int i = 1;

            if (x1 == x2 && y1 == y2)
            {
                bm.SetPixel(x1, y1, Color.Blue);
                return;
            }

            if (Math.Abs(y2 - y1) > Math.Abs(x2 - x1))
                l = Math.Abs(y2 - y1);
            else l = Math.Abs(x2 - x1);

            dx = (double)(x2 - x1) / l;
            dy = (double)(y2 - y1) / l;

            x = x1 + 0.5 * Math.Sign(dx);
            y = y1 + 0.5 * Math.Sign(dy);

            while (i <= l)
            {
                bm.SetPixel((int)Math.Floor(x), (int)Math.Floor(y), Color.Blue);
                x = x + dx;
                y = y + dy;
                i++;
            }
            pictureBox1.Image = bm;
        }

        private void Conv()
        {
            x1 = Convert.ToInt32(textBox1.Text);
            y1 = Convert.ToInt32(textBox2.Text);
            x2 = Convert.ToInt32(textBox3.Text);
            y2 = Convert.ToInt32(textBox4.Text);
        }

        private void ClearPictureBox()
        {
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearPictureBox();
            Conv();
            CDA(x1, y1, x2, y2, bm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearPictureBox();
            Conv();
            BresenhamFloat(x1, y1, x2, y2, bm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearPictureBox();
            Conv();
            BresenhamInt(x1, y1, x2, y2, bm);  
        }
    }
}

