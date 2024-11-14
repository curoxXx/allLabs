using grafika3lab.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace grafika3lab
{
    class ImageProcessing
    {
        public static Bitmap ConvertToBlackAndWhite(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    float saturation = GetSaturation(pixelColor);

                    if (saturation < 0.75f)
                    {
                        int grayValue = (int)(pixelColor.R * 0.299 + pixelColor.G * 0.587 + pixelColor.B * 0.114);
                        Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                        result.SetPixel(x, y, grayColor);
                    }
                    else
                    {
                        result.SetPixel(x, y, pixelColor);
                    }
                }
            }
            return result;
        }

        public static float GetSaturation(Color color)
        {
            float max = Math.Max(color.R, Math.Max(color.G, color.B));
            float min = Math.Min(color.R, Math.Min(color.G, color.B));

            if (max == 0) return 0;
            return 1f - (1f * min / max);
        }

        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }
            return resized;
        }

        public static Bitmap OverlayImages(Bitmap baseImage, Bitmap overlayImage)
        {
            Bitmap result = new Bitmap(baseImage.Width, baseImage.Height);

            overlayImage = ResizeImage(overlayImage, baseImage.Width, baseImage.Height);

            for (int x = 0; x < baseImage.Width; x++)
            {
                for (int y = 0; y < baseImage.Height; y++)
                {
                    Color basePixel = baseImage.GetPixel(x, y);
                    Color overlayPixel = overlayImage.GetPixel(x, y);

                    if (overlayPixel.R > 240 && overlayPixel.G > 240 && overlayPixel.B > 240)
                    {
                        result.SetPixel(x, y, basePixel);
                    }
                    else
                    {
                        result.SetPixel(x, y, overlayPixel);
                    }
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Bitmap image1 = Resources.image1;
            Bitmap image2 = Resources.image2;

            int targetWidth = Math.Min(image1.Width, image2.Width);
            int targetHeight = Math.Min(image1.Height, image2.Height);

            Bitmap resizedImage1 = ResizeImage(image1, targetWidth, targetHeight);
            Bitmap resizedImage2 = ResizeImage(image2, targetWidth, targetHeight);

            Bitmap processedImage1 = ConvertToBlackAndWhite(resizedImage1);
            Bitmap processedImage2 = ConvertToBlackAndWhite(resizedImage2);

            processedImage1.Save("output1.png", ImageFormat.Png);
            processedImage2.Save("output2.png", ImageFormat.Png);

            Bitmap finalImage = OverlayImages(processedImage1, processedImage2);
            finalImage.Save("final_output.png", ImageFormat.Png);

            Console.WriteLine("Изображения успешно обработаны, наложены и сохранены.");
        }
    }
}