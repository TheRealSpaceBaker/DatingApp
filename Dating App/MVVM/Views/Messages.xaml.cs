using System.Collections.ObjectModel;
using Dating_App.MVVM.ViewModels;
using Dating_App.MVVM.Models;
using Microsoft.Maui.Controls;
using Dating_App.MVVM.Models.Data;

namespace Dating_App.MVVM.Views;

public partial class Messages : ContentPage
{
    public ObservableCollection<MessageViewModel> MessagesView { get; set; }
    public Messages()
	{
		InitializeComponent();

        FillViewModel();

        BindingContext = this;
    }

    private async void FillViewModel()
    {
        MessagesView = new ObservableCollection<MessageViewModel>();
        var data = await Session.LoggedInUser.GetMatches();
        foreach (var message in data) 
        {
            User otherUser = null;

            if (message.User1Id == Session.LoggedInUser.Id)
            {
                otherUser = message.User2;
            }
            else
            {
                otherUser = message.User1;
            }

            var viewModel = new MessageViewModel() { Match = otherUser, Name = otherUser.Name };

            if (otherUser.ProfilePicture != null)
            {
                viewModel.Picture = ImageSource.FromStream(() => new MemoryStream(otherUser.ProfilePicture));
            }
            else
            {
                viewModel.Picture = ImageSource.FromFile("default_profile.png");
            }

            if (message.MessageContent == null)
            {
                viewModel.Message = "No message yet.";
            }
            else
            {
                viewModel.Message = message.MessageContent;
            }

            MessagesView.Add(viewModel);
        }
    }

    private async void OnMessageTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is MessageViewModel matchTapped)
        {
            await Navigation.PushAsync(new MatchChat(matchTapped.Match));
        }
    }
}