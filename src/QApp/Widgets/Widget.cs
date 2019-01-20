using System;
using System.Collections.Generic;
using System.Text;
using QApp.Core.Drawing;

namespace QApp.Widgets
{
    public abstract class Widget : IWidget
    {
        public event EventHandler<EventArgs> StateChanged;
        public void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, new EventArgs());
        }

        public string Id { get; private set; }

        public Position Position { get; private set; }

        public Widget(string id)
        {
            this.Id = id;
            this.Position = Position.Relative;
        }

        ~Widget()
        {
            this.UnMount();
        }

        //public virtual void Init() { }

        //public virtual void Load() { }

        public virtual void Mount() { }

        public abstract Canvas Draw(Graphics g);

        public virtual void DrawComplete() { }

        public virtual void UnMount() { }

        //public virtual void Unload() { }

        //public virtual void RenderCompleted() { }
    }
}
