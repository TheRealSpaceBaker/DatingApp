using System.Collections.ObjectModel;
using Dating_App.MVVM.ViewModels;

namespace Dating_App.MVVM.Views;

public partial class MatchChat : ContentPage
{
    public ObservableCollection<MatchChatViewModel> MatchChatView { get; set; }
    public MatchChat()
	{
		InitializeComponent();
        //FillViewModel();

    }
    //private async void FillViewModel()
    //{
    //    MatchChatView = new ObservableCollection<MatchChatViewModel>();
    //    var data = await Session.LoggedInUser.GetMessages();
    //    foreach (var message in data)
    //    {
    //        var viewModel = new MatchChatViewModel() { };


    //        MatchChatView.Add(viewModel);
    //    }
    //}
}