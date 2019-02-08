using TWidgets.Core.Drawing;
using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core;

namespace TWidgets.Widgets
{
    public class Separator : BoxWidget
    {
        public Separator(string id) : base(id)
        { }

        public override void Draw(Graphics g)
        {
            g.Draw(new Line(this.Margin, this.Border));
        }
    }
}
