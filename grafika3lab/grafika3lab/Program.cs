using grafika3lab.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Remoting.Channels;

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

    public static Bitmap OverlayImages(Bitmap baseImage, Bitmap overlayImage)
    {
        Bitmap result = new Bitmap(baseImage.Width, baseImage.Height);

        using (Graphics g = Graphics.FromImage(result))
        {
            g.DrawImage(baseImage, 0, 0);
            g.DrawImage(overlayImage, 0, 0);
        }
        return result;
    }

    static void Main(string[] args)
    {
        Bitmap image1 = Resources.image1;
        Bitmap image2 = Resources.image2;
        Bitmap processedImage1 = ConvertToBlackAndWhite(image1);
        Bitmap processedImage2 = ConvertToBlackAndWhite(image2);
        processedImage1.Save("output1.png", ImageFormat.Png);
        processedImage2.Save("output2.png", ImageFormat.Png);
        Bitmap finalImage = OverlayImages(processedImage1, processedImage2);
        finalImage.Save("final_output.png", ImageFormat.Png);
        Console.WriteLine("Изображения успешно обработаны и сохранены.");
    }
}
