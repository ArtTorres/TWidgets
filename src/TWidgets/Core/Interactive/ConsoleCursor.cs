namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Represents the position of the input cursor.
    /// </summary>
    public class ConsoleCursor
    {
        /// <summary>
        /// Gets or sets the X axis position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y axis position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="ConsoleCursor"/>.
        /// </summary>
        public ConsoleCursor()
        { }

        /// <summary>
        /// Initializes an instance of <see cref="ConsoleCursor"/>.
        /// </summary>
        /// <param name="x">The X axis position.</param>
        /// <param name="y">The Y axis position.</param>
        public ConsoleCursor(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
