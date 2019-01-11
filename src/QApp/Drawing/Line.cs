using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Drawing
{
    public class Line
    {
        // Spaces
        public Margin Margin { get; set; }

        // Template
        public char Template { get; set; }
        public int Length { get; set; }

        public Line(char template, int length)
        {
            Template = template;
            Length = length;
        }

        //public string[] Draw()
        //{
        //    var output = new char[_length];

        //    for (int i = 0; i < _length; i++)
        //    {
        //        output[i] = _char;
        //    }

        //    return new string[] { output.ToString() };
        //}
    }
}
