using System;
namespace Lands1.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    {
        #region Attributes
        // como los Borders los voy a mostrar en un listview tengo que manejarlo como Observablecollection atributo y propiedad
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;

        #endregion

        #region Properties

        public Land Land
        {
            get;
            set;
        }

        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { this.SetValue(ref this.borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get { return this.currencies; }
            set { this.SetValue(ref this.currencies, value); }
        }

        public ObservableCollection<Language> Languages
        {
            get { return this.languages; }
            set { this.SetValue(ref this.languages, value); }
        }
        #endregion

        #region Constructors
        //llamado al constructor desde el Icommand SelectLandCommnad que llama al metodo SelectLand en la clase LandItemViewModel, que pasa como parametro el objeto land que se ha seleccionado en la View  LandsPage TapGestureRecognizer al seleccionar un pais
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Languages = new ObservableCollection<Language>(this.Land.Languages);
        }
        #endregion

        #region Methods
        private void LoadBorders()
        {
            //metodo que anade los Borders a la propiedad observable Borders
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList.Where(l => l.Alpha3Code == border).FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add (new Border  { Code = land.Alpha3Code, Name = land.Name});
                }
            }
            
        }
        #endregion


    }
}
