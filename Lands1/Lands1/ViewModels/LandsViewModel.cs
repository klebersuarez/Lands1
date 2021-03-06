﻿namespace Lands1.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Services;
    using Models;
    using Xamarin.Forms;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System.Linq;

    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<LandItemViewModel> lands;  //private List<Land> lands;  como se va a pintar en un listview debe ser OBservableCollection, deberia se la observable coleccion de la Model Land (clase), pero se movio a la clase LandItemvieModel porque hay codigo
        private bool isRefreshing;   //atributo refrescado de la listview al que hace referencia en la LandsView
        private string filter;
        //private List<Land> landList;  //la borro porque se la creo como propiedad en la MainViewModel , para que pueda hacer listado de Borders

        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set { 
                SetValue(ref this.filter, value);
                this.Search();
            }
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
            this.IsRefreshing = true;
            //chequeo si hay conexion
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message,"Aceptar" );
                await Application.Current.MainPage.Navigation.PopAsync();  //retrocede pagina
                return;
            }

            //ejecuta el metodo de obter paises GetList de Land que esta en la clase ApiService
            var response = await this.apiService.GetList<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)   //si no hay conexion a internet
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();  //retrocede pagina
                return;
            }
            this.IsRefreshing = false;
            //this.landList = (List<Land>)response.Result;  //se cambia por la linea a continuacion, ya que la propiedad landList se movio a MainViewModel como LandsList para que este disponible en todo el proyecto
            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;   //la propiedad LandsList que esta en la Mainviewmodel va a tener el resultado de lista de paises
            this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());   // para convertir de una lista de tipo Land a una LandItemViewModel
        }

        
        //metodo que convierte la observable colection Land a LandItemViewModel para no ponerle el Icommand a la clase Land que es modelo, sino a la LandItemViewModel clase q hereda de la Land
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().LandsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            }); 
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }

        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            //si el filtro esta vacia , muestra la lista original nuevamente
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            }
            else 
            {
                //carga la lista usando LINQ System.Linq , con condiciones where
                //ademas si quiero que la listview se actualice cada vez q ingresa una letra en el texto Filter, 
                //en esa definicion propiedad debo llamar este metodo Search (ver propiedad Filter)
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(this.Filter.ToLower()) 
                                       || l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion

    }
}
