using System;
using System.Collections.Generic;
using System.Text;
using QApp.Core.Drawing;

namespace QApp.Widgets
{
    public abstract class Box : Widget
    {
        public Margin Margin { get; set; }

        //public Padding Padding { get; set; }

        public Box(string id) : base(id)
        {
            this.Margin = new Margin();
        }

        public override void Draw(Graphics g)
        {
            //g.DrawRectangle();
        }
    }
}
