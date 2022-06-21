using MIST.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MIST.Views
{
    public class ProgrammerPage : EmployeePage
    {
        public ProgrammerViewModel ViewModel { get; private set; }
        public ProgrammerPage(EmployeeViewModel vm):base()
        {
            ViewModel = (ProgrammerViewModel)vm;
            ContentStack.Children.Add(new Label { Text = "Языки программирования" });
            var languagesEntry = new Entry { };
            languagesEntry.SetBinding(Entry.TextProperty, "languages");
            ContentStack.Children.Add(languagesEntry);
            this.BindingContext = ViewModel;
        }
    }
}