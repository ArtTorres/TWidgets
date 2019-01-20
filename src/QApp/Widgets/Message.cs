using QApp.Core.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Widgets
{
    public class Message : Widget
    {
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
                this.OnStateChanged();
            }
        }

        public Message(string id) : base(id)
        {}

        public override void Draw(Graphics g)
        {
            g.DrawText(this.Text, this.Margin, this.Padding);
        }
    }
}
