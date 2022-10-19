using Microsoft.Maui.Controls;
using Modern_UI_Design_1.API;

namespace Modern_UI_Design_1;


public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		if (!UserAuth.IsLoggedIn())
		{
			App.Current.MainPage = new Views.LoginOrSignupPage();
		}

	}
}

