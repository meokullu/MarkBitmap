using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace MarkBitmap
{
    [SupportedOSPlatform("windows")]
    public partial class MarkBitmap
    {
        private static byte[] ToBuffer(Bitmap bmp)
        {
            // Creating a buffer
            byte[] buffer = new byte[bmp.Width * bmp.Height * 3];

            //
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);

            //
            Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);

            //
            bmp.UnlockBits(bmpData);

            //
            return buffer;
        }

        private static Bitmap ToBMP(byte[] buffer, int width, int height)
        {
            //
            Bitmap bitmap = new Bitmap(width: width, height: height, PixelFormat.Format24bppRgb);

            //
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width: width, height: height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

            //
            Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);

            //
            bitmap.UnlockBits(bmpData);

            //
            return bitmap;
        }
    }

    public partial class MarkBitmap
    {
        #region Marking buffer

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte[] MarkHorizontally(byte[] buffer, int count, int height, int width, Color color)
        {
            //
            int dividor = height / count;

            //
            int offset;

            //
            for (int i = 1; i < dividor; i++)
            {
                //
                for (int j = 0; j < width; j++)
                {
                    //
                    offset = (((i * dividor * width) + j - 1) * 3);

                    //
                    buffer[offset] = color.B;
                    buffer[offset + 1] = color.G;
                    buffer[offset + 2] = color.R;
                }
            }

            //
            return buffer;
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte[] MarkVertically(byte[] buffer, int count, int height, int width, Color color)
        {
            //
            return buffer;
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte[] MarkDiagonally(byte[] buffer, int count, int height, int width, Color color)
        {
            //
            return buffer;
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static byte[] MarkDiagonallyInverse(byte[] buffer, int count, int height, int width, Color color)
        {
            //
            return buffer;
        }

        #endregion Marking buffer
    }

    [SupportedOSPlatform("windows")]
    public partial class MarkBitmap
    {
        //
        private readonly static string messageBitmapNull = "Bitmap is null";

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="count"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Bitmap MarkHorizontally(Bitmap bitmap, int count, Color color)
        {
            // Null control
            if (bitmap == null)
            {
                //
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            return ToBMP(MarkHorizontally(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="count"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap MarkHorizontallyUnsafe(Bitmap bitmap, int count, Color color)
        {
            //
            return ToBMP(MarkHorizontally(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="count"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Bitmap MarkVertically(Bitmap bitmap, int count, Color color)
        {
            // Null control
            if (bitmap == null)
            {
                //
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            return ToBMP(MarkVertically(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="count"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap MarkVerticallyUnsafe(Bitmap bitmap, int count, Color color)
        {
            //
            return ToBMP(MarkVertically(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="count"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Bitmap MarkDiagonally(Bitmap bitmap, int count, Color color)
        {
            //
            if (bitmap == null)
            {
                //
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            return ToBMP(MarkDiagonally(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="count"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap MarkDiagonallyUnsafe(Bitmap bitmap, int count, Color color)
        {
            //
            return ToBMP(MarkDiagonally(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="count"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Bitmap MarkDiagonallyInverse(Bitmap bitmap, int count, Color color)
        {
            //
            if (bitmap == null)
            {
                //
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            return ToBMP(MarkDiagonallyInverse(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="count"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap MarkDiagonallyInverseUnsafe(Bitmap bitmap, int count, Color color)
        {
            //
            return ToBMP(MarkDiagonallyInverse(ToBuffer(bitmap), count: count, width: bitmap.Width, height: bitmap.Height, color: color), bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="divideCountHeight"></param>
        /// <param name="divideCountWidth"></param>
        /// <param name="divideCountDiagonal"></param>
        /// <param name="divideCountDiagonalInverse"></param>
        /// <param name="colorHeight"></param>
        /// <param name="colorWidth"></param>
        /// <param name="colorDiagonal"></param>
        /// <param name="colorDiagonalInverse"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Bitmap MarkEightArmedCross(Bitmap bitmap, int divideCountHeight, int divideCountWidth, int divideCountDiagonal, int divideCountDiagonalInverse, Color colorHeight, Color colorWidth, Color colorDiagonal, Color colorDiagonalInverse)
        {
            // Null Check
            if (bitmap == null)
            {
                //
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            var buffer = ToBuffer(bitmap);

            //
            var horizontallyMarked = MarkHorizontally(buffer, count: divideCountHeight, width: bitmap.Width, height: bitmap.Height, color: colorWidth);

            //
            var verticallyMarked = MarkVertically(horizontallyMarked, count: divideCountWidth, width: bitmap.Width, height: bitmap.Height, color: colorHeight);

            //
            var diagonallyMarked = MarkDiagonally(verticallyMarked, count: divideCountDiagonal, width: bitmap.Width, height: bitmap.Height, color: colorDiagonal);

            //
            var diagonallyInverseMarked = MarkDiagonallyInverse(diagonallyMarked, count: divideCountDiagonalInverse, width: bitmap.Width, height: bitmap.Height, color: colorDiagonalInverse);

            //
            var bmp = ToBMP(diagonallyInverseMarked, width: bitmap.Width, height: bitmap.Height);

            //
            return bmp;
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="divideCountHeight"></param>
        /// <param name="divideCountWidth"></param>
        /// <param name="divideCountDiagonal"></param>
        /// <param name="divideCountDiagonalInverse"></param>
        /// <param name="colorHeight"></param>
        /// <param name="colorWidth"></param>
        /// <param name="colorDiagonal"></param>
        /// <param name="colorDiagonalInverse"></param>
        /// <returns></returns>
        public static Bitmap MarkEightArmedCrossUnsafe(Bitmap bitmap, int divideCountHeight, int divideCountWidth, int divideCountDiagonal, int divideCountDiagonalInverse, Color colorHeight, Color colorWidth, Color colorDiagonal, Color colorDiagonalInverse)
        {
            //
            var buffer = ToBuffer(bitmap);

            //
            var horizontallyMarked = MarkHorizontally(buffer, count: divideCountHeight, width: bitmap.Width, height: bitmap.Height, color: colorWidth);

            //
            var verticallyMarked = MarkVertically(horizontallyMarked, count: divideCountWidth, width: bitmap.Width, height: bitmap.Height, color: colorHeight);

            //
            var diagonallyMarked = MarkDiagonally(verticallyMarked, count: divideCountDiagonal, width: bitmap.Width, height: bitmap.Height, color: colorDiagonal);

            //
            var diagonallyInverseMarked = MarkDiagonallyInverse(diagonallyMarked, count: divideCountDiagonalInverse, width: bitmap.Width, height: bitmap.Height, color: colorDiagonalInverse);

            //
            Bitmap bmp = ToBMP(diagonallyInverseMarked, width: bitmap.Width, height: bitmap.Height);

            //
            return bmp;
        }
    }

    public partial class MarkBitmap
    {
        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="customScaling"></param>
        /// <param name="width"></param>
        public static void MarkBuffer(byte[] buffer, int customScaling, int width)
        {
            //
            for (int i = 0; i < width * customScaling; i++)
            {
                //buffer[i * 3 + 0] = 0;
                //buffer[i * 3 + 1] = 0;
                //buffer[i * 3 + 2] = 255;

                //buffer[i * 3 + 3] = 0;
                //buffer[i * 3 + 4] = 0;
                //buffer[i * 3 + 5] = 255;

                //buffer[(customScaling * GenWidth * i * 3) + 0] = 255;
                //buffer[(customScaling * GenWidth * i * 3) + 1] = 0;
                //buffer[(customScaling * GenWidth * i * 3) + 2] = 0;

                //buffer[(customScaling * GenWidth * i * 3) + 3] = 255;
                //buffer[(customScaling * GenWidth * i * 3) + 4] = 0;
                //buffer[(customScaling * GenWidth * i * 3) + 5] = 0;

                //buffer[(customScaling * width * i * 3) + i * 3 - 3] = 0;
                //buffer[(customScaling * width * i * 3) + i * 3 - 2] = 0;
                //buffer[(customScaling * width * i * 3) + i * 3 - 1] = 255;

                //buffer[(customScaling * width * i * 3) + i * 3 + 0] = ((byte)((byte)i % 2 == 0 ? 0 : 255));
                //buffer[(customScaling * width * i * 3) + i * 3 + 1] = ((byte)((byte)i % 2 == 0 ? 255 : 0));
                //buffer[(customScaling * width * i * 3) + i * 3 + 2] = ((byte)((byte)i % 2 == 0 ? 0 : 255));

                //buffer[(customScaling * width * i * 3) + i * 3 + 3] = 255;
                //buffer[(customScaling * width * i * 3) + i * 3 + 4] = 0;
                //buffer[(customScaling * width * i * 3) + i * 3 + 5] = 0;

                buffer[customScaling * width * i + customScaling * i * 3 + 0] = 255;
                buffer[customScaling * width * i + customScaling * i * 3 + 1] = 255;
                buffer[customScaling * width * i + customScaling * i * 3 + 2] = 255;

                //buffer[(customScaling * GenWidth * i * 3) + i * 3 + 0] = 0;
                //buffer[(customScaling * GenWidth * i * 3) + i * 3 + 1] = 255;
                //buffer[(customScaling * GenWidth * i * 3) + i * 3 + 2] = 0;

                //buffer[(customScaling * GenWidth * i * 3) + i * 3 + 3] = 0;
                //buffer[(customScaling * GenWidth * i * 3) + i * 3 + 4] = 255;
                //buffer[(customScaling * GenWidth * i * 3) + i * 3 + 5] = 0;
            }
        }

        /// <summary>
        /// Do not use.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Bitmap MarkBitmapInternal(Bitmap bitmap)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                //
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            for (int i = 1; i < 4; i++)
            {
                //
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(bitmap.Width / 4 * i, j, Color.White);
                }
            }

            //
            for (int i = 0; i < 4; i++)
            {
                //
                for (int j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(j, bitmap.Height / 4 * i, Color.White);
                }
            }

            //
            for (int i = 0; i < bitmap.Width - 1; i++)
            {
                //
                bitmap.SetPixel(i, i, Color.White);
                bitmap.SetPixel(i, i + 1, Color.White);
                bitmap.SetPixel(i + 1, i, Color.White);
            }

            //
            for (int i = 1; i < bitmap.Height - 1; i++)
            {
                //
                bitmap.SetPixel(bitmap.Width - i, i, Color.White);
                bitmap.SetPixel(bitmap.Width - i - 1, i, Color.White);
                bitmap.SetPixel(bitmap.Width - i, i + 1, Color.White);
            }

            //
            int quarterWidth = bitmap.Width / 8;
            int quarterHeight = bitmap.Height / 8;

            //
            for (int i = 3 * quarterWidth; i < quarterWidth * 5; i++)
            {
                //
                bitmap.SetPixel(i, 3 * quarterHeight, Color.White);
                bitmap.SetPixel(i, 5 * quarterHeight, Color.White);
            }

            //
            for (int i = 3 * quarterHeight; i < quarterHeight * 5; i++)
            {
                //
                bitmap.SetPixel(3 * quarterHeight, i, Color.White);
                bitmap.SetPixel(5 * quarterHeight, i, Color.White);
            }

            //
            return bitmap;
        }
    }
}