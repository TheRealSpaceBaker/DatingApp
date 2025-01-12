using Dating_App.MVVM.Views.Authentication;
using Dating_App.MVVM.Models;
using Dating_App.MVVM.Models.Data;
using Dating_App.MVVM.ViewModels;
using SQLite;

namespace Dating_App.MVVM.Views;

public partial class Profile : ContentPage
{
    private DatingRegistry _db = new DatingRegistry();
    private ProfileViewModel ProfileView = new ProfileViewModel();
    private string _selectedImagePath;
    public Profile()
    {
        InitializeComponent();

        if (Session.LoggedInUser?.ProfilePicture != null)
        {
            // Convert byte array back to an image source
            ProfilePicture.Source = ImageSource.FromStream(() => new MemoryStream(Session.LoggedInUser?.ProfilePicture));
        }

        BindingContext = ProfileView;
    }

    private void OnLogOutClicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new StartPage(_db));
    }
    private void PrintInfo(object sender, EventArgs e)
    {
        Console.WriteLine(Session.LoggedInUser.Name);
    }
    private async void OnUploadClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select an Image"
            });

            if (result != null)
            {
                _selectedImagePath = result.FullPath;

                ProfilePicture.Source = ImageSource.FromFile(_selectedImagePath);

                SaveButton.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
    public async void OnSaveClicked(object sender, EventArgs e)
    {
        byte[] imageBytes = File.ReadAllBytes(_selectedImagePath);

        Session.LoggedInUser.ProfilePicture = imageBytes;

        await _db.AddOrUpdateUser(Session.LoggedInUser);
    }

}