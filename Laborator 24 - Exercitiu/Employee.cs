using Laborator_24___Exercitiu.Departments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu
{
    class Employee
    {
        private readonly string _name;
        private readonly Guid _id;
        private readonly IDepartment _department;
        private double _salary;

        public string Name { get => _name; }
        public Guid ID { get => _id; }
        public IDepartment Department { get => _department; }
        public double Salary { get => _salary; }


        public Employee(string name, double baseSalary, IDepartment department)
        {
            _name = name;
            _id = Guid.NewGuid();
            _department = department;
            _salary = baseSalary;
        }


        /// <summary>
        /// Give a promotion to an employee by specifying the raise percentage.
        /// </summary>
        /// <param name="raisePercentage">Raise Percentage</param>
        public void RaiseSalary(double raisePercentage) => _salary += _salary * raisePercentage / 100d;


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employee name:  {Name} ");
            sb.AppendLine($"Employee ID:  {ID}");
            sb.AppendLine($"Employee Salary:  {Salary} lei");
            sb.AppendLine($"Employee Department:  {Department}");

            return sb.ToString();
        }
    }
}
