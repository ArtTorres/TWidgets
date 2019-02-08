
namespace TWidgets.Util
{
    public static class BorderTemplate
    {
        public const int BORDER_TOP_LEFT = 0;
        public const int BORDER_TOP = 1;
        public const int BORDER_TOP_RIGHT = 2;
        public const int BORDER_LEFT = 3;
        public const int BACKGROUND = 4;
        public const int BORDER_RIGHT = 5;
        public const int BORDER_BOTTOM_LEFT = 6;
        public const int BORDER_BOTTOM = 7;
        public const int BORDER_BOTTOM_RIGHT = 8;

        public const int TEMPLATE_SIZE = 9;

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
