using System;
using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    /// <summary>
    /// Represents a text message preceded by a character animation in the <see cref="Console"/>.
    /// </summary>
    public class ProgressChar : Message
    {
        private int _frame = 0; // The initial frame.

        /// <summary>
        /// Gets or sets the character animation.
        /// </summary>
        public char[] Animation { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="ProgressChar"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public ProgressChar(string id) : base(id)
        {
            this.Animation = TextAnimation.BARS;
            this.Position = Position.Fixed;
        }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            g.Draw(new Text(
                $"{Animation[_frame]} {this.Text}",
                this.Margin
                )
            );
        }

        /// <summary>
        /// Executes just before the widget is drawn.
        /// </summary>
        public override void DrawComplete()
        {
            if (++_frame >= Animation.Length) _frame = 0;
        }
    }
}
