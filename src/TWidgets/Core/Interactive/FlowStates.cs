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
        /// Represents the header phase.
        /// </summary>
        Header,

        /// <summary>
        /// Represents the capture phase.
        /// </summary>
        Capture,

        /// <summary>
        /// Represents the error phase.
        /// </summary>
        Error,

        /// <summary>
        /// Represents a flow evaluation phase.
        /// </summary>
        Control,

        /// <summary>
        /// Represents the footer phase.
        /// </summary>
        Footer,

        /// <summary>
        /// Represents the end phase.
        /// </summary>
        End
    }
}
