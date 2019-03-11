using System;
using TWidgets.Core.Drawing;
using TWidgets.Core.Utils;

namespace TWidgets
{
    /// <summary>
    /// Represents a text marquee in the <see cref="Console"/>.
    /// </summary>
    public class Marquee : BoxTWidget
    {
        /// <summary>
        /// Gets or sets the <see cref="Marquee"/> padding.
        /// </summary>
        public Padding Padding { get; set; }

        /// <summary>
        /// Gets or sets the list items.
        /// </summary>
        public string[] Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                this.OnStateChanged();
            }
        }
        private string[] _items;

        /// <summary>
        /// Initializes an instance of <see cref="Marquee"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public Marquee(string id) : base(id)
        {
            this.Padding = new Padding();
            this.TextAlign = Align.Center;
        }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            // Draw Rectangle
            int rectangleHeight = this.Items.Length + (this.Border.Width * 2) + this.Padding.Top + this.Padding.Bottom;
            g.Draw(
                new Rectangle(
                    g.Canvas.Width,
                    rectangleHeight,
                    this.Margin,
                    this.Border
                )
            );

            g.ResetCursors();

            // Draw List inside Rectangle
            var textMargin = new Margin(
                Margin.Top + Border.Width + Padding.Top,
                Margin.Left + Border.Width + Padding.Left,
                Margin.Bottom + Border.Width + Padding.Bottom,
                Margin.Right + Border.Width + Padding.Right
            );

            int maxWidth = g.Canvas.Width - textMargin.Left - textMargin.Right;
            g.Draw(
                new List(
                    TextUtils.ResizeLines(
                        this.Items,
                        maxWidth
                    ),
                    textMargin
                )
                {
                    Align = this.TextAlign
                }
            );
        }
    }
}
