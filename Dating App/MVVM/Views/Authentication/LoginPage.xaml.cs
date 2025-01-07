using Dating_App.MVVM.Models;
using Dating_App.MVVM.Models.Data;

namespace Dating_App.MVVM.Views.Authentication;

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
        if (string.IsNullOrEmpty(EmailOrUsernameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
        {
            DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }
        User loggedInUser = await _db.GetUser(EmailOrUsernameEntry.Text);
        if (loggedInUser == null)
        {
            DisplayAlert("Error", "User not found", "OK");
            return;
        }
        Session.LoggedInUser = loggedInUser;
        App.Current.MainPage = new NavigationPage(new Navigationbar());
    }
}