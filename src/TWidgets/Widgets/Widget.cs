using System;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    public abstract class Widget : IWidget, IMarginable
    {
        #region Events

        public event EventHandler<EventArgs> StateChanged;
        public void OnStateChanged()
        {
            this.StateChanged?.Invoke(this, new EventArgs());
        }

        #endregion

        public string Id { get; private set; }

        public Position Position { get; set; }

        public WidgetColor ForegroundColor { get; set; }

        public WidgetColor BackgroundColor { get; set; }

        public Margin Margin { get; set; }

        public Widget(string id)
        {
            this.Id = id;

            this.Position = Position.Relative;
            this.Margin = new Margin();

            this.ForegroundColor = WidgetColor.System;
            this.BackgroundColor = WidgetColor.System;
        }

        ~Widget()
        {
            this.UnMount();
        }

        public virtual void Mount() { }

        public virtual void Load() { }

        public virtual void BeforeDraw() { }

        public abstract void Draw(Graphics g);

        public virtual void DrawComplete() { }

        public virtual void Unload() { }

        public virtual void UnMount() { }
    }
}
