using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    public class Marquee : BoxWidget
    {
        private string[] _items;
        public string[] Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                this.OnStateChanged();
            }
        }

        public Padding Padding { get; set; }

        public Marquee(string id) : base(id)
        {
            this.Padding = new Padding();
        }

        public override void Draw(Graphics g)
        {
            // Draw Rectangle
            int rectangleHeight = this.Items.Length + (this.Border.Width * 2) + this.Padding.Top + this.Padding.Bottom;
            g.Draw(
                new Rectangle(
                    g.Canvas.Width,
                    rectangleHeight,
                    this.Margin,
                    this.Border
                )
            );

            g.ResetCursors();

            // Draw List inside Rectangle
            var textMargin = new Margin(
                Margin.Top + Border.Width + Padding.Top,
                Margin.Left + Border.Width + Padding.Left,
                Margin.Bottom + Border.Width + Padding.Bottom,
                Margin.Right + Border.Width + Padding.Right
            );

            g.Draw(
                new List(
                    TextUtils.ResizeLines(
                        this.Items,
                        g.Canvas.Width
                    ),
                    textMargin
                )
                {
                    Align = this.TextAlign
                }
            );
        }
    }
}
