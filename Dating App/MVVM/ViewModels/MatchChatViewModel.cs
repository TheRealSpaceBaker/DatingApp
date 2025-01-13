using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dating_App.MVVM.Models;

namespace Dating_App.MVVM.ViewModels
{
    public class MatchChatViewModel
    {
        public User Match { get; set; }
        public Message MatchMessage { get; set; }
        public int Column { get; set; }

    }
}
