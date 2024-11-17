using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2Grafik
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox;
        private Button drawButton;
        private TextBox radiusTextBox;


        public Form1()
        {
            InitializeComponent();
            pictureBox = new PictureBox
            {
                Size = new Size(400, 400),
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(10, 10)
            };

            drawButton = new Button
            {
                Text = "Нарисовать окружность",
                Location = new Point(10, 420)
            };
            drawButton.Click += button1_Click;
            drawButton.Width = 200;
            radiusTextBox = new TextBox
            {
                Location = new Point(220, 420),
                Width = 50
            };

            Controls.Add(pictureBox);
            Controls.Add(drawButton);
            Controls.Add(radiusTextBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int radius;
            if (int.TryParse(radiusTextBox.Text, out radius))
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                DrawCircle(bmp, pictureBox.Width / 2, pictureBox.Height / 2, radius);
                pictureBox.Image = bmp;
            }
            else
            {
                MessageBox.Show("Введите корректный радиус.");
            }
        }
        private void DrawCircle(Bitmap bmp, int X1, int Y1, int R)
        {
            int x = 0;
            int y = R;
            int delta = 1 - 2 * R;
            int error = 0;

            while (y >= x)
            {
                DrawPixel(bmp, X1 + x, Y1 + y);
                DrawPixel(bmp, X1 + x, Y1 - y);
                DrawPixel(bmp, X1 - x, Y1 + y);
                DrawPixel(bmp, X1 - x, Y1 - y);
                DrawPixel(bmp, X1 + y, Y1 + x);
                DrawPixel(bmp, X1 + y, Y1 - x);
                DrawPixel(bmp, X1 - y, Y1 + x);
                DrawPixel(bmp, X1 - y, Y1 - x);

                error = 2 * (delta + y) - 1;

                if ((delta < 0) && (error <= 0))
                {
                    delta += 2 * ++x + 1;
                    continue;
                }
                if ((delta > 0) && (error > 0))
                {
                    delta -= 2 * --y + 1;
                    continue;
                }
                delta += 2 * (++x - --y);
            }
        }
        private void DrawPixel(Bitmap bmp, int x, int y)
        {
            if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
            {
                bmp.SetPixel(x, y, Color.Black);
            }
        }
    }
}
