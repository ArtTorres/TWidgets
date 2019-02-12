using System;
using System.Linq;
using System.Threading;
using TWidgets;
using TWidgets.Util;
using TWidgets.Widgets;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        static void MessageSample()
        {
            var msg = new Message("txt")
            {
                Text = "Hello World"
            };
            msg.Margin.All = 1;
            msg.ForegroundColor = WidgetColor.Red;

            WidgetPlayer.Mount(msg);

            Console.WriteLine("--END--");
        }

        static void MarqueeSample()
        {
            var marquee = new Marquee("mar");
            marquee.Items = new string[] {
                "Hello World",
                "GoodBye World"
            };
            marquee.Margin.All = 1;
            marquee.Padding.All = 1;
            marquee.Border.Template = BorderTemplate.DOTTED;
            marquee.ForegroundColor = WidgetColor.Blue;

            WidgetPlayer.Mount(marquee);

            Console.WriteLine("--END--");
        }

        static void SeparatorSample()
        {
            var separator = new Separator("sep");
            separator.Margin.All = 1;
            separator.ForegroundColor = WidgetColor.Yellow;

            WidgetPlayer.Mount(separator);

            Console.WriteLine("--END--");
        }

        static void BulletSample()
        {
            var list = new BulletList("lst");
            list.Margin.All = 1;
            list.BackgroundColor = WidgetColor.DarkBlue;
            list.ForegroundColor = WidgetColor.White;
            list.Items = new string[] {
                "Uno",
                "Dos",
                "Tres"
            };

            WidgetPlayer.Mount(list);

            Console.WriteLine("--END--");
        }

        static void TextInputSample()
        {
            var tInput = new TextInput("txi");
            tInput.HeaderText = "Example Header";

            WidgetPlayer.Mount(tInput);

            Console.WriteLine("--END--");

            foreach (var value in tInput.Values)
            {
                Console.WriteLine("{0},{1}", value.Key, value.Value);
            }
        }

        static void ProgressBarSample()
        {
            var progress = new ProgressBar("pb");
            progress.Width = 0;
            progress.Margin.All = 1;
            progress.Template = ProgressBarTemplate.ARROW;

            WidgetPlayer.Mount(progress);

            for (int i = 0; i < 10; i++)
            {
                progress.PerformStep();
                Thread.Sleep(200);
            }

            Console.WriteLine("--END--");
        }

        static void ProgressCharSample()
        {
            var progress = new ProgressChar("pc");
            progress.Text = "Start Message";

            WidgetPlayer.Mount(progress);

            for (int i = 0; i < 5;)
            {
                progress.Text = $"Message {++i:00}";
                Thread.Sleep(500);
            }

            Console.WriteLine("--END--");
        }

        static void StopMessageSample()
        {
            var widget = new StopMessage("txt")
            {
                Text = "-- Press to Continue --"
            };

            WidgetPlayer.Mount(widget);

            Console.WriteLine("--END--");
        }

        static void OptionInputSample()
        {
            var widget = new OptionInput("cinput")
            {
                InstructionsText = "Select an option >>",
                ErrorText = "Option no available, select one of the list!",
                Items = new string[] {
                    "Item A",
                    "Item B",
                    "Item C"
                },
                NumberSeparator = ')'
            };
            widget.Margin.All = 1;

            WidgetPlayer.Mount(widget);

            Console.WriteLine("--END--");
        }

        static void ProgressListSample()
        {
            var widget = new ProgressList("plist");
            widget.Width = 20;
            widget.Margin.All = 1;
            widget.Items.Add(new ProgressItem() { Text = "Item A" });
            widget.Items.Add(new ProgressItem() { Text = "Item B" });
            widget.Items.Add(new ProgressItem() { Text = "Item C" });

            var random = new Random();

            WidgetPlayer.Mount(widget);

            do
            {
                widget.Items[random.Next(widget.Items.Count)].PerformStep();
                Thread.Sleep(500);
            } while (!AreTasksFinished());

            Console.WriteLine("--END--");

            bool AreTasksFinished()
            {
                return 100 == widget.Items.Select(s => s.Value).Sum() / widget.Items.Count;
            }
        }
    }
}
