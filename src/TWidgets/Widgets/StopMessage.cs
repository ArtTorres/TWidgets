using System;
using System.Collections.Generic;
using TWidgets.Core.Drawing;
using TWidgets.Core.Interactive;

namespace TWidgets
{
    /// <summary>
    /// Represents a text message in the <see cref="Console"/> and then stops waiting for a key input.
    /// </summary>
    public class StopMessage : InteractiveTWidget
    {
        /// <summary>
        /// Gets or sets the text of the message.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                this.OnStateChanged();
            }
        }
        private string _text;

        /// <summary>
        /// Initializes an instance of <see cref="StopMessage"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public StopMessage(string id) : base(id)
        {
            this.CursorPosition.Y = 1;
        }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            g.Draw(new Text(this.Text, this.Margin) { Align = this.TextAlign });
        }

        /// <summary>
        /// Executes to perform capture actions.
        /// </summary>
        /// <returns>A collection of instances of <see cref="InputAction"/>.</returns>
        public override IEnumerable<InputAction> InputActions()
        {
            yield return new InputAction("stop-message.value", InputMethod.ReadKey, ErrorAction.Ignore);
        }

        /// <summary>
        /// Executes to valide the capture actions.
        /// </summary>
        /// <param name="id">The id of the input value.</param>
        /// <param name="value">The input value.</param>
        /// <returns>The result of the validation.</returns>
        public override ValidateAction ValidateAction(string id, string value)
        {
            return new ValidateAction(ValidationState.Accept);
        }
    }
}
