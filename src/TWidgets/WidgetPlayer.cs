using System;
using System.Collections.Generic;
using System.Linq;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;

namespace TWidgets
{
    /// <summary>
    /// Displays the mounted <see cref="IWidget"/> in the system <see cref="Console"/>.This class cannot be inherited.
    /// </summary>
    public sealed class WidgetPlayer
    {
        #region Instance

        /// <summary>
        /// Gets an instance of <see cref="WidgetPlayer"/>.
        /// </summary>
        private static WidgetPlayer Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private static readonly Lazy<WidgetPlayer> _instance = new Lazy<WidgetPlayer>(() => new WidgetPlayer());

        /// <summary>
        /// Gets the <see cref="IWidget"/> mounted.
        /// </summary>
        public static IWidget Widget
        {
            get
            {
                return Instance._widget;
            }
        }

        /// <summary>
        /// Mounts a <see cref="IWidget"/> in the player.
        /// </summary>
        /// <param name="widget"></param>
        public static void Mount(IWidget widget)
        {
            Instance.MountWidget(widget);
        }

        /// <summary>
        /// Unmounts a <see cref="IWidget"/> from the player.
        /// </summary>
        public static void Unmount()
        {
            Instance.UnmountWidget();
        }

        #endregion

        private InputFlow _inputFlow;
        private IWidget _widget;
        private IEnumerable<string> _errorMessages;

        /// <summary>
        /// Initializes an instance of <see cref="WidgetPlayer"/>.
        /// </summary>
        private WidgetPlayer()
        {
            RenderEngine.Instance.BeforeRender += OnBeforeRender;
            RenderEngine.Instance.RenderComplete += OnRenderComplete;

            InputEngine.Instance.Captured += OnCaptured;

            _inputFlow = new InputFlow();
        }

        /// <summary>
        /// Initializes an instance of <see cref="WidgetPlayer"/>.
        /// </summary>
        /// <param name="widget">The widget to be played.</param>
        /// <param name="autoplay">Play on mount.</param>
        private void MountWidget(IWidget widget, bool autoplay = true)
        {
            if (null != _widget)
            {
                this.UnmountWidget();
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

        /// <summary>
        /// Unmounts the mounted <see cref="IWidget"/>.
        /// </summary>
        private void UnmountWidget()
        {
            // Unset Events
            _widget.StateChanged -= OnStateChanged;

            _widget.UnMount();
            _widget = null;
        }

        /// <summary>
        /// Displays the <see cref="IWidget"/> in the system <see cref="Console"/>.
        /// </summary>
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

        /// <summary>
        /// Displays the <see cref="IWidget"/> in the system <see cref="Console"/>.
        /// </summary>
        /// <param name="widget">The widget to be displayed.</param>
        private void DrawSimpleWidget(IWidget widget)
        {
            // Draw Widget
            var g = this.GetNewGraphics();

            widget.Draw(g);

            // Display on Console
            this.Display(g);
        }

        /// <summary>
        /// Displays the <see cref="IInputWidget"/> in the system <see cref="Console"/>.
        /// </summary>
        /// <param name="widget">The widget to be displayed.</param>
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
                        HeaderStep();
                        break;
                    case InputFlow.States.Capture:
                        CaptureStep(actions[ix]);
                        break;
                    case InputFlow.States.Error:

                        ErrorStep(actions[ix]);
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
                        FooterStep();
                        break;
                }
            } while (_inputFlow.State != InputFlow.States.End);

            void HeaderStep()
            {
                var g = GetNewGraphics();

                input.DrawHeader(g);

                this.Display(g);

                _inputFlow.Action = InputFlow.Actions.Continue;
            }

            // Displays Input on capture messages.
            void CaptureStep(InputAction action)
            {
                var g = GetNewGraphics();

                (widget as IWidget).Draw(g);

                this.Display(g);

                InputEngine.Instance.SaveSystemCursor();
                InputEngine.Instance.Cursor = new InputCursor(
                    input.CursorPosition.X,
                    InputEngine.Instance.SystemCursor.Y + input.CursorPosition.Y - 1
                );
                InputEngine.Instance.Capture(action.Id, action.Method);
            }

            // Displays Input Errors
            void ErrorStep(InputAction action)
            {
                if (action.Action != ValidateAction.Ignore)
                {
                    var g = GetNewGraphics();

                    input.DrawError(g, _errorMessages);

                    this.Display(g);
                }
                if (action.Action == ValidateAction.Repeat)
                {
                    _inputFlow.Action = InputFlow.Actions.Ok;
                }
                else
                {
                    _inputFlow.Action = InputFlow.Actions.Continue;
                }
            }

            // Displays Input Footer
            void FooterStep()
            {
                var g = GetNewGraphics();

                input.DrawFooter(g);

                this.Display(g);

                _inputFlow.Action = InputFlow.Actions.Continue;
            }
        }

        /// <summary>
        /// Gets a new instance of <see cref="Graphics"/>.
        /// </summary>
        /// <returns></returns>
        private Graphics GetNewGraphics()
        {
            return new Graphics(
                new Canvas(
                    RenderEngine.Instance.WindowWidth,
                    RenderEngine.Instance.WindowHeight
                )
            );
        }

        /// <summary>
        /// Displays a <see cref="Graphics"/> in the <see cref="RenderEngine"/>.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        private void Display(Graphics g)
        {
            RenderEngine.Instance.SaveSystemColor();
            RenderEngine.Instance.SetForegroundColor(_widget.ForegroundColor);
            RenderEngine.Instance.SetBackgroundColor(_widget.BackgroundColor);
            RenderEngine.Instance.Display(g.Canvas);
        }

        #region Input Steps



        #endregion

        #region Widget Events

        /// <summary>
        /// Invoked when the state of a <see cref="IWidget"/> changed.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event object.</param>
        private void OnStateChanged(object sender, EventArgs e)
        {
            this.PlayWidget();
        }

        #endregion

        #region RenderEngine Events

        /// <summary>
        /// Invoked before the Render occurres on <see cref="RenderEngine"/>.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event object.</param>
        private void OnBeforeRender(object sender, EventArgs e)
        {
            // Restart position for Fixed widgets
            if (Position.Fixed == _widget.Position)
            {
                InputEngine.Instance.Cursor = InputEngine.Instance.SystemCursor;
            }
        }

        /// <summary>
        /// Invoked after the Render occurres on <see cref="RenderEngine"/>.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event object.</param>
        private void OnRenderComplete(object sender, EventArgs e)
        {
            // Launch DrawComplete Event
            _widget.DrawComplete();

            // Reset Colors
            RenderEngine.Instance.LoadSystemColor();
        }

        #endregion

        #region InputEngine Events

        /// <summary>
        /// Invoked when a captured event occurres on <see cref="InputEngine"/>.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event object.</param>
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
