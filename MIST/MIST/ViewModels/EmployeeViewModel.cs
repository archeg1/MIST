using MIST.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MIST.ViewModels
{
    public class EmployeeViewModel : IEmployeeViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        EmployeeListViewModel model;
        public IEmployee Employee { get; protected set; }

        public EmployeeViewModel(IEmployee employee)
        {
            Employee = employee;
        }

        public EmployeeListViewModel ListViewModel
        {
            get { return model; }
            set 
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged("ListViewModel");
                }
            
            }
        }
        public int Id
        {
            get { return Employee.Id; }
        }
        public string fName
        {
            get { return Employee.FName; }
            set
            {
                if(Employee.FName != value)
                {
                    Employee.FName = value;
                    OnPropertyChanged("FName");
                }
            }
        }
        public string sName
        {
            get { return Employee.SName; }
            set
            {
                if(Employee.SName != value)
                {
                    Employee.SName = value;
                    OnPropertyChanged("SName");
                }
            }
        }
        public string tName
        {
            get { return Employee.TName; }
            set
            {
                if(Employee.TName != value)
                {
                    Employee.TName = value;
                    OnPropertyChanged("TName");
                }
            }
        }
        public int Age
        {
            get { return Employee.Age; }
            set
            {
                if (Employee.Age != value)
                {
                    Employee.Age = value;
                    OnPropertyChanged("Age");
                }
            }
        }
        public bool IsWorking
        {
            get { return Employee.IsWorking; }
            set
            {
                if (Employee.IsWorking != value)
                {
                    Employee.IsWorking = value;
                    OnPropertyChanged("IsWorking");
                }
            }
        }

        public double Experience
        {
            get { return Employee.Experience; }
            set
            {
                if(Employee.Experience != value)
                {
                    Employee.Experience = value;
                    OnPropertyChanged("Experience");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
