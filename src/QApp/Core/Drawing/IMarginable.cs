using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core.Drawing
{
    public interface IMarginable
    {
        Margin Margin { get; set; }

        Padding Padding { get; set; }
    }
}
