namespace Lands1.ViewModels
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Models;
    using Xamarin.Forms;

    //esta clase se creo para colocar el comando SelectLandCommand ya que no se puede colocarlo en la clase Land porque daña el modelo.  Se llama desde el Gesture Recognizer en el View  LandsPage
    public class LandItemViewModel : Land
    {
        #region Commands
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
            MainViewModel.GetInstance().Land = new LandViewModel(this);   //se instancia la LandViewModel se pasa como parametro el objeto seleccionado (el pais osea Land) para que se ejecute en el constructor, toda la clase this. , para instanciar usando patron singleton implementado en mainviewmodel
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());    //antes LandPage
        }
        #endregion

    }


}
