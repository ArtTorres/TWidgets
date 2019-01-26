using TWidgets;
using TWidgets.Util;
using TWidgets.Widgets;
using System;

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

            WidgetPlayer.Mount(marquee);

            Console.WriteLine("--END--");

            var separator = new Separator("sep");
            separator.Margin.All = 1;

            WidgetPlayer.Mount(separator);

            Console.WriteLine("--END--");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hola ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Mundo");

            Console.ReadKey();
        }
    }
}
