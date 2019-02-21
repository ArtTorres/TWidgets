namespace TWidgets.Core.Drawing
{
    public class Text : IMarginable, IAlignable
    {
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the align of text.
        /// </summary>
        public Align Align { get; set; }

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
