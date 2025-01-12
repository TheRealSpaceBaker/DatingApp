using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.MVVM.ViewModels
{
    public class MessageViewModel
    {
        public string? Name { get; set; }
        public string? Message { get; set; }
        public string? Picture { get; set; }


        public Command<MessageViewModel> MessageTappedCommand => new Command<MessageViewModel>((message) =>
        {
            // Print the name of the clicked user to the console
            Console.WriteLine($"Clicked on user: {message.Name}");
        });
    }
}
