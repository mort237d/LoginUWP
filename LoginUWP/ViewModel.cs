using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using LoginUWP.Annotations;

namespace LoginUWP
{
    class ViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username { get; set; }
        public string Password { get; set; }
        public string ErrorMessage {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private List<User> userList = new List<User>(){new User("Morten", "Jagd"), new User("Kaffe", "Kage"), new User("k","k")};

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }

        private MainPage _mainPage;

        public ViewModel()
        {
            LoginCommand = new RelayCommand(OnLoginClick);
            ExitCommand = new RelayCommand(OnExitClick);
        }

        public void OnLoginClick()
        {
            foreach (var user in userList)
            {
                if (user.Username == Username && user.Password == Password)
                {
                    Frame currentFrame = Window.Current.Content as Frame;
                    currentFrame.Navigate(typeof(LoginBlankPage));
                    break;
                }
                else
                {
                    ErrorMessage = "ERROR!!!";
                }
            }
        }

        public void OnExitClick()
        {
            CoreApplication.Exit();
        }

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
