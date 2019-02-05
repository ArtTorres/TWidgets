using System;
using System.Collections.Generic;
using System.Text;

namespace TWidgets.Core
{
    internal sealed class InputEngine
    {
        #region Instance

        private static readonly Lazy<InputEngine> instance = new Lazy<InputEngine>(() => new InputEngine());

        public static InputEngine Instance
        {
            get
            {
                return instance.Value;
            }
        }

        #endregion

        public event EventHandler<EventArgs> BeforeRender;
        public void OnBeforeRender()
        {
            this.BeforeRender?.Invoke(this, new EventArgs());
        }

        public InputCursor SystemCursor { get; private set; }

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

        private InputEngine()
        {
            SystemCursor = new InputCursor();
        }

        public void SaveSystemCursor()
        {
            SystemCursor.X = Console.CursorLeft;
            SystemCursor.Y = Console.CursorTop;
        }

        public void LoadSystemCursor()
        {
            Console.SetCursorPosition(
                SystemCursor.X,
                SystemCursor.Y
            );
        }

        public char Read()
        {
            return (char)Console.Read();
        }

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
