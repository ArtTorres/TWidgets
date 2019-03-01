using System;
using System.Collections.Generic;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;

namespace TWidgets
{
    /// <summary>
    /// Represents a the input of text in the <see cref="Console"/>.
    /// </summary>
    public class TextInput : InputWidget, IBordeable
    {
        /// <summary>
        /// Gets the footer line border.
        /// </summary>
        public Border Border { get; private set; }

        // TODO: Evaluate the position of this property
        /// <summary>
        /// Gets or sets the validation behavior.
        /// </summary>
        public ValidateAction Action { get; set; }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        public string HeaderText { get; set; }

        /// <summary>
        /// Gets or sets the text cursor placed before the input.
        /// </summary>
        public string CursorText { get; set; } = ">>";

        /// <summary>
        /// Initializes an instance of <see cref="TextInput"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public TextInput(string id) : base(id)
        {
            this.Border = new Border();
            this.CursorPosition.X = CursorText.Length + 1;
            this.CursorPosition.Y = 0;
        }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            g.Draw(new Text($"{CursorText} ", this.Margin));
        }

        /// <summary>
        /// Executes to draw a header before the capture of inputs.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        public override void DrawHeader(Graphics g)
        {
            if (!string.IsNullOrEmpty(this.HeaderText))
                g.Draw(new Text(this.HeaderText, this.Margin));
        }

        /// <summary>
        /// Executes to draw a footer after the capture of inputs.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        public override void DrawFooter(Graphics g)
        {
            g.Draw(new Line(this.Margin, this.Border));
        }

        /// <summary>
        /// Executes to draw a list of error messages.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        /// <param name="messages">The error messages.</param>
        public override void DrawError(Graphics g, IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                g.Draw(new Text(message, this.Margin));
            }
        }

        /// <summary>
        /// Executes to perform capture actions.
        /// </summary>
        /// <returns>A collection of instances of <see cref="InputAction"/>.</returns>
        public override IEnumerable<InputAction> InputActions()
        {
            yield return new InputAction("text-input.value", InputMethod.ReadLine, ValidateAction.Repeat);
        }

        /// <summary>
        /// Executes to valide the capture actions.
        /// </summary>
        /// <param name="id">The id of the input value.</param>
        /// <param name="value">The input value.</param>
        /// <returns>The result of the validation.</returns>
        public override ValidationResult ValidateInput(string id, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new ValidationResult(ValidationState.Invalid, "Empty Input");
            }
            else
            {
                return new ValidationResult(ValidationState.Valid);
            }
        }
    }
}
