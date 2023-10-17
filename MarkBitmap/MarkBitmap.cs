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
        /// <summary>
        /// Transforming bitmap data into byte array.
        /// </summary>
        /// <param name="bitmap">Specified bitmap.</param>
        /// <returns>Byte array whose filled with bitmap's color data.</returns>
        private static byte[] ToBuffer(Bitmap bitmap)
        {
            // Creating a buffer width length of each pixels and its three component's length.
            byte[] buffer = new byte[bitmap.Width * bitmap.Height * 3];

            // Creating a BitmapData. (ReadOnly)
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

            // Coping data from buffer into BitmapData with buffer length.
            Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);

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
        // Default null message if bitmap is not specified.
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
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            // TODO: Parse methods.
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
            // TODO: Parse methods.
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
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            // TODO: Parse methods.
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
            // TODO: Parse methods.
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
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            // TODO: Parse methods.
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
            // TODO: Parse methods.
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
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            // TODO: Parse methods.
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
            // TODO: Parse methods.
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
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            byte[] buffer = ToBuffer(bitmap);

            //
            byte[] horizontallyMarked = MarkHorizontally(buffer, count: divideCountHeight, width: bitmap.Width, height: bitmap.Height, color: colorWidth);

            //
            byte[] verticallyMarked = MarkVertically(horizontallyMarked, count: divideCountWidth, width: bitmap.Width, height: bitmap.Height, color: colorHeight);

            //
            byte[] diagonallyMarked = MarkDiagonally(verticallyMarked, count: divideCountDiagonal, width: bitmap.Width, height: bitmap.Height, color: colorDiagonal);

            //
            byte[] diagonallyInverseMarked = MarkDiagonallyInverse(diagonallyMarked, count: divideCountDiagonalInverse, width: bitmap.Width, height: bitmap.Height, color: colorDiagonalInverse);

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
            byte[] buffer = ToBuffer(bitmap);

            //
            byte[] horizontallyMarked = MarkHorizontally(buffer, count: divideCountHeight, width: bitmap.Width, height: bitmap.Height, color: colorWidth);

            //
            byte[] verticallyMarked = MarkVertically(horizontallyMarked, count: divideCountWidth, width: bitmap.Width, height: bitmap.Height, color: colorHeight);

            //
            byte[] diagonallyMarked = MarkDiagonally(verticallyMarked, count: divideCountDiagonal, width: bitmap.Width, height: bitmap.Height, color: colorDiagonal);

            //
            byte[] diagonallyInverseMarked = MarkDiagonallyInverse(diagonallyMarked, count: divideCountDiagonalInverse, width: bitmap.Width, height: bitmap.Height, color: colorDiagonalInverse);

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
        /// <exception cref="ArgumentNullException">Throws if bitmap is null.</exception>
        public static Bitmap MarkBitmapInternal(Bitmap bitmap)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            for (int i = 1; i < 4; i++)
            {
                //
                for (int j = 0; j < bitmap.Height; j++)
                {
                    //
                    bitmap.SetPixel(bitmap.Width / 4 * i, j, Color.White);
                }
            }

            //
            for (int i = 0; i < 4; i++)
            {
                //
                for (int j = 0; j < bitmap.Width; j++)
                {
                    //
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

        //
        private static Color InvertColor(Color color)
        {
            //
            Color newColor = Color.FromArgb(red: 255 - color.R, green: 255 - color.G, blue: 255 - color.B);

            //
            return newColor;
        }

        private static Color OppositeGray(Color color)
        {
            //
            byte oppositeGray = (byte)(255 - ((color.R + color.G + color.B) / 3));

            //
            Color newColor = Color.FromArgb(red: oppositeGray, green: oppositeGray, blue: oppositeGray);

            //
            return newColor;
        }

        public static Bitmap MarkAsCameraV2(Bitmap bitmap)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            for (int i = 1; i < bitmap.Height - 1; i++)
            {
                //
               // bitmap.SetPixel(0, i, i % 2 == 0 ? Color.Black : Color.White);
               // bitmap.SetPixel(1, i, i % 2 == 0 ? Color.White : Color.Black);

                //
               // bitmap.SetPixel(bitmap.Width - 1, i, i % 2 == 0 ? Color.Black : Color.White);
               // bitmap.SetPixel(bitmap.Width - 2, i, i % 2 == 0 ? Color.White : Color.Black);
            }

            //
            for (int i = 1; i < bitmap.Width; i++)
            {
                //
              //  bitmap.SetPixel(i, 0, i % 2 == 0 ? Color.Black : Color.White);
              //  bitmap.SetPixel(i, 1, i % 2 == 0 ? Color.White : Color.Black);

                //
               // bitmap.SetPixel(i, bitmap.Height - 1, i % 2 == 0 ? Color.Black : Color.White);
               // bitmap.SetPixel(i, bitmap.Height - 2, i % 2 == 0 ? Color.White : Color.Black);
            }

            //
            for (int i = 0; i < bitmap.Width - 1; i++)
            {
                //
                bitmap.SetPixel(i, i, OppositeGray(bitmap.GetPixel(i, i)));
                bitmap.SetPixel(i, i + 1, OppositeGray(bitmap.GetPixel(i, i + 1)));
                bitmap.SetPixel(i + 1, i, OppositeGray(bitmap.GetPixel(i + 1, i)));
            }

            //
            for (int i = 1; i < bitmap.Height - 1; i++)
            {
                //
                bitmap.SetPixel(bitmap.Width - i, i, OppositeGray(bitmap.GetPixel(bitmap.Width - 1, i)));
                bitmap.SetPixel(bitmap.Width - i - 1, i, OppositeGray(bitmap.GetPixel(bitmap.Width - i - 1, i)));
                bitmap.SetPixel(bitmap.Width - i, i + 1, OppositeGray(bitmap.GetPixel(bitmap.Width - i, i + 1)));
            }

            //
            return bitmap;
        }

        public static Bitmap MarkAsCamera(Bitmap bitmap)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            for (int i = 0; i < bitmap.Height; i++)
            {
                //
                bitmap.SetPixel(0, i, OppositeGray(bitmap.GetPixel(0, i)));
                bitmap.SetPixel(bitmap.Width - 1, i, OppositeGray(bitmap.GetPixel(bitmap.Width - 1, i)));
            }

            //
            for (int i = 0; i < bitmap.Width; i++)
            {
                //
                bitmap.SetPixel(i, 0, OppositeGray(bitmap.GetPixel(i, 0)));
                bitmap.SetPixel(i, bitmap.Height - 1, OppositeGray(bitmap.GetPixel(i, bitmap.Height - 1)));
            }

            //
            int quarterWidth = bitmap.Width / 8;
            int quarterHeight = bitmap.Height / 8;

            //
            for (int i = 1 * quarterWidth; i < 7 * quarterWidth; i++)
            {
                //
                bitmap.SetPixel(i, 1 * quarterHeight, OppositeGray(bitmap.GetPixel(i, 1 * quarterHeight)));
                bitmap.SetPixel(i, 7 * quarterHeight, OppositeGray(bitmap.GetPixel(i, 7 * quarterHeight)));
            }

            //
            for (int i = 1 * quarterHeight; i < 7 * quarterHeight; i++)
            {
                //
                bitmap.SetPixel(1 * quarterHeight, i, OppositeGray(bitmap.GetPixel(1 * quarterHeight, i)));
                bitmap.SetPixel(7 * quarterHeight, i, OppositeGray(bitmap.GetPixel(7 * quarterHeight, i)));
            }

            //
            for (int i = 3 * quarterWidth; i < 5 * quarterWidth; i++)
            {
                //
                bitmap.SetPixel(i, 3 * quarterHeight, OppositeGray(bitmap.GetPixel(i, 3 * quarterHeight)));
                bitmap.SetPixel(i, 5 * quarterHeight, OppositeGray(bitmap.GetPixel(i, 5 * quarterHeight)));
            }

            //
            for (int i = 3 * quarterHeight; i < 5 * quarterHeight; i++)
            {
                //
                bitmap.SetPixel(3 * quarterHeight, i, OppositeGray(bitmap.GetPixel(3 * quarterHeight, i)));
                bitmap.SetPixel(5 * quarterHeight, i, OppositeGray(bitmap.GetPixel(5 * quarterHeight, i)));
            }

            //
            return bitmap;
        }

        public static Bitmap MarkMultiGrid(Bitmap bitmap)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException(messageBitmapNull);
            }

            //
            for (int i = 1; i < 4; i++)
            {
                //
                for (int j = 0; j < bitmap.Height; j++)
                {
                    //
                    bitmap.SetPixel(bitmap.Width / 4 * i, j, OppositeGray(bitmap.GetPixel((bitmap.Width / 4 * i), j)));
                }
            }

            //
            for (int i = 0; i < 4; i++)
            {
                //
                for (int j = 0; j < bitmap.Width; j++)
                {
                    //
                    bitmap.SetPixel(j, bitmap.Height / 4 * i, OppositeGray(bitmap.GetPixel(j, bitmap.Height / 4 * i)));
                }
            }

            //
            for (int i = 0; i < bitmap.Width - 1; i++)
            {
                //
                bitmap.SetPixel(i, i, OppositeGray(bitmap.GetPixel(i, i)));
                bitmap.SetPixel(i, i + 1, OppositeGray(bitmap.GetPixel(i, i + 1)));
                bitmap.SetPixel(i + 1, i, OppositeGray(bitmap.GetPixel(i + 1, i)));
            }

            //
            for (int i = 1; i < bitmap.Height - 1; i++)
            {
                //
                bitmap.SetPixel(bitmap.Width - i, i, OppositeGray(bitmap.GetPixel(bitmap.Width - i, i)));
                bitmap.SetPixel(bitmap.Width - i - 1, i, OppositeGray(bitmap.GetPixel((bitmap.Width - i - 1), i)));
                bitmap.SetPixel(bitmap.Width - i, i + 1, OppositeGray(bitmap.GetPixel((bitmap.Width - i), i + 1)));
            }

            //
            int quarterWidth = bitmap.Width / 8;
            int quarterHeight = bitmap.Height / 8;

            //
            for (int i = 3 * quarterWidth; i < quarterWidth * 5; i++)
            {
                //
                bitmap.SetPixel(i, 3 * quarterHeight, OppositeGray(bitmap.GetPixel(i, 3 * quarterHeight)));
                bitmap.SetPixel(i, 5 * quarterHeight, OppositeGray(bitmap.GetPixel(i, 5 * quarterHeight)));
            }

            //
            for (int i = 3 * quarterHeight; i < quarterHeight * 5; i++)
            {
                //
                bitmap.SetPixel(3 * quarterHeight, i, OppositeGray(bitmap.GetPixel(3 * quarterHeight, i)));
                bitmap.SetPixel(5 * quarterHeight, i, OppositeGray(bitmap.GetPixel(5 * quarterHeight, i)));
            }

            //
            return bitmap;
        }
    }
}