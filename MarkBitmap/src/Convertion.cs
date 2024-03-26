using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MarkBitmap
{
    public partial class MarkBitmap
    {
        /// <summary>
        /// Transforming between Bitmap and byte array.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <returns>Byte array whose filled with bitmap's color data.</returns>
        public static byte[] ToBuffer(Bitmap bitmap)
        {
            // Creating a BitmapData. (ReadOnly)
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // Getting depth of bitmap.
            int depth = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;

            // Creating a buffer width length of each pixels and its three component's length.
            byte[] buffer = new byte[bmpData.Width * bmpData.Height * depth];

            // Coping data from buffer into BitmapData with buffer length.
            Marshal.Copy(bmpData.Scan0, buffer, 0, buffer.Length);

            // Unlocking bitmaps.
            bitmap.UnlockBits(bmpData);

            // Returning buffer.
            return buffer;
        }

        /// <summary>
        /// Transforming byte array data into a bitmap. 
        /// </summary>
        /// <param name="buffer">Specified buffer whose consists RGB color data in byte array.</param>
        /// <param name="width">Specified width whose will be bitmap's width.</param>
        /// <param name="height">Specified height whose will be bitmap's height.</param>
        /// <returns>Bitmap</returns>
        public static Bitmap ToBMP(byte[] buffer, int width, int height)
        {
            // Creating a bitmap with given width, height and specified pixel format.
            Bitmap bitmap = new Bitmap(width: width, height: height, PixelFormat.Format24bppRgb);

            // Creating a BitmapData. (WriteOnly)
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width: width, height: height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

            // Copying data from BitmapData into buffer with buffer length.
            Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);

            // Unlocking bitmaps.
            bitmap.UnlockBits(bmpData);

            // Returning buffer.
            return bitmap;
        }
    }
}
