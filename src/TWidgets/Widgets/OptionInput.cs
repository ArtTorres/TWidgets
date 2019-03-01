using System.Collections.Generic;
using System.Linq;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;
using TWidgets.Core.Utils;

namespace TWidgets
{
    /// <summary>
    /// Represents a widget who displays a list of instructions and waits for a selection..
    /// </summary>
    public class OptionInput : InputWidget
    {
        /// <summary>
        /// Gets or sets the header instruction text.
        /// </summary>
        public string InstructionsText { get; set; }

        /// <summary>
        /// Gets or sets the error text.
        /// </summary>
        public string ErrorText { get; set; }

        /// <summary>
        /// Gets or sets the number separator character.
        /// </summary>
        public char NumberSeparator { get; set; } = '.';

        /// <summary>
        /// Gets or sets the option items.
        /// </summary>
        public string[] Items { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="OptionInput"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public OptionInput(string id) : base(id)
        { }

        /// <summary>
        /// Executes before the widget is drawn.
        /// </summary>
        public override void BeforeDraw()
        {
            this.CursorPosition.X = InstructionsText.Length + Margin.Left + 1;
            this.CursorPosition.Y = -Margin.Bottom;
        }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            var marginA = new Margin(
                Margin.Top,
                Margin.Left,
                0,
                Margin.Right
            );
            var marginB = new Margin(
                0,
                Margin.Left,
                Margin.Bottom,
                Margin.Right
            );

            g.Draw(
                new List(
                    TextUtils.ResizeLines(
                        JoinNumbers(this.Items).ToArray(),
                        g.Canvas.Width
                    ),
                    marginA
                )
            );
            g.Draw(new Text(this.InstructionsText, marginB));
        }

        /// <summary>
        /// Executes to draw a list of error messages.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        /// <param name="messages">The error messages.</param>
        public override void DrawError(Graphics g, IEnumerable<string> messages)
        {
            var margin = new Margin(
                0,
                Margin.Left,
                0,
                Margin.Right
            );

            foreach (var message in messages)
            {
                g.Draw(new Text(message, margin));
            }
        }

        /// <summary>
        /// Executes to perform capture actions.
        /// </summary>
        /// <returns>A collection of instances of <see cref="InputAction"/>.</returns>
        public override IEnumerable<InputAction> InputActions()
        {
            yield return new InputAction("choice-input.value", InputMethod.ReadLine, ValidateAction.Repeat);
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
                return new ValidationResult(ValidationState.Invalid, this.ErrorText);
            }
            else
            {
                int.TryParse(value, out int result);

                if (result > 0 && result <= Items.Length)
                {
                    return new ValidationResult(ValidationState.Valid);
                }
                else
                {
                    return new ValidationResult(ValidationState.Invalid, this.ErrorText);
                }
            }
        }

        private IEnumerable<string> JoinNumbers(string[] items)
        {
            int i = 0;
            foreach (var item in items)
            {
                yield return $"{++i}{NumberSeparator} {item}";
            }
        }
    }
}
