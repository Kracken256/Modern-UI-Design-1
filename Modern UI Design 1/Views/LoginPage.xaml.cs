using Modern_UI_Design_1.API;

namespace Modern_UI_Design_1.Views;

public partial class LoginPage : ContentPage
{
	private string email;
	public LoginPage()
	{
		InitializeComponent();
	}
	public LoginPage(string _email)
	{
		email = _email;
        InitializeComponent();
    }

	private void Button_Clicked(object sender, EventArgs e)
	{
		if (password_input.Text == null || password_input.Text.Length == 0)
		{
			is_valid_password_warning.IsVisible = true;
			return;
		}
		bool isValid = UserAuth.ValidateCreds(email,password_input.Text);
		if (isValid)
		{
			Navigation.PushModalAsync(new Dashboard());
		} else
		{
			is_valid_password_warning.IsVisible = true;
		}
		return;
	}

	private void Button_Clicked_1(object sender, EventArgs e)
	{
        Navigation.PushModalAsync(new LoginOrSignupPage(), false);
		return;
	}

	private void password_input_TextChanged(object sender, TextChangedEventArgs e)
	{
        if (password_input.Text.Length < 2)
        {
            is_valid_password_warning.IsVisible = false;
            return;
        }
    }
}