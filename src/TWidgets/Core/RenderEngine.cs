using TWidgets.Core.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TWidgets.Core
{
    internal sealed class RenderEngine
    {
        #region Instance

        private static readonly Lazy<RenderEngine> instance = new Lazy<RenderEngine>(() => new RenderEngine());

        public static RenderEngine Instance
        {
            get
            {
                return instance.Value;
            }
        }

        #endregion

        public event EventHandler<EventArgs> RenderComplete;
        public void OnRenderComplete()
        {
            this.RenderComplete?.Invoke(this, new EventArgs());
        }

        public int WindowWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

        public int WindowHeight
        {
            get
            {
                return Console.WindowHeight;
            }
        }

        public void Display(Canvas canvas)
        {
            this.WriteCanvas(canvas.Map);
            this.OnRenderComplete();
        }

        private void WriteCanvas(string[] map)
        {
            foreach(var line in map)
            {
                Console.Write(line);
            }

            //Console.Write("\n");
        }

        #region Write Tools

        private void Write(string value)
        {
            Console.Write(value);
        }

        private void Write(string value, int row, int column)
        {
            Console.SetCursorPosition(column, row);
            this.Write(value);
        }

        private void Clear()
        {
            Console.Clear();
        }

        private void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private void SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        #endregion
    }
}
