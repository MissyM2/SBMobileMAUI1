using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole;

namespace SBMobileMAUI1;

public partial class App : Application
{
	public App()
	{
		// Create a logger configuration.
		Log.Logger = new LoggerConfiguration()
			.WriteTo.Console()
			.MinimumLevel.Information()
			.CreateLogger();
			
		InitializeComponent();

		MainPage = new AppShell();
	}
}
