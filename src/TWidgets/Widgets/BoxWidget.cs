using TWidgets.Core.Drawing;

namespace TWidgets.Widgets
{
    public abstract class BoxWidget : Widget, IBordeable
    {
        public Border Border { get; private set; }

        public int Width { get; set; } = 0;

        public BoxWidget(string id) : base(id)
        {
            this.Border = new Border();
        }
    }
}
