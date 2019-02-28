using TWidgets.Core.Drawing;

namespace TWidgets.Widgets
{
    /// <summary>
    /// Implements the basic functionality common to box type widgets.
    /// </summary>
    public abstract class BoxWidget : Widget, IBordeable
    {
        /// <summary>
        ///  Gets the border property of the widget.
        /// </summary>
        public Border Border { get; private set; }

        /// <summary>
        /// Gets or sets the width size of the widget.
        /// </summary>
        public int Width { get; set; } = 0;

        /// <summary>
        /// Initializes an instance of <see cref="BoxWidget"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public BoxWidget(string id) : base(id)
        {
            this.Border = new Border();
        }
    }
}
