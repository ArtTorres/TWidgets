using System;
using System.Collections.Generic;
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
            this.Canvas.Draw(new string('-',this.Canvas.Width));
        }

        public void Draw(Rectangle rectangle, Margin margin, Padding padding)
        {

        }

        public void DrawRectangle()
        {

        }

        public void Draw(Text text)
        {

        }

        public void DrawText(string value, Margin margin = new Margin())
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
