using System;

namespace TWidgets.Core.Events
{
    /// <summary>
    /// Represents the data of an input event.
    /// </summary>
    public class InputEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the identifier of the argument.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the value of an argument.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Initializes an instance of <see cref="InputEventArgs"/>.
        /// </summary>
        /// <param name="id">The identifier of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        public InputEventArgs(string id, char value)
        {
            this.Id = id;
            this.Value = value.ToString();
        }

        /// <summary>
        /// Initializes an instance of <see cref="InputEventArgs"/>.
        /// </summary>
        /// <param name="id">The id of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        public InputEventArgs(string id, string value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}
