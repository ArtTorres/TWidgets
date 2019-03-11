using System;
using TWidgets.Core.Drawing;

namespace TWidgets
{
    /// <summary>
    /// Represents a text message in the <see cref="Console"/>.
    /// </summary>
    public class Message : TWidgetBase
    {
        /// <summary>
        /// Gets or sets the text of the message.
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
                this.OnStateChanged();
            }
        }
        private string _text;

        /// <summary>
        /// Initializes an instance of <see cref="Message"/>.
        /// </summary>
        /// <param name="id">The identifier of the widget.</param>
        public Message(string id) : base(id)
        { }

        /// <summary>
        /// Executes to draw the widget.
        /// </summary>
        /// <param name="g">A <see cref="Graphics"/> object.</param>
        public override void Draw(Graphics g)
        {
            g.Draw(new Text(this.Text, this.Margin) { Align = this.TextAlign });
        }
    }
}
