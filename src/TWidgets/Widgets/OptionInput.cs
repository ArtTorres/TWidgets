using System.Collections.Generic;
using System.Linq;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    public class OptionInput : InputWidget
    {
        public string[] Items { get; set; }

        public string InstructionsText { get; set; }

        public string ErrorText { get; set; }

        public char NumberSeparator { get; set; } = '.';

        public OptionInput(string id) : base(id)
        { }

        public override void BeforeDraw()
        {
            this.CursorPosition.X = InstructionsText.Length + Margin.Left + 1;
            this.CursorPosition.Y = -Margin.Bottom;
        }

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

        public override IEnumerable<InputAction> InputActions()
        {
            yield return new InputAction("choice-input.value", InputMethod.ReadLine, ValidateAction.Repeat);
        }

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
