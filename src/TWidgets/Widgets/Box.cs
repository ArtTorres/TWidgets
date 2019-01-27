using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core.Drawing;

namespace TWidgets.Widgets
{
    public abstract class Box : Widget, IBordeable
    {
        public Border Border { get; private set; }

        public int Width { get; set; } = 0;

        public Box(string id) : base(id)
        {
            this.Border = new Border();
        }
    }
}
