using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Departments
{
    class HumanResourcesDepartment : IDepartment
    {
        private readonly static HumanResourcesDepartment _instance = new HumanResourcesDepartment();
        public static HumanResourcesDepartment Instance { get => _instance; }


        private HumanResourcesDepartment() { }


        public override string ToString() => "Human Resources Department";
    }
}
