using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public class Rectangle
    {
        // Template coordinates
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

        // Spaces
        public Margin Margin { get; set; }
        public Padding Padding { get; set; }

        // Template
        public char[] BorderTemplate { get; set; }

        public Rectangle(int width, int height, int envWidth, bool shrink = true)
        {
            this.Margin = new Margin()
            {
                top = 0,
                left = 1,
                bottom = 0,
                right = 1
            };
            this.Padding = new Padding()
            {
                top = 0,
                left = 0,
                bottom = 1,
                right = 0
            };

            this.BorderTemplate = new char[] { '┌', '─', '┐', '│', ' ', '│', '└', '─', '┘' };
        }
    }
}
