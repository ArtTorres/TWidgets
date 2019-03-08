namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Specifies constants that defines the phases of the <see cref="IWorkflow"/>.
    /// </summary>
    public enum FlowStates
    {
        /// <summary>
        /// Represents the start phase.
        /// </summary>
        Start,

        /// <summary>
        /// Represents the capture phase.
        /// </summary>
        Input,

        /// <summary>
        /// Represents the error phase.
        /// </summary>
        Error,

        /// <summary>
        /// Represents a flow evaluation phase.
        /// </summary>
        Control,

        /// <summary>
        /// Represents the end phase.
        /// </summary>
        End
    }
}
