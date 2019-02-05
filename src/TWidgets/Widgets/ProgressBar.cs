using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core;
using TWidgets.Core.Drawing;

namespace TWidgets.Widgets
{
    public class ProgressBar : BoxWidget
    {
        public double Step { get; set; } = 1.0d;
        public double Max { get; set; } = 100.0d;
        public double Min { get; set; } = 0.0d;

        public double Progress { get; private set; }

        private const int BAR_START = 0;
        private const int BAR_BACKGROUND = 1;
        private const int BAR_FILLED = 2;
        private const int BAR_END = 3;

        public const int TEMPLATE_SIZE = 4;

        private char[] _template;
        public char[] Template
        {
            get
            {
                return _template;
            }
            set
            {
                if (_template.Length != TEMPLATE_SIZE)
                    throw new Exception($"Template size different of {TEMPLATE_SIZE}.");

                _template = value;
            }
        }

        public ProgressBar(string id) : base(id)
        {
            _template = new char[] { '[', ' ', '█', ']' };
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
