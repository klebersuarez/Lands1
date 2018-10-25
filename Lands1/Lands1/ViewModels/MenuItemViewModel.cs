using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lands1.Views;
using Xamarin.Forms;

namespace Lands1.ViewModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }

        }

        private void Navigate()
        {
            if (this.PageName == "LoginPage")
            {
                var mainViewModel = MainViewModel.GetInstance();
                Application.Current.MainPage = new NavigationPage(
                    new LoginPage());
            }
        }
        #endregion
    }


}
