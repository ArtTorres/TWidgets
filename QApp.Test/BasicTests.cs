using QApp.Presentation;
using QApp.Test.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace QApp.Test
{
    public class BasicTests
    {
        //private readonly ITestOutputHelper output;

        //public BasicTests(ITestOutputHelper output)
        //{
        //    this.output = output;
        //}

        [Fact]
        public void MarqueeTemplate()
        {
            var width = 12;
            var lines = new string[] { "line one", "line two", "line three" };
            var marquee = Marquee.Instance.Draw(width, lines);

            var result = new StringBuilder();
            result.Append(@"
                ############
                # line one #
                # line two #
                #line three#
                ############            
            ");

            Assert.Equal(result.ToString(), marquee.ToString());
        }

        [Fact]
        public void HelpTemplate()
        {

        }

        [Fact]
        public void DisplayHeader()
        {

        }

        [Fact]
        public void DisplayHelp()
        {

        }

        [Fact]
        public void MapArguments()
        {

        }

        [Fact]
        public void BasicExecution()
        {
            var args = new string[] {
                "",""
            };

            var app = new BasicApp();
            app.Execute(args);

        }
    }
}
