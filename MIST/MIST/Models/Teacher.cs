using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MIST.Models
{
    [JsonConverter(typeof(EmployeeConverter))]
    public class Teacher : Employee
    {
        public Teacher():base()
        {
            type = EmployeeType.TEACHER;
        }
    }
}
