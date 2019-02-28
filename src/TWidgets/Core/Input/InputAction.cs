namespace TWidgets.Core.Input
{
    /// <summary>
    /// Represents the input actions to perform for a <see cref="IInputWidget"/>.
    /// </summary>
    public class InputAction
    {
        /// <summary>
        /// Gets or sets the identifier of the input value
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the input method.
        /// </summary>
        public InputMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the validation action.
        /// </summary>
        public ValidateAction Action { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="InputAction"/>.
        /// </summary>
        /// <param name="id">The identifier of the input value.</param>
        /// <param name="method">The input method.</param>
        /// <param name="action">The validation action.</param>
        public InputAction(string id, InputMethod method, ValidateAction action)
        {
            this.Id = id;
            this.Method = method;
            this.Action = action;
        }
    }
}
