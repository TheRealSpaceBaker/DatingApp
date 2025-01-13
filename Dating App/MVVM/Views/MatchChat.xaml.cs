using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Dating_App.MVVM.Models;
using Dating_App.MVVM.Models.Data;
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

        Title = match.Name;

        FillViewModel();

        BindingContext = this;
    }
    private async void FillViewModel()
    {
        MatchChatView = new ObservableCollection<MatchChatViewModel>();
        var data = await Session.LoggedInUser.GetMessages(_match);
        foreach (var message in data)
        {
            AddViewModel(message);
        }
    }
    private async void AddViewModel(Message message)
    {
        bool currentUserIsUser1 = message.User1Id == Session.LoggedInUser.Id;
        int column = message.User1IsSender == currentUserIsUser1 ? 1 : 0;
        var viewModel = new MatchChatViewModel() { Match = _match, Column = column, MatchMessage = message };
        MatchChatView.Add(viewModel);
    }

    private async void SendTapped(object sender, TappedEventArgs e)
    {
        var _db = new DatingRegistry();
        var message = new Message()
        {
            IsMatch = false,
            User1Id = Session.LoggedInUser.Id,
            User2Id = _match.Id,
            User1IsSender = true,
            MessageContent = TextBox.Text,
            DateTimeSent = DateTime.Now
        };
        AddViewModel(await _db.AddOrUpdateMatch(message));
        TextBox.Text = "";
    }
}