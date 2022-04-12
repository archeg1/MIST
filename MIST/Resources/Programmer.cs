using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIST.Resources
{
    internal class Programmer : Employee
    {
        List<String> languagesList;
        Programmer()
        {

        }
        public Programmer(String creatingString)
        {

        }

        public override double getSalary()
        {
            return IEmployee.MROT + languagesList.Count*500 + experience*120;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}