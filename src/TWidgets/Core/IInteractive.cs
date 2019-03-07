using System.Collections.Generic;
using TWidgets.Core.Drawing;
using TWidgets.Core.Interactive;

namespace TWidgets.Core.Input
{
    /// <summary>
    /// Provides the functions to implement a input widget.
    /// </summary>
    public interface IInteractive
    {
        /// <summary>
        /// Gets the input values.
        /// </summary>
        Dictionary<string, string> Values { get; }

        /// <summary>
        /// Gets the cursor position for capture.
        /// </summary>
        ConsoleCursor CursorPosition { get; }

        /// <summary>
        /// Sets a input value.
        /// </summary>
        /// <param name="id">The id of the input value.</param>
        /// <param name="value">The input value.</param>
        void MapValues(string id, string value);

        /// <summary>
        /// Executes to perform capture actions.
        /// </summary>
        /// <returns>A collection of instances of <see cref="InputAction"/>.</returns>
        IEnumerable<InputAction> InputActions();

        /// <summary>
        /// Executes to valide the capture actions.
        /// </summary>
        /// <param name="id">The id of the input value.</param>
        /// <param name="value">The input value.</param>
        /// <returns>The result of the validation.</returns>
        ValidateAction ValidateAction(string id, string value);

        /// <summary>
        /// Executes to draw a header before the capture of inputs.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        void DrawHeader(Graphics g);

        /// <summary>
        /// Executes to draw a footer after the capture of inputs.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        void DrawFooter(Graphics g);

        /// <summary>
        /// Executes to draw a list of error messages.
        /// </summary>
        /// <param name="g">A graphics object.</param>
        /// <param name="messages"></param>
        void DrawError(Graphics g, IEnumerable<string> messages);
    }
}
