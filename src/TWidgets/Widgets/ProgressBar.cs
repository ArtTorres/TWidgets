using System;
using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    /// <summary>
    /// Represents a progressive text bar in the <see cref="Console"/>.
    /// </summary>
    public class ProgressBar : BoxWidget
    {
        /// <summary>
        /// Gets or sets the maximum value of the <see cref="ProgressBar"/>.
        /// </summary>
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
        private double _maximum;

        /// <summary>
        /// Gets or sets the minimal value of the <see cref="ProgressBar"/>.
        /// </summary>
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
        private double _minimum;

        /// <summary>
        /// Gets or sets the value of the <see cref="ProgressBar"/>.
        /// </summary>
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
        private double _value;

        /// <summary>
        /// Gets or sets the size of the value increments.
        /// </summary>
        public double Step { get; set; } = 10.0d;

        /// <summary>
        /// Gets or sets the progress bar template.
        /// </summary>
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
        private char[] _template;

        /// <summary>
        /// Initializes an instance of <see cref="ProgressBar"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public ProgressBar(string id) : base(id)
        {
            _maximum = 100.0d;
            _minimum = 0.0d;

            _template = ProgressBarTemplate.SIMPLE;
            this.Position = Position.Fixed;
        }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            g.Draw(new Text(
                $"{Template[ProgressBarTemplate.BAR_START]}{ComposeBar(g.Canvas.Width)}{Template[ProgressBarTemplate.BAR_END]}",
                this.Margin
                )
            );

            string ComposeBar(int canvasWidth)
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

        /// <summary>
        /// Performs a increment on the value in the <see cref="ProgressBar"/>.
        /// </summary>
        public void PerformStep()
        {
            this.Value += this.Step;
        }
    }
}
