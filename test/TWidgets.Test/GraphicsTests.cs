using TWidgets.Core.Drawing;
using Xunit;

namespace TWidgets.Test
{
    public class GraphicsTests
    {
        [Fact]
        public void RawDrawing()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);
        }

        [Fact]
        public void LineDrawing()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);
        }

        [Fact]
        public void RectangleDrawing()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);
        }

        [Fact]
        public void FillRectangleDrawing()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);
        }

        [Fact]
        public void TextDrawing()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);

            var text = new Text("Hello World") { Align = Align.Left };
            text.Margin.Left = 1;
            text.Margin.Right = 1;
            graphics.Draw(text);

            text.Align = Align.Center;
            graphics.Draw(text);

            text.Align = Align.Right;
            graphics.Draw(text);

            Assert.Equal("#Hello World########", canvas.Map[0]);
            Assert.Equal("#####Hello World####", canvas.Map[1]);
            Assert.Equal("########Hello World#", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);
        }

        [Fact]
        public void ListDrawing()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);

            var list = new List(new string[] {
                "Four",
                "Five",
                "Nine"
            });
            list.Margin.Left = 1;
            list.Margin.Right = 1;

            graphics.Draw(list);

            list.Align = Align.Center;
            graphics.Draw(list);

            list.Align = Align.Right;
            graphics.Draw(list);

            Assert.Equal("#Four###############", canvas.Map[0]);
            Assert.Equal("#Five###############", canvas.Map[1]);
            Assert.Equal("#Nine###############", canvas.Map[2]);
            Assert.Equal("########Four########", canvas.Map[3]);
            Assert.Equal("########Five########", canvas.Map[4]);
            Assert.Equal("########Nine########", canvas.Map[5]);
            Assert.Equal("###############Four#", canvas.Map[6]);
            Assert.Equal("###############Five#", canvas.Map[7]);
            Assert.Equal("###############Nine#", canvas.Map[8]);
            Assert.Equal(9, canvas.Rows);
        }
    }
}
