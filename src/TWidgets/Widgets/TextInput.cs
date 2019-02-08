using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Core.IO;

namespace TWidgets.Widgets
{
    public class TextInput : InputWidget, IBordeable
    {
        public Border Border { get; private set; }

        public ValidateAction Action { get; set; }

        public TextInput(string id) : base(id)
        {
            this.Border = new Border();
            this.Cursor.X = 3;
            this.Cursor.Y = 1;
        }

        public override void Draw(Graphics g)
        {
            g.Draw(new Text(">> ", this.Margin));
        }

        public override void DrawHeader(Graphics g)
        {
            g.Draw(new Text("Enter Text: ", this.Margin));
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
            yield return new InputAction("var1", InputMethod.ReadLine, ValidateAction.Repeat);
            yield return new InputAction("var2", InputMethod.ReadLine, ValidateAction.Repeat);
            yield return new InputAction("var3", InputMethod.ReadLine, ValidateAction.Repeat);
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
