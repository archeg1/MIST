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

        private List<IEmployee> employers;

        public delegate void EmployersHandler();

        public event EmployersHandler? EmployersCountChanged;

        public EmployeesList()
        {
            employers = new List<IEmployee>();
        }

        public EmployeesList(List<IEmployee> employees)
        {
            this.employers = employees;
        }

        public void Clear()
        {
            employers.Clear();
            EmployersCountChanged?.Invoke();
        }

        public double GetTotalSalary()
        {
            return employers.Sum(item => item.getSalary());
        }

        public double GetMidSalary()
        {
            return employers.Average(item => item.getSalary());
        }

        public void AddEmployer(IEmployee employer)
        {
            employers.Add(employer);
            EmployersCountChanged?.Invoke();
        }
    }
}