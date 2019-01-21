using QApp.Core.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Widgets
{
    public class Marquee : Box
    {
        public Marquee(string id) : base(id)
        { }

        public override void Draw(Graphics g)
        {
            g.Draw(
                new Rectangle(
                    g.Canvas.Width,
                    5,
                    this.Margin,
                    this.Padding,
                    this.Border
                )
            );
        }
    }
}
