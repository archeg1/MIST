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
    interface IEmployee
    {
        const float MROT = 13000;
        double getSalary();
        String toString();
    }
}