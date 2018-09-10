namespace Lands1.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Services;
    using Models;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Land> lands;
        //private List<Land> lands;  como se va a pintar en un listview debe ser OBservableCollection
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        #endregion


        #region Constructors
        public LandsViewModel()
        {
            this.apiService = new ApiService();  //instancia la clase apiservice para poder consumirlo
            this.LoadLands();     //cargapaises metodo
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            //ejecuta el metodo de obter paises GetList de Land que esta en la clase ApiService
            var response = await this.apiService.GetList<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        }
        #endregion

    }
}
