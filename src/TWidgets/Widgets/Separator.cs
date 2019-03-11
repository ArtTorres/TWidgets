using System;
using TWidgets.Core.Drawing;

namespace TWidgets
{
    /// <summary>
    /// Represents a line separator in the <see cref="Console"/>.
    /// </summary>
    public class Separator : BoxTWidget
    {
        /// <summary>
        /// Initializes an instance of <see cref="Separator"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public Separator(string id) : base(id)
        { }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            g.Draw(new Line(this.Margin, this.Border));
        }
    }
}
