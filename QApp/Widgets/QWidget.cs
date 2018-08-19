using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Widgets
{
    public abstract class QWidget
    {
        public abstract void Init();
        public abstract void Load();
        public abstract void Draw();
        public abstract void DrawComplete();
        public abstract void Unload();
    }
}
