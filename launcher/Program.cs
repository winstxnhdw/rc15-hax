using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

Console.WriteLine("Waiting for Robocraft to launch..");
Process? process;

while ((process = Process.GetProcessesByName("RobocraftClient").SingleOrDefault()) is null) {
    Thread.Sleep(1000);
}

using Process game = process;
_ = game.WaitForInputIdle();
using Stream resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("Launcher.Payload.rc15-hax.dll")
    ?? throw new InvalidOperationException("The embedded rc15-hax payload is missing.");
byte[] payload = new byte[resource.Length];
resource.ReadExactly(payload);
Console.WriteLine("Loading rc15-hax...");
MonoInjector.Inject(game, payload);
Console.WriteLine("rc15-hax loaded.");

if (!Console.IsInputRedirected && !Console.IsOutputRedirected) {
    Console.WriteLine("Press any key to close.");
    _ = Console.ReadKey(intercept: true);
}
