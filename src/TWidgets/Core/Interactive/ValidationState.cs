namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Specifies constants that defines the state of a validation.
    /// </summary>
    public enum ValidationState
    {
        /// <summary>
        /// The validation is acceptable.
        /// </summary>
        Accept,

        /// <summary>
        /// The validation is not acceptable.
        /// </summary>
        Reject,

        /// <summary>
        /// The validation must be repeated.
        /// </summary>
        Repeat
    }
}
