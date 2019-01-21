using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public class Line: IMarginable, IBordeable
    {
        public Border Border { get; private set; }
        public Margin Margin { get; set; }

        public Line()
            :this(
                 new Margin(),
                 new Border()
            )
        {

        }

        public Line(Margin margin, Border border)
        {
            this.Margin = margin;
            this.Border = border;
        }
    }
}
