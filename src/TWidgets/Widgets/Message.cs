using TWidgets.Core.Drawing;

namespace TWidgets.Widgets
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
        { }

        public override void Draw(Graphics g)
        {
            g.Draw(new Text(this.Text, this.Margin) { Align = this.TextAlign });
        }
    }
}
