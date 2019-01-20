using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public sealed class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int RowCursor { get; set; }
        public int ColumnCursor { get; set; }

        public char BackgroundChar { get; set; }

        private StringBuilder _builder;
        public string[] Map
        {
            get
            {
                return _builder.ToString().Split(',');
            }
        }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;

            RowCursor = 0;
            ColumnCursor = 0;

            _builder = new StringBuilder(width);
            _builder.Append(this.BackgroundChar, width);
        }

        public void Draw(string value)
        {
            this.Draw(
                value,
                this.RowCursor,
                this.ColumnCursor
            );
        }

        public void Draw(string value, int row, int column)
        {
            int ix = row * Width + column;  // index
            int lix = ix + value.Length;    // last index

            if (lix > _builder.Length)
            {
                _builder.Append(
                    this.BackgroundChar, 
                    (lix - Width) <= Width ? ix + Width : lix
                );
                //_builder.Capacity = (lix - Width) <= Width ? ix + Width : lix;
            }

            _builder.Insert(ix, value);
        }

        public void Clear()
        {
            _builder.Clear();
        }

        public void SetForegroundColor(ConsoleColor color)
        {
            //TODO: Implement Color change support
        }

        public void SetBackgroundColor(ConsoleColor color)
        {
            //TODO: Implement Color change support
        }
    }
}
