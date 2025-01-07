using Dating_App.Models.Data;
using Dating_App.Pages.Authentication;

namespace Dating_App
{
    public partial class App : Application
    {
        public static DatingRegistry _db { get; set; }
        public App(DatingRegistry db)
        {

            InitializeComponent();

            _db = db;
            MainPage = new NavigationPage( new Pages.Authentication.StartPage(_db));
            
        }
    }
}
