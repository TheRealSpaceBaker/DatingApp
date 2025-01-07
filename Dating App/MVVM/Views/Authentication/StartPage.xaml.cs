using System.Security.Cryptography.X509Certificates;
using Dating_App.MVVM.Models.Data;

namespace Dating_App.MVVM.Views.Authentication;

public partial class StartPage : ContentPage
{
    private readonly DatingRegistry _db;
    public StartPage(DatingRegistry db)
	{
		InitializeComponent();
        _db = db;
        Session.LoggedInUser = null;
    }

	public void OnLoginClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage(_db));
    }
	public void OnRegisterClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterPage(_db));
    }

}
