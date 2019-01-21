using QApp.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                return TextTools.Split(
                    _builder.ToString().Substring(0, (this.RowCursor) * Width),
                    this.Width
                ).ToArray();
            }
        }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;

            RowCursor = 0;
            ColumnCursor = 0;

            BackgroundChar = ' ';

            _builder = new StringBuilder(width);
            _builder.Append(this.BackgroundChar, width);
        }

        public void Draw(string value)
        {
            this.Draw(
                value,
                this.ColumnCursor,
                this.RowCursor
            );
        }

        public void Draw(string value, int column, int row)
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

            _builder.Remove(ix, value.Length);
            _builder.Insert(ix, value);
        }

        public void DrawLine(string value)
        {
            this.Draw(value);
            this.RowCursor += 1;
        }

        public void DrawLine(string value, int column, int row)
        {
            this.Draw(value, column, row);
            this.RowCursor += 1;
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
