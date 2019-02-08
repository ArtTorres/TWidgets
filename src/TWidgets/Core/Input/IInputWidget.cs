using System.Collections.Generic;
using TWidgets.Core.Drawing;

namespace TWidgets.Core.Input
{
    public interface IInputWidget
    {
        Dictionary<string, string> Values { get; }

        InputCursor CursorPosition { get; }

        void MapValues(string id, string value);

        void DrawHeader(Graphics g);

        void DrawFooter(Graphics g);

        void DrawError(Graphics g, IEnumerable<string> messages);

        IEnumerable<InputAction> InputActions();

        ValidationResult ValidateInput(string id, string value);
    }
}
