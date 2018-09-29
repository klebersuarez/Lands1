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

        #endregion

        #region Constructors
        //llamado al constructor desde el Icommand SelectLandCommnad que llama al metodo SelectLand en la clase LandItemViewModel, que pasa como parametro el objeto land que se ha seleccionado en la View  LandsPage TapGestureRecognizer al seleccionar un pais
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
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
