using TWidgets.Core.Drawing;
using Xunit;

namespace TWidgets.Test
{
    public class CanvasTest
    {
        [Fact]
        public void DrawLine()
        {
            var canvas = new Canvas(20, 10, '#');

            canvas.DrawLine("Hello World");

            Assert.Equal("Hello World#########", canvas.Map[0]);
            Assert.Equal(1, canvas.Rows);
        }

        [Fact]
        public void DrawInPosition()
        {
            var canvas = new Canvas(20, 10, '#');

            canvas.Draw("Hello World", 3, 1);
            canvas.RowCursor = 2;

            Assert.Equal("####################", canvas.Map[0]);
            Assert.Equal("###Hello World######", canvas.Map[1]);
            Assert.Equal(2, canvas.Rows);
        }

        [Fact]
        public void CursorPositions()
        {
            var canvas = new Canvas(20, 10, '#');

            canvas.ColumnCursor = 2;
            canvas.RowCursor = 2;

            canvas.Draw("Hello World");

            canvas.RowCursor += 1;

            Assert.Equal("####################", canvas.Map[0]);
            Assert.Equal("####################", canvas.Map[1]);
            Assert.Equal("##Hello World#######", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);
        }

        [Fact]
        public void ResetCanvas()
        {
            var canvas = new Canvas(20, 10);

            canvas.DrawLine("Hello World");
            canvas.DrawLine("Hello World");
            canvas.DrawLine("Hello World");

            Assert.Equal(3, canvas.RowCursor);
            Assert.Equal(3, canvas.Rows);

            canvas.Clear();

            Assert.Equal(0, canvas.RowCursor);
            Assert.Empty(canvas.Map);
            Assert.Equal(0, canvas.Rows);
        }
    }
}
