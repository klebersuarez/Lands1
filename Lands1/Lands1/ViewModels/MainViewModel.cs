namespace Lands1.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;
    using Helpers;

    public class MainViewModel
    {
        #region Properties
        //estas propiedades estaran visibles en toda la App
        // creo la propiedad LandList para que este disponible desde la Mainviewmodel y la borro de la LandsViewModel
        public List<Land> LandsList
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;
        }

        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }
        public LandsViewModel Lands
        {   get;
            set;
        }
        public LandViewModel Land
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();

        }
        #endregion

        #region Methods
        //crea el menu hamburguesa master detail
        private void LoadMenu()
        {
            this.Menus= new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add( new MenuItemViewModel 
            {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title = Languages.MyProfile
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "StatsPage",
                Title = Languages.Stats
            });
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut
            });
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
