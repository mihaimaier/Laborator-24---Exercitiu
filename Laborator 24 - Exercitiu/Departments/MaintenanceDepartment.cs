using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Departments
{
    class MaintenanceDepartment : IDepartment
    {
        private readonly static MaintenanceDepartment _instance = new MaintenanceDepartment();
        public static MaintenanceDepartment Instance { get => _instance; }


        private MaintenanceDepartment() { }


        public override string ToString() => "Maintenance Department";
    }
}
