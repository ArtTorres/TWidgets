
namespace TWidgets.Core.Drawing
{
    public class Padding
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Bottom { get; set; }
        public int Right { get; set; }

        private int _all;
        public int All
        {
            get
            {
                return _all;
            }
            set
            {
                Top = value;
                Left = value;
                Bottom = value;
                Right = value;
                _all = value;
            }
        }

        public Padding()
        {
            this.All = 0;
        }

        public Padding(int all)
        {
            this.All = all;
        }

        public Padding(int top, int left, int bottom, int right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }
    }
}
