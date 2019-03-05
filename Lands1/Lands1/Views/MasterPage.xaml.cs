using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Lands1.Views
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            App.Navigator = Navigator;  //Para que el menu Navigator sea visible en toda la App
        }
    }
}
