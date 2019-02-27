using System.Collections.Generic;

namespace TWidgets.Util
{
    /// <summary>
    /// Provides utilities to process text.
    /// </summary>
    public static class TextUtils
    {
        /// <summary>
        /// Split a text in pieces of the same size.
        /// </summary>
        /// <param name="value">The text value.</param>
        /// <param name="size">The size of the chunks.</param>
        /// <returns>A collection of <see cref="string"/>.</returns>
        public static IEnumerable<string> Split(string value, int size)
        {
            int chunk = value.Length / size;

            for (int i = 0; i <= chunk; i++)
            {
                int c = i * size;
                int len = value.Length - c;

                if (len == 0) continue;

                if (len < size)
                    yield return value.Substring(c, len);
                else
                    yield return value.Substring(c, size);
            }
        }

        /// <summary>
        /// Evaluates a text value, if it's shorter fills with background characters to the max length, 
        /// if longer, the value will be trim to the max length.
        /// </summary>
        /// <param name="value">The text value.</param>
        /// <param name="maxLength">The max length of the text.</param>
        /// <param name="background">A background character.</param>
        /// <returns>A normalized text.</returns>
        public static string Normalize(string value, int maxLength, char background = ' ')
        {
            if (value.Length < maxLength)
            {
                // Fill with empty characters
                return string.Concat(value, new string(background, maxLength - value.Length));
            }
            else if (value.Length == maxLength)
            {
                // No changes
                return value;
            }
            else
            {
                // Trim to max
                return value.Substring(0, maxLength);
            }
        }

        /// <summary>
        /// Resizes the text values who overpass a maximum width.
        /// </summary>
        /// <param name="lines">A collection of text lines.</param>
        /// <param name="maxWidth">The max length of the text.</param>
        /// <returns>A collection of <see cref="string"/>.</returns>
        public static string[] ResizeLines(string[] lines, int maxWidth)
        {
            var output = new List<string>();

            foreach (var line in lines)
            {
                if (line.Length > maxWidth)
                {
                    output.AddRange(
                        Split(line, maxWidth)
                    );
                }
                else
                {
                    output.Add(line);
                }
            }

            return output.ToArray();
        }
    }
}
