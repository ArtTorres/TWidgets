using System;

namespace TWidgets.Widgets
{
    /// <summary>
    /// Represents a progressive text bar with text.
    /// </summary>
    public class ProgressItem
    {
        #region Events

        /// <summary>
        /// Occurs when the value of an <see cref="ProgressItem"/> changed./>.
        /// </summary>
        public event EventHandler<EventArgs> ItemChanged;

        /// <summary>
        /// Raises the <see cref="ItemChanged"/> event.
        /// </summary>
        public void OnItemChanged()
        {
            this.ItemChanged?.Invoke(this, new EventArgs());
        }

        #endregion

        /// <summary>
        /// Gets or sets the maximum value of the <see cref="ProgressItem"/>.
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
        /// Gets or sets the minimal value of the <see cref="ProgressItem"/>.
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
        /// Gets or sets the value of the <see cref="ProgressItem"/>.
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

                this.OnItemChanged();
            }
        }
        private double _value;

        /// <summary>
        /// Gets or sets the size of the value increments.
        /// </summary>
        public double Step { get; set; } = 10.0d;

        /// <summary>
        /// Gets or sets the text after the bar in the <see cref="ProgressItem"/>.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                this.OnItemChanged();
            }
        }
        private string _text;

        /// <summary>
        /// Initializes an instance of <see cref="ProgressItem"/>.
        /// </summary>
        public ProgressItem()
        {
            _maximum = 100.0d;
            _minimum = 0.0d;

            this.Text = string.Empty;
        }

        /// <summary>
        /// Performs a increment on the value in the <see cref="ProgressItem"/>.
        /// </summary>
        public void PerformStep()
        {
            this.Value += this.Step;
        }
    }
}
