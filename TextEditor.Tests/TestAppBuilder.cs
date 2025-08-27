using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Headless;
using Avalonia;
using TextEditor.Tests;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]
namespace TextEditor.Tests
{
    public class TestAppBuilder
    {
        public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
            .UseHeadless(new AvaloniaHeadlessPlatformOptions());
    }
}
