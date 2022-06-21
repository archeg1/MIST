using MIST.Models;
using MIST.ViewModels;
using MIST.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIST
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage( new EmployeeListPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
