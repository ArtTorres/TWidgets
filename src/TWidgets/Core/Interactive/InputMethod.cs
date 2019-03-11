using System;

namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Specifies constants that defines the input method in the <see cref="Console"/>.
    /// </summary>
    public enum InputMethod
    {
        /// <summary>
        /// Reads the next character from the standard input stream.
        /// </summary>
        Read,

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed key is displayed in the console window.
        /// </summary>
        ReadKey,

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        ReadLine
    }
}
