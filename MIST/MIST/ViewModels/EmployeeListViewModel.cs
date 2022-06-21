using MIST.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using MIST.Views;
using System.Threading.Tasks;

namespace MIST.ViewModels
{
    public class EmployeeListViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   // была ли начальная инициализация

        private bool isBusy;    // идет ли загрузка с сервера
        public EmployeeList employees { get; set; }

        private EmployeesService employeesService = new EmployeesService();

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private EmployeeFactory employeeFactory = new EmployeeFactory();

        public ICommand CreateEmployeeCommand { get; protected set; }
        public ICommand DeleteEmployeeCommand { get; protected set; }
        public ICommand SaveEmployeeCommand { get; protected set; }
        public ICommand BackCommand { get; protected set; }

        IEmployee selectedEmployee;
        public INavigation Navigation { get; set; }

        public EmployeeListViewModel()
        {
            employees = new EmployeeList();
            isBusy = false;
            CreateEmployeeCommand = new Command(CreateEmployee);
            DeleteEmployeeCommand = new Command(DeleteEmployee);
            SaveEmployeeCommand = new Command(SaveEmployee);
            BackCommand = new Command(Back);
        }

        public async Task GetEmployees()
        {
            if (initialized == true) return;
            IsBusy = true;
            var tempEmployees = await employeesService.Get() as List<IEmployee>;

            foreach (var employeeItem in tempEmployees)
                employees.Add(employeeItem);
            IsBusy = false;
            initialized = true;
        }

        public IEmployee SelectedEmployee
        {
            get { return selectedEmployee; }
            set 
            { 
                if(value != selectedEmployee)
                {
                    IEmployee tempEmployee = value;
                    selectedEmployee = null;
                    OnPropertyChanged("SelectedEmployee");
                    EmployeeViewModel employeeViewModel = employeeFactory.getEmployeeViewModel(tempEmployee);
                    employeeViewModel.ListViewModel = this;
                    EmployeePage employeePage = employeeFactory.getEmployeePage(employeeViewModel);
                    Navigation.PushAsync(employeePage);
                }                    
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private async void CreateEmployee()
        {
            var result = await Navigation.ShowPopupAsync(new EmployeesTypes());
            if(result!= null)
            {
                try
                {
                    IEmployee employee = employeeFactory.getEmployee(result.ToString());
                    EmployeeViewModel employeeViewModel = employeeFactory.getEmployeeViewModel(employee);
                    employeeViewModel.ListViewModel = this;
                    EmployeePage employeePage = employeeFactory.getEmployeePage(employeeViewModel);                    
                    Navigation.PushAsync(employeePage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private async void SaveEmployee(object employeeObject)
        {
            EmployeeViewModel employeeVm = employeeObject as EmployeeViewModel;
            if (employeeVm != null)
            {
                IEmployee employee = employeeVm.Employee;

                if(employee.Id>0) // Не новый
                {
                    IEmployee updatedEmployee = await employeesService.Update(employee);
                    if (updatedEmployee != null)
                    {
                        int pos = employees.Employees.IndexOf(updatedEmployee);
                        employees.Employees.RemoveAt(pos);
                        employees.Employees.Insert(pos, updatedEmployee);
                    }
                }
                else // Новый
                {
                    IEmployee addedEmployee = await employeesService.Add(employee);
                    if (addedEmployee!=null)
                        employees.Employees.Add(addedEmployee);
                }
                IsBusy = false;
            }
            Back();
        }

        private async void DeleteEmployee(object employeeObject)
        {

            EmployeeViewModel employeeVm = employeeObject as EmployeeViewModel;
            if (employeeVm != null)
            {
                if (employeeVm.Employee!=null)
                {
                    IsBusy = true;
                    IEmployee deletedEmployee = await employeesService.Delete(employeeVm.Employee.Id);
                    if (deletedEmployee!=null)
                    {
                        bool deleteResult = employees.Employees.Remove(deletedEmployee);
                        int a = 0;
                    }
                    IsBusy = false;
                }
            }
            Back();

        }


    }
}
