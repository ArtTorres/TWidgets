using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TWidgets.Test
{
    public class GraphicsTests
    {
        //[Fact]
        //public void LineDrawing()
        //{
        //}

        //[Fact]
        //public void RectangleDrawing()
        //{
        //}

        //[Fact]
        //public void FillRectangleDrawing()
        //{
        //}

        //[Fact]
        //public void TextDrawing()
        //{
        //}

        [Fact]
        public void WidgetDrawing()
        {
            var message = new Widgets.Message("demo") { Text = "Hello World" };

            message.Draw(new Core.Drawing.Graphics());
        }
    }
}
