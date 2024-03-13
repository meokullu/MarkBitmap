using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace MarkBitmap
{
    /// <summary>
    /// Extra markings.
    /// </summary>
    public partial class MarkBitmap
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="length"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Bitmap MarkCorners(Bitmap bitmap, int length, Color color)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException($"nullass {bitmap}");
            }

            // Convertion to byte array.
            byte[] buffer = ToBuffer(bitmap);

            // Marking buffer.
            byte[] processedBuffer = MarkCorners(buffer, bitmap.Width, bitmap.Height, length, color);

            // Creating bitmap from marked buffer.
            Bitmap processedBitmap = ToBMP(processedBuffer, bitmap.Width, bitmap.Height);

            // Returning bitmap.
            return processedBitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Bitmap MarkCameraGrid(Bitmap bitmap, Color color)
        {
            // Checking if bitmap is null.
            if (bitmap == null)
            {
                // Throwing an ArgumentNullException with specified message.
                throw new ArgumentNullException($"nullass {bitmap}");
            }

            // Transform to byte array.
            byte[] buffer = ToBuffer(bitmap);

            #region Vertical lines

            //
            buffer = MarkVerticalLine(buffer, bitmap.Width / 3, 0, bitmap.Width, bitmap.Height - 1, color);
            buffer = MarkVerticalLine(buffer, bitmap.Width * 2 / 3, 0, bitmap.Width, bitmap.Height - 1, color);

            #endregion Vertical lines

            #region Horizontal lines

            //
            buffer = MarkHorizontalLine(buffer, 0, bitmap.Height / 3, bitmap.Width, bitmap.Width - 1, color);
            buffer = MarkHorizontalLine(buffer, 0, bitmap.Height * 2 / 3, bitmap.Width, bitmap.Width - 1, color);

            #endregion Horizontal lines

            #region Corners

            //
            buffer = MarkCorners(buffer, bitmap.Width, bitmap.Height, (bitmap.Width > bitmap.Height ? bitmap.Height / 10 : bitmap.Width / 10), color);

            #endregion Corners

            #region Center grid

            //
            int length = bitmap.Width > bitmap.Height ? bitmap.Height / 6 : bitmap.Width / 6;

            //
            int x = (bitmap.Width / 2) - length / 2;
            int y = (bitmap.Height / 2) - length / 2;

            //
            int xOffset = x + length;
            int yOffset = y + length;

            //
            buffer = MarkVerticalLine(buffer, x, y, bitmap.Width, length, color);
            buffer = MarkVerticalLine(buffer, xOffset, y, bitmap.Width, length, color);

            //
            buffer = MarkHorizontalLine(buffer, x, y, bitmap.Width, length, color);
            buffer = MarkHorizontalLine(buffer, x, yOffset, bitmap.Width, length, color);

            #endregion Center grid

            #region Center cross

            //
            int crossLength = bitmap.Width > bitmap.Height ? bitmap.Height / 12 : bitmap.Width / 12;

            //
            int xCross = (bitmap.Width / 2);
            int yCross = (bitmap.Height / 2);

            //
            buffer = MarkVerticalLine(buffer, xCross - 1, yCross - crossLength / 2, bitmap.Width, crossLength, Color.Yellow);
            buffer = MarkVerticalLine(buffer, xCross, yCross - crossLength / 2, bitmap.Width, crossLength, color);
            buffer = MarkVerticalLine(buffer, xCross + 1, yCross - crossLength / 2, bitmap.Width, crossLength, Color.Yellow);

            //
            buffer = MarkHorizontalLine(buffer, xCross - crossLength / 2, yCross - 1, bitmap.Width, crossLength, Color.Yellow);
            buffer = MarkHorizontalLine(buffer, xCross - crossLength / 2, yCross, bitmap.Width, crossLength, color);
            buffer = MarkHorizontalLine(buffer, xCross - crossLength / 2, yCross + 1, bitmap.Width, crossLength, Color.Yellow);

            #endregion Center cross

            // Create marked bitmap.
            Bitmap markedBitmap = ToBMP(buffer, bitmap.Width, bitmap.Height);

            // Returning bitmap.
            return markedBitmap;
        }
    }
}