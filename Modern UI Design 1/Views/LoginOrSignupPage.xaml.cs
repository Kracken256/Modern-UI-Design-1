using Modern_UI_Design_1.API;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Modern_UI_Design_1.Views;

public partial class LoginOrSignupPage : ContentPage
{
	public LoginOrSignupPage()
	{
		InitializeComponent();
	}
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (email_input.Text.Length == 0)
        {
            is_valid_email_warning.IsVisible = false;
            return;
        }
        if (IsValidEmail(email_input.Text))
        {
            is_valid_email_warning.IsVisible = false;
        }
        return;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (!IsValidEmail(email_input.Text))
        {
            is_valid_email_warning.IsVisible = true;
            return;
        }
        if (UserAuth.UserExists(email_input.Text))
        {
            Navigation.PushModalAsync(new LoginPage(email_input.Text), false);
        }
    }
}