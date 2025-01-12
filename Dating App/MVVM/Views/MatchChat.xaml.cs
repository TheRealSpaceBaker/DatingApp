using System.Collections.ObjectModel;
using Dating_App.MVVM.Models;
using Dating_App.MVVM.ViewModels;

namespace Dating_App.MVVM.Views;

public partial class MatchChat : ContentPage
{
    private User _match;
    public ObservableCollection<MatchChatViewModel> MatchChatView { get; set; }
    public MatchChat(User match)
	{
		InitializeComponent();

        _match = match;

        FillViewModel();

        BindingContext = this;
    }
    private async void FillViewModel()
    {
        MatchChatView = new ObservableCollection<MatchChatViewModel>();
        var data = await Session.LoggedInUser.GetMessages(_match);
        foreach (var message in data)
        {
            var viewModel = new MatchChatViewModel() { MatchMessage = message };
            MatchChatView.Add(viewModel);
        }
    }
}