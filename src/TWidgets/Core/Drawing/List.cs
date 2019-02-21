
namespace TWidgets.Core.Drawing
{
    public class List : IMarginable, IAlignable
    {
        /// <summary>
        /// Gets or sets the align of text.
        /// </summary>
        public Align Align { get; set; }

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
