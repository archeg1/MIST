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
    internal class Employee : IEmployee
    {

        protected String fName, sName, tName;
        protected double experience;        

        public virtual double getSalary()
        {
            return IEmployee.MROT;
        }

        public virtual String toString()
        {
            return "";
        }
    }
}