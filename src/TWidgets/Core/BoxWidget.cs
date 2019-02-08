using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core.Drawing;

namespace TWidgets.Core
{
    public abstract class BoxWidget : Widget, IBordeable
    {
        public Border Border { get; private set; }

        public int Width { get; set; } = 0;

        public BoxWidget(string id) : base(id)
        {
            this.Border = new Border();
        }
    }
}
