using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QApp.Core.Drawing
{
    public class Graphics
    {
        public Canvas Canvas { get; private set; }

        public Graphics(Canvas canvas)
        {
            this.Canvas = canvas;
        }

        public void Draw(string raw)
        {
            this.Canvas.Draw(raw);
        }

        public void Draw(Line line, Margin margin)
        {

        }

        public void DrawLine()
        {
            this.Canvas.Draw(new string('-', this.Canvas.Width));
        }

        public void Draw(Rectangle rectangle)
        {

        }

        public void DrawText(string value, Margin margin, Padding padding)
        {
            this.DrawText(new Text(value, margin, padding));
        }

        public void DrawText(Text text)
        {
            int x = this.Canvas.ColumnCursor + text.Margin.Left + text.Padding.Left;
            int y = this.Canvas.RowCursor + text.Margin.Top + text.Padding.Top;

            int xp = this.Canvas.Width - text.Margin.Right - text.Padding.Right;
            int yp = this.Canvas.Height - text.Margin.Bottom - text.Padding.Bottom;

            if (x + text.Value.Length > xp)
            {
                var lines = this.Split(text.Value, xp - x);
                foreach (var line in lines)
                {
                    this.Canvas.Draw(line, x, y);
                    this.Canvas.RowCursor += 1;
                }
            }
            else
            {
                this.Canvas.Draw(text.Value, x, y);
            }

            this.Canvas.RowCursor = y;
        }

        public void Clear()
        {
            this.Canvas.Clear();
        }

        public void SetForegroundColor(ConsoleColor color)
        {
            this.Canvas.SetForegroundColor(color);
        }

        public void SetBackgroundColor(ConsoleColor color)
        {
            this.Canvas.SetBackgroundColor(color);
        }

        private IEnumerable<string> Split(string value, int size)
        {
            return Enumerable.Range(0, value.Length / size)
                .Select(i => value.Substring(i * size, size));
        }
    }
}
