using System;
using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Core
{
    /// <summary>
    /// Performs display operations in the system <see cref="Console"/>.
    /// </summary>
    internal sealed class RenderEngine
    {
        #region Instance

        /// <summary>
        /// Gets an instance of <see cref="RenderEngine"/>.
        /// </summary>
        public static RenderEngine Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private static readonly Lazy<RenderEngine> _instance = new Lazy<RenderEngine>(() => new RenderEngine());

        #endregion

        /// <summary>
        /// Occurs before display a <see cref="Canvas"/>.
        /// </summary>
        public event EventHandler<EventArgs> BeforeRender;

        /// <summary>
        /// Raises the <see cref="BeforeRender"/> event.
        /// </summary>
        public void OnBeforeRender()
        {
            this.BeforeRender?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Occurs after display a <see cref="Canvas"/>.
        /// </summary>
        public event EventHandler<EventArgs> RenderComplete;

        /// <summary>
        /// Raises the <see cref="RenderComplete"/> event.
        /// </summary>
        public void OnRenderComplete()
        {
            this.RenderComplete?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Gets the width of the <see cref="Console"/> window.
        /// </summary>
        public int WindowWidth
        {
            get
            {
                return Console.WindowWidth;
            }
        }

        /// <summary>
        /// Gets the height of the <see cref="Console"/> window.
        /// </summary>
        public int WindowHeight
        {
            get
            {
                return Console.WindowHeight;
            }
        }

        /// <summary>
        /// Gets the current foreground color.
        /// </summary>
        public int WindowForegroundColor { get; private set; }

        /// <summary>
        /// Gets the current background color.
        /// </summary>
        public int WindowBackgroundColor { get; private set; }

        /// <summary>
        /// Initializes an instance of <see cref="RenderEngine"/>.
        /// </summary>
        private RenderEngine()
        {
            this.SaveSystemColor();
        }

        /// <summary>
        /// Displays an instance of <see cref="Canvas"/> in <see cref="Console"/>.
        /// </summary>
        /// <param name="canvas"></param>
        public void Display(Canvas canvas)
        {
            this.OnBeforeRender();
            this.WriteCanvas(canvas.Map);
            this.OnRenderComplete();
        }

        /// <summary>
        /// Writes the text representation of <see cref="Canvas"/> in <see cref="Console"/>.
        /// </summary>
        /// <param name="map">A text representation of a <see cref="Canvas"/>.</param>
        private void WriteCanvas(string[] map)
        {
            foreach (var line in map)
            {
                Console.Write(line);
            }
        }

        #region Write Tools

        /// <summary>
        /// Removes all the content in <see cref="Console"/>.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Saves the current color of the <see cref="Console"/> in a temporal cache.
        /// </summary>
        public void SaveSystemColor()
        {
            this.WindowForegroundColor = (int)Console.ForegroundColor;
            this.WindowBackgroundColor = (int)Console.BackgroundColor;
        }

        /// <summary>
        /// Sets in <see cref="Console"/> a set of colors from cache.
        /// </summary>
        public void LoadSystemColor()
        {
            Console.ForegroundColor = (ConsoleColor)this.WindowForegroundColor;
            Console.BackgroundColor = (ConsoleColor)this.WindowBackgroundColor;
        }

        /// <summary>
        /// Sets the foreground color in <see cref="Console"/>.
        /// </summary>
        /// <param name="color"></param>
        public void SetForegroundColor(WidgetColor color)
        {
            if (WidgetColor.System == color)
                Console.ForegroundColor = (ConsoleColor)this.WindowForegroundColor;
            else
                Console.ForegroundColor = (ConsoleColor)(int)color;
        }

        /// <summary>
        /// Sets the background color in <see cref="Console"/>.
        /// </summary>
        /// <param name="color">A specified <see cref="WidgetColor"/>.</param>
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
