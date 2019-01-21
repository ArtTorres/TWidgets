using QApp.Util;
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

        public void Draw(Line line)
        {
            int x = this.Canvas.ColumnCursor + line.Margin.Left + line.Padding.Left;
            int y = this.Canvas.RowCursor + line.Margin.Top + line.Padding.Top;

            int xp = this.Canvas.Width - line.Margin.Right - line.Padding.Right;
            int yp = this.Canvas.Height - line.Margin.Bottom - line.Padding.Bottom;

            this.Canvas.Draw(new string(line.Border.Top, xp - x), x, y);
        }

        public void Draw(Rectangle rectangle)
        {
            // TODO: Fix Drawing
            int x = this.Canvas.ColumnCursor + rectangle.Margin.Left + rectangle.Padding.Left;
            int y = this.Canvas.RowCursor + rectangle.Margin.Top + rectangle.Padding.Top;

            int xp = this.Canvas.Width - rectangle.Margin.Right - rectangle.Padding.Right - 1;
            //int yp = this.Canvas.Height - rectangle.Margin.Bottom - rectangle.Padding.Bottom - 1;

            this.Canvas.RowCursor += y;
            int rows = this.Canvas.RowCursor + rectangle.Height;

            for (int i = y; i < rows; i++)
            {
                if (i == y)
                {
                    this.Canvas.Draw(rectangle.Border.TopLeft.ToString(), x, i);

                    int offset = x + 1;
                    this.Canvas.Draw(new string(rectangle.Border.Top, xp - offset), offset, i);

                    this.Canvas.Draw(rectangle.Border.TopRight.ToString(), xp, i);
                }
                else if (i == (rows - 1))
                {
                    this.Canvas.Draw(rectangle.Border.BottomLeft.ToString(), x, i);

                    int offset = x + 1;
                    this.Canvas.Draw(new string(rectangle.Border.Bottom, xp - offset), offset, i);

                    this.Canvas.Draw(rectangle.Border.BottomRight.ToString(), xp, i);
                }
                else
                {
                    this.Canvas.Draw(rectangle.Border.Left.ToString(), x, i);

                    int offset = x + 1;
                    this.Canvas.Draw(new string(rectangle.Border.Background, xp - offset), offset, i);

                    this.Canvas.Draw(rectangle.Border.Right.ToString(), xp, i);
                }

                this.Canvas.RowCursor += 1;
            }

            for (int i = 0; i < rectangle.Margin.Bottom + rectangle.Padding.Bottom; i++)
            {
                this.Canvas.DrawLine(
                    new string(' ', this.Canvas.Width)
                );
            }
        }

        public void Draw(Text text)
        {
            int x = this.Canvas.ColumnCursor + text.Margin.Left + text.Padding.Left;
            int y = this.Canvas.RowCursor + text.Margin.Top + text.Padding.Top;

            int xp = this.Canvas.Width - text.Margin.Right - text.Padding.Right;
            int yp = this.Canvas.Height - text.Margin.Bottom - text.Padding.Bottom;

            if (x + text.Value.Length > xp)
            {
                var lines = TextTools.Split(text.Value, xp - x);
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

        public void DrawText(string value, Margin margin, Padding padding)
        {
            this.Draw(new Text(value, margin, padding));
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
    }
}
