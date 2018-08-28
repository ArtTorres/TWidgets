using QApp.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Widgets
{
    public interface IWidget
    {
        string Id { get; }

        void Init();
        void Load();
        void Draw(Graphics g);
        void DrawComplete();
        void Unload();
    }
}
