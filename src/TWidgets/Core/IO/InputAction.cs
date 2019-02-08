namespace TWidgets.Core.IO
{
    public class InputAction
    {
        public string id;

        public InputMethod method;

        public ValidateAction action;

        public InputAction(string id, InputMethod method, ValidateAction action)
        {
            this.id = id;
            this.method = method;
            this.action = action;
        }
    }
}
