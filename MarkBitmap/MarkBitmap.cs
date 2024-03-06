using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace MarkBitmap
{
    public partial class MarkBitmap
    {
        /// <summary>
        /// Transforming between Bitmap and byte array.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <returns>Byte array whose filled with bitmap's color data.</returns>
        private static byte[] ToBuffer(Bitmap bitmap)
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
        private static Bitmap ToBMP(byte[] buffer, int width, int height)
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

    /// <summary>
    /// Marking through byte[] to byte[].
    /// </summary>
    public partial class MarkBitmap
    {
        #region Marking buffer

        /// <summary>
        /// Do not use. Adds horizontally lines with given count.
        /// </summary>
        /// <param name="buffer">Byte array that holds bitmap image data.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Byte array after applied changes.</returns>
        public static byte[] MarkHorizontally(byte[] buffer, int count, int width, int height, Color color)
        {
            // Offset blocks to shift.
            int offset = width * height / count;

            // Loop for each marking lines.
            for (int j = 0; j < count; j++)
            {
                // Loop for width.
                for (int i = 0; i < width; i++)
                {
                    // Changes value of array with certain index. Instead of RGB, it is BGR which is alphabetically.
                    buffer[(3 * (offset * j + i))] = color.B;
                    buffer[(3 * (offset * j + i)) + 1] = color.G;
                    buffer[(3 * (offset * j + i)) + 2] = color.R;
                }
            }

            // Returning applied result.
            return buffer;
        }

        /// <summary>
        /// Do not use. Adds vertically lines with given count.
        /// </summary>
        /// <param name="buffer">Byte array that holds bitmap image data.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Byte array after applied changes.</returns>
        public static byte[] MarkVertically(byte[] buffer, int count, int width, int height, Color color)
        {
            // Offset blocks to shift.
            int offset = width / count;

            // Loop for each marking lines.
            for (int j = 0; j < count; j++)
            {
                // Loop for height.
                for (int i = 0; i < height; i++)
                {
                    // Changes value of array with certain index. Instead of RGB, it is BGR which is alphabetically.
                    buffer[(3 * (offset * j + width * i))] = color.B;
                    buffer[(3 * (offset * j + width * i)) + 1] = color.G;
                    buffer[(3 * (offset * j + width * i)) + 2] = color.R;
                }
            }

            // Returning applied result.
            return buffer;
        }

        /// <summary>
        /// Do not use. Adds diagonal lines with given count.
        /// </summary>
        /// <param name="buffer">Byte array that holds bitmap image data.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Byte array after applied changes.</returns>
        public static byte[] MarkDiagonally(byte[] buffer, int count, int width, int height, Color color)
        {
            // Offset blocks to shift.
            int offset = 0;

            // Experimental.
            for (int i = 0; i < width; i++)
            {
                //
                offset = (i * width + i) * 3;

                // Changes value of array with certain index. Instead of RGB, it is BGR which is alphabetically.
                buffer[offset] = color.B;
                buffer[offset + 1] = color.G;
                buffer[offset + 2] = color.R;
            }

            // Returning applied result.
            return buffer;
        }

        /// <summary>
        /// Do not use. Adds diagonal inverse lines with given count.
        /// </summary>
        /// <param name="buffer">Byte array that holds bitmap image data.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="width">Image width.</param>
        /// <param name="height">Image height.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Byte array after applied changes.</returns>
        public static byte[] MarkDiagonallyInverse(byte[] buffer, int count, int width, int height, Color color)
        {
            // Offset blocks to shift.
            int offset = 0;

            // Experimental.
            //
            for (int i = width; i > 0; i--)
            {
                //
                offset = (i * width - i) * 3;

                // Changes value of array with certain index. Instead of RGB, it is BGR which is alphabetically.
                buffer[offset] = color.B;
                buffer[offset + 1] = color.G;
                buffer[offset + 2] = color.R;
            }

            // Returning applied result.
            return buffer;
        }

        #endregion Marking buffer
    }

    /// <summary>
    /// Marking through byte[] to byte[].
    /// </summary>
#if NET6_0_OR_GREATER
    [SupportedOSPlatform("windows")]
#endif
    public partial class MarkBitmap
    {
        // Default null message if bitmap is not specified.
        private static readonly string s_messageBitmapNull = "Bitmap is null";

        /// <summary>
        /// Do not use. Adds horizontally lines with given count.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="count"></param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Bitmap with applied changes.</returns>
        /// <exception cref="ArgumentNullException">Throws exception when bitmap is null.</exception>
        public static Bitmap MarkHorizontally(Bitmap bitmap, int count, Color color)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(s_messageBitmapNull);
            }

            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking horizontally.
            byte[] processedBuffer = MarkHorizontally(buffer: buffer, count: count, width: bitmap.Width, height: bitmap.Height, color: color);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(buffer: processedBuffer, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }

        /// <summary>
        /// Do not use. [Unsafe] version of MarkHorizontally(). Adds horizontally lines with given count.  
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Bitmap with applied changes.</returns>
        public static Bitmap MarkHorizontallyUnsafe(Bitmap bitmap, int count, Color color)
        {
            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking horizontally.
            byte[] processedBuffer = MarkHorizontally(buffer: buffer, count: count, width: bitmap.Width, height: bitmap.Height, color: color);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(buffer: processedBuffer, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }

        /// <summary>
        /// Do not use. Adds vertically lines with given count.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Bitmap with applied changes.</returns>
        /// <exception cref="ArgumentNullException">Throws exception when bitmap is null.</exception>
        public static Bitmap MarkVertically(Bitmap bitmap, int count, Color color)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(s_messageBitmapNull);
            }

            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking vertically.
            byte[] processedBuffer = MarkVertically(buffer: buffer, count: count, width: bitmap.Width, height: bitmap.Height, color: color);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(buffer: processedBuffer, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }

        /// <summary>
        /// Do not use. [Unsafe] version of MarkVertically(). Adds vertically lines with given count.  
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Bitmap with applied changes.</returns>
        public static Bitmap MarkVerticallyUnsafe(Bitmap bitmap, int count, Color color)
        {
            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking vertically.
            byte[] processedBuffer = MarkVertically(buffer: buffer, count: count, width: bitmap.Width, height: bitmap.Height, color: color);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(buffer: processedBuffer, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }

        /// <summary>
        /// Do not use. Adds diagonally lines with given count.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Bitmap with applied changes.</returns>
        /// <exception cref="ArgumentNullException">Throws exception when bitmap is null.</exception>
        public static Bitmap MarkDiagonally(Bitmap bitmap, int count, Color color)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(s_messageBitmapNull);
            }

            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking diagonally.
            byte[] processedBuffer = MarkDiagonally(buffer: buffer, count: count, width: bitmap.Width, height: bitmap.Height, color: color);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(buffer: processedBuffer, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }

        /// <summary>
        /// Do not use. [Unsafe] version of MarkDiagonally(). Adds vertically lines with given count.  
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Bitmap with applied changes.</returns>
        public static Bitmap MarkDiagonallyUnsafe(Bitmap bitmap, int count, Color color)
        {
            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking diagonally.
            byte[] processedBuffer = MarkDiagonally(buffer: buffer, count: count, width: bitmap.Width, height: bitmap.Height, color: color);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(buffer: processedBuffer, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }

        /// <summary>
        /// Do not use. Adds diagonally inverse lines with given count.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Bitmap with applied changes.</returns>
        /// <exception cref="ArgumentNullException">Throws exception when bitmap is null.</exception>
        public static Bitmap MarkDiagonallyInverse(Bitmap bitmap, int count, Color color)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(s_messageBitmapNull);
            }

            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking diagonally inverse.
            byte[] processedBuffer = MarkDiagonallyInverse(buffer: buffer, count: count, width: bitmap.Width, height: bitmap.Height, color: color);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(buffer: processedBuffer, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }

        /// <summary>
        /// Do not use. [Unsafe] version of MarkDiagonallyInverse(). Adds diagonally inverse lines with given count.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="count">Number of divides.</param>
        /// <param name="color">Color will be used as marking line.</param>
        /// <returns>Bitmap with applied changes.</returns>
        public static Bitmap MarkDiagonallyInverseUnsafe(Bitmap bitmap, int count, Color color)
        {
            // TODO: Parse methods.
            return ToBMP(MarkDiagonallyInverse(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use. Adds eight armed cross lines with given count.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="divideCountHeight">Number of divides.</param>
        /// <param name="divideCountWidth">Number of divides.</param>
        /// <param name="divideCountDiagonal">Number of divides.</param>
        /// <param name="divideCountDiagonalInverse">Number of divides.</param>
        /// <param name="colorHeight">Color will be used as marking line vertically.</param>
        /// <param name="colorWidth">Color will be used as marking line horizontally.</param>
        /// <param name="colorDiagonal">Color will be used as marking line diagonally.</param>
        /// <param name="colorDiagonalInverse">Color will be used as marking diagonally inverse.</param>
        /// <returns>Bitmap with applied changes.</returns>
        /// <exception cref="ArgumentNullException">Throws exception when bitmap is null.</exception>
        public static Bitmap MarkEightArmedCross(Bitmap bitmap, int divideCountHeight, int divideCountWidth, int divideCountDiagonal, int divideCountDiagonalInverse, Color colorHeight, Color colorWidth, Color colorDiagonal, Color colorDiagonalInverse)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(s_messageBitmapNull);
            }

            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking horizontally.
            byte[] horizontallyMarked = MarkHorizontally(buffer, count: divideCountHeight, width: bitmap.Width, height: bitmap.Height, color: colorWidth);

            // Process array with marking vertically.
            byte[] verticallyMarked = MarkVertically(horizontallyMarked, count: divideCountWidth, width: bitmap.Width, height: bitmap.Height, color: colorHeight);

            // Process array with marking diagonally.
            byte[] diagonallyMarked = MarkDiagonally(verticallyMarked, count: divideCountDiagonal, width: bitmap.Width, height: bitmap.Height, color: colorDiagonal);

            // Process array with marking diagonally inverse.
            byte[] diagonallyInverseMarked = MarkDiagonallyInverse(diagonallyMarked, count: divideCountDiagonalInverse, width: bitmap.Width, height: bitmap.Height, color: colorDiagonalInverse);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(diagonallyInverseMarked, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }

        /// <summary>
        /// Do not use. [Unsafe] version of MarkEightArmesCross(). Adds eight armed cross lines with given count.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <param name="divideCountHeight">Number of divides.</param>
        /// <param name="divideCountWidth">Number of divides.</param>
        /// <param name="divideCountDiagonal">Number of divides.</param>
        /// <param name="divideCountDiagonalInverse">Number of divides.</param>
        /// <param name="colorHeight">Color will be used as marking line vertically.</param>
        /// <param name="colorWidth">Color will be used as marking line horizontally.</param>
        /// <param name="colorDiagonal">Color will be used as marking line diagonally.</param>
        /// <param name="colorDiagonalInverse">Color will be used as marking line diagonally inverse.</param>
        /// <returns>Bitmap with applied changes.</returns>
        public static Bitmap MarkEightArmedCrossUnsafe(Bitmap bitmap, int divideCountHeight, int divideCountWidth, int divideCountDiagonal, int divideCountDiagonalInverse, Color colorHeight, Color colorWidth, Color colorDiagonal, Color colorDiagonalInverse)
        {
            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Process array with marking horizontally.
            byte[] horizontallyMarked = MarkHorizontally(buffer, count: divideCountHeight, width: bitmap.Width, height: bitmap.Height, color: colorWidth);

            // Process array with marking vertically.
            byte[] verticallyMarked = MarkVertically(horizontallyMarked, count: divideCountWidth, width: bitmap.Width, height: bitmap.Height, color: colorHeight);

            // Process array with marking diagonally.
            byte[] diagonallyMarked = MarkDiagonally(verticallyMarked, count: divideCountDiagonal, width: bitmap.Width, height: bitmap.Height, color: colorDiagonal);

            // Process array with marking diagonally inverse.
            byte[] diagonallyInverseMarked = MarkDiagonallyInverse(diagonallyMarked, count: divideCountDiagonalInverse, width: bitmap.Width, height: bitmap.Height, color: colorDiagonalInverse);

            // Tranforsm to Bitmap image.
            Bitmap processedBitmap = ToBMP(diagonallyInverseMarked, width: bitmap.Width, height: bitmap.Height);

            // Returning applied result.
            return processedBitmap;
        }
    }

    /// <summary>
    /// Extra markings.
    /// </summary>
    public partial class MarkBitmap
    {
        public static Bitmap MarkWithCameraGrid(Bitmap bitmap)
        {
            //
            Color color = Color.Black;

            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(s_messageBitmapNull);
            }

            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            ////
            //int quarterOfWidth = bitmap.Width / 4;
            //int quarterOfHeight = bitmap.Height / 4;

            //
            int offsetFirst = bitmap.Width * bitmap.Height / 4;
            int offsetSecond = bitmap.Width * bitmap.Height * 3 / 4;

            //
            int offset = offsetSecond;

            //
            for (int i = 0; i < bitmap.Width / 2; i++)
            {
                offset = offsetFirst + i;

                //
                buffer[(3 * offset) + 0] = color.B;
                buffer[(3 * offset) + 1] = color.G;
                buffer[(3 * offset) + 2] = color.R;
            }

            // Tranform to Bitmap image.
            Bitmap processedBitmap = ToBMP(buffer: buffer, width: bitmap.Width, height: bitmap.Height);

            //
            return processedBitmap;
        }
    }
}