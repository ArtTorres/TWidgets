using System;

namespace QApp.Presentation
{
    public class MarqueeTemplate
    {
        public MarqueeTemplate()
        {
            this.Margin = new Box()
            {
                top = 0,
                left = 1,
                bottom = 0,
                right = 1
            };
            this.Padding = new Box()
            {
                top = 0,
                left = 0,
                bottom = 1,
                right = 0
            };

            this.BackgroundColor = ConsoleColor.Black;
            this.ForegroundColor = ConsoleColor.Gray;
            this.BorderTemplate = new char[] { '┌', '─', '┐', '│', ' ', '│', '└', '─', '┘' }; 
            //new char[] { '╔', '═', '╗', '║', ' ', '║', '╚', '═', '╝' };
        }

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

        public Box Margin { get; set; }

        public Box Padding { get; set; }

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }

        public char[] BorderTemplate { get; set; }
    }
}
