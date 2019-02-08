using System.Collections.Generic;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;

namespace TWidgets.Core
{
    public abstract class InputWidget : Widget, IInputWidget
    {
        public Dictionary<string, string> Values { get; private set; }

        public InputCursor CursorPosition { get; private set; }

        public InputWidget(string id) : base(id)
        {
            this.Values = new Dictionary<string, string>();
            this.CursorPosition = new InputCursor();
        }

        public virtual void DrawHeader(Graphics g) { }

        public virtual void DrawFooter(Graphics g) { }

        public virtual void DrawError(Graphics g, IEnumerable<string> messages) { }

        public abstract IEnumerable<InputAction> InputActions();

        public abstract ValidationResult ValidateInput(string id, string value);

        public void MapValues(string id, string value)
        {
            this.Values.Add(id, value);
        }
    }
}
