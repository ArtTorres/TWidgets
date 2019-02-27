namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Represents a line which can be drawn on a <see cref="Canvas"/>.
    /// </summary>
    public class Line : IMarginable, IBordeable
    {
        /// <summary>
        /// Gets or sets the border of the line.
        /// </summary>
        public Border Border { get; private set; }

        /// <summary>
        /// Gets or sets the margin of the line.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        public Line()
            : this(new Margin(), new Border())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="margin">The margin of the line.</param>
        /// <param name="border">The border of the line.</param>
        public Line(Margin margin, Border border)
        {
            this.Margin = margin;
            this.Border = border;
        }
    }
}
