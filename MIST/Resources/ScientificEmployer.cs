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
    class ScientificEmployer : IEmployer
    {
        string _firstName;
        float _experience;
        public string fName { get => _firstName; set => _firstName = value; }
        public string sName { get; set; }
        public string tName { get; set; }
        public float experience { get => _experience; set => _experience = value; }

        public float getSalary()
        {
            return (float)(IEmployer.MROT + Math.Pow(_experience, 1/3));
        }
    }
}