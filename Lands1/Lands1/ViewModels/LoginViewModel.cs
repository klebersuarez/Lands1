
namespace Lands1.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        //#region Events
        //public event PropertyChangedEventHandler PropertyChanged;
        //#endregion

        #region Atributes
        //Los atributos van en minuscula , y son las mismas propiedades que se van a refrescar esto relacionado a Interfaz InotifyPropertyChanged
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
            //get{
            //    return this.password;
            //}
            //set{
            //    if (this.password!=value)
            //    {
            //        this.password = value;
            //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Password)));
            //    }
            //}
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get{
                return new RelayCommand(Login);
            }
        }


        private async void Login()
        {
            //validaciones que el usuario haya ingresado datos
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe Ingresar Email",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe Ingresar Password",
                    "Aceptar");
                return;
            }


            this.IsRunning = true;   //habilita 
            this.IsEnabled = false; //desabilita botones login register
            if (this.Email != "jzuluaga55@gmail.com" || this.Password !="1234"  ){
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Datos incorrectos ",
                    "Aceptar");
                this.Password = string.Empty;
                this.IsRunning = false;   //habilita 
                this.IsEnabled = true; //desabilita botones login register
                return;
            }

            this.IsRunning = false;   //habilita 
            this.IsEnabled = true; //desabilita botones login register
            await Application.Current.MainPage.DisplayAlert(
                    "OK",
                    "Perfecto ",
                    "Aceptar");
        }
        #endregion


        #region Constructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsRunning = false;
            this.IsEnabled = true;
        }
        #endregion
    }
}
