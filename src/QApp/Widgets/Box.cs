using System;
using System.Collections.Generic;
using System.Text;
using QApp.Core.Drawing;

namespace QApp.Widgets
{
    public class Box : Widget
    {
        public Margin Margin { get; set; }

        public Padding Padding { get; set; }

        public Box(string id) : base(id)
        {
        }

        public override Canvas Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
