namespace Lands1.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        //aqui van las entradas/literales definidos en Resource.resx
        public static string Error
        {
            get { return Resource.Error; }
        }
        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }
        public static string Accept
        {
            get { return Resource.Accept; }
        }
        public static string RememberMe
        {
            get { return Resource.RememberMe; }
        }
        public static string EmailPlaceHolder
        {
            get { return Resource.EmailPlaceHolder; }
        }
    }

}
