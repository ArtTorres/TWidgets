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

        public static IWidget Widget
        {
            get
            {
                return Instance._widget;
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

        private InputFlow _inputFlow;

        private IWidget _widget;

        private IEnumerable<string> _errorMessages;

        public WidgetPlayer()
        {
            RenderEngine.Instance.BeforeRender += OnBeforeRender;
            RenderEngine.Instance.RenderComplete += OnRenderComplete;

            InputEngine.Instance.Captured += OnCaptured;

            _inputFlow = new InputFlow();
        }

        private void MountWidget(IWidget widget, bool autoplay = true)
        {
            if (null != _widget)
            {
                this.UnMountWidget();
            }

            _widget = widget;

            // Set Events
            _widget.StateChanged += OnStateChanged;

            // Save initial position for Fixed widgets
            if (Position.Fixed == _widget.Position)
            {
                InputEngine.Instance.SaveSystemCursor();
            }

            if (_widget is IInputWidget)
            {
                _inputFlow.Start();
            }

            // Launch Mount Event
            _widget.Mount();

            if (autoplay)
                this.PlayWidget();
        }

        private void UnMountWidget()
        {
            // Unset Events
            _widget.StateChanged -= OnStateChanged;

            _widget.UnMount();
            _widget = null;
        }

        private void PlayWidget()
        {
            // Before Draw
            _widget.BeforeDraw();

            if (_widget is IInputWidget)
            {
                this.DrawInputWidget(_widget);
            }
            else
            {
                this.DrawSimpleWidget(_widget);
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
                switch (_inputFlow.NextState())
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
                            _inputFlow.Action = InputFlow.Actions.Continue;
                        }
                        else
                        {
                            _inputFlow.Action = InputFlow.Actions.Ok;
                        }
                        break;
                    case InputFlow.States.Footer:
                        this.FooterStep(input);
                        break;
                }
            } while (_inputFlow.State != InputFlow.States.End);
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
            RenderEngine.Instance.SetForegroundColor(_widget.ForegroundColor);
            RenderEngine.Instance.SetBackgroundColor(_widget.BackgroundColor);
            RenderEngine.Instance.Display(g.Canvas);
        }

        #region Input Steps

        private void HeaderStep(IInputWidget widget)
        {
            var g = GetGraphics();

            widget.DrawHeader(g);

            this.Display(g);

            _inputFlow.Action = InputFlow.Actions.Continue;
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
                _inputFlow.Action = InputFlow.Actions.Ok;
            }
            else
            {
                _inputFlow.Action = InputFlow.Actions.Continue;
            }
        }

        private void FooterStep(IInputWidget widget)
        {
            var g = GetGraphics();

            widget.DrawFooter(g);

            this.Display(g);

            _inputFlow.Action = InputFlow.Actions.Continue;
        }

        #endregion

        #region Widget Events

        private void OnStateChanged(object sender, EventArgs e)
        {
            this.PlayWidget();
        }

        #endregion

        #region RenderEngine Events

        private void OnBeforeRender(object sender, EventArgs e)
        {
            // Restart position for Fixed widgets
            if (Position.Fixed == _widget.Position)
            {
                InputEngine.Instance.Cursor = InputEngine.Instance.SystemCursor;
            }
        }

        private void OnRenderComplete(object sender, EventArgs e)
        {
            // Launch DrawComplete Event
            _widget.DrawComplete();

            // Reset Colors
            RenderEngine.Instance.LoadSystemColor();
        }

        #endregion

        #region InputEngine Events

        private void OnCaptured(object sender, Core.Events.InputEventArgs e)
        {
            var result = (_widget as IInputWidget).ValidateInput(e.Id, e.Value);

            switch (result.State)
            {
                case ValidationState.Invalid:
                    _errorMessages = result.Messages;
                    _inputFlow.Action = InputFlow.Actions.Error;
                    break;
                case ValidationState.Repeat:
                    _inputFlow.Action = InputFlow.Actions.Continue;
                    break;
                case ValidationState.Valid:
                    (_widget as IInputWidget).MapValues(e.Id, e.Value);
                    _inputFlow.Action = InputFlow.Actions.Ok;
                    break;
            }
        }

        #endregion
    }
}
