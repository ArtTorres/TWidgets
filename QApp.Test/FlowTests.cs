using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using QApp.Core;
using QApp.Widgets;

namespace QApp.Test
{
    public class FlowTests
    {
        [Fact]
        public void WidgetBasicExecution()
        {
            var manager = Workflow.Instance;
            manager.Items.Add(new Message("message-a"));
            manager.Items.Add(new Message("message-b"));
            manager.Items.Add(new Message("message-c"));

            var a1 = manager.Next("message-a");
            //TODO: Do something

            var b1 = manager.Next("message-b");
            //TODO: Do something

            var a2 = manager.Next("message-a");
            //TODO: Do something

            var c1 = manager.Next("message-c");
            //TODO: Do something
        }
    }
}
