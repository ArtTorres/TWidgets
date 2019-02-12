using System.Collections.Generic;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;

namespace TWidgets.Widgets
{
    public class StopMessage : InputWidget
    {
        private string _text;
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

        public StopMessage(string id) : base(id)
        {
            this.CursorPosition.Y = 1;
        }

        public override void Draw(Graphics g)
        {
            g.Draw(new Text(this.Text, this.Margin));
        }

        public override IEnumerable<InputAction> InputActions()
        {
            yield return new InputAction("stop-message.value", InputMethod.ReadKey, ValidateAction.Ignore);
        }

        public override ValidationResult ValidateInput(string id, string value)
        {
            return new ValidationResult(ValidationState.Valid);
        }
    }
}
