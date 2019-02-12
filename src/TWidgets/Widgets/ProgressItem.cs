using System;

namespace TWidgets.Widgets
{
    public class ProgressItem
    {
        #region Events

        public event EventHandler<EventArgs> ItemChanged;
        public void OnItemChanged()
        {
            this.ItemChanged?.Invoke(this, new EventArgs());
        }

        #endregion

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

        public double Step { get; set; } = 10.0d;

        private string _text;
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

                this.OnItemChanged();
            }
        }

        public ProgressItem()
        {
            _maximum = 100.0d;
            _minimum = 0.0d;

            this.Text = string.Empty;
        }

        public void PerformStep()
        {
            this.Value += this.Step;
        }
    }
}
