using Dating_App.MVVM.Views.Authentication;
using Dating_App.MVVM.Models;
using Dating_App.MVVM.Models.Data;
using Dating_App.MVVM.ViewModels;

namespace Dating_App.MVVM.Views;

public partial class Profile : ContentPage
{
    private DatingRegistry _db = new DatingRegistry();
    private ProfileViewModel ProfileView = new ProfileViewModel();
    public Profile()
    {
        InitializeComponent();

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
}