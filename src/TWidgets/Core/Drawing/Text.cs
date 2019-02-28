namespace TWidgets.Core.Drawing
{
    /// <summary>
    /// Represents a text which can be drawn on a <see cref="Canvas"/>.
    /// </summary>
    public class Text : IMarginable, IAlignable
    {
        /// <summary>
        /// Gets or sets the text value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the align of the text.
        /// </summary>
        public Align Align { get; set; }

        /// <summary>
        /// Gets or sets the margin of the text.
        /// </summary>
        public Margin Margin { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class.
        /// </summary>
        /// <param name="value">The text value</param>
        public Text(string value)
        {
            Value = value;
            Margin = new Margin();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Text"/> class.
        /// </summary>
        /// <param name="value">The text value.</param>
        /// <param name="magin">The margin of the text.</param>
        public Text(string value, Margin magin)
        {
            Value = value;
            Margin = magin;
        }
    }
}
