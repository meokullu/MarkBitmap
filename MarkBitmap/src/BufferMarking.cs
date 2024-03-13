using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkBitmap
{
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
            for (int i = 1; i < count; i++)
            {
                // Calling via inner method.
                buffer = MarkHorizontalLine(buffer: buffer, x: offset * i, y: 0, width: width, length: width, color: color);
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

            for (int i = 1; i < count; i++)
            {
                // Calling via inner method.
                buffer = MarkVerticalLine(buffer, x: 0, y: offset * i, width: width, length: height, color: color);
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
            int offset;

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
            int offset;

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

        public static byte[] MarkHorizontalLine(byte[] buffer, int x, int y, int width, int length, Color color)
        {
            //
            int widthBlock = y * width;

            //
            for (int i = 0; i < length; i++)
            {
                buffer[(widthBlock + i + x) * 3] = color.B;
                buffer[(widthBlock + i + x) * 3 + 1] = color.G;
                buffer[(widthBlock + i + x) * 3 + 2] = color.R;
            }

            //
            return buffer;
        }

        public static byte[] MarkVerticalLine(byte[] buffer, int x, int y, int width, int length, Color color)
        {
            //
            int widthBlock = y * width;

            //
            for (int i = 0; i < length; i++)
            {
                buffer[(x + (i * width) + (widthBlock)) * 3] = color.B;
                buffer[(x + (i * width) + (widthBlock)) * 3 + 1] = color.G;
                buffer[(x + (i * width) + (widthBlock)) * 3 + 2] = color.R;
            }

            //
            return buffer;
        }

        public static byte[] MarkCorners(byte[] buffer, int width, int height, int length, Color color)
        {
            // Top left
            buffer = MarkHorizontalLine(buffer: buffer, x: 0, y: 0, width: width, length: length, color: color);
            buffer = MarkVerticalLine(buffer: buffer, x: 0, y: 0, width: width, length: length, color: color);

            // Bottom left
            buffer = MarkHorizontalLine(buffer: buffer, x: 0, y: height - 1, width: width, length: length, color: color);
            buffer = MarkVerticalLine(buffer: buffer, x: 0, y: height - length, width: width, length: length, color: color);

            // Top right
            buffer = MarkHorizontalLine(buffer: buffer, width - length, 0, width, length, color);
            buffer = MarkVerticalLine(buffer: buffer, width - 1, 0, width, length, color);

            // Top bottom
            buffer = MarkHorizontalLine(buffer: buffer, width - length, height - 1, width, length, color);
            buffer = MarkVerticalLine(buffer: buffer, width - 1, height - 1 - length, width, length, color);

            //
            return buffer;
        }

        #endregion Marking buffer
    }
}
