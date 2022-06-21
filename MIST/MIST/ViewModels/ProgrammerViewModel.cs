
using MIST.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MIST.ViewModels
{
    public class ProgrammerViewModel : EmployeeViewModel
    {
        public Programmer Programmer { get; private set; }

        public ProgrammerViewModel( IEmployee employee): base (employee)
        {
            Programmer = (Programmer)employee;
        }
        public string languages {
            get { return Programmer.Languages; } 
            set { Programmer.Languages = value; }
        }

    }
}
