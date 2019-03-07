using System.Collections.Generic;
using TWidgets.Core.Input;

namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Represents the result of a validation in the an <see cref="IInteractive"/>.
    /// </summary>
    public struct ValidateAction
    {
        /// <summary>
        /// Gets or sets the validation state.
        /// </summary>
        public ValidationState State { get; private set; }

        /// <summary>
        /// Gets or sets the result messages.
        /// </summary>
        public IEnumerable<string> Messages { get; private set; }

        /// <summary>
        /// Initializes an instance of <see cref="ValidateAction"/>.
        /// </summary>
        /// <param name="state">The validation state.</param>
        public ValidateAction(ValidationState state)
        {
            this.State = state;
            this.Messages = new List<string>();
        }

        /// <summary>
        /// Initializes an instance of <see cref="ValidateAction"/>.
        /// </summary>
        /// <param name="state">The validation state.</param>
        /// <param name="message">The result message.</param>
        public ValidateAction(ValidationState state, string message)
        {
            this.State = state;
            this.Messages = new List<string>();
            ((List<string>)this.Messages).Add(message);
        }

        /// <summary>
        /// Initializes an instance of <see cref="ValidateAction"/>.
        /// </summary>
        /// <param name="state">The validation state.</param>
        /// <param name="messages">The result messages.</param>
        public ValidateAction(ValidationState state, IEnumerable<string> messages)
        {
            this.State = state;
            this.Messages = messages;
        }
    }
}
