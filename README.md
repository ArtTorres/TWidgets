# TWidgets

TWidgets is a framework for building text-based widgets that can be displayed in the console.

It already implement a collection of Twidgets to start with. If they're not enought, you can build your own Twidgets in a few steps.

Input TWidgets are available for scenarios where you need user interaction.

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
        var twidget=new Marquee("demo");

        twidget.Items = new string[] {
            "Welcome to Twidgets",
            "<Get Started>"
        };
        
        TWidgetPlayer.Mount(twidget);
    }
}
```

Output:

``` shell
┌─────────────────────────────┐
│     Welcome to TWidgets     │
│        <Get Started>        │
└─────────────────────────────┘
```
[>> See more on Get Started](https://github.com/arttorres/TWidgets/wiki/Get-Started)

---
## Project References
- [Homepage](https://arttorres.github.io/TWidgets)
- [Get Started](https://arttorres.github.io/TWidgets/articles/quickstart.html)
- [Documentation](https://arttorres.github.io/TWidgets/api/TWidgets.html)
- [Nuget Package](https://www.nuget.org/packages/TWidgets)
- [Release Notes](https://github.com/arttorres/TWidgets/releases)
- [Contributing Guidelines](https://github.com/ArtTorres/TWidgets/blob/master/.github/CONTRIBUTING.md)
- [License](https://github.com/ArtTorres/TWidgets/blob/master/LICENSE)

## Related Projects
- [EasyApp. A simple and ready application framework.](https://github.com/arttorres/EasyApp)
- [MagnetArgs. An argument parser with magnetism.](https://github.com/arttorres/MagnetArgs)
