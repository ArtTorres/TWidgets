namespace TWidgets.Core.Input
{
    /// <summary>
    /// Specifies constants that defines the state of a validation.
    /// </summary>
    public enum ValidationState
    {
        /// <summary>
        /// The validation is acceptable.
        /// </summary>
        Valid,

        /// <summary>
        /// The validation is not acceptable.
        /// </summary>
        Invalid,

        /// <summary>
        /// The validation must be repeated.
        /// </summary>
        Repeat
    }
}
