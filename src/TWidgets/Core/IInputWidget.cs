using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core.Drawing;
using TWidgets.Core.IO;

namespace TWidgets.Core
{
    public interface IInputWidget
    {
        //event EventHandler<EventArgs> StartCapture;

        //event EventHandler<EventArgs> EndCapture;

        //event EventHandler<EventArgs> InputCaptured;

        Dictionary<string, string> Values { get; }

        InputCursor Cursor { get; }

        void MapValues(string id, string value);

        void DrawHeader(Graphics g);

        void DrawFooter(Graphics g);

        void DrawError(Graphics g, IEnumerable<string> messages);

        IEnumerable<InputAction> InputActions();

        ValidationResult ValidateInput(string id, string value);
    }
}
