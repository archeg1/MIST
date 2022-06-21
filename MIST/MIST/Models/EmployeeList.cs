using MIST.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;

namespace MIST
{
    [JsonConverter(typeof(EmployeeConverter))]
    public class EmployeeList : INotifyPropertyChanged
    {
        private ObservableCollection<IEmployee> employees;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public EmployeeList()
        {
            employees = new ObservableCollection<IEmployee>();
        }
        public ObservableCollection<IEmployee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public double TotalSolary
        {
            get
            {
                return GetTotalSolary();
            }
        }
        public void clear()
        {
            employees.Clear();
        }
        public double GetTotalSolary()
        {
            return employees.Sum(x => x.getSolary());
        }
        public double GetMaxSolary()
        {
            return employees.Max(x => x.getSolary());
        }
        public double GetMinSolary()
        {
            return employees.Min(x => x.getSolary());
        }
        public void Add(IEmployee temp)
        {
            employees.Add(temp);
            OnPropertyChanged("TotalSolary");
        }
        public void Remove(IEmployee temp)
        {
            employees.Remove(temp);
        }
        
    }
}
