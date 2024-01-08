using Serilog;

namespace SBMobileMAUI1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		
		Log.Debug("In MainPage");
	}

	
}

