namespace TWidgets.Core.Input
{
    internal sealed class InputFlow
    {
        public enum States
        {
            Start,
            Header,
            Capture,
            Error,
            Control,
            Footer,
            End
        }
        public States State { get; private set; }

        public enum Actions
        {
            Continue,
            Error,
            Ok
        }
        public Actions Action { get; set; }

        private States[,] _stateMachine;

        public InputFlow()
        {
            _stateMachine = new States[,] {
            //    Start           Header          Capture           Error           Control         Footer      End
                { States.Header,  States.Capture, States.Capture,   States.Control, States.Capture, States.End, States.End }, // Continue
                { States.Header,  States.Capture, States.Error,     States.Capture, States.Footer,  States.End, States.End }, // Error
                { States.Header,  States.Capture, States.Control,   States.Capture, States.Footer,  States.End, States.End }  // Ok
            };
        }

        public void Start()
        {
            this.State = States.Start;
            this.Action = Actions.Continue;
        }

        public States NextState()
        {
            return this.State = _stateMachine[(int)this.Action, (int)this.State];
        }
    }
}
