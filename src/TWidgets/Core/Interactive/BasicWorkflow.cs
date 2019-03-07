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
            //    Start           Header          Capture           Error           Control         Footer      End
                { FlowStates.Header,  FlowStates.Capture, FlowStates.Capture,   FlowStates.Control, FlowStates.Capture, FlowStates.End, FlowStates.End }, // Continue
                { FlowStates.Header,  FlowStates.Capture, FlowStates.Error,     FlowStates.Capture, FlowStates.Footer,  FlowStates.End, FlowStates.End }, // Error
                { FlowStates.Header,  FlowStates.Capture, FlowStates.Control,   FlowStates.Capture, FlowStates.Footer,  FlowStates.End, FlowStates.End }  // Ok
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
