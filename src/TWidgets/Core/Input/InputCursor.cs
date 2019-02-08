namespace TWidgets.Core.Input
{
    public class InputCursor
    {
        public int X { get; set; }

        public int Y { get; set; }

        public InputCursor()
        { }

        public InputCursor(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
