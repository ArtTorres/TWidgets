using System;
using System.Collections.Generic;
using System.Linq;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;
using TWidgets.Core.Interactive;

namespace TWidgets
{
    /// <summary>
    /// Displays the mounted <see cref="ITWidget"/> in the system <see cref="Console"/>.This class cannot be inherited.
    /// </summary>
    public sealed class TWidgetPlayer
    {
        #region Instance

        /// <summary>
        /// Gets an instance of <see cref="TWidgetPlayer"/>.
        /// </summary>
        private static TWidgetPlayer Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private static readonly Lazy<TWidgetPlayer> _instance = new Lazy<TWidgetPlayer>(() => new TWidgetPlayer());

        /// <summary>
        /// Gets the <see cref="ITWidget"/> mounted.
        /// </summary>
        public static ITWidget Widget
        {
            get
            {
                return Instance._widget;
            }
        }

        /// <summary>
        /// Mounts a <see cref="ITWidget"/> in the player.
        /// </summary>
        /// <param name="widget"></param>
        public static void Mount(ITWidget widget)
        {
            Instance.MountWidget(widget);
        }

        /// <summary>
        /// Unmounts a <see cref="ITWidget"/> from the player.
        /// </summary>
        public static void Unmount()
        {
            Instance.UnmountWidget();
        }

        #endregion

        private ITWidget _widget;
        private IEnumerable<string> _errorMessages;

        /// <summary>
        /// Initializes an instance of <see cref="TWidgetPlayer"/>.
        /// </summary>
        private TWidgetPlayer()
        {
            RenderEngine.Instance.BeforeRender += OnBeforeRender;
            RenderEngine.Instance.RenderComplete += OnRenderComplete;

            InputEngine.Instance.Captured += OnCaptured;
        }

        /// <summary>
        /// Initializes an instance of <see cref="TWidgetPlayer"/>.
        /// </summary>
        /// <param name="widget">The widget to be played.</param>
        /// <param name="autoplay">Play on mount.</param>
        private void MountWidget(ITWidget widget, bool autoplay = true)
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

            // Launch Mount Event
            _widget.Mount();

            if (autoplay)
                this.PlayWidget();
        }

        /// <summary>
        /// Unmounts the mounted <see cref="ITWidget"/>.
        /// </summary>
        private void UnmountWidget()
        {
            // Unset Events
            _widget.StateChanged -= OnStateChanged;

            _widget.UnMount();
            _widget = null;
        }

        /// <summary>
        /// Displays the <see cref="ITWidget"/> in the system <see cref="Console"/>.
        /// </summary>
        private void PlayWidget()
        {
            // Before draw
            _widget.BeforeDraw();

            // Perform input
            if (_widget is IInteractive)
            {
                this.DrawInteractiveWidget(_widget as IInteractive);
            }
            else
            {
                // Draw widget
                this.DrawBasicWidget(_widget);
            }
        }

        /// <summary>
        /// Displays the <see cref="ITWidget"/> in the system <see cref="Console"/>.
        /// </summary>
        /// <param name="widget">The widget to be displayed.</param>
        private void DrawBasicWidget(ITWidget widget)
        {
            // New graphics
            var g = this.GetNewGraphics();

            // Draw widget
            widget.Draw(g);

            // Display on Console
            this.Display(g);
        }

        /// <summary>
        /// Displays the <see cref="IInteractive"/> in the system <see cref="Console"/>.
        /// </summary>
        /// <param name="widget">The widget to be displayed.</param>
        private void DrawInteractiveWidget(IInteractive widget)
        {
            widget.Workflow.Start();

            var actions = widget.InputActions().ToArray();
            int ix = 0;

            do
            {
                switch (widget.Workflow.NextState())
                {
                    case FlowStates.Input:
                        CaptureStep(actions[ix]);
                        break;
                    case FlowStates.Error:
                        ErrorStep(actions[ix]);
                        break;
                    case FlowStates.Control:
                        if (ix < actions.Length - 1)
                        {
                            ix++;
                            widget.Workflow.Action = FlowActions.Continue;
                        }
                        else
                        {
                            widget.Workflow.Action = FlowActions.Ok;
                        }
                        break;
                }

            } while (widget.Workflow.State != FlowStates.End);

            // Displays Input on capture messages.
            void CaptureStep(InputAction action)
            {
                int startRow = InputEngine.Instance.Cursor.Y;

                this.DrawBasicWidget(widget as ITWidget);

                int size = InputEngine.Instance.Cursor.Y - startRow;

                // Set cursor position
                InputEngine.Instance.Cursor = new ConsoleCursor(
                    widget.CursorPosition.X,
                    startRow + widget.CursorPosition.Y
                );

                // Perform capture
                InputEngine.Instance.Capture(action.Id, action.Method);

                // Restore drawing position
                InputEngine.Instance.Cursor = new ConsoleCursor(
                    0,
                    startRow + size
                );
            }

            // Displays Input Errors
            void ErrorStep(InputAction action)
            {
                if (action.Action != ErrorAction.Ignore)
                {
                    var g = GetNewGraphics();

                    widget.DrawError(g, _errorMessages);

                    this.Display(g);
                }

                if (action.Action == ErrorAction.Repeat)
                {
                    widget.Workflow.Action = FlowActions.Ok;
                }
                else
                {
                    widget.Workflow.Action = FlowActions.Continue;
                }
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
        /// Invoked when the state of a <see cref="ITWidget"/> changed.
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
        private void OnCaptured(object sender, Core.Events.InteractiveEventArgs e)
        {
            var iWidget = (_widget as IInteractive);
            var result = iWidget.ValidateAction(e.Id, e.Value);

            switch (result.State)
            {
                case ValidationState.Reject:
                    _errorMessages = result.Messages;
                    iWidget.Workflow.Action = FlowActions.Error;
                    break;
                case ValidationState.Repeat:
                    iWidget.Workflow.Action = FlowActions.Continue;
                    break;
                case ValidationState.Accept:
                    iWidget.MapValues(e.Id, e.Value);
                    iWidget.Workflow.Action = FlowActions.Ok;
                    break;
            }
        }

        #endregion
    }
}
