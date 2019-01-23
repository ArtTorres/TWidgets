using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Util
{
    public class BorderTemplates
    {
        public static readonly char[] DOTTED = new char[] {
            '·', '·', '·',
            '·', ' ', '·',
            '·', '·', '·'
        };

        public static readonly char[] STARS = new char[] {
            '*', '*', '*',
            '*', ' ', '*',
            '*', '*', '*'
        };

        public static readonly char[] RIDGE = new char[] {
            '╔', '═', '╗',
            '║', ' ', '║',
            '╚', '═', '╝'
        };

        public static readonly char[] FILL = new char[] {
            '█', '█', '█',
            '█', '█', '█',
            '█', '█', '█'
        };

        public static readonly char[] SOLID = new char[] {
            '┌', '─', '┐',
            '│', ' ', '│',
            '└', '─', '┘'
        };
    }
}
