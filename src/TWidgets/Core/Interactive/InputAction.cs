using TWidgets.Core.Input;

namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Represents the input actions to perform for a <see cref="IInteractive"/>.
    /// </summary>
    public struct InputAction
    {
        /// <summary>
        /// Gets the identifier of the input value
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the input method.
        /// </summary>
        public InputMethod Method { get; private set; }

        /// <summary>
        /// Gets the validation action.
        /// </summary>
        public ErrorAction Action { get; private set; }

        /// <summary>
        /// Initializes an instance of <see cref="InputAction"/>.
        /// </summary>
        /// <param name="id">The identifier of the input value.</param>
        /// <param name="method">The input method.</param>
        /// <param name="action">The validation action.</param>
        public InputAction(string id, InputMethod method, ErrorAction action)
        {
            this.Id = id;
            this.Method = method;
            this.Action = action;
        }
    }
}
