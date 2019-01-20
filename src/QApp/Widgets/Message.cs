using QApp.Core.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Widgets
{
    public class Message : Widget
    {
        private string _text;
        public string Text {
            get
            {
                return _text;
            }
            set {
                _text = value;
                this.OnStateChanged();
            }
        }

        public Message(string id) : base(id)
        {
        }

        //public override void Init()
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Load()
        //{
        //    throw new NotImplementedException();
        //}

        public override Canvas Draw(Graphics g)
        {
            g.DrawLine();
            g.Draw(this.Text);
            g.DrawLine();

            return g.Canvas;
        }

        //public override void DrawComplete()
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Unload()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
