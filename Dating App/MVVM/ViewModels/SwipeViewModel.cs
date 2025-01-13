using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dating_App.MVVM.Models;
using Dating_App.MVVM.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Dating_App;
using Microsoft.Maui.Graphics;

namespace Dating_App.MVVM.ViewModels
{
    public partial class SwipeViewModel : ObservableObject
    {
        private readonly DatingRegistry _registry;
        private List<User> _allUsers;
        private int _currentIndex;

        [ObservableProperty]
        private User currentUser;

        [ObservableProperty]
        private ImageSource currentUserProfilePicture;

        [ObservableProperty]
        private bool hasUsers;

        [ObservableProperty]
        private bool hasNoUsers;

        public SwipeViewModel()
        {
            _registry = new DatingRegistry();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            // Fetch all users from the database
            var allUsers = await _registry.GetAllUsers();

            // Exclude the logged-in user
            _allUsers = allUsers?.Where(u => u.Id != Session.LoggedInUser?.Id).ToList();

            _currentIndex = 0;

            UpdateUserState();
        }

        [RelayCommand]
        private void Like()
        {
            MoveToNextUser();
        }

        [RelayCommand]
        private void Dislike()
        {
            MoveToNextUser();
        }

        private void MoveToNextUser()
        {
            if (_allUsers == null || _allUsers.Count == 0)
                return;

            _currentIndex++;

            UpdateUserState();
        }

        private void UpdateUserState()
        {
            if (_currentIndex < _allUsers?.Count)
            {
                CurrentUser = _allUsers[_currentIndex];
                if (CurrentUser?.ProfilePicture != null)
                {
                    CurrentUserProfilePicture = ImageSource.FromStream(() => new MemoryStream(CurrentUser.ProfilePicture));
                }
                else
                {
                    CurrentUserProfilePicture = "default_profile.jpg";
                }
                HasUsers = true;
                HasNoUsers = false;
            }
            else
            {
                CurrentUser = null;
                CurrentUserProfilePicture = "default_profile.jpg";
                HasUsers = false;
                HasNoUsers = true;
            }
        }
    }
}
