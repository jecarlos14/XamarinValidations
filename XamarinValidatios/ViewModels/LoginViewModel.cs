using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinValidatios.Views;

namespace XamarinValidatios.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T backingStore, T value,
                    [CallerMemberName]string propertyName = "",
                    Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        #region Instances
        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        #endregion

        #region Commands
        public ICommand LogInCommand { get; private set; }
        #endregion

        public LoginViewModel()
        {
            initClass();
            initCommands();
        }

        #region Private Methods
        private void initClass()
        {

        }

        private void initCommands()
        {
            LogInCommand = new Command(LogIn);
        }

        private void LogIn()
        {
            App.Current.MainPage = new HomeMasterDetailPage();
        }
        #endregion
    }
}
