using Avalonia;
using Avalonia.ReactiveUI;
using System;
using Avalonia.Threading;
using System.Threading;
using MirrorMirrorMvvm.ViewModels;


namespace MirrorMirrorMvvm;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);
    // Timer timer = new Timer(RefreshContext, null, TimeSpan.Zero, TimeSpan.FromSeconds(.1));

    // private static void RefreshContext(object? state)
    // {
    //     Console.WriteLine("Refresh");
    //     Dispatcher.UIThread.InvokeAsync(() =>
    //     {
    //         // refresh context here
    //         MainWindowViewModel vm = new MainWindowViewModel();
    //         vm.GetGreeting();
    //     });
    // }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
}
