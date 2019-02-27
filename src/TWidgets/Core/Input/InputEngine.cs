using System;
using TWidgets.Core.Events;

namespace TWidgets.Core.Input
{
    /// <summary>
    /// Performs input operations in the system <see cref="Console"/>.
    /// </summary>
    internal sealed class InputEngine
    {
        #region Instance

        /// <summary>
        /// Gets an instance of <see cref="InputEngine"/>.
        /// </summary>
        public static InputEngine Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private static readonly Lazy<InputEngine> _instance = new Lazy<InputEngine>(() => new InputEngine());

        #endregion

        #region Events

        /// <summary>
        /// Occurs before capture an input.
        /// </summary>
        public event EventHandler<EventArgs> BeforeCapture;

        /// <summary>
        /// Raises the <see cref="BeforeCapture"/> event.
        /// </summary>
        public void OnBeforeCapture()
        {
            this.BeforeCapture?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Occurs after capture an input.
        /// </summary>
        public event EventHandler<EventArgs> AfterCapture;

        /// <summary>
        /// Raises the <see cref="AfterCapture"/> event.
        /// </summary>
        public void OnAfterCapture()
        {
            this.AfterCapture?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Occurs just after a input is captured.
        /// </summary>
        public event EventHandler<InputEventArgs> Captured;

        /// <summary>
        /// Raises the <see cref="Captured"/> event.
        /// </summary>
        public void OnCaptured(string id, char value)
        {
            this.Captured?.Invoke(this, new InputEventArgs(id, value));
        }

        /// <summary>
        /// Raises the <see cref="Captured"/> event.
        /// </summary>
        public void OnCaptured(string id, string value)
        {
            this.Captured?.Invoke(this, new InputEventArgs(id, value));
        }

        #endregion

        /// <summary>
        /// Gets cursor values.
        /// </summary>
        public InputCursor SystemCursor { get; private set; }

        /// <summary>
        /// Gets or sets cursor values in the <see cref="Console"/>.
        /// </summary>
        public InputCursor Cursor
        {
            get
            {
                return new InputCursor()
                {
                    X = Console.CursorLeft,
                    Y = Console.CursorTop
                };
            }

            set
            {
                Console.SetCursorPosition(value.X, value.Y);
            }
        }

        /// <summary>
        /// Initializes an instance of <see cref="InputEngine"/>.
        /// </summary>
        private InputEngine()
        {
            SystemCursor = new InputCursor();
        }

        /// <summary>
        /// Saves the <see cref="Console"/> cursors in a cache.
        /// </summary>
        public void SaveSystemCursor()
        {
            SystemCursor.X = Console.CursorLeft;
            SystemCursor.Y = Console.CursorTop;
        }

        /// <summary>
        /// Sets a cached cursors into <see cref="Console"/>.
        /// </summary>
        public void LoadSystemCursor()
        {
            Console.SetCursorPosition(
                SystemCursor.X,
                SystemCursor.Y
            );
        }

        /// <summary>
        /// Performs a read action from the standard input stream. 
        /// </summary>
        /// <param name="id">The identifier for the read action.</param>
        /// <param name="type">The type of read to be performed.</param>
        public void Capture(string id, InputMethod type)
        {
            switch (type)
            {
                case InputMethod.Read:
                    this.OnCaptured(id, this.Read());
                    break;
                case InputMethod.ReadKey:
                    this.OnCaptured(id, this.ReadKey());
                    break;
                case InputMethod.ReadLine:
                    this.OnCaptured(id, this.ReadLine());
                    break;
            }
        }

        /// <summary>
        /// Reads the next character from the standard input stream.
        /// </summary>
        /// <returns>A single character.</returns>
        private char Read()
        {
            return (char)Console.Read();
        }

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed key is displayed in the console window.
        /// </summary>
        /// <returns>A single character.</returns>
        private char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns>A text line.</returns>
        private string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
