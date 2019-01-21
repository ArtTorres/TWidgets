using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public class Border
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

        public char TopLeft
        {
            get
            {
                return Template[BORDER_TOP_LEFT];
            }
            set
            {
                Template[BORDER_TOP_LEFT] = value;
            }
        }

        public char Top
        {
            get
            {
                return Template[BORDER_TOP];
            }
            set
            {
                Template[BORDER_TOP] = value;
            }
        }

        public char TopRight
        {
            get
            {
                return Template[BORDER_TOP_RIGHT];
            }
            set
            {
                Template[BORDER_TOP_RIGHT] = value;
            }
        }

        public char Left
        {
            get
            {
                return Template[BORDER_LEFT];
            }
            set
            {
                Template[BORDER_LEFT] = value;
            }
        }

        public char Background
        {
            get
            {
                return Template[BACKGROUND];
            }
            set
            {
                Template[BACKGROUND] = value;
            }
        }

        public char Right
        {
            get
            {
                return Template[BORDER_RIGHT];
            }
            set
            {
                Template[BORDER_RIGHT] = value;
            }
        }

        public char BottomLeft
        {
            get
            {
                return Template[BORDER_BOTTOM_LEFT];
            }
            set
            {
                Template[BORDER_BOTTOM_LEFT] = value;
            }
        }

        public char Bottom
        {
            get
            {
                return Template[BORDER_BOTTOM];
            }
            set
            {
                Template[BORDER_BOTTOM] = value;
            }
        }

        public char BottomRight
        {
            get
            {
                return Template[BORDER_BOTTOM_RIGHT];
            }
            set
            {
                Template[BORDER_BOTTOM_RIGHT] = value;
            }
        }

        private char[] _template;
        public char[] Template
        {
            get
            {
                return _template;
            }
            set
            {
                if (_template.Length != TEMPLATE_SIZE)
                    throw new Exception($"Template size different of {TEMPLATE_SIZE}.");

                _template = value;
            }
        }

        public Border()
        {
            _template = new char[] {
                '┌', '─', '┐',
                '│', ' ', '│',
                '└', '─', '┘'
            };
        }

        public Border(char[] template)
        {
            _template = template;
        }
    }
}
