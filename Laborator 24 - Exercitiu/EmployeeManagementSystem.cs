using Laborator_24___Exercitiu.Departments;
using Laborator_24___Exercitiu.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator_24___Exercitiu
{
    class EmployeeManagementSystem
    {
        private readonly static EmployeeManagementSystem _instance = new EmployeeManagementSystem();
        public static EmployeeManagementSystem Instance { get => _instance; }

        private readonly List<Employee> _companyEmployees = new List<Employee>();
        public List<Employee> CompanyEmployees { get => _companyEmployees; } //is not used but might be usefull later on


        private EmployeeManagementSystem() { }


        /// <summary>
        /// Add new people to company
        /// </summary>
        /// <param name="luckyNewEmployee">The LUCKIEST man alive</param>
        public void AddEmployee(Employee luckyNewEmployee)
        {
            _companyEmployees.ForEach(e =>
            {
                if (e.ID == luckyNewEmployee.ID)
                {
                    throw new EmployeeAlreadyExistsException();
                }
            });
            _companyEmployees.Add(luckyNewEmployee);
        }


        /// <summary>
        /// Get rid of unwanted people from company
        /// </summary>
        /// <param name="luckyNewEmployee">The UNLUCKIEST man alive</param>
        public Employee RemoveEmployee(Guid employeeID)
        {
            Employee employeeToRemove = _companyEmployees.Find(e => e.ID == employeeID);

            if (employeeToRemove == null)
            {
                throw new EmployeeDoesNotExistException();
            }

            _companyEmployees.Remove(employeeToRemove);
            return employeeToRemove;

        }


        /// <summary>
        /// Returns the well paid employee in the Company
        /// </summary>
        /// <param name="department"></param>
        /// <returns>The well paid employees</returns>
        public List<Employee> GetNoOfWellPayedEmployees(double minimumSalary)
        {
            List<Employee> employees = _companyEmployees.FindAll(e => e.Salary > minimumSalary);

            if (employees.Count == 0)
            {
                throw new NoWellPaidEmployeesExistInCompanyException();
            }
            return employees;
        }


        /// <summary>
        /// Returns the employees in the department
        /// </summary>
        /// <param name="department"></param>
        /// <returns>Department employees</returns>
        public List<Employee> GetEmployeesByDepartment(IDepartment department)
        {
            List<Employee> employees = _companyEmployees.FindAll(e => e.Department == department);

            if (employees.Count == 0)
            {
                throw new NoEmployeesExistInDepartmentException();
            }
            return employees;
        }


        /// <summary>
        /// Returns the well paid employee in the company
        /// </summary>
        /// <returns>The well paid employee</returns>
        public List<Employee> GetMaxSalary()
        {
            if (_companyEmployees.Count == 0)
            {
                throw new NoEmployeesExistInCompanyException();
            }
            return GetBestPaidEmployee(_companyEmployees);
        }


        /// <summary>
        /// Returns the best paid employee in the department
        /// </summary>
        /// <param name="department"></param>
        /// <returns>The well paid employees</returns>
        public List<Employee> GetMaxSalary(IDepartment department)
        {
            if (_companyEmployees.Count == 0)
            {
                throw new NoEmployeesExistInCompanyException();
            }

            List<Employee> departmentEmployees = _companyEmployees.FindAll(e => e.Department == department);

            if (departmentEmployees.Count == 0)
            {
                throw new NoEmployeesExistInDepartmentException();
            }
            return GetBestPaidEmployee(departmentEmployees);
        }


        /// <summary>
        /// Returns the best paid employee in the departments
        /// </summary>
        /// <param name="department"></param>
        /// <returns>The well paid employees</returns>
        public List<Employee> GetMaxSalary(List<IDepartment> departaments)
        {
            List<Employee> employees = new List<Employee>();

            departaments.ForEach(d => employees.AddRange(GetMaxSalary(d)));

            return employees;
        }


        /// <summary>
        /// Returns the sum of all companyEmployees salaries
        /// </summary>
        /// <returns>Sum of salaries</returns>
        public double GetTotalCost()
        {
            double cost = 0d;

            _companyEmployees.ForEach(e =>
            {
                cost += e.Salary;
            });
            return cost;
        }


        /// <summary>
        /// Returns the sum of salaries in a departement
        /// </summary>
        /// <returns>Sum of salaries in department</returns>
        public double GetCostForDepartment(IDepartment department)
        {
            double cost = 0d;

            GetEmployeesByDepartment(department).ForEach(e => cost += e.Salary);
            return cost;
        }


        /// <summary>
        /// Increase employee salary
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="percent"></param>
        public void IncreaseSalary(Guid employeeID, double increasePercentage)
        {
            Employee luckyEmployee = _companyEmployees.Find(e => e.ID == employeeID);

            if (luckyEmployee == null)
            {
                throw new EmployeeDoesNotExistException();
            }

            luckyEmployee.RaiseSalary(increasePercentage);
        }


        /// <summary>
        /// Increase department companyEmployees salaries
        /// </summary>
        /// <param name="department"></param>
        /// <param name="increasePercentage"></param>
        public void IncreaseSalary(IDepartment department, double increasePercentage)
        {
            List<Employee> luckyEmployees = _companyEmployees.FindAll(e => e.Department == department);

            if (luckyEmployees.Count == 0)
            {
                throw new NoEmployeesExistInDepartmentException();
            }

            luckyEmployees.ForEach(e => e.RaiseSalary(increasePercentage));
        }


        /// <summary>
        /// Increase departments companyEmployees salaries
        /// </summary>
        /// <param name="departments">The list of departments to raise salaries</param>
        /// <param name="increasePercentage"></param>
        /// <exception cref="NoEmployeesExistInDepartmentException"></exception>
        public void IncreaseSalary(List<IDepartment> departments, double increasePercentage)
        {
            departments.ForEach(d => IncreaseSalary(d, increasePercentage));
        }


        private List<Employee> GetBestPaidEmployee(List<Employee> companyEmployees)
        {
            double bestSalary = companyEmployees[0].Salary;

            companyEmployees.ForEach(e =>
            {
                if (e.Salary > bestSalary)
                {
                    bestSalary = e.Salary;
                }
            });

            return companyEmployees.FindAll(e => e.Salary == bestSalary);
        }
    }
}
