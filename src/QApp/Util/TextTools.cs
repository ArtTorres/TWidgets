using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QApp.Util
{
    public static class TextTools
    {
        //public static IEnumerable<string> Split(string value, int size)
        //{
        //    return Enumerable.Range(0, value.Length / size)
        //        .Select(i => value.Substring(i * size, size));
        //}

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
    }
}
