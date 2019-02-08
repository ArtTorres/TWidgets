using System;
using System.Collections.Generic;
using System.Linq;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;

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
                this.DrawSimpleWidget(Widget);
            }
        }

        private void DrawSimpleWidget(IWidget widget)
        {
            // Draw Widget
            var g = this.GetGraphics();

            widget.Draw(g);

            // Display on Console
            this.Display(g);
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
                        this.HeaderStep(input);
                        break;
                    case InputFlow.States.Capture:
                        this.CaptureStep(actions[ix], input);
                        break;
                    case InputFlow.States.Error:

                        this.ErrorStep(actions[ix], input);
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
                        this.FooterStep(input);
                        break;
                }
            } while (InputFlow.Instance.State != InputFlow.States.End);
        }

        private Graphics GetGraphics()
        {
            return new Graphics(
                new Canvas(
                    RenderEngine.Instance.WindowWidth,
                    RenderEngine.Instance.WindowHeight
                )
            );
        }

        private void Display(Graphics g)
        {
            RenderEngine.Instance.SaveSystemColor();
            RenderEngine.Instance.SetForegroundColor(Widget.ForegroundColor);
            RenderEngine.Instance.SetBackgroundColor(Widget.BackgroundColor);
            RenderEngine.Instance.Display(g.Canvas);
        }

        #region Input Steps

        private void HeaderStep(IInputWidget widget)
        {
            var g = GetGraphics();

            widget.DrawHeader(g);

            this.Display(g);

            InputFlow.Instance.Action = InputFlow.Actions.Continue;
        }

        private void CaptureStep(InputAction action, IInputWidget widget)
        {
            var g = GetGraphics();

            (widget as IWidget).Draw(g);

            this.Display(g);

            InputEngine.Instance.SaveSystemCursor();
            InputEngine.Instance.Cursor = new InputCursor(
                widget.CursorPosition.X,
                InputEngine.Instance.SystemCursor.Y + widget.CursorPosition.Y - 1
            );
            InputEngine.Instance.Capture(action.id, action.method);
        }

        private void ErrorStep(InputAction action, IInputWidget widget)
        {
            if (action.action != ValidateAction.Ignore)
            {
                var g = GetGraphics();

                widget.DrawError(g, _errorMessages);

                this.Display(g);
            }
            if (action.action == ValidateAction.Repeat)
            {
                InputFlow.Instance.Action = InputFlow.Actions.Ok;
            }
            else
            {
                InputFlow.Instance.Action = InputFlow.Actions.Continue;
            }
        }

        private void FooterStep(IInputWidget widget)
        {
            var g = GetGraphics();

            widget.DrawFooter(g);

            this.Display(g);

            InputFlow.Instance.Action = InputFlow.Actions.Continue;
        }

        #endregion

        #region Widget Events

        private void OnStateChanged(object sender, EventArgs e)
        {
            this.DrawSimpleWidget((IWidget)sender);
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
    }
}
