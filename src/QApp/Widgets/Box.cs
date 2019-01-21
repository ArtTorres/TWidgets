using System;
using System.Collections.Generic;
using System.Text;
using QApp.Core.Drawing;

namespace QApp.Widgets
{
    public abstract class Box : Widget, IBordeable
    {
        public Border Border { get; private set; }

        public Box(string id) : base(id)
        {
            this.Border = new Border();
        }
    }
}
