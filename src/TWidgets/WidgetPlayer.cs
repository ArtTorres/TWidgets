using System;
using TWidgets.Core;
using TWidgets.Core.Drawing;

namespace TWidgets
{
    public class WidgetPlayer
    {
        #region Instance

        private static readonly Lazy<WidgetPlayer> instance = new Lazy<WidgetPlayer>(() => new WidgetPlayer());

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

        public IWidget Widget { get; private set; }

        //public bool DrawOnMount { get; set; } = true;

        public WidgetPlayer()
        {
            RenderEngine.Instance.BeforeRender += OnBeforeRender;
            RenderEngine.Instance.RenderComplete += OnRenderComplete;
        }

        private void MountWidget(IWidget widget, bool drawOnMount = true)
        {
            if (null != Widget)
            {
                this.UnMountWidget();
            }

            Widget = widget;

            // Set Events
            Widget.StateChanged += OnStateChanged;

            // Save initial position for Fixed widgets
            if (Position.Fixed == Widget.Position)
            {
                InputEngine.Instance.SaveSystemCursor();
            }

            //if (Widget is IInput)
            //{
            //    var input = (IInput)Widget;
            //    input.StartCapture += OnStartCapture;
            //    input.EndCapture += OnEndCapture;
            //    input.InputCaptured += OnInputCapture;
            //}

            // Launch Mount Event
            Widget.Mount();

            if (drawOnMount)
                this.PlayWidget();
        }

        private void UnMountWidget()
        {
            // Unset Events
            Widget.StateChanged -= OnStateChanged;

            //if (Widget is IInput)
            //{
            //    var input = (IInput)Widget;
            //    input.StartCapture -= OnStartCapture;
            //    input.EndCapture -= OnEndCapture;
            //    input.InputCaptured -= OnInputCapture;
            //}

            Widget.UnMount();
            Widget = null;
        }

        private void PlayWidget()
        {
            if (Widget is IInput)
            {
                // TODO: implement input widgets
                var input = (IInput)Widget;

                var g = new Graphics(
                    new Canvas(
                        RenderEngine.Instance.WindowWidth,
                        RenderEngine.Instance.WindowHeight
                    )
                );

                input.BeforeCapture(g);

                this.DrawWidget(Widget);

                Widget.Draw(g);
                input.StartCapture();

                input.MapValues(null);

                switch (input.ValidateInput())
                {
                    case ValidationState.Valid:
                        input.AfterCapture(g);
                        break;
                    case ValidationState.Invalid:
                        input.DisplayError(g, null);
                        PlayWidget();
                        break;
                    case ValidationState.Repeat:
                        PlayWidget();
                        break;
                }
            }
            else
            {
                this.DrawWidget(Widget);
            }
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
            // Restart position for Fixed widgets
            if (Position.Fixed == Widget.Position)
            {
                InputEngine.Instance.Cursor = InputEngine.Instance.SystemCursor;
            }
        }

        private void OnRenderComplete(object sender, EventArgs e)
        {
            // Launch DrawComplete Event
            Widget.DrawComplete();

            // Reset Colors
            RenderEngine.Instance.LoadSystemColor();
        }

        //private void OnStartCapture(object sender, EventArgs e)
        //{
        //}

        //private void OnEndCapture(object sender, EventArgs e)
        //{
        //}

        //private void OnInputCapture(object sender, EventArgs e)
        //{
        //}
    }
}
