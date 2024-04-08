using System;
using System.Drawing;

namespace MarkBitmap
{
    /// <summary>
    /// Marking through byte[] to byte[].
    /// </summary>
    public partial class MarkBitmap
    {
        public static void SetColorOnArray(byte[] buffer, int index, Color color)
        {
            // Changes value of array with certain index. Instead of RGB, it is BGR which is alphabetically.
            buffer[index + 0] = color.B;
            buffer[index + 1] = color.G;
            buffer[index + 2] = color.R;
        }

        public static void SetColorOnArray(byte[] buffer, int index, Func<byte, byte, byte, Color> colorFunc)
        {
            if (colorFunc == null)
            {
                throw new ArgumentNullException("colorFunc is null");
            }

            SetColorOnArray(buffer, index, colorFunc(buffer[index], buffer[index + 1], buffer[index + 2]));
        }

        public static Color ColorFuncDefault(byte red, byte green, byte blue)
        {
            byte avarage = (byte)((255 - red + 255 - green + 255 - blue) / 3);

            return Color.FromArgb(avarage, avarage, avarage);
        }

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
            int offset = width / count;

            // Loop for each marking lines.
            for (int i = 1; i < count; i++)
            {
                // Calling via inner method.
                buffer = MarkHorizontalLine(buffer: buffer, x: offset * i, y: 0, width: width, length: width - 1, color: color);
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
            int offset = height / count;

            for (int i = 1; i < count; i++)
            {
                // Calling via inner method.
                buffer = MarkVerticalLine(buffer: buffer, x: 0, y: offset * i, width: width, length: height - 1, color: color);
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
                offset = ((i * width) + i) * 3;

                // Changes value of array with certain index. Instead of RGB, it is BGR which is alphabetically.
                SetColorOnArray(buffer, offset, color);
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
                offset = ((i * width) - i) * 3;

                SetColorOnArray(buffer, offset, color);
            }

            // Returning applied result.
            return buffer;
        }

        #region Lines

        public static byte[] MarkHorizontalLine(byte[] buffer, int x, int y, int width, int length, Color color)
        {
            //
            for (int i = 0; i < length; i++)
            {
                int index = ((y * width) + i + x) * 3;

                //Debug.WriteLine($"MarkHorizontalLine => x: {x}, y: {y} l: {length}");

                //SetColorOnArray(markedBuffer, index, ColorFuncDefault);
                SetColorOnArray(buffer, index, color);
            }

            //
            return buffer;
        }

        public static byte[] MarkVerticalLine(byte[] buffer, int x, int y, int width, int length, Color color)
        {

            //
            for (int i = 0; i < length; i++)
            {
                int index = (((i + y) * width) + x) * 3;

                //Debug.WriteLine($"MarkVerticalLine => x: {x}, y: {y} l: {length}");

                //SetColorOnArray(markedBuffer, index, ColorFuncDefault);
                SetColorOnArray(buffer, index, color);
            }

            //
            return buffer;
        }

        public static byte[] MarkDiagonalLine(byte[] buffer, int x, int y, int width, int length, Color color)
        {
            //
            for (int i = 0; i < length; i++)
            {
                int index = (((i + y) * width) + i + x) * 3;

                //SetColorOnArray(markedBuffer, index, ColorFuncDefault);
                SetColorOnArray(buffer, index, color);
            }

            //
            return buffer;
        }

        public static byte[] MarkDiagonalInverseLine(byte[] buffer, int x, int y, int width, int length, Color color)
        {
            //
            for (int i = 0; i < length; i++)
            {
                int index = (((y + i) * width) - i + x) * 3;

                //SetColorOnArray(markedBuffer, index, ColorFuncDefault);
                SetColorOnArray(buffer, index, color);
            }

            //
            return buffer;
        }

        #endregion Lines

        public static byte[] MarkCorners(byte[] buffer, int width, int height, int length, Color color)
        {
            // Top left
            buffer = MarkHorizontalLine(buffer: buffer, x: 0, y: 0, width: width, length: length, color: color);
            buffer = MarkVerticalLine(buffer: buffer, x: 0, y: 0, width: width, length: length, color: color);

            // Bottom left
            buffer = MarkHorizontalLine(buffer: buffer, x: 0, y: height - 1, width: width, length: length - 1, color: color);
            buffer = MarkVerticalLine(buffer: buffer, x: 0, y: height - length + 1, width: width, length: length - 1, color: color);

            // Top right
            buffer = MarkHorizontalLine(buffer: buffer, x: width - length + 1, y: 0, width, length, color);
            buffer = MarkVerticalLine(buffer: buffer, x: width - 1, y: 0, width, length, color);

            // Bottom right
            buffer = MarkHorizontalLine(buffer: buffer, x: width - length + 1, y: height - 1, width, length - 1, color);
            buffer = MarkVerticalLine(buffer: buffer, x: width - 1, y: height - length + 1, width, length - 1, color);

            //
            return buffer;
        }

        #endregion Marking buffer
    }
}
