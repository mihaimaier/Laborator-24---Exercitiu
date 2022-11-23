using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Exceptions
{
    class EmployeeAlreadyExistsException : Exception
    {
        private const string message = "Employee {0} with ID {1} already exists";

        public EmployeeAlreadyExistsException() : base(message)
        {
        }
    }
}
