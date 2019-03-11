using System;
using TWidgets.Core.Drawing;

namespace TWidgets.Core
{
    /// <summary>
    /// Provides the functions to implement a TWidget.
    /// </summary>
    public interface ITWidget
    {
        /// <summary>
        /// Occurs when a value of the widget changes.
        /// </summary>
        event EventHandler<EventArgs> StateChanged;

        /// <summary>
        /// Gets the identified of the widget.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets or sets the position of the widget.
        /// </summary>
        Position Position { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the widget.
        /// </summary>
        TWidgetColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the widget.
        /// </summary>
        TWidgetColor BackgroundColor { get; set; }

        /// <summary>
        /// Executes when the widget get mounted.
        /// </summary>
        void Mount();

        /// <summary>
        /// Executes when the widget is loaded.
        /// </summary>
        void Load();

        /// <summary>
        /// Executes before the widget is drawn.
        /// </summary>
        void BeforeDraw();

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        void Draw(Graphics g);

        /// <summary>
        /// Executes just before the widget is drawn.
        /// </summary>
        void DrawComplete();

        /// <summary>
        /// Executes just after the widget is unloaded.
        /// </summary>
        void Unload();

        /// <summary>
        /// Executes before the widget get unmounted.
        /// </summary>
        void UnMount();
    }
}
