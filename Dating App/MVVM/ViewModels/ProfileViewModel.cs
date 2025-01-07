using Dating_App.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.MVVM.ViewModels
{
    public class ProfileViewModel
    {
        public User? LoggedInUser { get; set; } = Session.LoggedInUser;
        public string? Username { get; set; } = Session.LoggedInUser.Username;
        public string? Email { get; set; } = Session.LoggedInUser.Email;
        public string? Name { get; set; } = Session.LoggedInUser.Name;
        public string? PhoneNumber { get; set; } = Session.LoggedInUser.PhoneNumber;
    }
}
