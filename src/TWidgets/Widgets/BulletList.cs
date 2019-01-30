using System.Collections.Generic;
using System.Linq;
using TWidgets.Core.Drawing;
using TWidgets.Util;

namespace TWidgets.Widgets
{
    public class BulletList : Widget
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

        public BulletList(string id) : base(id)
        { }

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
            );
        }

        private IEnumerable<string> JoinBullets(string[] items)
        {
            foreach (var item in items)
            {
                yield return string.Concat(this.Bullet, " ", item);
            }
        }
    }
}
