using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIST.Models
{
    public class Employee : IEmployee
    {
        const double MROT = 12000;
        private int id;
        private string fName = "";
        private string sName = "";
        private string tName = "";
        private int age = 14;
        private double experience;
        private bool isWorking;
        protected EmployeeType type = EmployeeType.NONE;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }   
        public string SName
        {
            get { return sName; }
            set { sName = value; }
        }
        public string TName
        {
            get { return tName; }
            set { tName = value; }
        }
        public int Age
        {
            get { return age; }
            set { /*if(value>14) */ age = value; }
        }
        public double Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public bool IsWorking
        {
            get { return isWorking;}
            set { isWorking = value;}
        }

        public EmployeeType Type
        {
            get { return type; }
        }

        public virtual double getSolary()
        {
            return MROT;
        }

        public virtual string toString()
        {
            return fName+ " "+ sName+ " "+ tName;
        }


    }
}
