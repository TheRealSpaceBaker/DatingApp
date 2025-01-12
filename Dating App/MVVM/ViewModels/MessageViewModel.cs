using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dating_App.MVVM.Models;
using Dating_App.MVVM.Views;

namespace Dating_App.MVVM.ViewModels
{
    public class MessageViewModel
    {
        public User Match { get; set; }
        public string? Name { get; set; }
        public string? Message { get; set; }
        public ImageSource? Picture { get; set; }

    }
}
