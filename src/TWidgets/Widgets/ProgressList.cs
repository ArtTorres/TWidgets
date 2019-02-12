using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    public class ProgressList : BoxWidget
    {
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

        public ObservableCollection<ProgressItem> Items { get; set; }

        public ProgressList(string id) : base(id)
        {
            _template = ProgressBarTemplate.SIMPLE;
            this.Position = Position.Fixed;

            this.Items = new ObservableCollection<ProgressItem>();
            this.Items.CollectionChanged += OnCollectionChanged;
        }

        public override void Draw(Graphics g)
        {
            int ix = 0;
            int lix = this.Items.Count - 1;
            foreach (var item in this.Items)
            {
                int barWidth = (this.Width == 0 ? g.Canvas.Width - item.Text.Length - 1 : this.Width) - 2 - this.Margin.Left - this.Margin.Right;
                var margin = new Margin(ix == 0 ? Margin.Top : 0, Margin.Left, ix >= lix ? Margin.Bottom : 0, Margin.Right);

                g.Draw(
                    new Text(
                        string.Concat(
                            Template[ProgressBarTemplate.BAR_START],
                            ComposeBar(item, barWidth),
                            Template[ProgressBarTemplate.BAR_END],
                            $" {item.Text}"
                        ),
                        margin
                    )
                );

                ix++;
            }

            string ComposeBar(ProgressItem item, int canvasWidth)
            {
                int filled = (int)(item.Value * canvasWidth / item.Maximum);
                int background = (int)(canvasWidth - filled);

                return string.Concat(
                    new string(Template[ProgressBarTemplate.BAR_FILLED], filled),
                    new string(Template[ProgressBarTemplate.BAR_BACKGROUND], background)
                );
            }
        }

        #region Events

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in (sender as ObservableCollection<ProgressItem>))
                {
                    item.ItemChanged += OnItemChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in (sender as ObservableCollection<ProgressItem>))
                {
                    item.ItemChanged -= OnItemChanged;
                }
            }
        }

        private void OnItemChanged(object sender, EventArgs e)
        {
            this.OnStateChanged();
        }

        #endregion
    }
}
