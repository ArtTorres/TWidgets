﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWidgets.Util
{
    public static class TextUtils
    {
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

        public static string Normalize(string value, int maxLength)
        {
            if (value.Length < maxLength)
            {
                // Fill with empty characters
                return string.Concat(value, new string(' ', maxLength - value.Length));
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
    }
}
