using TWidgets.Core.Drawing;
using Xunit;

namespace TWidgets.Test
{
    public class WidgetTests
    {
        [Fact]
        public void ProgressChar()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);
        }

        [Fact]
        public void ProgressBar()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);
        }

        [Fact]
        public void MessageTest()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);

            var widget = new Message("demo");
            widget.Text = "Hello World";
            widget.Margin.Left = 1;
            widget.Margin.Right = 1;

            widget.Draw(graphics);

            widget.TextAlign = Align.Center;
            widget.Draw(graphics);

            widget.TextAlign = Align.Right;
            widget.Draw(graphics);

            Assert.Equal("#Hello World########", canvas.Map[0]);
            Assert.Equal("#####Hello World####", canvas.Map[1]);
            Assert.Equal("########Hello World#", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);
        }

        [Fact]
        public void StopMessageTest()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);

            var widget = new StopMessage("demo");
            widget.Text = "Hello World";

            widget.Draw(graphics);

            widget.TextAlign = Align.Center;
            widget.Draw(graphics);

            widget.TextAlign = Align.Right;
            widget.Draw(graphics);

            Assert.Equal("Hello World#########", canvas.Map[0]);
            Assert.Equal("#####Hello World####", canvas.Map[1]);
            Assert.Equal("#########Hello World", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);
        }

        [Fact]
        public void MarqueeTest()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);

            var widget = new Marquee("demo");
            widget.Items = new string[] {
                "Four",
                "Five",
                "Nine"
            };

            widget.TextAlign = Align.Left;
            widget.Draw(graphics);

            Assert.Equal("┌──────────────────┐", canvas.Map[0]);
            Assert.Equal("│Four              │", canvas.Map[1]);
            Assert.Equal("│Five              │", canvas.Map[2]);
            Assert.Equal("│Nine              │", canvas.Map[3]);
            Assert.Equal("└──────────────────┘", canvas.Map[4]);
            Assert.Equal(5, canvas.Rows);

            canvas = new Canvas(20, 10, '#');
            graphics = new Graphics(canvas);

            widget.TextAlign = Align.Center;
            widget.Draw(graphics);

            Assert.Equal("┌──────────────────┐", canvas.Map[0]);
            Assert.Equal("│       Four       │", canvas.Map[1]);
            Assert.Equal("│       Five       │", canvas.Map[2]);
            Assert.Equal("│       Nine       │", canvas.Map[3]);
            Assert.Equal("└──────────────────┘", canvas.Map[4]);
            Assert.Equal(5, canvas.Rows);

            canvas = new Canvas(20, 10, '#');
            graphics = new Graphics(canvas);

            widget.TextAlign = Align.Right;
            widget.Draw(graphics);

            Assert.Equal("┌──────────────────┐", canvas.Map[0]);
            Assert.Equal("│              Four│", canvas.Map[1]);
            Assert.Equal("│              Five│", canvas.Map[2]);
            Assert.Equal("│              Nine│", canvas.Map[3]);
            Assert.Equal("└──────────────────┘", canvas.Map[4]);
            Assert.Equal(5, canvas.Rows);
        }

        [Fact]
        public void BulletListTest()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);

            var widget = new BulletList("demo");
            widget.Items = new string[] {
                "Four",
                "Five",
                "Nine"
            };

            widget.Draw(graphics);

            Assert.Equal("■ Four##############", canvas.Map[0]);
            Assert.Equal("■ Five##############", canvas.Map[1]);
            Assert.Equal("■ Nine##############", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);

            canvas = new Canvas(20, 10, '#');
            graphics = new Graphics(canvas);

            widget.TextAlign = Align.Center;
            widget.Draw(graphics);

            Assert.Equal("#######■ Four#######", canvas.Map[0]);
            Assert.Equal("#######■ Five#######", canvas.Map[1]);
            Assert.Equal("#######■ Nine#######", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);

            canvas = new Canvas(20, 10, '#');
            graphics = new Graphics(canvas);

            widget.TextAlign = Align.Right;
            widget.Draw(graphics);

            Assert.Equal("##############■ Four", canvas.Map[0]);
            Assert.Equal("##############■ Five", canvas.Map[1]);
            Assert.Equal("##############■ Nine", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);
        }

        [Fact]
        public void NumberListTest()
        {
            var canvas = new Canvas(20, 10, '#');
            var graphics = new Graphics(canvas);

            var widget = new NumberList("demo");
            widget.Items = new string[] {
                "One",
                "Two",
                "Six"
            };

            widget.Draw(graphics);

            Assert.Equal("1. One##############", canvas.Map[0]);
            Assert.Equal("2. Two##############", canvas.Map[1]);
            Assert.Equal("3. Six##############", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);

            canvas = new Canvas(20, 10, '#');
            graphics = new Graphics(canvas);

            widget.TextAlign = Align.Center;
            widget.Draw(graphics);

            Assert.Equal("#######1. One#######", canvas.Map[0]);
            Assert.Equal("#######2. Two#######", canvas.Map[1]);
            Assert.Equal("#######3. Six#######", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);

            canvas = new Canvas(20, 10, '#');
            graphics = new Graphics(canvas);

            widget.TextAlign = Align.Right;
            widget.Draw(graphics);

            Assert.Equal("##############1. One", canvas.Map[0]);
            Assert.Equal("##############2. Two", canvas.Map[1]);
            Assert.Equal("##############3. Six", canvas.Map[2]);
            Assert.Equal(3, canvas.Rows);
        }
    }
}
