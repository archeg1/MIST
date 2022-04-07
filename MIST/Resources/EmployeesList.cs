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
    class EmployeesList
    {

        private List<IEmployer> employers;

        public EmployeesList()
        {

        }

        public void Clear()
        {
            employers.Clear();
        }

        public float GetTotalSalary()
        {
            return employers.Sum(item => item.getSalary());
        }

        public float GetMidSalary()
        {
            return employers.Average(item => item.getSalary());
        }

        public void AddEmployer(IEmployer employer)
        {
            employers.Add(employer);
        }
    }
}