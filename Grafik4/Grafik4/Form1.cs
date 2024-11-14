using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Grafik4
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap affineImage;
        private Bitmap nonlinearImage;
        private Bitmap inverseAffineImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBoxOriginal.Image = originalImage;
                }
            }
        }

        private void btnAffineTransform_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }
            float angle = 0;
            if (txtAngle.Text == "") { angle = 0; }
            else angle = float.Parse(txtAngle.Text) * (float)(Math.PI / 180); 
            int width = originalImage.Width;
            int height = originalImage.Height;

            affineImage = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int i1 = (int)(((i - width / 2) * Math.Cos(angle) - (j - height / 2) * Math.Sin(angle)) * 2 + width / 2);
                    int j1 = (int)(((i - width / 2) * Math.Sin(angle) + (j - height / 2) * Math.Cos(angle)) * 2 + height / 2);

                    if (i1 >= 0 && i1 < width && j1 >= 0 && j1 < height)
                    {
                        affineImage.SetPixel(i, j, originalImage.GetPixel(i1, j1));
                    }
                }
            }
            pictureBoxTransformed.Image = affineImage;
        }

        private void btnNonLinearTransform_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            int width = originalImage.Width;
            int height = originalImage.Height;
            nonlinearImage = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int i1 = (int)Math.Sqrt(Math.Exp(i));
                    int j1 = j;

                    if (i1 >= 0 && i1 < width && j1 >= 0 && j1 < height)
                    {
                        nonlinearImage.SetPixel(i, j, originalImage.GetPixel(i1, j1));
                    }
                }
            }
            pictureBoxNonLinearTransform.Image = nonlinearImage;
        }
    

        private void btnInverseTransform_Click(object sender, EventArgs e)
        {
            if (affineImage == null)
            {
                MessageBox.Show("Please perform a transformation first.");
                return;
            }

            float angle = 0;
            if (txtAngle.Text == "") { angle = 0; }
            else angle = float.Parse(txtAngle.Text) * (float)(Math.PI / 180);
            int width = affineImage.Width;
            int height = affineImage.Height;
            Bitmap inverseImage = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int i1 = (int)(((i - width / 2) * Math.Cos(-angle) - (j - height / 2) * Math.Sin(-angle)) / 2 + width / 2);
                    int j1 = (int)(((i - width / 2) * Math.Sin(-angle) + (j - height / 2) * Math.Cos(-angle)) / 2 + height / 2);

                    if (i1 >= 0 && i1 < width && j1 >= 0 && j1 < height)
                    {
                        inverseImage.SetPixel(i, j, affineImage.GetPixel(i1, j1));
                    }
                }
            }
            pictureBoxRestored.Image = inverseImage;
        }

        private void SaveImage(Bitmap image)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void btnSaveNonLinearImage_Click(object sender, EventArgs e)
        {
            if (nonlinearImage != null)
            {
                SaveImage(nonlinearImage);
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (affineImage != null)
            {
                SaveImage(affineImage);
            }
        }
    }
}

