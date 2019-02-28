namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Represents the empty space around an element.
    /// </summary>
    public class Margin
    {
        /// <summary>
        /// Gets or sets the top empty space.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Gets or sets the left empty space.
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Gets or sets the bottom empty space.
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// Gets or sets the right empty space.
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// Gets or sets the empty space around the element.
        /// </summary>
        public int All
        {
            get
            {
                return _all;
            }
            set
            {
                Top = value;
                Left = value;
                Bottom = value;
                Right = value;
                _all = value;
            }
        }
        private int _all;

        /// <summary>
        /// Initializes a new instance of the <see cref="Margin"/> class.
        /// </summary>
        public Margin()
        {
            All = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Margin"/> class.
        /// </summary>
        /// <param name="all">The empty space around the element.</param>
        public Margin(int all)
        {
            All = all;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Margin"/> class.
        /// </summary>
        /// <param name="top">The top empty space.</param>
        /// <param name="left">The left empty space.</param>
        /// <param name="bottom">The bottom empty space.</param>
        /// <param name="right">The right empty space.</param>
        public Margin(int top, int left, int bottom, int right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }
    }
}
