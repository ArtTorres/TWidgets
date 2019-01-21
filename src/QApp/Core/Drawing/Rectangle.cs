using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public class Rectangle : IMarginable, IBordeable
    {
        public Border Border { get; private set; }
        public Margin Margin { get; set; }
        public Padding Padding { get; set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(int width, int height)
            : this(
                width,
                height,
                new Margin(),
                new Padding(),
                new Border()
            )
        { }

        public Rectangle(int width, int height, Margin margin, Padding padding, Border border)
        {
            this.Width = width;
            this.Height = height;

            this.Margin = margin;
            this.Padding = padding;
            this.Border = border;
        }
    }
}
