using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    public class ProgressChar : Message
    {
        public char[] Animation { get; set; }

        private int _frame = 0;

        public ProgressChar(string id) : base(id)
        {
            this.Animation = TextAnimations.BARS;
            base.Position = Position.Fixed;
        }

        public override void Draw(Graphics g)
        {
            g.Draw(new Text(
                $"{Animation[_frame]} {this.Text}",
                this.Margin
                )
            );
        }

        public override void DrawComplete()
        {
            if (++_frame >= Animation.Length) _frame = 0;
        }
    }
}
