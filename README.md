# TWidgets

Twidgets is a framework for building text-based widgets that can be displayed in the console.

It already implement a collection of Twidgets to start with. If they're not enought, you can build your own Twidgets in a few steps.

Input Twidgets are available for scenarios where you need user interaction.

Give it a try and share your experience.

----

## Quick Install
Package Manager:
``` shell
PM> Install-Package Twidgets
```

[>> See more installation options](https://github.com/arttorres/TWidgets/wiki/Install)

---
## Quick Start
Example: Drawing a simple marquee presentation.

``` csharp
using Twidgets;

class Program
{
    static void Main(string[] args){
        var widget=new Marquee("demo");

        widget.Items = new string[] {
            "Welcome to Twidgets",
            "<Get Started>"
        };
        
        WidgetPlayer.Mount(widget);
    }
}
```

Output:

``` shell
┌─────────────────────────────┐
│     Welcome to Twidgets     │
│        <Get Started>        │
└─────────────────────────────┘
```
[>> See more on Get Started](https://github.com/arttorres/TWidgets/wiki/Get-Started)

---
## Project References
- [Homepage](https://github.com/arttorres/Twidgets/wiki)
- [Get Started](https://github.com/arttorres/TWidgets/wiki/Get-Started)
- [Documentation](https://github.com/arttorres/TWidgets/wiki/Documentation)
- [Nuget Package](https://www.nuget.org/packages/TWidgets)
- [Release Notes](https://github.com/arttorres/TWidgets/releases)
- [Contributing Guidelines](https://github.com/arttorres/TWidgets/.github/CONTRIBUTING)
- [License](https://github.com/arttorres/TWidgets/LICENSE)

## Related Projects
- [EasyApp. A easy and ready application framework.](https://github.com/arttorres/EasyApp)
- [MagnetArgs. An argument parser with magnetism.](https://github.com/arttorres/MagnetArgs)
