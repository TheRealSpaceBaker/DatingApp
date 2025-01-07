using System.Collections.ObjectModel;
using Dating_App.MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace Dating_App.MVVM.Views;

public partial class Messages : ContentPage
{
    public ObservableCollection<MessageViewModel> MessagesView { get; set; }
    public Messages()
	{
		InitializeComponent();

        
        MessagesView = new ObservableCollection<MessageViewModel>
            {
                new MessageViewModel { Name = "Persoon 1", Message = "Meest Recente Bericht", Picture = "qa.png" },
                new MessageViewModel { Name = "Persoon 2", Message = "Meest Recente Bericht", Picture = "qa.png"  },
                new MessageViewModel { Name = "Persoon 3", Message = "Meest Recente Bericht", Picture = "qa.png"  },
                new MessageViewModel { Name = "Persoon 4", Message = "Meest Recente Bericht", Picture = "qa.png"  },
                new MessageViewModel { Name = "Persoon 5", Message = "Meest Recente Bericht", Picture = "qa.png"  }
            };

        BindingContext = this;
    }
}