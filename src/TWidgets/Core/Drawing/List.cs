
namespace TWidgets.Core.Drawing
{
    public class List : IMarginable
    {
        public Margin Margin { get; set; }

        public string[] Items { get; private set; }

        public List(string[] items)
            : this(
                 items,
                 new Margin()
            )
        {
        }

        public List(string[] items, Margin margin)
        {
            this.Items = items;
            this.Margin = margin;
        }
    }
}
