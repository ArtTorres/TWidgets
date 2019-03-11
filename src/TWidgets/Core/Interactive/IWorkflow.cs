namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Provides the functions to implement a Workflow.
    /// </summary>
    public interface IWorkflow
    {
        /// <summary>
        /// Gets the current state of the <see cref="IWorkflow"/>.
        /// </summary>
        FlowStates State { get; }

        /// <summary>
        /// Gets or sets the action to be performed in the <see cref="IWorkflow"/>.
        /// </summary>
        FlowActions Action { get; set; }

        /// <summary>
        /// Sets the flow to the initial state.
        /// </summary>
        void Start();

        /// <summary>
        /// Move the flow to the next state.
        /// </summary>
        /// <returns>The new state.</returns>
        FlowStates NextState();
    }
}
