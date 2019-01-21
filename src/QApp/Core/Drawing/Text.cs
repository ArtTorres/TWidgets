using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public class Text : IMarginable
    {
        public string Value { get; set; }

        public Margin Margin { get; set; }

        public Text(string value)
        {
            Value = value;
            Margin = new Margin();
        }

        public Text(string value, Margin magin)
        {
            Value = value;
            Margin = magin;
        }
    }
}
