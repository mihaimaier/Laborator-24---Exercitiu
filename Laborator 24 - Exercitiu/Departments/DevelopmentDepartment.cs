using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Departments
{
    class DevelopmentDepartment : IDepartment
    {
        private readonly static DevelopmentDepartment _instance = new DevelopmentDepartment();
        public static DevelopmentDepartment Instance { get => _instance; }


        private DevelopmentDepartment() { }


        public override string ToString() => "Development Department";
    }
}
