using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Drawing
{
    public class Graphics
    {
        private int _envWidth;
        public Canvas Canvas;

        public Graphics(Canvas canvas)
        {
            this.Canvas = canvas;
        }

        public void Draw(Line line, Margin margin)
        {

        }

        public void Draw(Rectangle rectangle, Margin margin, Padding padding)
        {

        }

        public void Draw(Text text)
        {

        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
    }
}
