using System;
using System.Collections.Generic;
using System.Text;
using TWidgets.Core.Events;
using TWidgets.Core.Input;

namespace TWidgets.Core.Input
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

        #region Events

        public event EventHandler<EventArgs> BeforeCapture;
        public void OnBeforeCapture()
        {
            this.BeforeCapture?.Invoke(this, new EventArgs());
        }

        public event EventHandler<EventArgs> AfterCapture;
        public void OnAfterCapture()
        {
            this.AfterCapture?.Invoke(this, new EventArgs());
        }

        public event EventHandler<InputEventArgs> Captured;
        public void OnCaptured(string id, char value)
        {
            this.Captured?.Invoke(this, new InputEventArgs(id, value));
        }
        public void OnCaptured(string id, string value)
        {
            this.Captured?.Invoke(this, new InputEventArgs(id, value));
        }

        #endregion

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

        private char Read()
        {
            return (char)Console.Read();
        }

        private char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        private string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
