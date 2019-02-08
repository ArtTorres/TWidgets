using System;
using TWidgets.Core.Drawing;
using TWidgets.Util;
using TWidgets.Widgets;

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

        public event EventHandler<EventArgs> BeforeRender;
        public void OnBeforeRender()
        {
            this.BeforeRender?.Invoke(this, new EventArgs());
        }

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

        public int WindowForegroundColor { get; private set; }

        public int WindowBackgroundColor { get; private set; }

        private RenderEngine()
        {
            this.SaveSystemColor();
        }

        public void Display(Canvas canvas)
        {
            this.OnBeforeRender();
            this.WriteCanvas(canvas.Map);
            this.OnRenderComplete();
        }

        private void WriteCanvas(string[] map)
        {
            foreach (var line in map)
            {
                Console.Write(line);
            }
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

        public void SaveSystemColor()
        {
            this.WindowForegroundColor = (int)Console.ForegroundColor;
            this.WindowBackgroundColor = (int)Console.BackgroundColor;
        }

        public void LoadSystemColor()
        {
            Console.ForegroundColor = (ConsoleColor)this.WindowForegroundColor;
            Console.BackgroundColor = (ConsoleColor)this.WindowBackgroundColor;
        }

        public void SetForegroundColor(WidgetColor color)
        {
            if (WidgetColor.System == color)
                Console.ForegroundColor = (ConsoleColor)this.WindowForegroundColor;
            else
                Console.ForegroundColor = (ConsoleColor)(int)color;
        }

        public void SetBackgroundColor(WidgetColor color)
        {
            if (WidgetColor.System == color)
                Console.BackgroundColor = (ConsoleColor)this.WindowBackgroundColor;
            else
                Console.BackgroundColor = (ConsoleColor)(int)color;
        }

        #endregion
    }
}
