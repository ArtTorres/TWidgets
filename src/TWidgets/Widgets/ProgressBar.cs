using System;
using TWidgets.Core;
using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    public class ProgressBar : BoxWidget
    {
        private double _maximum;
        public double Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                if (value < Minimum) Minimum = value;
                if (value < Value) Value = value;

                _maximum = value;
            }
        }

        private double _minimum;
        public double Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                if (value > Maximum) Maximum = value;
                if (value > Value) Value = value;

                _minimum = value;
            }
        }

        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value > Maximum)
                    _value = Maximum;
                else if (value < Minimum)
                    _value = Minimum;
                else
                    _value = value;

                this.OnStateChanged();
            }
        }

        public double Step { get; set; } = 10.0d;

        private char[] _template;
        public char[] Template
        {
            get
            {
                return _template;
            }
            set
            {
                if (_template.Length != ProgressBarTemplate.TEMPLATE_SIZE)
                    throw new Exception($"Template size different of {ProgressBarTemplate.TEMPLATE_SIZE}.");

                _template = value;
            }
        }

        public ProgressBar(string id) : base(id)
        {
            _maximum = 100.0d;
            _minimum = 0.0d;

            _template = ProgressBarTemplate.SIMPLE;
            this.Position = Position.Fixed;
        }

        public override void Draw(Graphics g)
        {
            g.Draw(new Text(
                $"{Template[ProgressBarTemplate.BAR_START]}{ComposeBar(g.Canvas.Width)}{Template[ProgressBarTemplate.BAR_END]}",
                this.Margin
                )
            );
        }

        public void PerformStep()
        {
            this.Value += this.Step;
        }

        private string ComposeBar(int canvasWidth)
        {
            double width = (this.Width == 0 ? canvasWidth : this.Width) - 2 - this.Margin.Left - this.Margin.Right;

            int filled = (int)(Value * width / Maximum);
            int background = (int)(width - filled);

            return string.Concat(
                new string(Template[ProgressBarTemplate.BAR_FILLED], filled),
                new string(Template[ProgressBarTemplate.BAR_BACKGROUND], background)
            );
        }
    }
}
