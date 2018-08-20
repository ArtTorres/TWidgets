using System;

namespace QApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class HelpGroupAttribute : Attribute
    {
        public int HelpOrder
        {
            get;
            set;
        }

        public HelpGroupAttribute(int helpOrder = 0)
        {
            this.HelpOrder = helpOrder;
        }
    }
}
