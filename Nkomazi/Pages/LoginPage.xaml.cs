using Nkomazi.Models;

namespace Nkomazi.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text?.Trim();
        string password = passwordEntry.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Missing Info", "Please enter both username and password.", "OK");
            return;
        }

        if (await Core.AuthService.LoginAsync(username, password))
        {
            // Clear navigation stack and navigate to MainPage. 
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Invalid login credentials", "OK");
            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
            usernameEntry.Focus();
            return;
        }
    }

}