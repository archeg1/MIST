using MIST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIST.Views
{
    public partial class EmployeesTypes : Popup
    {
        public static Size Small => new Size(300, 300);
        public List<String> types { get; set; }
        public EmployeesTypes()
        {
            InitializeComponent();
            types = getTypes();
            this.BindingContext = this;
        }

        public List<String> getTypes()
        {
            return EmployeeFactory.EmployeeTypes.Keys.ToList();
        }

        private void EmployeeTypesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Dismiss(e.SelectedItem.ToString());
        }
    }
}