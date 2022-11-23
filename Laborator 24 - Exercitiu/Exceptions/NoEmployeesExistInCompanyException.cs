using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Exceptions
{
    class NoEmployeesExistInCompanyException : Exception
    {
        private const string message = "No employees exist in Company";

        public NoEmployeesExistInCompanyException() : base(message)
        {
        }
    }
}
