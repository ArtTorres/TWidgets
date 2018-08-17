using System;

namespace QApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class OptionSetAttribute : Attribute
    {
        public int HelpOrder
        {
            get;
            set;
        }

        public OptionSetAttribute(int helpOrder = 0)
        {
            this.HelpOrder = helpOrder;
        }
    }
}
