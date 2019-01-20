using System;
using System.Collections.Generic;
using System.Text;
using QApp.Core.Drawing;

namespace QApp.Widgets
{
    public abstract class Widget : IWidget
    {
        #region Instance

        public event EventHandler<EventArgs> StateChanged;
        public void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, new EventArgs());
        }

        #endregion

        public string Id { get; private set; }

        public Position Position { get; private set; }

        public Margin Margin { get; set; }

        public Padding Padding { get; set; }

        public Widget(string id)
        {
            this.Id = id;
            this.Position = Position.Relative;
            this.Margin = new Margin();
            this.Padding = new Padding();
        }

        ~Widget()
        {
            this.UnMount();
        }

        public virtual void Mount() { }

        public abstract void Draw(Graphics g);

        public virtual void DrawComplete() { }

        public virtual void UnMount() { }
    }
}
