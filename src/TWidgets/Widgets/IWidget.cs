using TWidgets.Core.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TWidgets.Widgets
{
    public interface IWidget
    {
        event EventHandler<EventArgs> StateChanged;

        string Id { get; }

        Position Position { get; }

        //void Init();

        //void Load();

        void Mount();

        void Draw(Graphics g);

        void DrawComplete();

        void UnMount();

        //void Unload();
    }
}
