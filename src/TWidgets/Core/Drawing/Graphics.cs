namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Encapsulates a drawing surface. This class cannot be inherited.
    /// </summary>
    public sealed class Graphics
    {
        /// <summary>
        /// Gets the current <see cref="Canvas"/>.
        /// </summary>
        public Canvas Canvas { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="Graphics"/> class with a initial <see cref="Canvas"/>.
        /// </summary>
        /// <param name="canvas">The initial <see cref="Canvas"/>.</param>
        public Graphics(Canvas canvas)
        {
            this.Canvas = canvas;
        }

        /// <summary>
        /// Draws a value on <see cref="Canvas"/>.
        /// </summary>
        /// <param name="value">The value to be drawn.</param>
        public void Draw(string value)
        {
            this.Canvas.Draw(value);
        }

        /// <summary>
        /// Draws a value on <see cref="Canvas"/> in a specified column.
        /// </summary>
        /// <param name="value">The value to be drawn.</param>
        /// <param name="column">A column position.</param>
        public void Draw(string value, int column)
        {
            this.Canvas.Draw(value, column, this.Canvas.RowCursor);
        }

        /// <summary>
        /// Draws a value on <see cref="Canvas"/> in a specific column and row.
        /// </summary>
        /// <param name="value">The value to be drawn.</param>
        /// <param name="column">A column position.</param>
        /// <param name="row">A row position.</param>
        public void Draw(string value, int column, int row)
        {
            this.Canvas.Draw(value, column, row);
        }

        /// <summary>
        /// Draws a <see cref="Line"/> on <see cref="Canvas"/>.
        /// </summary>
        /// <param name="line">The line object.</param>
        public void Draw(Line line)
        {
            // Draw top margin
            this.Canvas.DrawSpace(line.Margin.Top);

            int x = this.Canvas.ColumnCursor + line.Margin.Left;
            int xp = this.Canvas.Width - line.Margin.Right;

            this.Canvas.DrawLine(new string(line.Border.Top, xp - x), x);

            // Draw bottom margin
            this.Canvas.DrawSpace(line.Margin.Bottom);
        }

        /// <summary>
        /// Draws a <see cref="List"/> on <see cref="Canvas"/>.
        /// </summary>
        /// <param name="list">The list object.</param>
        public void Draw(List list)
        {
            // Draw top margin
            this.Canvas.DrawSpace(list.Margin.Top);

            // Draw items
            foreach (var item in list.Items)
            {
                int x = this.CalculateAlignedPosition(
                    this.Canvas.Width,
                    item.Length,
                    this.Canvas.ColumnCursor,
                    list.Margin,
                    list.Align
                );

                this.Canvas.DrawLine(item, x);
            }

            // Draw bottom margin
            this.Canvas.DrawSpace(list.Margin.Bottom);
        }

        /// <summary>
        /// Draws a <see cref="Rectangle"/> on <see cref="Canvas"/>.
        /// </summary>
        /// <param name="rectangle">The rectangle object.</param>
        public void Draw(Rectangle rectangle)
        {
            // Draw top margin
            this.Canvas.DrawSpace(rectangle.Margin.Top);

            int x = this.Canvas.ColumnCursor + rectangle.Margin.Left;
            int y = this.Canvas.RowCursor;

            int xp = this.Canvas.Width - rectangle.Margin.Right - 1;

            int rows = rectangle.Height;

            for (int i = 0; i < rows; i++)
            {
                int c = this.Canvas.RowCursor;

                if (i == 0)
                {   // Draw Top
                    this.Canvas.Draw(rectangle.Border.TopLeft.ToString(), x, c);

                    int offset = x + 1;
                    this.Canvas.Draw(new string(rectangle.Border.Top, xp - offset), offset, c);

                    this.Canvas.Draw(rectangle.Border.TopRight.ToString(), xp, c);
                }
                else if (i == (rows - 1))
                {   // Draw Bottom
                    this.Canvas.Draw(rectangle.Border.BottomLeft.ToString(), x, c);

                    int offset = x + 1;
                    this.Canvas.Draw(new string(rectangle.Border.Bottom, xp - offset), offset, c);

                    this.Canvas.Draw(rectangle.Border.BottomRight.ToString(), xp, c);
                }
                else
                {   // Draw Center
                    this.Canvas.Draw(rectangle.Border.Left.ToString(), x, c);

                    int offset = x + 1;
                    this.Canvas.Draw(new string(rectangle.Border.Background, xp - offset), offset, c);

                    this.Canvas.Draw(rectangle.Border.Right.ToString(), xp, c);
                }

                this.Canvas.RowCursor += 1;
            }

            // Draw bottom margin
            this.Canvas.DrawSpace(rectangle.Margin.Bottom);
        }

        /// <summary>
        /// Draws a <see cref="Text"/> on <see cref="Canvas"/>.
        /// </summary>
        /// <param name="text">The text object.</param>
        public void Draw(Text text)
        {
            this.Draw(text, this.Canvas.ColumnCursor);
        }

        /// <summary>
        /// Draws a <see cref="Text"/> on <see cref="Canvas"/> in a specific column.
        /// </summary>
        /// <param name="text">The text object.</param>
        /// <param name="column">A column position.</param>
        public void Draw(Text text, int column)
        {
            this.Draw(text, column, this.Canvas.RowCursor);
        }

        /// <summary>
        /// Draws a <see cref="Text"/> on <see cref="Canvas"/> in a specific column and row.
        /// </summary>
        /// <param name="text">The text object.</param>
        /// <param name="column">A column position.</param>
        /// <param name="row">A row position.</param>
        public void Draw(Text text, int column, int row)
        {
            // Draw top margin
            this.Canvas.DrawSpace(text.Margin.Top);

            // Draw Text component
            int x = this.CalculateAlignedPosition(
                this.Canvas.Width,
                text.Value.Length,
                this.Canvas.ColumnCursor,
                text.Margin,
                text.Align
            );
            int y = this.Canvas.RowCursor + text.Margin.Top;

            this.Canvas.DrawLine(text.Value, x);

            // Draw bottom margin
            this.Canvas.DrawSpace(text.Margin.Bottom);
        }

        /// <summary>
        /// Sets to initial positions all <see cref="Canvas"/> cursors.
        /// </summary>
        public void ResetCursors()
        {
            this.Canvas.ColumnCursor = 0;
            this.Canvas.RowCursor = 0;
        }

        /// <summary>
        /// Removes all content on <see cref="Canvas"/>.
        /// </summary>
        public void Clear()
        {
            this.Canvas.Clear();
        }

        /// <summary>
        /// Calculate the initial position of a value based in a specified align.
        /// </summary>
        /// <param name="width">The width of the <see cref="Canvas"/>.</param>
        /// <param name="length">The length of the value.</param>
        /// <param name="column">The value of the column position.</param>
        /// <param name="margin">The value of <see cref="Margin"/>.</param>
        /// <param name="align">The specified <see cref="Align"/>.</param>
        /// <returns>The position value of the initial position.</returns>
        private int CalculateAlignedPosition(int width, int length, int column, Margin margin, Align align)
        {
            int ix = -1;  // index

            switch (align)
            {
                case Align.Left:
                    return ix = CalculateLeftIndex();
                case Align.Center:
                    return ix = CalculateCenterIndex();
                case Align.Right:
                    return ix = CalculateRightIndex();
                default:
                    return ix;
            }

            int CalculateLeftIndex()
            {
                return column + margin.Left;
            }
            int CalculateCenterIndex()
            {
                int center = (width / 2);
                int offset = (length + margin.Left + margin.Right) / 2;

                int inc = (center - offset) * 2 % 2 == 0 ? 0 : 1;

                return center - offset - column + margin.Left + inc;
            }
            int CalculateRightIndex()
            {
                return width - (column + margin.Right) - length;
            }
        }
    }
}
