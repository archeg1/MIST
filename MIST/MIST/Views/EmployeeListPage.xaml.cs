using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MIST.ViewModels;

namespace MIST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeListPage : ContentPage
    {
        EmployeeListViewModel viewModel;
        public EmployeeListPage()
        {
            InitializeComponent();
            viewModel = new EmployeeListViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }
        protected override async void OnAppearing()
        {
            await viewModel.GetEmployees();
            base.OnAppearing();
        }
    }
}