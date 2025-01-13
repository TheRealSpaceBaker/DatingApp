using Dating_App.MVVM.Views.Authentication;
using Dating_App.MVVM.Models;
using Dating_App.MVVM.Models.Data;
using Dating_App.MVVM.ViewModels;
using SQLite;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace Dating_App.MVVM.Views;

public partial class Profile : ContentPage
{
    private DatingRegistry _db = new DatingRegistry();
    private ProfileViewModel ProfileView = new ProfileViewModel();
    private string _selectedImagePath;

    private readonly string _apiKey = "1HBk9fdF8A6IsHY99cMQ8YcMP2CtXVHCDQnaqCNuSAvMMZpmJMe5JQQJ99BAAC5RqLJXJ3w3AAAFACOGNpXD"; 
    private readonly string _endpoint = "https://datingappnsfwdetectionapi.cognitiveservices.azure.com/";

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

                if (! await CheckImageForNSFW(_selectedImagePath))
                {
                    await DisplayAlert("Warning", "The image contains explicit content", "OK");
                    return;
                }

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
    public async Task<bool> CheckImageForNSFW(string imageUrl)
    {
        var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(_apiKey))
        {
            Endpoint = _endpoint   
        };

        List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
        {
            VisualFeatureTypes.Adult
        };
        using var imageStream = File.OpenRead(imageUrl);
        ImageAnalysis results = await client.AnalyzeImageInStreamAsync(imageStream, features);

        return !(results.Adult.IsAdultContent || results.Adult.IsRacyContent || results.Adult.IsGoryContent);

    }
}