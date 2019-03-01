using System;
using System.Collections.Generic;
using System.Linq;
using TWidgets.Core.Drawing;
using TWidgets.Core.Utils;

namespace TWidgets
{
    /// <summary>
    /// Represents a numbered list in the <see cref="Console"/>.
    /// </summary>
    public class NumberList : TWidget
    {
        /// <summary>
        /// Gets or sets the list items.
        /// </summary>
        public string[] Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                this.OnStateChanged();
            }
        }
        private string[] _items;

        /// <summary>
        /// Initializes an instance of <see cref="NumberList"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public NumberList(string id) : base(id)
        { }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            g.Draw(
                new List(
                    TextUtils.ResizeLines(
                        JoinBullets(this.Items).ToArray(),
                        g.Canvas.Width
                    ),
                    this.Margin
                )
                {
                    Align = this.TextAlign
                }
            );
        }

        /// <summary>
        /// Adds a bullet character to the list items.
        /// </summary>
        /// <param name="items">The current items.</param>
        /// <returns>A list of items preceded with a bullet.</returns>
        private IEnumerable<string> JoinBullets(string[] items)
        {
            int i = 0;
            foreach (var item in items)
            {
                yield return $"{++i}. {item}";
            }
        }
    }
}
