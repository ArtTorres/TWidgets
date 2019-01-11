using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace QApp.Presentation
{
    public class Marquee
    {
        private MarqueeTemplate _template;
        private static Marquee _instance;

        private Marquee() { }

        public static Marquee Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new Marquee();
                    _instance._template = new MarqueeTemplate();
                }

                return _instance;
            }
        }

        public string[] Draw(int windowWidth, params string[] labels)
        {
            var output = new List<string>();

            // Draw Top Margin
            for (int i = 0; i < _template.Margin.top; i++)
                output.Add("");

            // Draw Top Line
            output.Add(this.DrawLine(windowWidth));

            // Draw Top Padding
            for (int i = 0; i < _template.Padding.top; i++)
                output.Add(this.DrawPadding(windowWidth));

            // Draw Labels
            output.AddRange(this.DrawLabels(windowWidth, labels));

            // Draw Bottom Padding
            for (int i = 0; i < _template.Padding.bottom; i++)
                output.Add(this.DrawPadding(windowWidth));

            // Draw Bottom Line
            output.Add(this.DrawLine(windowWidth, true));

            // Draw Bottom Margin
            for (int i = 0; i < _template.Margin.bottom; i++)
                output.Add("");

            return output.ToArray();
        }

        private string DrawLine(int maxWidth, bool drawBottom = false)
        {
            var buffer = new StringBuilder();

            // Draw Left Magin 
            for (int i = 0; i < _template.Margin.left; i++)
                buffer.Append(' ');

            // Draw Left Border
            int btix = drawBottom ? MarqueeTemplate.BORDER_BOTTOM_LEFT : MarqueeTemplate.BORDER_TOP_LEFT;
            buffer.Append(_template.BorderTemplate[btix]);

            // Draw Border
            int ix = drawBottom ? MarqueeTemplate.BORDER_BOTTOM : MarqueeTemplate.BORDER_TOP;
            int size = maxWidth - _template.Margin.left - _template.Margin.right - 2;
            for (int i = 0; i < size; i++)
                buffer.Append(_template.BorderTemplate[ix]);

            // Draw Right Border
            int bbix = drawBottom ? MarqueeTemplate.BORDER_BOTTOM_RIGHT : MarqueeTemplate.BORDER_TOP_RIGHT;
            buffer.Append(_template.BorderTemplate[bbix]);

            // Draw Right Magin 
            for (int i = 0; i < _template.Margin.right - 1; i++)
                buffer.Append(' ');

            return buffer.ToString();
        }

        private string DrawPadding(int maxWidth)
        {
            var buffer = new StringBuilder();

            // Draw Left Magin 
            for (int i = 0; i < _template.Margin.left; i++)
                buffer.Append(' ');

            // Draw Left Border
            buffer.Append(_template.BorderTemplate[MarqueeTemplate.BORDER_LEFT]);

            // Draw Border
            int size = maxWidth - _template.Margin.left - _template.Margin.right - 2;
            for (int i = 0; i < size; i++)
                buffer.Append(_template.BorderTemplate[MarqueeTemplate.BACKGROUND]);

            // Draw Right Border
            buffer.Append(_template.BorderTemplate[MarqueeTemplate.BORDER_RIGHT]);

            // Draw Right Magin 
            for (int i = 0; i < _template.Margin.right - 1; i++)
                buffer.Append(' ');

            return buffer.ToString();
        }

        private string[] DrawLabels(int maxWidth, string[] labels)
        {
            var output = new List<string>();

            int labelSize = labels.Max(s => s.Length);
            double leftSize = Math.Truncate((double)((maxWidth) / 2) - (labelSize / 2) - _template.Margin.left - _template.Padding.left - 1);

            foreach (var text in labels)
            {
                var buffer = new StringBuilder();

                // Draw Left Magin 
                for (int i = 0; i < _template.Margin.left; i++)
                    buffer.Append(' ');

                // Draw Left Border
                buffer.Append(_template.BorderTemplate[MarqueeTemplate.BORDER_LEFT]);

                // Draw Left Padding
                for (int i = 0; i < _template.Padding.left; i++)
                    buffer.Append(' ');

                // Draw Left Background
                for (int i = 0; i < leftSize; i++)
                    buffer.Append(_template.BorderTemplate[MarqueeTemplate.BACKGROUND]);

                // Draw Text
                buffer.Append(text);

                // Draw Right Background
                double rightSize = Math.Truncate((double)(maxWidth) - leftSize - _template.Margin.left - _template.Padding.left - text.Length - _template.Margin.right - _template.Padding.right - 2);
                for (int i = 0; i < rightSize; i++)
                    buffer.Append(_template.BorderTemplate[MarqueeTemplate.BACKGROUND]);

                // Draw Right Padding
                for (int i = 0; i < _template.Padding.right; i++)
                    buffer.Append(' ');

                // Draw Right Border
                buffer.Append(_template.BorderTemplate[MarqueeTemplate.BORDER_RIGHT]);

                // Draw Right Magin 
                for (int i = 0; i < _template.Margin.right - 1; i++)
                    buffer.Append(' ');

                output.Add(buffer.ToString());
            }

            return output.ToArray();
        }
    }
}
