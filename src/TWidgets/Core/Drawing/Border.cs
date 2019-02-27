using System;
using TWidgets.Util;

namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Draws a border, background, or both around another element.
    /// </summary>
    public class Border
    {
        /// <summary>
        /// Gets or sets the top-left character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the top character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the top-right character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the left character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the background character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the right character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the bottom-left character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the bottom character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the bottom-right character in the border template.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the border template.
        /// </summary>
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
        private char[] _template;

        /// <summary>
        /// Gets the width of the border.
        /// </summary>
        public int Width
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        public Border()
        {
            _template = BorderTemplate.SOLID;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="template">The character template for the border.</param>
        public Border(char[] template)
        {
            _template = template;
        }
    }
}
