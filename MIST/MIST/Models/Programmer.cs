using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIST.Models
{
    [JsonConverter(typeof(EmployeeConverter))]
    public class Programmer : Employee
    {
        public Programmer():base()
        {
            type = EmployeeType.PROGRAMMER;
        }

        private string techStack = "";

        private string languages = "Никакие не знаю";
        public string Languages 
        {
            get { return languages; } 
            set { languages = value; } 
        }

        public string TechStack
        {
            get { return techStack; }
            set { techStack = value; }
        }

        public override double getSolary()
        {
            return base.getSolary()*2 + (languages!=null? languages.Split(';').Length*5000 : 0) + Experience*1250;
        }

        public override bool Equals(object obj) => this.Equals(obj as Programmer);

        public bool Equals(Programmer p)
        {
            return (base.Equals(p as Employee) && 
                (p.Languages == this.Languages) && 
                (p.TechStack == this.TechStack));
        }
    }
}
