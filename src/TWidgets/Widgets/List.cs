using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core.Drawing;

namespace TWidgets.Widgets
{
    public class List : Box
    {
        public char Bullet { get; set; } = '■';

        private string[] _items;
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

        public List(string id) : base(id)
        { }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
