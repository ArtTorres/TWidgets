namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Represents a rectangle which can be drawn on a <see cref="Canvas"/>.
    /// </summary>
    public class Rectangle : IMarginable, IBordeable
    {
        /// <summary>
        /// Gets or sets the border of the rectangle.
        /// </summary>
        public Border Border { get; private set; }

        /// <summary>
        /// Gets or sets the margin of the rectangle.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(int width, int height)
            : this(
                width,
                height,
                new Margin(),
                new Border()
            )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="margin">The margin of the rectangle.</param>
        /// <param name="border">The border of the rectangle.</param>
        public Rectangle(int width, int height, Margin margin, Border border)
        {
            this.Width = width;
            this.Height = height;

            this.Margin = margin;
            this.Border = border;
        }
    }
}
