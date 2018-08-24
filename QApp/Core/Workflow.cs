using QApp.Widgets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core
{
    public class Workflow
    {
        private static Workflow _instance;
        public static Workflow Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new Workflow();

                return _instance;
            }
        }

        private Stack<string> _history;
        public Dictionary<string, IWidget> Items { get; set; }

        public IWidget this[string key]
        {
            get
            {
                return Current();
            }
            set
            {
                Next(key);
            }
        }

        private Workflow()
        {
            _history = new Stack<string>();
            this.Items = new Dictionary<string, IWidget>();
        }

        public IWidget Previous()
        {
            return this.Items[_history.Pop()];
        }

        public IWidget Current()
        {
            return this.Items[_history.Peek()];
        }

        public IWidget Next(string id)
        {
            _history.Push(id);

            return this.Items[_history.Peek()];
        }
    }

    public static class Extensions
    {
        public static void Add(this Dictionary<string, IWidget> obj, IWidget widget)
        {
            obj.Add(widget.Id, widget);
        }
    }
}
