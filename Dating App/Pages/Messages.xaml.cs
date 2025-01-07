using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace Dating_App;

public partial class Messages : ContentPage
{
    public ObservableCollection<MessageModel> MessagesView { get; set; }
    public Messages()
	{
		InitializeComponent();

        
        MessagesView = new ObservableCollection<MessageModel>
            {
                new MessageModel { Name = "Persoon 1", Message = "Meest Recente Bericht", Picture = "qa.png" },
                new MessageModel { Name = "Persoon 2", Message = "Meest Recente Bericht", Picture = "qa.png"  },
                new MessageModel { Name = "Persoon 3", Message = "Meest Recente Bericht", Picture = "qa.png"  },
                new MessageModel { Name = "Persoon 4", Message = "Meest Recente Bericht", Picture = "qa.png"  },
                new MessageModel { Name = "Persoon 5", Message = "Meest Recente Bericht", Picture = "qa.png"  }
            };

        BindingContext = this; // Set BindingContext to this page
    }
    public class MessageModel
    {
        public string? Name { get; set; }
        public string? Message { get; set; }
        public string? Picture { get; set; }
    }
}