using Dating_App.MVVM.Models;
using System;
using Dating_App.MVVM.Models.Data;

namespace Dating_App.MVVM.Views.Authentication;

public partial class RegisterPage : ContentPage
{
    private readonly DatingRegistry _db;
	public RegisterPage(DatingRegistry db)
	{
		InitializeComponent();
        _db = db;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UsernameEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(PhoneEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text) || string.IsNullOrEmpty(ConfirmPasswordEntry.Text))
        {
            DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }
        else if (!string.Equals(PasswordEntry.Text, ConfirmPasswordEntry.Text))
        {
            DisplayAlert("Error", "Passwords do not match\nPlease try again", "OK");
            return;
        }
        else
        {
            var loggedInUser = await _db.AddOrUpdateUser(new User 
            {
                Username = UsernameEntry.Text,
                CapitalizedUsername = UsernameEntry.Text.ToUpper(),
                Email = EmailEntry.Text,
                CapitalizedEmail = EmailEntry.Text.ToUpper(),
                Name = NameEntry.Text,
                PhoneNumber = PhoneEntry.Text,
                Password = PasswordEntry.Text
            });
            if (loggedInUser != null) 
            {
                Session.LoggedInUser = loggedInUser;
                await DisplayAlert("Success", "Created account successfully\nWelcome!", "OK");
                App.Current.MainPage = new NavigationPage(new Navigationbar());
            }
            else
            {
                DisplayAlert("Error", _db.statusMessage, "OK");
            }
            return;
        }
    }
}