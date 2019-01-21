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
            // Draw top margin
            for (int i = 0; i < line.Margin.Top; i++)
            {
                this.Canvas.DrawLine(
                    new string(' ', this.Canvas.Width)
                );
            }

            int x = this.Canvas.ColumnCursor + line.Margin.Left;
            //int y = this.Canvas.RowCursor + line.Margin.Top + line.Padding.Top;

            int xp = this.Canvas.Width - line.Margin.Right;
            //int yp = this.Canvas.Height - line.Margin.Bottom - line.Padding.Bottom;

            //this.Canvas.Draw(new string(line.Border.Top, xp - x), x, y);

            this.Canvas.DrawLine(new string(line.Border.Top, xp - x), x, this.Canvas.RowCursor);

            // Draw bottom margin
            for (int i = 0; i < line.Margin.Bottom; i++)
            {
                this.Canvas.DrawLine(
                    new string(' ', this.Canvas.Width),
                    x,
                    this.Canvas.RowCursor
                );
            }
        }

        public void Draw(Rectangle rectangle)
        {
            // Draw top margin
            for (int i = 0; i < rectangle.Margin.Top; i++)
            {
                this.Canvas.DrawLine(
                    new string(' ', this.Canvas.Width)
                );
            }

            // TODO: Fix Drawing
            int x = this.Canvas.ColumnCursor + rectangle.Margin.Left;
            int y = this.Canvas.RowCursor;

            int xp = this.Canvas.Width - rectangle.Margin.Right - 1;
            //int yp = this.Canvas.Height - rectangle.Margin.Bottom - 1;

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
            for (int i = 0; i < rectangle.Margin.Bottom; i++)
            {
                this.Canvas.DrawLine(
                    new string(' ', this.Canvas.Width)
                );
            }
        }

        public void Draw(Text text)
        {
            // TODO: Fix Text Drawing
        }

        public void Draw(Text text, int column, int row)
        {
            int x = this.Canvas.ColumnCursor + text.Margin.Left;
            int y = this.Canvas.RowCursor + text.Margin.Top;

            int xp = this.Canvas.Width - text.Margin.Right;
            int yp = this.Canvas.Height - text.Margin.Bottom;

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

        public void DrawText(string value, Margin margin)
        {
            this.Draw(new Text(value, margin));
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
