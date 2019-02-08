using System.Collections.Generic;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;

namespace TWidgets.Widgets
{
    public class TextInput : InputWidget, IBordeable
    {
        public Border Border { get; private set; }

        public ValidateAction Action { get; set; }

        public string HeaderText { get; set; }

        public string CursorText { get; set; } = ">>";

        public TextInput(string id) : base(id)
        {
            this.Border = new Border();
            this.CursorPosition.X = CursorText.Length + 1;
            this.CursorPosition.Y = 0;
        }

        public override void Draw(Graphics g)
        {
            g.Draw(new Text($"{CursorText} ", this.Margin));
        }

        public override void DrawHeader(Graphics g)
        {
            if (!string.IsNullOrEmpty(this.HeaderText))
                g.Draw(new Text(this.HeaderText, this.Margin));
        }

        public override void DrawFooter(Graphics g)
        {
            g.Draw(new Line(this.Margin, this.Border));
        }

        public override void DrawError(Graphics g, IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                g.Draw(new Text(message, this.Margin));
            }
        }

        public override IEnumerable<InputAction> InputActions()
        {
            yield return new InputAction("text-input.value", InputMethod.ReadLine, ValidateAction.Repeat);
        }

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
