using System;

namespace TWidgets.Core.Events
{
    public class InputEventArgs : EventArgs
    {
        public string Id { get; private set; }

        public string Value { get; private set; }

        public InputEventArgs(string id, char value)
        {
            this.Id = id;
            this.Value = value.ToString();
        }

        public InputEventArgs(string id, string value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}
