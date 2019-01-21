using QApp.Core.Drawing;
using QApp.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QApp.Widgets
{
    public class Marquee : Box
    {
        private string[] _lines;
        public string[] Lines
        {
            get
            {
                return _lines;
            }
            set
            {
                _lines = value;
                this.OnStateChanged();
            }
        }

        public Padding Padding { get; set; }

        public Marquee(string id) : base(id)
        {
            this.Padding = new Padding();
        }

        public override void Draw(Graphics g)
        {
            int rectangleHeight = this.Lines.Length + (this.Border.Width * 2) + this.Padding.Top + this.Padding.Bottom;
            g.Draw(
                new Rectangle(
                    g.Canvas.Width,
                    rectangleHeight,
                    this.Margin,
                    this.Border
                )
            );

            g.ResetCursors();

            var textMargin = new Margin(
                Margin.Top + Border.Width + Padding.Top,
                Margin.Left + Border.Width + Padding.Left,
                Margin.Bottom + Border.Width + Padding.Bottom,
                Margin.Right + Border.Width + Padding.Right
            );

            g.Canvas.RowCursor = textMargin.Top;

            foreach (var line in Resize(this.Lines, g.Canvas.Width))
            {
                g.Draw(line, textMargin.Left, g.Canvas.RowCursor);
                g.Canvas.RowCursor += 1;
            }
        }

        private string[] Resize(string[] lines, int maxWidth)
        {
            var output = new List<string>();

            foreach (var line in lines)
            {
                if (line.Length > maxWidth)
                {
                    output.AddRange(
                        TextUtils.Split(line, maxWidth)
                    );
                }
                else
                {
                    output.Add(line);
                }
            }

            return output.ToArray();
        }
    }
}
