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
    internal class EmployeeCreator
    {
        public IEmployee CreateEmployee(string creatingString)
        {
            if (creatingString == null)
                return null;
            else
            {
                switch (creatingString)
                {
                    case string a when a.Contains("Программист"):
                        return new Programmer(creatingString);
                        break;

                }
                return new ScientificEmployee();
            }
        }
    }
}