using MIST.ViewModels;
using MIST.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIST.Models
{
    public class EmployeeFactory
    {
        public static Dictionary<String, EmployeeType> EmployeeTypes = new Dictionary<string, EmployeeType> { 
            { "Программист", EmployeeType.PROGRAMMER },
            { "Учитель", EmployeeType.TEACHER },
            { "Инженер", EmployeeType.ENGINEER },
            { "Архитектор", EmployeeType.ARCHITECT }
        };
        public Employee getEmployee(string type)
        {
            Employee employee = null;
            if (type == null)
                throw new ArgumentNullException("type");
            else
            {
                switch (EmployeeTypes[type])
                {
                    case EmployeeType.PROGRAMMER: 
                        employee = new Programmer(); 
                        break;
                    default:
                        throw new ArgumentException("No such employee OR not implemented yet");
                }
            }
            return employee;
        }
        public EmployeeViewModel getEmployeeViewModel(IEmployee employee)
        {
            EmployeeViewModel employeeViewModel = null;
            switch(employee.Type)
            {
                case EmployeeType.PROGRAMMER:
                    employeeViewModel = new ProgrammerViewModel(employee);
                    break;
                default:
                    throw new ArgumentException("No such employee OR not implemented yet");
            }
            return employeeViewModel;
        }
        public EmployeePage getEmployeePage(EmployeeViewModel employeeViewModel)
        {
            EmployeePage employeePage  = null;
            switch (employeeViewModel.Employee.Type)
            {
                case EmployeeType.PROGRAMMER:
                    employeePage = new ProgrammerPage(employeeViewModel);
                    break;
                default:
                    throw new ArgumentException("No such employee OR not implemented yet");
            }
            return employeePage;
        }
    }
}
