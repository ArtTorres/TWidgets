using TWidgets.Core.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace TWidgets.Widgets
{
    public class Separator : Box
    {
        public Separator(string id) : base(id)
        { }

        public override void Draw(Graphics g)
        {
            g.Draw(new Line(this.Margin, this.Border));
        }
    }
}
