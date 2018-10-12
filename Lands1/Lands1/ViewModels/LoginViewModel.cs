
namespace Lands1.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;
    using Services;
    using Helpers;

    public class LoginViewModel : BaseViewModel
    {
        //#region Events
        //public event PropertyChangedEventHandler PropertyChanged;
        //#endregion

        #region Services
        private ApiService apiService;
        #endregion

        #region Atributes
        //Los atributos van en minuscula , y son las mismas propiedades que se van a refrescar esto relacionado a Interfaz InotifyPropertyChanged
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
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
            //validaciones que el usuario haya ingresado datos -- con idioma usando los archivos Resource.resx 
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
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

            // valida login
            this.IsRunning = true;   //habilita 
            this.IsEnabled = false; //desabilita botones login register

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;   //habilita 
                this.IsEnabled = true; //desabilita botones login register

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var token = await this.apiService.GetToken("https://lands1api201810.azurewebsites.net", this.Email, this.Password);
            if (token == null)
            {
                this.IsRunning = false;   //habilita 
                this.IsEnabled = true; //desabilita botones login register
                await Application.Current.MainPage.DisplayAlert(
                    "Error",                    
                    "Something was Wrong, plese try later",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;   //habilita 
                this.IsEnabled = true; //desabilita botones login register
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    token.ErrorDescription,
                    "Aceptar");
                this.Password = string.Empty;
                return;
            }
            //if (this.Email != "jzuluaga55@gmail.com" || this.Password !="1234"  ){
            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error",
            //        "Datos incorrectos ",
            //        "Aceptar");
            //    this.Password = string.Empty;
            //    this.IsRunning = false;   //habilita 
            //    this.IsEnabled = true; //desabilita botones login register
            //    return;
            //}
           

            //navega a la sgte pagina
            this.IsRunning = false;   //des habilita 
            this.IsEnabled = true; //habilita botones login register
            this.Email = string.Empty;
            this.Password = string.Empty;
            //await Application.Current.MainPage.DisplayAlert(
            //        "OK",
            //        "Perfecto ",
            //        "Aceptar");
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            mainViewModel.Lands = new LandsViewModel();   //para instanciar landsviewmodel usando patron singleton implementado en mainviewmodel
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

        }
        #endregion


        #region Constructor
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsRemembered = true;
            this.IsRunning = false;
            this.IsEnabled = true;
            
        }
        #endregion
    }
}
