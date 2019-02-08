using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core.Drawing;
using TWidgets.Core.Input;
using TWidgets.Widgets;

namespace TWidgets.Core
{
    public abstract class InputWidget : Widget, IInputWidget
    {
        #region Events

        //public event EventHandler<EventArgs> StartCapture;
        //public void OnStartCapture()
        //{
        //    this.StartCapture?.Invoke(this, new EventArgs());
        //}

        //public event EventHandler<EventArgs> EndCapture;
        //public void OnEndCapture()
        //{
        //    this.EndCapture?.Invoke(this, new EventArgs());
        //}

        //public event EventHandler<EventArgs> InputCaptured;
        //public void OnInputCaptured()
        //{
        //    this.InputCaptured?.Invoke(this, new EventArgs());
        //}

        #endregion

        public Dictionary<string, string> Values { get; private set; }

        public InputCursor Cursor { get; private set; }

        public InputWidget(string id) : base(id)
        {
            this.Values = new Dictionary<string, string>();
            this.Cursor = new InputCursor();
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
