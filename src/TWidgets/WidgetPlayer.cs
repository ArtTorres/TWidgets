using System;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Widgets;

namespace TWidgets
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
            //RenderEngine.Instance.BeforeRender += OnBeforeRender;
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
            // Before Draw
            widget.BeforeDraw();

            // Draw Widget
            var g = new Graphics(
                new Canvas(
                    RenderEngine.Instance.WindowWidth,
                    RenderEngine.Instance.WindowHeight
                )
            );
            widget.Draw(g);

            // Display on Console
            RenderEngine.Instance.SaveSystemColor();
            RenderEngine.Instance.SetForegroundColor(widget.ForegroundColor);
            RenderEngine.Instance.SetBackgroundColor(widget.BackgroundColor);
            RenderEngine.Instance.Display(g.Canvas);
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            this.DrawWidget((IWidget)sender);
        }

        private void OnBeforeRender(object sender, EventArgs e)
        {
            
        }

        private void OnRenderComplete(object sender, EventArgs e)
        {
            // Launch DrawComplete Event
            _widget.DrawComplete();

            // Reset Colors
            RenderEngine.Instance.LoadSystemColor();
        }
    }
}
