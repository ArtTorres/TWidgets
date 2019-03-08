namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Represent the workflow to execute during an input capture.
    /// </summary>
    public class BasicWorkflow : IWorkflow
    {
        /// <summary>
        /// Gets the current state of the <see cref="BasicWorkflow"/>.
        /// </summary>
        public FlowStates State { get; private set; }

        /// <summary>
        /// Gets or sets the action to be performed in the <see cref="BasicWorkflow"/>.
        /// </summary>
        public FlowActions Action { get; set; }

        private FlowStates[,] _stateMachine; // A finite-state machine

        /// <summary>
        /// Initializes an instance of <see cref="BasicWorkflow"/>.
        /// </summary>
        public BasicWorkflow()
        {
            _stateMachine = new FlowStates[,] {
            //    Start             Capture             Error                 Control             End
                { FlowStates.Input, FlowStates.Input,   FlowStates.Control,   FlowStates.Input,   FlowStates.End }, // Continue
                { FlowStates.Input, FlowStates.Error,   FlowStates.Input,     FlowStates.End,     FlowStates.End }, // Error
                { FlowStates.Input, FlowStates.Control, FlowStates.Input,     FlowStates.End,     FlowStates.End }  // Ok
            };
        }

        /// <summary>
        /// Sets the flow to the initial state.
        /// </summary>
        public void Start()
        {
            this.State = FlowStates.Start;
            this.Action = FlowActions.Continue;
        }

        /// <summary>
        /// Move the flow to the next state.
        /// </summary>
        /// <returns>The new state.</returns>
        public FlowStates NextState()
        {
            return this.State = _stateMachine[(int)this.Action, (int)this.State];
        }
    }
}
