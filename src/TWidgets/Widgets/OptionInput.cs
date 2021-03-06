﻿using System.Collections.Generic;
using System.Linq;
using TWidgets.Core.Drawing;
using TWidgets.Core.Interactive;
using TWidgets.Core.Utils;

namespace TWidgets
{
    /// <summary>
    /// Represents a widget who displays a list of instructions and waits for a selection..
    /// </summary>
    public class OptionInput : InteractiveTWidget
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
        }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            g.Draw(
                new List(
                    TextUtils.ResizeLines(
                        JoinNumbers(this.Items).ToArray(),
                        g.Canvas.Width
                    ),
                    new Margin(
                        Margin.Top,
                        Margin.Left,
                        1,
                        Margin.Right
                    )
                )
            );

            this.CursorPosition.Y = g.Canvas.Rows;

            g.Draw(
                new Text(
                    this.InstructionsText, 
                    new Margin(
                        0,
                        Margin.Left,
                        Margin.Bottom,
                        Margin.Right
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
            yield return new InputAction("option-input.value", InputMethod.ReadLine, ErrorAction.Repeat);
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
                return new ValidateAction(ValidationState.Reject, this.ErrorText);
            }
            else
            {
                int.TryParse(value, out int result);

                if (result > 0 && result <= Items.Length)
                {
                    return new ValidateAction(ValidationState.Accept);
                }
                else
                {
                    return new ValidateAction(ValidationState.Reject, this.ErrorText);
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
