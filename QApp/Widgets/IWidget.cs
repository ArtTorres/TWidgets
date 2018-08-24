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
        void Draw();
        void DrawComplete();
        void Unload();
    }
}
