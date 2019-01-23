using QApp.Core;
using QApp.Core.Drawing;
using QApp.Widgets;
using System;
using System.Collections.Generic;
using System.Text;

namespace QApp
{
    public class WidgetPlayer
    {
        #region Instance

        private static readonly Lazy<WidgetPlayer> instance = new Lazy<WidgetPlayer>(() => new WidgetPlayer());
        private IWidget _widget;

        private static WidgetPlayer Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public static void Mount(IWidget widget)
        {
            Instance.MountWidget(widget);
        }

        public static void UnMount()
        {
            Instance.UnMountWidget();
        }

        #endregion

        public WidgetPlayer()
        {
            RenderEngine.Instance.RenderComplete += OnRenderComplete;
        }

        private void MountWidget(IWidget widget)
        {
            if (null != _widget)
            {
                this.UnMountWidget();
            }

            _widget = widget;
            _widget.StateChanged += OnStateChanged;

            // Launch Mount Event
            _widget.Mount();

            this.DrawWidget(_widget);
        }

        private void UnMountWidget()
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
