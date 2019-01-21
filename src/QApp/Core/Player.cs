using QApp.Core.Drawing;
using QApp.Widgets;
using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core
{
    public class Player
    {
        #region Instance

        private static readonly Lazy<Player> instance = new Lazy<Player>(() => new Player());
        private IWidget _widget;

        public static Player Instance
        {
            get
            {
                return instance.Value;
            }
        }

        #endregion

        public Player()
        {
            RenderEngine.Instance.RenderComplete += OnRenderComplete;
        }

        public void Mount(IWidget widget)
        {
            if (null != _widget)
            {
                this.UnMount();
            }

            _widget = widget;
            _widget.StateChanged += OnStateChanged;

            // Launch Mount Event
            _widget.Mount();

            this.DrawWidget(_widget);
        }

        public void UnMount()
        {
            _widget.StateChanged -= OnStateChanged;
            _widget = null;
        }

        private void DrawWidget(IWidget widget)
        {
            // Draw Widget
            var g = new Graphics(
                new Canvas(
                    RenderEngine.Instance.WindowWidth,
                    RenderEngine.Instance.WindowHeight
                )
            );
            widget.Draw(g);

            // Display on Console
            RenderEngine.Instance.Display(g.Canvas);
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            this.DrawWidget((IWidget)sender);
        }

        private void OnRenderComplete(object sender, EventArgs e)
        {
            // Launch DrawComplete Event
            _widget.DrawComplete();
        }
    }
}
