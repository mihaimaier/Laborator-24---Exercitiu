using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Exceptions
{
    class NoEmployeesExistInDepartmentException : Exception
    {
        private const string message = "No employees exists in {0}";

        public NoEmployeesExistInDepartmentException() : base(message)
        {
        }
    }
}
