using System;
using TWidgets.Core.Drawing;

namespace TWidgets.Widgets
{
    public interface IWidget
    {
        event EventHandler<EventArgs> StateChanged;

        string Id { get; }

        Position Position { get; }

        WidgetColor ForegroundColor { get; set; }

        WidgetColor BackgroundColor { get; set; }

        void Mount();

        void BeforeDraw();

        void Draw(Graphics g);

        void DrawComplete();

        void UnMount();
    }
}
