using Dating_App.MVVM.Models.Data;
using Dating_App.MVVM.Views.Authentication;

namespace Dating_App
{
    public partial class App : Application
    {
        public static DatingRegistry _db { get; set; }
        public App(DatingRegistry db)
        {

            InitializeComponent();

            _db = db;
            MainPage = new NavigationPage( new StartPage(_db));
            
        }
    }
}
