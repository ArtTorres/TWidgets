﻿using MagnetArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Parsers
{
    public class MessagePriorityParser : IParser
    {
        public object Parse(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "high":
                    return MessagePriority.High;
                case "medium":
                    return MessagePriority.Medium;
                case "low":
                    return MessagePriority.Low;
                default:
                    throw new Exception(string.Format("Value {0} for MessagePriority not found.", value));
            }
        }
    }
}
