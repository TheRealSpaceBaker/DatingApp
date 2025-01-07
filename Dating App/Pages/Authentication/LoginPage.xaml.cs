using Dating_App.Models.Data;
using Dating_App.Models;

namespace Dating_App.Pages.Authentication;

public partial class LoginPage : ContentPage
{
    private readonly DatingRegistry _db;
    public LoginPage(DatingRegistry db)
    {
        InitializeComponent();
        Session.LoggedInUser = null;
        _db = db;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
        {
            DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }
        User loggedInUser = await _db.GetUser(NameEntry.Text);
        if (loggedInUser == null)
        {
            DisplayAlert("Error", "User not found", "OK");
            return;
        }
        Session.LoggedInUser = loggedInUser;
        App.Current.MainPage = new NavigationPage(new Pages.Navigationbar());
    }
}