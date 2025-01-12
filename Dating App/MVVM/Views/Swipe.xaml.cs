using Dating_App.MVVM.ViewModels;
namespace Dating_App.MVVM.Views;

public partial class Swipe : ContentPage
{
    public Swipe()
    {
        InitializeComponent();



        BindingContext = new SwipeViewModel();
    }
}
