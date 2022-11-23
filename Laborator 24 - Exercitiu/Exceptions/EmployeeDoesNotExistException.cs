using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Exceptions
{
    [Serializable]
    internal class EmployeeDoesNotExistException : Exception
    {
        private const string message = "Employee with ID {0} does not exist";

        public EmployeeDoesNotExistException() : base(message)
        {
        }
    }
}
