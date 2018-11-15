using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LoginUWP.Annotations;

namespace LoginUWP
{
    class User : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        public string Username {
            get { return _username; }
            set
            {
                _username = value;
            }
        }
        public string Password {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        public User(string username, string password)
        {
            _username = username;
            _password = password;
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
