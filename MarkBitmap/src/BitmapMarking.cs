using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MarkBitmap
{
    /// <summary>
    /// Marking through Bitmap to Bitmap.
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
}
