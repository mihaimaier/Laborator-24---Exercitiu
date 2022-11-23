using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Departments
{
    class TestingDepartment : IDepartment
    {
        private readonly static TestingDepartment _instance = new TestingDepartment();
        public static TestingDepartment Instance { get => _instance; }


        private TestingDepartment() { }


        public override string ToString() => "Testing Department";
    }
}
