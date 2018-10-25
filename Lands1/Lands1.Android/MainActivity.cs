using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;

namespace Lands1.Droid
{
    [Activity(Label = "Lands1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
#pragma warning disable CS0618 // 'CachedImageRenderer' está obsoleto: 'Use the same class in FFImageLoading.Forms.Platform namespace'
            CachedImageRenderer.Init(true);
#pragma warning restore CS0618 // 'CachedImageRenderer' está obsoleto: 'Use the same class in FFImageLoading.Forms.Platform namespace'
            LoadApplication(new App());
        }
    }
}