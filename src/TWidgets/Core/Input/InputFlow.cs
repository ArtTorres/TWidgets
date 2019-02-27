namespace TWidgets.Core.Input
{
    /// <summary>
    /// Represent the workflow to execute during an input capture.
    /// </summary>
    internal sealed class InputFlow
    {
        /// <summary>
        /// Specifies constants that defines the phases of the <see cref="InputFlow"/>.
        /// </summary>
        public enum States
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

        /// <summary>
        /// Specifies constants that defines the actions to perform in the phases of the <see cref="InputFlow"/>.
        /// </summary>
        public enum Actions
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
            Ok
        }

        /// <summary>
        /// Gets the current state of the <see cref="InputFlow"/>.
        /// </summary>
        public States State { get; private set; }

        /// <summary>
        /// Gets or sets the action to be performed in the <see cref="InputFlow"/>.
        /// </summary>
        public Actions Action { get; set; }

        private States[,] _stateMachine; // A finite-state machine

        /// <summary>
        /// Initializes an instance of <see cref="InputFlow"/>.
        /// </summary>
        public InputFlow()
        {
            _stateMachine = new States[,] {
            //    Start           Header          Capture           Error           Control         Footer      End
                { States.Header,  States.Capture, States.Capture,   States.Control, States.Capture, States.End, States.End }, // Continue
                { States.Header,  States.Capture, States.Error,     States.Capture, States.Footer,  States.End, States.End }, // Error
                { States.Header,  States.Capture, States.Control,   States.Capture, States.Footer,  States.End, States.End }  // Ok
            };
        }

        /// <summary>
        /// Sets the flow to the initial state.
        /// </summary>
        public void Start()
        {
            this.State = States.Start;
            this.Action = Actions.Continue;
        }

        /// <summary>
        /// Move the flow to the next state.
        /// </summary>
        /// <returns>The new state.</returns>
        public States NextState()
        {
            return this.State = _stateMachine[(int)this.Action, (int)this.State];
        }
    }
}
