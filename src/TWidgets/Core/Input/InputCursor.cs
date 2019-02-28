namespace TWidgets.Core.Input
{
    /// <summary>
    /// Represents the position of the input cursor.
    /// </summary>
    public class InputCursor
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
        /// Initializes an instance of <see cref="InputCursor"/>.
        /// </summary>
        public InputCursor()
        { }

        /// <summary>
        /// Initializes an instance of <see cref="InputCursor"/>.
        /// </summary>
        /// <param name="x">The X axis position.</param>
        /// <param name="y">The Y axis position.</param>
        public InputCursor(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
