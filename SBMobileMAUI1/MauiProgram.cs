using LocalizationResourceManager.Maui;
using Microsoft.Extensions.Logging;
using SBMobileMAUI1.SupportingFiles.Localization;
using Serilog;
using Serilog.Formatting.Compact;

namespace SBMobileMAUI1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		//  SERILOG
		SetupSerilog();

		builder
			.UseMauiApp<App>()
			.RegisterAppServices()
			.RegisterViewsAndViewModels()
			.UseLocalizationResourceManager(settings =>
			{
				settings.RestoreLatestCulture(true);
				settings.AddResource(AppResources.ResourceManager);
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
	{
		// mauiAppBuilder.Services.AddSingleton<IAlertController, AlertControl>();
		// mauiAppBuilder.Services.AddSingleton<MessageManager>();
		// mauiAppBuilder.Services.AddSingleton<IDialogService, DialogService>();
		// //mauiAppBuilder.Services.AddSingleton<SurveyBuilderApplication>();
		// mauiAppBuilder.Services.AddSingleton<BroadcastMessageService>();

		return mauiAppBuilder;

	}

	public static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		// PAGES AND VIEW MODELS
		// mauiAppBuilder.Services.AddSingleton<FaqPage>();
		// mauiAppBuilder.Services.AddSingleton<FaqPageVM>();
		// mauiAppBuilder.Services.AddSingleton<ContactPage>();
		// mauiAppBuilder.Services.AddSingleton<ContactPageVM>();
		// mauiAppBuilder.Services.AddSingleton<SettingsPageVM>();
		// mauiAppBuilder.Services.AddSingleton<SettingsPage>();
		// mauiAppBuilder.Services.AddSingleton<IncentivesPageVM>();
		// mauiAppBuilder.Services.AddSingleton<IncentivesPage>();
		// mauiAppBuilder.Services.AddSingleton<SurveyListPageVM>();
		// mauiAppBuilder.Services.AddSingleton<SurveyListPage>();
		// mauiAppBuilder.Services.AddSingleton<SurveyLandingPageVM>();
		// mauiAppBuilder.Services.AddSingleton<SurveyLandingPage>();
		// mauiAppBuilder.Services.AddSingleton<LoginPage>();
		// mauiAppBuilder.Services.AddSingleton<LoginPageVM>();

		return mauiAppBuilder;
	}

	private static void SetupSerilog()
	{
		try
		{

			Console.WriteLine(LogHelper.GetLogFilename());
			var file = LogHelper.GetLogFilename();

			/*
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.WithProperty("Project", "NASA")
            .WriteTo.File(file, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
            .CreateLogger();
            */

			Log.Logger = new LoggerConfiguration()
					 // Set default log level limit to Debug
					 .MinimumLevel.Debug()
					 //.WriteTo.NSLog()  //xamarin sink
					 // Create a custom logger in order to set another limit,
					 // particularly, any logs from Information level will also be written into a rolling file
					 .WriteTo.Logger(config =>
						 config
							 .MinimumLevel.Information()
							 .WriteTo.File(new CompactJsonFormatter(), LogHelper.GetLogFilename()
							 , retainedFileCountLimit: 7
							 , rollingInterval: RollingInterval.Day
							 )
					 )
					 //.Enrich.WithProperty("DeviceInfoModel", DeviceInfo.Model)
					 //.Enrich.WithProperty("DeviceInfoManufacturer", DeviceInfo.Manufacturer)
					 //.Enrich.WithProperty("DeviceInfoVersionString", DeviceInfo.VersionString)
					 //.Enrich.WithProperty("DeviceInfoPlatform", DeviceInfo.Platform)
					 //.Enrich.WithProperty("AppVersion", VersionTracking.CurrentBuild)


					 .CreateLogger();

		}
		catch (Exception ex)
		{
			Console.WriteLine("SetupSerilog: " + ex.Message);
		}
	}



}
