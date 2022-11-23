using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu.Exceptions
{
    class NoWellPaidEmployeesExistInCompanyException : Exception
    {
        private const string message = "No well paid employees exist in Company";

        public NoWellPaidEmployeesExistInCompanyException() : base(message)
        {
        }
    }
}
