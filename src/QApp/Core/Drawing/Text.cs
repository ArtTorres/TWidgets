using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public class Text
    {
        public string Value { get; set; }

        public Margin Margin { get; set; }

        public Padding Padding { get; set; }

        public Text(string value)
        {
            Value = value;
            Margin = new Margin();
            Padding = new Padding();
        }

        public Text(string value, Margin magin)
        {
            Value = value;
            Margin = magin;
            Padding = new Padding();
        }

        public Text(string value, Margin magin, Padding padding)
        {
            Value = value;
            Margin = magin;
            Padding = padding;
        }
    }
}
