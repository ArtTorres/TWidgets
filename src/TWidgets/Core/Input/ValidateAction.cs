namespace TWidgets.Core.Input
{
    /// <summary>
    /// Specifies constants that defines the behavior after a validation.
    /// </summary>
    public enum ValidateAction
    {
        /// <summary>
        /// Repeat the input.
        /// </summary>
        Repeat,

        /// <summary>
        /// Continue with the next input or finish.
        /// </summary>
        Continue,

        /// <summary>
        /// Ignore the validation results.
        /// </summary>
        Ignore
    }
}
