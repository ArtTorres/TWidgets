using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public sealed class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public int RowCursor { get; private set; }
        public int ColumnCursor { get; private set; }

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
            int index = row * Width + column;

            _builder.Insert(index, value);
        }

        public void Clear()
        {
            _builder.Clear();
        }

        public void SetForegroundColor(ConsoleColor color)
        {

        }

        public void SetBackgroundColor(ConsoleColor color)
        {

        }
    }
}
