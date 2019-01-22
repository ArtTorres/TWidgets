using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Util
{
    public class BorderTemplates
    {
        public static char[] DOTTED = new char[] {
            '·', '·', '·',
            '·', ' ', '·',
            '·', '·', '·'
        };

        public static char[] STARS = new char[] {
            '*', '*', '*',
            '*', ' ', '*',
            '*', '*', '*'
        };

        public static char[] RIDGE = new char[] {
            '╔', '═', '╗',
            '║', ' ', '║',
            '╚', '═', '╝'
        };

        public static char[] SOLID = new char[] {
            '█', '█', '█',
            '█', '█', '█',
            '█', '█', '█'
        };
    }
}
