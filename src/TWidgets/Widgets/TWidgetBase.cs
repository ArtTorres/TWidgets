using System;
using TWidgets.Core;
using TWidgets.Core.Drawing;

namespace TWidgets
{
    /// <summary>
    /// Implements the basic functionality common to widgets.
    /// </summary>
    public abstract class TWidgetBase : ITWidget, IMarginable
    {
        #region Events

        /// <summary>
        /// Occurs when a value of the widget changes.
        /// </summary>
        public event EventHandler<EventArgs> StateChanged;

        /// <summary>
        /// Raises the <see cref="StateChanged"/> event.
        /// </summary>
        public void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, new EventArgs());
        }

        #endregion

        /// <summary>
        /// Gets the identified of the widget.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the position of the widget.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the align property of the widget.
        /// </summary>
        public Align TextAlign { get; set; }

        /// <summary>
        /// Gets or sets the margin property of the widget.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the widget.
        /// </summary>
        public TWidgetColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the widget.
        /// </summary>
        public TWidgetColor BackgroundColor { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="TWidgetBase"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public TWidgetBase(string id)
        {
            this.Id = id;

            this.Position = Position.Relative;
            this.TextAlign = Align.Left;
            this.Margin = new Margin();

            this.ForegroundColor = TWidgetColor.System;
            this.BackgroundColor = TWidgetColor.System;
        }

        /// <summary>
        /// Destroys the instance of <see cref="TWidgetBase"/>.
        /// </summary>
        ~TWidgetBase()
        {
            this.UnMount();
        }

        /// <summary>
        /// Executes when the widget get mounted.
        /// </summary>
        public virtual void Mount() { }

        /// <summary>
        /// Executes when the widget is loaded.
        /// </summary>
        public virtual void Load() { }

        /// <summary>
        /// Executes before the widget is drawn.
        /// </summary>
        public virtual void BeforeDraw() { }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// Executes just before the widget is drawn.
        /// </summary>
        public virtual void DrawComplete() { }

        /// <summary>
        /// Executes just after the widget is unloaded.
        /// </summary>
        public virtual void Unload() { }

        /// <summary>
        /// Executes before the widget get unmounted.
        /// </summary>
        public virtual void UnMount() { }
    }
}
