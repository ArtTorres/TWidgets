namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Specifies constants that defines the actions to perform in the phases of the <see cref="IWorkflow"/>.
    /// </summary>
    public enum FlowActions
    {
        /// <summary>
        /// Continue the flow to the next state.
        /// </summary>
        Continue,

        /// <summary>
        /// Continue the flow to the next error state.
        /// </summary>
        Error,

        /// <summary>
        /// Continue the flow to the next valid state.
        /// </summary>
        Ok,

        /// <summary>
        /// Ends the flow immediately.
        /// </summary>
        Abort
    }
}
