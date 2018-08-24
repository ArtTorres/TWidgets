using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Widgets
{
    public abstract class Widget : IWidget
    {
        public string Id { get; private set; }

        public Widget(string id)
        {
            this.Id = id;
        }

        ~Widget()
        {
            this.Unload();
        }

        public abstract void Init();
        public abstract void Load();
        public abstract void Draw();
        public abstract void DrawComplete();
        public abstract void Unload();
    }
}
