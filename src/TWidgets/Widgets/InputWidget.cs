using System.Collections.Generic;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;

namespace TWidgets
{
    /// <summary>
    /// Implements the basic functionality common to input type widgets.
    /// </summary>
    public abstract class InputWidget : TWidgetBase, IInputWidget
    {
        /// <summary>
        /// Gets the input values.
        /// </summary>
        public Dictionary<string, string> Values { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public InputCursor CursorPosition { get; private set; }

        /// <summary>
        /// Initializes an instance of <see cref="InputWidget"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public InputWidget(string id) : base(id)
        {
            this.Values = new Dictionary<string, string>();
            this.CursorPosition = new InputCursor();
        }

        /// <summary>
        /// Sets a input value.
        /// </summary>
        /// <param name="id">The id of the input value.</param>
        /// <param name="value">The input value.</param>
        public void MapValues(string id, string value)
        {
            this.Values.Add(id, value);
        }

        /// <summary>
        /// Executes to draw a header before the capture of inputs.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        public virtual void DrawHeader(Graphics g) { }

        /// <summary>
        /// Executes to draw a footer after the capture of inputs.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        public virtual void DrawFooter(Graphics g) { }

        /// <summary>
        /// Executes to draw a list of error messages.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        /// <param name="messages">The error messages.</param>
        public virtual void DrawError(Graphics g, IEnumerable<string> messages) { }


        /// <summary>
        /// Executes to perform capture actions.
        /// </summary>
        /// <returns>A collection of instances of <see cref="InputAction"/>.</returns>
        public abstract IEnumerable<InputAction> InputActions();

        /// <summary>
        /// Executes to valide the capture actions.
        /// </summary>
        /// <param name="id">The id of the input value.</param>
        /// <param name="value">The input value.</param>
        /// <returns>The result of the validation.</returns>
        public abstract ValidationResult ValidateInput(string id, string value);
    }
}
