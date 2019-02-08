using System.Collections.Generic;

namespace TWidgets.Core.Input
{
    public class ValidationResult
    {
        public ValidationState State { get; set; }

        public IEnumerable<string> Messages { get; set; }

        public ValidationResult(ValidationState state)
        {
            this.State = state;
            this.Messages = new List<string>();
        }

        public ValidationResult(ValidationState state, string message)
        {
            this.State = state;
            this.Messages = new List<string>();
            ((List<string>)this.Messages).Add(message);
        }

        public ValidationResult(ValidationState state, IEnumerable<string> messages)
        {
            this.State = state;
            this.Messages = messages;
        }
    }
}
