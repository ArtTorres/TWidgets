namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Represents a text list which can be drawn on a <see cref="Canvas"/>.
    /// </summary>
    public class List : IMarginable, IAlignable
    {
        /// <summary>
        /// Gets or sets the align of list.
        /// </summary>
        public Align Align { get; set; }

        /// <summary>
        /// Gets or sets the margin of the list.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// Gets or sets the text items in the list.
        /// </summary>
        public string[] Items { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        /// <param name="items"></param>
        public List(string[] items)
            : this(items, new Margin())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class.
        /// </summary>
        /// <param name="items">The text items in the list.</param>
        /// <param name="margin">The margin of the list.</param>
        public List(string[] items, Margin margin)
        {
            this.Items = items;
            this.Margin = margin;
        }
    }
}
