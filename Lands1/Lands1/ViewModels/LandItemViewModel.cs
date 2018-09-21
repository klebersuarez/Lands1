namespace Lands1.ViewModels
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Models;
    using Xamarin.Forms;

    //esta clase para colocar el comando SelectLandCommand ya que no se puede colocarlo en la clase Land porque daña el modelo
    public class LandItemViewModel : Land
    {
        #region Commandos
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);
            }
        }
        #endregion

        #region Metodos
        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);   //se pasa como parametro el objeto seleccionado, toda la clase this. , para instanciar usando patron singleton implementado en mainviewmodel
            await Application.Current.MainPage.Navigation.PushAsync(new LandPage());
        }
        #endregion

    }


}
