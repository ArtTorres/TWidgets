using System.Linq;
using System.Text;
using TWidgets.Core.Utils;

namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Represents the area of drawing. This class cannot be inherited.
    /// </summary>
    public sealed class Canvas
    {
        /// <summary>
        /// Gets the width of the <see cref="Canvas"/>.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height of the <see cref="Canvas"/>.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets or sets the column position in the <see cref="Canvas"/>.
        /// </summary>
        public int ColumnCursor { get; set; }

        /// <summary>
        /// Gets or sets the row position in the <see cref="Canvas"/>.
        /// </summary>
        public int RowCursor
        {
            get
            {
                return _rowCursor;
            }
            set
            {
                if (value > Rows)
                {
                    Rows = value;
                }

                _rowCursor = value;
            }
        }
        private int _rowCursor;

        /// <summary>
        /// Gets the current columns on the <see cref="Canvas"/>.
        /// </summary>
        public int Columns
        {
            get
            {
                return Width;
            }
        }

        /// <summary>
        /// Gets the current rows on the <see cref="Canvas"/>.
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Gets or sets the background character.
        /// </summary>
        public char BackgroundChar { get; private set; }

        /// <summary>
        /// Gets the text representation of the <see cref="Canvas"/>.
        /// </summary>
        public string[] Map
        {
            get
            {
                return TextUtils.Split(
                    TextUtils.Normalize(
                        _map.ToString(),
                        this.Rows * Width
                    ),
                    this.Width
                ).ToArray();
            }
        }
        private StringBuilder _map;

        /// <summary>
        /// Initializes a new instance of <see cref="Canvas"/> class with a initial size.
        /// </summary>
        /// <param name="width">The width of the canvas.</param>
        /// <param name="height">The height of the canvas.</param>
        /// <param name="background">The default background character.</param>
        public Canvas(int width, int height, char background = ' ')
        {
            Width = width;
            Height = height;

            RowCursor = 0;
            ColumnCursor = 0;

            BackgroundChar = background;

            _map = new StringBuilder(width);
            _map.Append(this.BackgroundChar, width);
        }

        /// <summary>
        /// Draws a text in the current position.
        /// </summary>
        /// <param name="value">A text value.</param>
        public void Draw(string value)
        {
            this.Draw(
                value,
                this.ColumnCursor,
                this.RowCursor
            );
        }

        /// <summary>
        /// Draws a text in a specified position.
        /// </summary>
        /// <param name="value">A text value.</param>
        /// <param name="column">The column position.</param>
        /// <param name="row">The row position.</param>
        public void Draw(string value, int column, int row)
        {
            int ix = row * Width + column;  // index
            int lix = ix + value.Length; // last index

            if (lix > _map.Length)
            {
                _map.Append(
                    this.BackgroundChar,
                    (lix - Width) <= Width ? ix + Width : lix
                );
            }

            _map.Remove(ix, value.Length);
            _map.Insert(ix, value);
        }

        /// <summary>
        /// Draws a text in the current position and increase the row position.
        /// </summary>
        /// <param name="value">A text value.</param>
        public void DrawLine(string value)
        {
            this.Draw(value);

            this.ColumnCursor = 0;
            this.RowCursor += 1;
        }

        /// <summary>
        /// Draws a text in a specified position and increase the row position.
        /// </summary>
        /// <param name="value">A text value.</param>
        /// <param name="column">The column position.</param>
        public void DrawLine(string value, int column)
        {
            this.Draw(value, column, this.RowCursor);

            this.ColumnCursor = 0;
            this.RowCursor += 1;
        }

        /// <summary>
        /// Increase the row position in a specified value.
        /// </summary>
        /// <param name="rows">The number of rows to increase.</param>
        public void DrawSpace(int rows = 1)
        {
            this.RowCursor += rows;
        }

        /// <summary>
        /// Removes the content of the <see cref="Canvas"/> and restarts the cursors.
        /// </summary>
        public void Clear()
        {
            _map.Clear();

            this.Rows = 0;
            this.ColumnCursor = 0;
            this.RowCursor = 0;
        }
    }
}
