using System;
using System.Collections.Generic;
using TWidgets.Core.Drawing;
using TWidgets.Core.Interactive;

namespace TWidgets
{
    /// <summary>
    /// Represents a the input of text in the <see cref="Console"/>.
    /// </summary>
    public class TextInput : InteractiveTWidget
    {
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
            this.CursorPosition.X = this.Margin.Left + CursorText.Length + 1;
        }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            bool headerEnabled = !string.IsNullOrEmpty(this.HeaderText);

            if (headerEnabled)
            {
                g.Draw(
                    new Text(
                        this.HeaderText,
                        new Margin(
                            this.Margin.Top,
                            this.Margin.Left,
                            0,
                            this.Margin.Right
                        )
                    )
                );
            }

            this.CursorPosition.Y = g.Canvas.Rows;

            g.Draw(
                new Text(
                    $"{CursorText} ",
                    new Margin(
                        headerEnabled ? 0 : this.Margin.Top,
                        this.Margin.Left,
                        this.Margin.Bottom,
                        this.Margin.Right
                    )
                )
            );
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
            yield return new InputAction("text-input.value", InputMethod.ReadLine, ErrorAction.Repeat);
        }

        /// <summary>
        /// Executes to valide the capture actions.
        /// </summary>
        /// <param name="id">The id of the input value.</param>
        /// <param name="value">The input value.</param>
        /// <returns>The result of the validation.</returns>
        public override ValidateAction ValidateAction(string id, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new ValidateAction(ValidationState.Reject, "Empty Input");
            }
            else
            {
                return new ValidateAction(ValidationState.Accept);
            }
        }
    }
}
