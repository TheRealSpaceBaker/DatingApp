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

        //MessagesView = new ObservableCollection<MessageViewModel>
        //    {
        //        new MessageViewModel { Name = "Persoon 1", Message = "Meest Recente Bericht", Picture = "qa.png" },
        //        new MessageViewModel { Name = "Persoon 2", Message = "Meest Recente Bericht", Picture = "qa.png"  },
        //        new MessageViewModel { Name = "Persoon 3", Message = "Meest Recente Bericht", Picture = "qa.png"  },
        //        new MessageViewModel { Name = "Persoon 4", Message = "Meest Recente Bericht", Picture = "qa.png"  },
        //        new MessageViewModel { Name = "Persoon 5", Message = "Meest Recente Bericht", Picture = "qa.png"  }
        //    };

        BindingContext = this;
    }

    private async void FillViewModel()
    {
        MessagesView = new ObservableCollection<MessageViewModel>();
        var data = await Session.LoggedInUser.GetMatches();
        foreach (var message in data) 
        {
            var viewModel = new MessageViewModel() { Name = message.Match.Name, Picture = "qa.png" };

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


    private void MessageClicked(object sender, TappedEventArgs e)
    {
        Console.WriteLine("Message");
    }
}