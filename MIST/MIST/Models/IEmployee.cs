using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIST.Models
{
    public enum EmployeeType { NONE = -1, PROGRAMMER, TEACHER, ENGINEER, ARCHITECT };
           
    public interface IEmployee
    {
        int Id { get; set; }
        EmployeeType Type { get; }
        string FName { get; set; }
        string SName { get; set; }
        string TName { get; set; }
        int Age { get; set; }
        double Experience { get; set; }

        bool IsWorking { get; set; }

        double getSolary();

        string toString();

    }
}
