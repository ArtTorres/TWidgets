using System;
using TWidgets;
using TWidgets.Util;
using TWidgets.Widgets;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var msg = new Message("txt")
            {
                Text = "Hello World"
            };
            msg.Margin.All = 1;
            msg.ForegroundColor = WidgetColor.Red;

            WidgetPlayer.Mount(msg);

            Console.WriteLine("--END--");

            var marquee = new Marquee("mar");
            marquee.Lines = new string[] {
                "Hello World",
                "GoodBye World"
            };
            marquee.Margin.All = 1;
            marquee.Padding.All = 1;
            marquee.Border.Template = BorderTemplates.DOTTED;
            marquee.ForegroundColor = WidgetColor.Blue;

            WidgetPlayer.Mount(marquee);

            Console.WriteLine("--END--");

            var separator = new Separator("sep");
            separator.Margin.All = 1;
            separator.ForegroundColor = WidgetColor.Yellow;

            WidgetPlayer.Mount(separator);

            Console.WriteLine("--END--");

            Console.WriteLine("Text with System Color");

            Console.ReadKey();
        }
    }
}
