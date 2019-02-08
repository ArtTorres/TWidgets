using System;
using TWidgets.Util;

namespace TWidgets.Core.Drawing
{
    public class Border
    {
        public char TopLeft
        {
            get
            {
                return Template[BorderTemplate.BORDER_TOP_LEFT];
            }
            set
            {
                Template[BorderTemplate.BORDER_TOP_LEFT] = value;
            }
        }

        public char Top
        {
            get
            {
                return Template[BorderTemplate.BORDER_TOP];
            }
            set
            {
                Template[BorderTemplate.BORDER_TOP] = value;
            }
        }

        public char TopRight
        {
            get
            {
                return Template[BorderTemplate.BORDER_TOP_RIGHT];
            }
            set
            {
                Template[BorderTemplate.BORDER_TOP_RIGHT] = value;
            }
        }

        public char Left
        {
            get
            {
                return Template[BorderTemplate.BORDER_LEFT];
            }
            set
            {
                Template[BorderTemplate.BORDER_LEFT] = value;
            }
        }

        public char Background
        {
            get
            {
                return Template[BorderTemplate.BACKGROUND];
            }
            set
            {
                Template[BorderTemplate.BACKGROUND] = value;
            }
        }

        public char Right
        {
            get
            {
                return Template[BorderTemplate.BORDER_RIGHT];
            }
            set
            {
                Template[BorderTemplate.BORDER_RIGHT] = value;
            }
        }

        public char BottomLeft
        {
            get
            {
                return Template[BorderTemplate.BORDER_BOTTOM_LEFT];
            }
            set
            {
                Template[BorderTemplate.BORDER_BOTTOM_LEFT] = value;
            }
        }

        public char Bottom
        {
            get
            {
                return Template[BorderTemplate.BORDER_BOTTOM];
            }
            set
            {
                Template[BorderTemplate.BORDER_BOTTOM] = value;
            }
        }

        public char BottomRight
        {
            get
            {
                return Template[BorderTemplate.BORDER_BOTTOM_RIGHT];
            }
            set
            {
                Template[BorderTemplate.BORDER_BOTTOM_RIGHT] = value;
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
                if (_template.Length != BorderTemplate.TEMPLATE_SIZE)
                    throw new Exception($"Template size different of {BorderTemplate.TEMPLATE_SIZE}.");

                _template = value;
            }
        }

        public int Width
        {
            get
            {
                return 1;
            }
        }

        public Border()
        {
            _template = BorderTemplate.SOLID;
        }

        public Border(char[] template)
        {
            _template = template;
        }
    }
}
