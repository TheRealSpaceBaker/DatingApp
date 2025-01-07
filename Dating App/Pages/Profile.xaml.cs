using Dating_App.Pages.Authentication;
using Dating_App.Models;
using Dating_App.Models.Data;

namespace Dating_App;

public partial class Profile : ContentPage
{
    private DatingRegistry _db = new DatingRegistry();
    public Profile()
    {
        InitializeComponent();
    }

    private void OnLogOutClicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new StartPage(_db));
    }
    private void PrintInfo(object sender, EventArgs e)
    {
        Console.WriteLine(Session.LoggedInUser.Name);
    }
}