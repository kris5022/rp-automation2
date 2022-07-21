using System.Drawing;
using System.Drawing.Imaging;

namespace RP.Automation.Core.Utilities
{
    public static class Screenshot
    {
        public static void SaveScreenshot()
        {
            var rect = new Rectangle(300, 540, 1050, 210);
            var bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save(@"C:\Users\Krystsina_Pulatava\Desktop\Screenshots\ActualScreenshot.jpg", ImageFormat.Jpeg);
        }

        public static bool Equality(Image Img1, Image Img2)
        {
            Bitmap Bmp1 = (Bitmap)Img1;
            Bitmap Bmp2 = (Bitmap)Img2;

            var pixelTrue = 0.0;
            var pixelFalse = 0.0;

            if (Bmp1.Size == Bmp2.Size)
            {
                for (int i = 0; i < Bmp1.Width; i++)
                    for (int j = 0; j < Bmp1.Height; j++)
                    {
                        var pixel1 = Bmp1.GetPixel(i, j);
                        var pixel2 = Bmp2.GetPixel(i, j);
                        if (pixel1 != pixel2) pixelFalse++;
                        else
                            pixelTrue++;
                    }
            }
            else return false;

            var percentResult = (pixelTrue / (pixelTrue + pixelFalse)) * 100;
            return percentResult >= 97;
        }
    }
}
