namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Represents the empty space inside between an element an their inner elements.
    /// </summary>
    public class Padding
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
        /// Gets or sets the empty space inside between an element an their inner elements.
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
        /// Initializes a new instance of the <see cref="Padding"/> class.
        /// </summary>
        public Padding()
        {
            All = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Padding"/> class.
        /// </summary>
        /// <param name="all">The empty space around the element.</param>
        public Padding(int all)
        {
            All = all;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Padding"/> class.
        /// </summary>
        /// <param name="top">The top empty space.</param>
        /// <param name="left">The left empty space.</param>
        /// <param name="bottom">The bottom empty space.</param>
        /// <param name="right">The right empty space.</param>
        public Padding(int top, int left, int bottom, int right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }
    }
}
