using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Presentation
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class HeaderAttribute : Attribute
    {
        public string[] Values { get; private set; }

        public HeaderAttribute(params string[] headers)
        {
            this.Values = headers;
        }
    }
}
