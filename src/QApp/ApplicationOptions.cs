using MagnetArgs;
using QApp.Attributes;
using QApp.Parsers;
using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace QApp
{
    public class ApplicationOptions : MagnetOption
    {
        [Arg("--help", Alias = "-h"), IfPresent]
        [Help("Displays the help instructions.", Example = "--help", Group = "Help", Order = 0)]
        public bool ShowHelp { get; set; }

        //[Arg("--log", Alias = "-l"), Parser(typeof(MessagePriorityParser)), Default("low")]
        //[Help("Displays the logging options.", Example = "--log", Group = "Help", Order = 1)]
        //public MessagePriority MessagePriority { get; set; }
    }
}
