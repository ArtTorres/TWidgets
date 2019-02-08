using System;
using System.Collections.Generic;
using System.Linq;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Core.IO;

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

        private IEnumerable<string> _errorMessages;

        public WidgetPlayer()
        {
            RenderEngine.Instance.BeforeRender += OnBeforeRender;
            RenderEngine.Instance.RenderComplete += OnRenderComplete;

            InputEngine.Instance.Captured += OnCaptured;
        }

        private void MountWidget(IWidget widget, bool autoplay = true)
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

            if (Widget is IInputWidget)
            {
                //var input = (IInput)Widget;
                //input.StartCapture += OnStartCapture;
                //input.EndCapture += OnEndCapture;
                //input.InputCaptured += OnInputCapture;

                InputFlow.Instance.Start();
            }

            // Launch Mount Event
            Widget.Mount();

            if (autoplay)
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
            // Before Draw
            Widget.BeforeDraw();

            if (Widget is IInputWidget)
            {
                this.DrawInputWidget(Widget);
            }
            else
            {
                this.DrawWidget(Widget);
            }
        }

        private void DrawInputWidget(IWidget widget)
        {
            var input = (IInputWidget)widget;

            var actions = input.InputActions().ToArray();
            int ix = 0;

            do
            {
                switch (InputFlow.Instance.NextState())
                {
                    case InputFlow.States.Header:
                        var g = New();

                        input.DrawHeader(g);

                        this.Draw(g);

                        InputFlow.Instance.Action = InputFlow.Actions.Continue;
                        break;
                    case InputFlow.States.Capture:

                        //InputEngine.Instance.Cursor = input.Cursor;

                        var gc = New();
                        widget.Draw(gc);
                        this.Draw(gc);

                        InputEngine.Instance.Capture(actions[ix].id, actions[ix].method);
                        break;
                    case InputFlow.States.Error:
                        if (actions[ix].action != ValidateAction.Ignore)
                        {
                            var ge = New();
                            input.DrawError(ge, _errorMessages);
                            this.Draw(ge);
                        }
                        if (actions[ix].action == ValidateAction.Repeat)
                        {
                            InputFlow.Instance.Action = InputFlow.Actions.Ok;
                        }
                        else
                        {
                            InputFlow.Instance.Action = InputFlow.Actions.Continue;
                        }
                        break;
                    case InputFlow.States.Control:
                        if (ix < actions.Length - 1)
                        {
                            ix++;
                            InputFlow.Instance.Action = InputFlow.Actions.Continue;
                        }
                        else
                        {
                            InputFlow.Instance.Action = InputFlow.Actions.Ok;
                        }
                        break;
                    case InputFlow.States.Footer:

                        var gf = New();
                        input.DrawFooter(gf);
                        this.Draw(gf);

                        InputFlow.Instance.Action = InputFlow.Actions.Continue;
                        break;
                }
            } while (InputFlow.Instance.State != InputFlow.States.End);
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
            RenderEngine.Instance.SaveSystemColor();
            RenderEngine.Instance.SetForegroundColor(widget.ForegroundColor);
            RenderEngine.Instance.SetBackgroundColor(widget.BackgroundColor);
            RenderEngine.Instance.Display(g.Canvas);
        }

        private Graphics New()
        {
            return new Graphics(
                new Canvas(
                    RenderEngine.Instance.WindowWidth,
                    RenderEngine.Instance.WindowHeight
                )
            );
        }

        private void Draw(Graphics g)
        {
            RenderEngine.Instance.SaveSystemColor();
            RenderEngine.Instance.SetForegroundColor(Widget.ForegroundColor);
            RenderEngine.Instance.SetBackgroundColor(Widget.BackgroundColor);
            RenderEngine.Instance.Display(g.Canvas);
        }

        #region Steps



        #endregion

        #region Widget Events

        private void OnStateChanged(object sender, EventArgs e)
        {
            this.DrawWidget((IWidget)sender);
        }

        #endregion

        #region RenderEngine Events

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

        #endregion

        #region InputEngine Events

        private void OnCaptured(object sender, Core.Events.InputEventArgs e)
        {
            var result = (Widget as IInputWidget).ValidateInput(e.Id, e.Value);

            switch (result.State)
            {
                case ValidationState.Invalid:
                    _errorMessages = result.Messages;
                    InputFlow.Instance.Action = InputFlow.Actions.Error;
                    break;
                case ValidationState.Repeat:
                    InputFlow.Instance.Action = InputFlow.Actions.Continue;
                    break;
                case ValidationState.Valid:
                    (Widget as IInputWidget).MapValues(e.Id, e.Value);
                    InputFlow.Instance.Action = InputFlow.Actions.Ok;
                    break;
            }
        }

        #endregion

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
