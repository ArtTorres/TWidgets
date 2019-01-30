using TWidgets.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWidgets.Core.Drawing
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
            this.Canvas.DrawSpace(line.Margin.Top);

            int x = this.Canvas.ColumnCursor + line.Margin.Left;
            int xp = this.Canvas.Width - line.Margin.Right;

            this.Canvas.DrawLine(new string(line.Border.Top, xp - x), x, this.Canvas.RowCursor);

            // Draw bottom margin
            this.Canvas.DrawSpace(line.Margin.Bottom);
        }

        public void Draw(List list)
        {
            // Draw top margin
            this.Canvas.DrawSpace(list.Margin.Top);

            int x = this.Canvas.ColumnCursor + list.Margin.Left;

            foreach (var item in list.Items)
            {
                this.Canvas.DrawLine(item, x, this.Canvas.RowCursor);
            }

            // Draw bottom margin
            this.Canvas.DrawSpace(list.Margin.Bottom);
        }

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

        public void Draw(Text text)
        {
            this.Draw(text, this.Canvas.ColumnCursor);
        }

        public void Draw(Text text, int column)
        {
            this.Draw(text, column, this.Canvas.RowCursor);
        }

        public void Draw(Text text, int column, int row)
        {
            int x = this.Canvas.ColumnCursor + text.Margin.Left;
            int y = this.Canvas.RowCursor + text.Margin.Top;

            // Draw top margin
            this.Canvas.DrawSpace(text.Margin.Top);

            this.Canvas.DrawLine(text.Value, x, y);

            // Draw bottom margin
            this.Canvas.DrawSpace(text.Margin.Bottom);
        }

        public void Draw(string value, int column, int row)
        {
            this.Canvas.Draw(value, column, row);
        }

        public void ResetCursors()
        {
            this.Canvas.ColumnCursor = 0;
            this.Canvas.RowCursor = 0;
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
