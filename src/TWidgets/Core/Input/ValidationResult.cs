using System.Collections.Generic;

namespace TWidgets.Core.Input
{
    /// <summary>
    /// Represents the result of a validation in the an <see cref="IInputWidget"/>.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Gets or sets the validation state.
        /// </summary>
        public ValidationState State { get; set; }

        /// <summary>
        /// Gets or sets the result messages.
        /// </summary>
        public IEnumerable<string> Messages { get; set; }

        /// <summary>
        /// Initializes an instance of <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="state">The validation state.</param>
        public ValidationResult(ValidationState state)
        {
            this.State = state;
            this.Messages = new List<string>();
        }

        /// <summary>
        /// Initializes an instance of <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="state">The validation state.</param>
        /// <param name="message">The result message.</param>
        public ValidationResult(ValidationState state, string message)
        {
            this.State = state;
            this.Messages = new List<string>();
            ((List<string>)this.Messages).Add(message);
        }

        /// <summary>
        /// Initializes an instance of <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="state">The validation state.</param>
        /// <param name="messages">The result messages.</param>
        public ValidationResult(ValidationState state, IEnumerable<string> messages)
        {
            this.State = state;
            this.Messages = messages;
        }
    }
}
